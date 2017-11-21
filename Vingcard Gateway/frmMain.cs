using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Threading;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Telegram_Gateway
{
    public partial class frmMain : Form
    {
        public static DataTransfer.JsonObject sessions = null;
        public static DataTransfer.JsonObjectID ids = null;
        public static Boolean bIsWaitingFeedback = false;

        public List<messagesList> myresult = null;
        public List<messagesAutoGet> messagesSupportInProject = null; // 工程中支持的信息列表
        public receivedMessages myMessages = null;
        public List<int> myReceivedUpdateIds = null;
        public BackgroundWorker SearchDevices = null;

        public Byte[] randomSearchBuffer = null;

        private delegate void FlushClient(); //代理

        Thread thread = null;
        Thread threadHttp = null;
        Thread threadDisplayMessages = null;

        public static String sUrl = "";

        #region
        public class receivedMessages
        {
            public String ok;
            public List<messagesList> result;
        }

        [Serializable]
        public class messagesList
        {
            public int update_id { get; set; }
            public message message { get; set; }
        }

        [Serializable]
        public class messagesAutoGet
        {
            public int update_id { get; set; }
            public String sMessage { get; set; }
            public Byte bSubNetId { get;set;}
            public Byte bDeviceId { get; set; }
            public Byte bChnId { get; set; }
            public int iDeviceType { get; set; }
            public Boolean bIsNeedReadRemark { get; set; }
            public Byte bigType;
            public Byte smallType;
        }

        public class message
        {
            public int message_id { get; set; } //  命令号
            public from from { get; set; }
            public chat chat { get; set; }
            public int date { get; set; }
           public String text { get; set; }
        }
        [Serializable]
        public class chat
        {
            public int id { get; set; } //  命令号
            public String first_name { get; set; } // 名称
            public String last_name { get; set; } // 姓名
            public String username { get; set; } // 全名
            public String type { get; set; } // 短信类型
        }

        [Serializable]
        public class from
        {
            public int id { get; set; } //  命令号
            public Boolean is_bot { get; set; }  // 
            public String first_name { get; set; } // 名称
            public String last_name { get; set; } // 姓名
            public String username { get; set; } // 全名
            public String language_code { get; set; } // 短信类型
        }
        #endregion

        System.Timers.Timer timerCall = new System.Timers.Timer();
        public static String sUrlHead = "https://api.telegram.org/bot418868770:AAEb-vpxkUU1ZCraDoHrRyESzhMJlQoAtH0/";

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// read ip 
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            string strIP = "";
            CsConst.mstrActiveIPs = new List<string>();
            IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress ip in arrIPAddresses)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                {
                    CsConst.mstrActiveIPs.Add(ip.ToString());
                }
            }
            strIP = CsConst.mstrINIDefault.IniReadValue("ProgramMode", "IP", "");
            if (strIP == null || strIP == "" || !CsConst.mstrActiveIPs.Contains(strIP))
            {
                if (CsConst.mstrActiveIPs.Count != 0)
                    strIP = CsConst.mstrActiveIPs[0];
            }
            return strIP;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbRev.Text = "";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            CsConst.mstrINIDefault = new IniFile(System.Windows.Forms.Application.StartupPath + @"\ini\Default.ini");
            CsConst.myLocalIP = GetLocalIP();
            HDLUDP.GetRightIPAndPort();
            DisplayBasicInformation();
            DislayLockInformationWhenFirstLoad();
            timerCall = new System.Timers.Timer();
            timerCall.Interval = 5000 * 1;
            timerCall.Elapsed += new System.Timers.ElapsedEventHandler(timerCall_Elapsed);

            
            bIsWaitingFeedback = false;
        }

        void timerCall_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //使用代理
            try
            {
                 CallInformationFromServer();
            }
            catch
            { }
        }


        void DisplayBasicInformation()
        {
            cbIPs.Items.Clear();
            foreach (string strTmp in CsConst.mstrActiveIPs)
            {
                cbIPs.Items.Add(strTmp);
            }
            cbIPs.SelectedItem = CsConst.myLocalIP;
            tbPC1.Text = CsConst.mbytLocalSubNetID.ToString();
            tbPC2.Text = CsConst.mbytLocalDeviceID.ToString();
            tbPort.Text = "6000";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sUrl = sUrlHead;
            //CallInformationFromServer();
            try
            {
                //获取ID
               // GetIdForCallFunction();
                CsConst.MyQuene = new Queue<byte[]>();
                CsConst.MyBlnCapture = true;
                
                if (thread == null)
                {
                    thread = new Thread(CrossThreadFlush);
                    thread.IsBackground = true;
                    thread.Start();
                }
                HDLUDP.GetRightIPAndPort();
                CsConst.mySends.IniTheSocket(CsConst.myLocalIP);
                
                timerCall.Enabled = false;
                #region
                //if (threadDisplayMessages == null)
                //{
                //    threadDisplayMessages = new Thread(ThreadHttpFunction);   
                //    threadDisplayMessages.IsBackground = true;
                //    threadDisplayMessages.Start();
                //}

                //if (threadHttp == null)
                //{
                //    socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //    //服务端发送信息需要一个IP地址和端口号  
                //    IPAddress address = IPAddress.Parse(CsConst.myLocalIP);
                //    //将IP地址和端口号绑定到网络节点point上  
                //    IPEndPoint point = new IPEndPoint(address, 88);
                //    //此端口专门用来监听的  

                //    //监听绑定的网络节点  
                //    socketwatch.Bind(point);

                //    //将套接字的监听队列长度限制为20  
                //    socketwatch.Listen(20);

                //    //负责监听客户端的线程:创建一个监听线程  
                //    Thread threadwatch = new Thread(WaitReceiveHttpPostInformation);

                //    //将窗体线程设置为与后台同步，随着主线程结束而结束  
                //    threadwatch.IsBackground = true;

                //    //启动线程     
                //    threadwatch.Start();
                //}
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region
        static Socket socketwatch = null;
        static Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket> { };
        
         //监听客户端发来的请求  
        static void WaitReceiveHttpPostInformation()
        {
            Socket connection = null;

            //持续不断监听客户端发来的请求     
            while (true)
            {
                try
                {
                    connection = socketwatch.Accept();
                }
                catch (Exception ex)
                {
                    //提示套接字监听异常     
                    Console.WriteLine(ex.Message);
                    break;
                }

                //获取客户端的IP和端口号  
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;

                //让客户显示"连接成功的"的信息  
                string sendmsg = "Connection is built！\r\n" + "IP:" + clientIP + "，Port" + clientPort.ToString();
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
                connection.Send(arrSendMsg);

                //客户端网络结点号  
                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                //添加客户端信息  
                clientConnectionItems.Add(remoteEndPoint, connection);

                //IPEndPoint netpoint = new IPEndPoint(clientIP,clientPort); 
                IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;

                //创建一个通信线程      
                ParameterizedThreadStart pts = new ParameterizedThreadStart(recv);
                Thread thread = new Thread(pts);
                //设置为后台线程，随着主线程退出而退出 
                thread.IsBackground = true;
                //启动线程     
                thread.Start(connection);
            }
        }

        /// <summary>
        /// 接收客户端发来的信息，客户端套接字对象
        /// </summary>
        /// <param name="socketclientpara"></param>    
        static void recv(object socketclientpara)
        {
            Socket socketServer = socketclientpara as Socket;

            while (true)
            {
                //创建一个内存缓冲区，其大小为1024*1024字节  即1M     
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                //将接收到的信息存入到内存缓冲区，并返回其字节数组的长度    
                try
                {
                    int length = socketServer.Receive(arrServerRecMsg);

                    //将机器接受到的字节数组转换为人可以读懂的字符串     
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);

                    //将发送的字符串信息附加到文本框txtMsg上 
                    if (CsConst.MyHttpQueue == null) CsConst.MyHttpQueue = new Queue<string>();
                    CsConst.MyHttpQueue.Enqueue(strSRecMsg);
                    socketServer.Send(Encoding.UTF8.GetBytes(""));
                }
                catch (Exception ex)
                {
                    clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());

                    Console.WriteLine("Client Count:" + clientConnectionItems.Count);

                    //提示套接字监听异常  
                    Console.WriteLine("客户端" + socketServer.RemoteEndPoint + "已经中断连接" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                    //关闭之前accept出来的和客户端进行通信的套接字 
                    socketServer.Close();
                    break;
                }
            }
        }

        ///      
        /// 获取当前系统时间的方法    
        /// 当前时间     
        static DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }
   
        #endregion

        private void ThreadHttpFunction()
        {
            if (this.rbVingcard.InvokeRequired)//等待异步
            {
                FlushClient fc = new FlushClient(ThreadFunction);
                this.Invoke(fc); //通过代理调用刷新方法
            }
            else
            {
                try
                {
                    while (CsConst.MyHttpQueue != null && CsConst.MyHttpQueue.Count > 0)
                    {
                        //bIsBusyShowing = true;
                        #region
                        String sPostSms = CsConst.MyHttpQueue.Dequeue();
                        rbVingcard.AppendText(DateTime.Now.ToShortTimeString() + ":" + sPostSms);
                        rbVingcard.AppendText("\r\n");
                        Byte[] tmpSendBuf = new Byte[]{1,255};
                        CsConst.mySends.AddBufToSndList(tmpSendBuf, 0xE01C, 1, 1, false, false, false, false);
                        #endregion
                    }
                    //bIsBusyShowing = false;
                }
                catch
                {
                }
            }
        }

        private void CrossThreadFlush()
        {
            FlushClient fc = new FlushClient(ThreadFunction);
            this.Invoke(fc); //通过代理调用刷新方法

            while (thread.IsAlive)
            {
                //将sleep和无限循环放在等待异步的外面
                ThreadFunction();
                Thread.Sleep(1);
            }

        }

        private void ThreadFunction()
        {
            try
            {
                if (this.rtbRev.InvokeRequired)//等待异步
                {
                    FlushClient fc = new FlushClient(ThreadFunction);
                    this.Invoke(fc); //通过代理调用刷新方法
                }
                else
                {
                    try
                    {
                        while (CsConst.MyQuene != null && CsConst.MyQuene.Count > 0)
                        {
                            //bIsBusyShowing = true;
                            #region
                            byte[] Tmp = CsConst.MyQuene.Dequeue();
                            bool blnIsAdd = true;

                            if (blnIsAdd == true)
                            {
                                string strTmp = DateTime.Now.Hour.ToString("D2") + ":" +
                                                DateTime.Now.Minute.ToString("D2") + ":" +
                                                DateTime.Now.Second.ToString("D2") + ":" +
                                                DateTime.Now.Millisecond.ToString("D3") + " : ";

                                string str1 = "";//长度
                                string str2 = "";//源子网ID设备ID
                                string str3 = "";//设备类型
                                string str4 = "";//操作码
                                string str5 = "";//目标子网ID设备ID
                                string str6 = "";//数据
                                string strCRC = "";
                                str1 = Tmp[16].ToString("X2") + " ";
                                str2 = Tmp[17].ToString("X2") + " " + Tmp[18].ToString("X2") + " ";
                                str3 = Tmp[19].ToString("X2") + " " + Tmp[20].ToString("X2") + " ";
                                str4 = Tmp[21].ToString("X2") + " " + Tmp[22].ToString("X2") + " ";
                                str5 = Tmp[23].ToString("X2") + " " + Tmp[24].ToString("X2") + " ";
                                if (Tmp[16] != 255)
                                {
                                    int DataCount = Tmp[16] - 11;
                                    for (int i = 0; i < DataCount; i++)
                                        str6 = str6 + Tmp[25 + i].ToString("X2") + " ";
                                    strCRC = Tmp[25 + (Tmp[16] - 11)].ToString("X2") + " " + Tmp[25 + (Tmp[16] - 11) + 1].ToString("X2");
                                }
                                else
                                {
                                    int DataCount = Tmp[25] * 256 + Tmp[26] + 2;
                                    for (int i = 0; i < DataCount; i++)
                                        str6 = str6 + Tmp[25 + i].ToString("X2") + " ";
                                }
                                string strCMD = Tmp[21].ToString("X2") + Tmp[22].ToString("X2");

                                Int64 iTmpCommandid = 1;
                                if (rtbRev.Lines.Length > 0) iTmpCommandid = rtbRev.Lines.Length;
                                rtbRev.AppendText(iTmpCommandid.ToString("D5") + "  " + strTmp);
                                ShowText(str1, rtbRev.TextLength, str1.Length, Color.Pink);
                                ShowText(str2, rtbRev.TextLength, str2.Length, Color.Green);
                                ShowText(str3, rtbRev.TextLength, str3.Length, Color.Blue);
                                ShowText(str4, rtbRev.TextLength, str4.Length, Color.DarkRed);
                                ShowText(str5, rtbRev.TextLength, str5.Length, Color.Green);
                                ShowText(str6, rtbRev.TextLength, str6.Length, Color.Red);
                                ShowText(strCRC, rtbRev.TextLength, strCRC.Length, Color.Black);
                                rtbRev.AppendText("\r\n");
                            }

                            #endregion
                        }
                        //bIsBusyShowing = false;
                    }
                    catch
                    {
                    }
                }
            }
            catch { }
        }

        private void ShowText(string sText, int nStart, int nLength, Color color)
        {
            rtbRev.AppendText(sText);
            rtbRev.Select(nStart, nLength);    // 需要修改颜色的部分             
            rtbRev.SelectionColor = color;     // 颜色                    
        }

        public static Boolean TunelDataToVIngcard(String sRoomName, String sContent)
        {
            Boolean bIsSuccess = false;
            try
            {
                String sUrlAddress = String.Format("https://{0}/api/v1/tunnel",sUrl);

                Dictionary<String, String> dic = new Dictionary<String, string>();
                dic.Add("data", sContent);
                dic.Add("extId", sRoomName);

                String sFinalContent = JsonConvert.SerializeObject(dic);
                sFinalContent = sUrlHead + sFinalContent + "]}";
                //MessageBox.Show(sFinalContent);
                string strTmp = DataTransfer.send_request("POST", sUrlAddress, sFinalContent, sessions);                
                bIsSuccess = true;
            }
            catch
            {
                bIsSuccess = false;
            }
            return bIsSuccess;
        }

        public static String CryHDLDataToVingcardServer(Byte[] posttmpBytes)
        {
            String sResult = "";
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                md5.Initialize();
                md5.ComputeHash(posttmpBytes);

                sResult = Convert.ToBase64String(posttmpBytes);
            }
            catch
            { }
            return sResult;
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            HDLUDP.ConstPort = Convert.ToInt16(tbPort.Text);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (tbUrl.Text == null || tbUrl.Text == "") return;
            try
            {
                String sUrlAddress = tbUrl.Text;

                string strTmp = DataTransfer.send_request("GET", null, null);
                rtbTest.AppendText(strTmp);
            }
            catch
            { }
        }

        private void btnGetMe_Click(object sender, EventArgs e)
        {
            if (tbUrl.Text == null || tbUrl.Text == "") return;
            try
            {
                String sUrlAddress = String.Format("{0}getMe", sUrlHead);

                string strTmp = DataTransfer.send_request("GET", sUrlAddress, null);
                rtbTest.AppendText(sUrlAddress);
                rbVingcard.AppendText("\r\n");
                rtbTest.AppendText(strTmp);
                rbVingcard.AppendText("\r\n");
            }
            catch
            { }   
        }
        delegate void SetTextCallback(String sText);
        private void CallInformationFromServer()
        {
               if (tbUrl.Text == null || tbUrl.Text == "") return;
               try
               {
                   String sUrlAddress = String.Format("{0}getUpdates", sUrlHead);
                   string strTmp = DataTransfer.send_request("GET", sUrlAddress, null);
                   //String strTmp = rtbTest.Text;
                   receivedMessages otmp = new receivedMessages();
                   JavaScriptSerializer js = new JavaScriptSerializer();
                   otmp = js.Deserialize<receivedMessages>(strTmp);
                   CompareCallbackIfNewAdd(otmp);
               }
               catch
               { }
        }

        private void CompareCallbackIfNewAdd(receivedMessages otmp)
        {
            if (otmp == null) return;
            try
            {
                List<messagesList> NewAddedMessages = new List<messagesList>();
                //copy new message list to public struct
                #region
                if (myReceivedUpdateIds == null) myReceivedUpdateIds = new List<int>();
                if (myMessages == null) //全部添加
                {
                    myReceivedUpdateIds = new List<int>();
                    myMessages = otmp;
                    NewAddedMessages = otmp.result;
                }
                else
                {
                    List<messagesList> tmpMessageList = otmp.result;
                    if (tmpMessageList == null) return;
                    if (myMessages.result == null) myMessages.result = new List<messagesList>();
                    foreach (messagesList tmpMessage in tmpMessageList)
                    {
                        #region
                        if (myReceivedUpdateIds.Contains(tmpMessage.update_id) == false)
                        {
                            myMessages.result.Add(tmpMessage);
                            NewAddedMessages.Add(tmpMessage);
                        }
                        #endregion
                    }
                }

                //add update id to public buffer
                
                #endregion

                string sNewAddedMessages = "";
                foreach (messagesList tmpMessage in NewAddedMessages)
                {
                    myReceivedUpdateIds.Add(tmpMessage.update_id);
                    sNewAddedMessages += tmpMessage.message.text + " ;";
                    ConvertorMessageToLocalControlCommand(tmpMessage.message.text);
                }

                String strHead = DateTime.Now.Hour.ToString("D2") + ":" +
                                   DateTime.Now.Minute.ToString("D2") + ":" +
                                   DateTime.Now.Second.ToString("D2") + ":" +
                                   DateTime.Now.Millisecond.ToString("D3") + " : " +
                                   "Receive from Telegram server :" + sNewAddedMessages;

                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { strHead });
            }
            catch
            { }
        }

        private void ConvertorMessageToLocalControlCommand(String sRemark)
        {
            if (sRemark == null || sRemark == "") return;
            if (messagesSupportInProject == null || messagesSupportInProject.Count == 0) return;
            try
            {
                for (int i = 0; i < messagesSupportInProject.Count; i++)
                {
                    messagesAutoGet otmp = messagesSupportInProject[i];
                    if (otmp == null) continue;

                    if (sRemark.StartsWith(otmp.sMessage)) // 找到对应的设备备注
                    {
                        Byte bSubNetId = otmp.bSubNetId;
                        Byte bDeviceId = otmp.bDeviceId;
                        Byte bChnId = otmp.bChnId;
                        int iOperationCode = -1;
                        Byte[] arrTmpSend = null;
                        #region
                        switch (otmp.bigType)
                        {
                            case 1: iOperationCode = 0x0031;
                                arrTmpSend = new Byte[4];
                                arrTmpSend[0] = bChnId;
                                if (sRemark.Contains("on") || sRemark.Contains("ON")) arrTmpSend[1] = 100;
                                break;
                            case 2: iOperationCode = 0xE3E4; 
                                arrTmpSend = new Byte[4];
                                arrTmpSend[0] = bChnId;
                                if (sRemark.Contains("open") || sRemark.Contains("OPEN")) arrTmpSend[1] = 1;
                                else if (sRemark.Contains("close") || sRemark.Contains("CLOSE")) arrTmpSend[1] = 2;
                                else if (sRemark.Contains("stop") || sRemark.Contains("STOP")) arrTmpSend[1] = 0;
                                break;
                            case 4: iOperationCode = 0xE3D8;
                                arrTmpSend = new Byte[4];
                                arrTmpSend[2] = bChnId;
                                arrTmpSend[0] = 18;
                                if (sRemark.Contains("on") || sRemark.Contains("ON")) arrTmpSend[1] = 255;
                                else if (sRemark.Contains("OFF") || sRemark.Contains("off")) arrTmpSend[1] = 0;
                                break;
                            case 9: iOperationCode = 0xE01C; 
                                arrTmpSend = new Byte[4];
                                arrTmpSend[0] = 201;
                                if (sRemark.Contains("play") || sRemark.Contains("PLAY")) arrTmpSend[1] = 255;
                                else if (sRemark.Contains("stop") || sRemark.Contains("STOP")) arrTmpSend[1] = 0;
                                break;
                        }
                        #endregion
                        
                        if (iOperationCode !=-1) CsConst.mySends.AddBufToSndList(arrTmpSend, iOperationCode, bSubNetId, bDeviceId, false, false, false, false);
                    }
                }                
            }
            catch
            { }
        }


        private void SetText(string text)
        {
            if (rbVingcard.Text == null || rbVingcard.Text == "") rbVingcard.AppendText(text);
            else rbVingcard.Text = rbVingcard.Text.Insert(0, text + "\r\n");
        }

        private void btnGetUpdates_Click(object sender, EventArgs e)
        {
            if (tbUrl.Text == null || tbUrl.Text == "") return;
            try
            {
                //String sUrlAddress = String.Format("{0}getUpdates", sUrlHead);

                //string strTmp = DataTransfer.send_request("GET", sUrlAddress, null);
                //rtbTest.AppendText(sUrlAddress);
                //rbVingcard.AppendText("\r\n");
                //rtbTest.AppendText(strTmp);
                //rbVingcard.AppendText("\r\n");

                //2017 test 
                String strTmp = rtbTest.Text;
                receivedMessages otmp = new receivedMessages();
                JavaScriptSerializer js = new JavaScriptSerializer();
                otmp = js.Deserialize<receivedMessages>(strTmp);
                //if (myresult == null) myresult = new List<messagesList>();
                CompareCallbackIfNewAdd(otmp);
                //myresult = js.Deserialize<List<messagesList>>(strTmp);
            }
            catch
            { }  
        }

        private void cbIPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            CsConst.myLocalIP = cbIPs.Text.ToString();
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            try
            {
               DialogResult oResult =  MessageBox.Show("It may take several minutes to get messages list, are you sure to go on ?","Read Whole Project" ,
                    MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);

               if (oResult == System.Windows.Forms.DialogResult.No || oResult == System.Windows.Forms.DialogResult.Cancel) return;
                messagesSupportInProject = new List<messagesAutoGet>();
                if (SearchDevices == null || SearchDevices.IsBusy == false)
                {
                    tbSearch.Enabled = false;
                    CsConst.mySends.AddBufToSndList(null, 0x000E, 255, 255, false, false, false, false);
                    NewFastSearch();
                }
               // MessageBox.Show(lvLock.Items.Count.ToString());
            }
            catch
            { }
        }

        private void NewFastSearch()
        {
            SearchDevices = new BackgroundWorker();
            SearchDevices.DoWork += new DoWorkEventHandler(calculationWorker_DoWork);
            SearchDevices.ProgressChanged += new ProgressChangedEventHandler(calculationWorker_ProgressChanged);
            SearchDevices.WorkerReportsProgress = true;
            SearchDevices.WorkerSupportsCancellation = true;
            SearchDevices.RunWorkerCompleted += new RunWorkerCompletedEventHandler(calculationWorker_RunWorkerCompleted);
            SearchDevices.RunWorkerAsync();
        }

        void calculationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (messagesSupportInProject != null && messagesSupportInProject.Count() > 0)
                {
                    timerCall.Enabled = false;
                }
                tbSearch.Enabled = true;
            }
            catch
            {
            }
            tbSearch.Enabled = true;
        }

        void calculationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {

            }
            catch
            {
            }
        }

        void calculationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CsConst.MySimpleSearchQuene = new List<byte[]>();
                Random tmp = new Random();
                randomSearchBuffer = new Byte[2];

                tmp.NextBytes(randomSearchBuffer);
                CsConst.mySends.AddBufToSndList(randomSearchBuffer, 0xE548, 255, 255, false, false, false, false);
                AddDeviceToList();
            }
            catch
            {
            }
        }


        private void AddDeviceToList()
        {
            Int16 iSendCount = 0;
            try
            {
            Resend:
                DateTime d1, d2;
                d1 = DateTime.Now;
                d2 = DateTime.Now;
                List<Byte> listSendBuf = new List<byte>();
                listSendBuf.AddRange(randomSearchBuffer);
                while (CsConst.MySimpleSearchQuene.Count > 0 || HDLUDP.Compare(d2, d1) < 2000)
                {
                    #region
                    d2 = DateTime.Now;
                    if (CsConst.MySimpleSearchQuene.Count == 0) continue;
                    if (CsConst.MySimpleSearchQuene[0]!= null)
                    {
                        byte[] readData = CsConst.MySimpleSearchQuene[0];
                        int index = 1;
                        if (messagesSupportInProject != null && messagesSupportInProject.Count > 0)
                        {
                            index = messagesSupportInProject.Count + 1;
                        }
                        int iDeviceType = readData[19] * 256 + readData[20];
                        //简易编程操作码返回
                        Boolean isAdd = true;
                        // 是否要增加
                        #region
                        Byte bSubNetId = readData[17];
                        Byte bDeviceId = readData[18];
                        if (messagesSupportInProject.Count > 0)
                        {
                            foreach (messagesAutoGet tmp in messagesSupportInProject)
                            {
                                if (bSubNetId == tmp.bSubNetId && bDeviceId == tmp.bDeviceId)
                                {
                                    isAdd = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            isAdd = true;
                        }
                        #endregion
                        if (isAdd)
                        {
                            listSendBuf.Add(bSubNetId);
                            listSendBuf.Add(bDeviceId);
                            if (readData[21] == 0xE5 && readData[22] == 0x49 && readData.Length >= 20)
                            {
                                #region                               
                                AddSimpleFUnctionListToPublicClasses(readData);
                                #endregion
                            }
                            else if (readData[21] == 0x00 && readData[22] == 0x0E && CsConst.AudioBoxDeviceTypeList.Contains(iDeviceType))
                            {
                                #region
                                messagesAutoGet temp = new messagesAutoGet();
                                index = index + 1;
                                byte[] arayRemark = new byte[20];

                                Array.Copy(readData, 25, arayRemark, 0, 20);
                                temp.sMessage = System.Text.ASCIIEncoding.ASCII.GetString(arayRemark);

                                temp.bSubNetId = readData[17];
                                temp.bDeviceId = readData[18];
                                temp.bChnId = readData[25];
                                temp.bigType = 9;
                                temp.bIsNeedReadRemark = false;
                                messagesSupportInProject.Add(temp);                                
                                #endregion
                            }
                        }
                    }
                    #endregion
                    CsConst.MySimpleSearchQuene.RemoveAt(0);
                }
                iSendCount++;
                if (iSendCount < 4)
                {
                    CsConst.mySends.AddBufToSndList(listSendBuf.ToArray(), 0xE548, 255, 255, false, false, false, false);
                    goto Resend;
                }
                GoOnSearchingDifferentType();
                DisplayLockInformationToListview();
            }
            catch
            {

            }
        }

        private void AddSimpleFUnctionListToPublicClasses(Byte[] FunctionsGroupE549Respond)
        {
            if (FunctionsGroupE549Respond == null) return;
            if (messagesSupportInProject== null) messagesSupportInProject= new List<messagesAutoGet>();
            try
            {
                byte[] arayRemark = new byte[20];
                Array.Copy(FunctionsGroupE549Respond, 27, arayRemark, 0, 20);

                String tmpRemark = System.Text.ASCIIEncoding.ASCII.GetString(arayRemark);
                Byte subnetId = FunctionsGroupE549Respond[17];
                Byte deviceId = FunctionsGroupE549Respond[18];
                Int32 deviceType = FunctionsGroupE549Respond[19] * 256 + FunctionsGroupE549Respond[20];

                Byte packetLength = (Byte)(FunctionsGroupE549Respond[16] - 20 - 13);

                for (Byte bTmp = 0; bTmp < packetLength / 3; bTmp++)
                {
                    Byte bigType = FunctionsGroupE549Respond[47 + bTmp * 3];

                    #region
                    Byte bSumChn = FunctionsGroupE549Respond[49 + bTmp * 3];
                    for (Byte bytChnID = 1; bytChnID <= bSumChn; bytChnID++)
                    {
                        messagesAutoGet temp = new messagesAutoGet();
                        temp.bSubNetId = subnetId;
                        temp.bDeviceId = deviceId;
                        temp.sMessage = tmpRemark;
                        temp.iDeviceType = deviceType;
                        temp.bigType = FunctionsGroupE549Respond[47 + bTmp * 3];
                        temp.smallType = FunctionsGroupE549Respond[48 + bTmp * 3];

                        temp.bChnId = bytChnID;
                        temp.bIsNeedReadRemark = true;
                        messagesSupportInProject.Add(temp);
                    }
                    #endregion
                }
            }
            catch
            { }
        }


        private void DisplayLockInformationToListview()
        {
            lvLock.Items.Clear();
            if (messagesSupportInProject == null || messagesSupportInProject.Count == 0) return;
            try
            {
                foreach (messagesAutoGet temp in messagesSupportInProject)
                {
                    #region
                    ListViewItem tmp = new ListViewItem();
                    
                    tmp.ImageIndex = 1;
                    tmp.StateImageIndex = 1;
                    
                    tmp.SubItems.Add((lvLock.Items.Count + 1).ToString());

                    tmp.SubItems.Add(temp.sMessage);
                    tmp.SubItems.Add(temp.bChnId.ToString());
                    tmp.SubItems.Add(temp.bSubNetId.ToString());
                    tmp.SubItems.Add(temp.bDeviceId.ToString());
                    lvLock.Items.Add(tmp);
                    #endregion
                }
            }
            catch
            { }
        }

        void GoOnSearchingDifferentType()
        {
            try
            {
                if (messagesSupportInProject == null || messagesSupportInProject.Count == 0) return;
                for (int i=0;i< messagesSupportInProject.Count;i++)
                {
                     messagesAutoGet oTmp = messagesSupportInProject[i];
                    if (oTmp.bIsNeedReadRemark == true)
                    {
                        byte[] ArayTmp = new byte[3] { oTmp.bigType,oTmp.smallType, oTmp.bChnId };   // { bytTypeB,oTmp.FunctionType,i};
                        if (CsConst.mySends.AddBufToSndList(ArayTmp, 0xE44A, oTmp.bSubNetId, oTmp.bDeviceId, false, false, true, false) == true)//少于3次发送命令
                        {
                            byte[] arayRemark = new byte[20];
                            Array.Copy(CsConst.myRevBuf, 28, arayRemark, 0, 20);
                            messagesSupportInProject[i].sMessage = System.Text.ASCIIEncoding.Default.GetString(arayRemark);
                            messagesSupportInProject[i].bIsNeedReadRemark = false;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            if (messagesSupportInProject == null) return;
            try
            {
                //CsConst.mySends.AddBufToSndList(null, 0x5708, 1, 1, false, false, true, false);
                //HDLUDP.DealWithTunnelDataIfNeedsUpdateStruct(null);
                if (messagesSupportInProject != null && messagesSupportInProject.Count > 0)
                {
                    FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + @"\MessageList.dat", FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    if (messagesSupportInProject != null) bf.Serialize(fs, messagesSupportInProject);
                    fs.Close();
                }

                // if (rtbRev.Text != null && rtbRev.Text != "") rtbRev.SaveFile(@"C:/" + DateTime.Now.ToString() + ".text");
            }
            catch
            { }
        }

        void DislayLockInformationWhenFirstLoad()
        {
            try
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\MessageList.dat") == true)
                {
                    FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + @"\MessageList.dat", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    if (messagesSupportInProject == null) messagesSupportInProject = new List<messagesAutoGet>();
                    messagesSupportInProject = bf.Deserialize(fs) as List<messagesAutoGet>;
                    fs.Close();

                    DisplayLockInformationToListview();
                }
            }
            catch
            { }
        }

    }
}
