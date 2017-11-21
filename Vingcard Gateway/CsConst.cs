using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;
using System.Drawing;


namespace Telegram_Gateway
{
    class CsConst
    {
        public static int mintDIndex = 1;  // used for add devcie dindex

        public static IniFile mstrINIDefault;///对LAN0,LAN1进行操作


        /// <summary>
        /// Main Form Const Start
        /// </summary>
        #region
        public static int MainFormSubNetIDStartFrom = 3;
        #endregion

        // public static Inifile

        // all different kinds of modules and their device type
       
        #region
        public static String[] LoadType = null; //负载类型
        public static String[] Weekdays =null; // 星期几
        public static String[] Status = null;  // 机械开关的开和关
        public static String[] UvSwitchStatus = null;  //通用开关的开和关
        public static String[] StatusAC = null;   //空调模式
        public static String[] StatusFAN = null;   // 风速
        public static List<String> CurtainModes = null;  // 风机状态
        public static String[] CurtainRelayState = null ;
        public static String[] NewIRLibraryDeviceType = null; // 红外码库类型列表
        public static String[] strWirelessAddressState = null;
        public static String[] strWirelessAddressConnection = null;
        public static String[] security = null;
        public static String[] MusicControl = null;
        public static String[] GPRSControl = null; // GPRS 
        public static String[] PanelControl = null; // 面板控制类型
        public static String[] TrueAndFalse = null; // 逻辑真假组合
        public static String[] InvalidAndValid = null; // 有效无效组合
        public static String[] MusicCommandHints = null; // 音乐播放器的命令提示
        public static String[] FloorheatingModeLists = null; // 地热模式列表
        #endregion
                                                                                 ///
        public static Boolean bIsStartTest = false;

        public static string mstrInvalid = "N/A";

        public static string mstrDefaultPath = null;  // default blank database path

        public static string mstrCurPath = null;  //当前工程的地址所在位置

        public static string mstrINIDefaultPath = null; // 读取配置显示文件的位置


        public static int iIsDragTemplateOrSimpleListOrCmd = -1;  // 0 1, 2

        /// <summary>
        /// 数据通讯时参数
        /// </summary>
        #region
        public static string myLocalIP = null; // 本机地址
        public static string myDestIP = null;  //发送到的IP地址
        public static int myintProxy = 0; // 0 局域网，1 点对点  2， 通过serverDown
        public static Boolean bIsAutoUpgrade = false;//是不是自动更新
        public static Boolean bIsDownloadSuccess = false;


        public static HDLSend mySends = new HDLSend();					//建立发送机制
        public static byte[] myRevBuf = null;

        public static byte[] ArayLevel = null;

        public static bool isCheckCRCForTestTool = true;
        public static Queue<Byte[]> MyQuene = new Queue<byte[]>();//命令测试存储数据
        public static Queue<String> MyHttpQueue = new Queue<string>(); // http 等待推送命令
        public static List<Byte[]> MySimpleSearchQuene = null; //temperature buffer for them 

        public static List<Byte[]> MySimpleDeviceListQuene = null; // save then could easy to change part information

        public static bool MyBlnModifyNetModule = false;
        public static bool MyBlnStartSimpleSearch = false;

        public static int MyUpgradeSubNetID = -1;
        public static int MyUpgradeDeviceID = -1;

        /// <summary>
        /// 重放相隔次数
        /// </summary>
        public static int replySpanTimes = 2000;//重发延时	
        public static int MoreDelay = 0;//重发再延时
        public static int mintFactoryTime = -1;//恢复出场设置计时
        /// <summary>
        /// 重放数据次数
        /// </summary>
        public static int replytimes = 5;//重发次数

        public static bool BigPacket = false;       //大包协议发送

         // 收发数据时 参数一致认为是正常
        public static bool MyBlnNeedF8 = false; // 是不是返回F8 
        public static int  MybytNeedParm1 = -1; // 第一个参数
        public static int  MybytNeedParm2 = -1; // 第二个参数
        public static int  MybytNeedParm3 = -1; // 第三个参数
        public static List<int> NeedAppendToPublicBufferCommands = new List<int> { } ; //0x1365};

        /// <summary>
        /// 数据上传模式 全部上传 0   分页上传1   手动上传2
        /// </summary>
        public static byte myUploadMode = 0;
        /// <summary>
        /// 数据下载模式 全部下载 0   分页下载1   手动下载2
        /// </summary>
        public static byte myDownLoadMode = 0;
        #endregion

        public static Boolean isIniAllKeySucess; 

        public static BackgroundWorker calculationWorker = null;

        public static byte mbytCurUsingSubNetID = 255;
        public static byte mbytCurUsingDevNetID = 255;
        public static byte mbytLocalSubNetID = 253;
        public static byte mbytLocalDeviceID = 254;
        public static int mintLocalDeviceType = 0xFFFE;
        public static bool MyBlnWait15FE = false;
        public static bool MyBlnCapture = false;  //表示是不是开始捕捉数据
        public static int MyMaxPacket = -1;  // 升级可以容纳的最大包数
        public static int MyUPgradeDeviceType = -1; // 升级设备的设备类型
        public static int MyStartORAskMore = -1; // 开始升级获取发送次数

        //获取当前活动的IP
        public static List<string> mstrActiveIPs;


        /// <summary>
        /// 工程模式 还是 工程师模式
        /// </summary>
        public static byte MyEditMode = 1;

        public static Boolean myUploadDownManually = false;

        public static bool MyShowWizardorNot = true;

        public static bool MyStartImport = false; // import from database or just change online 
        public static Color MyImportColor = new System.Drawing.Color();
        public static List<Color> MyImportColorList = null;
        public static List<int> MyImportDIndex = null;
        public static int ImportwdDeviceType = -1;

        public static bool MyStartOnlineMatch = false; // match from online devices list
        public static Color MyOnlineColor = new System.Drawing.Color();
        public static List<Color> MyOnlineColorList = null;
        public static List<int> MyOnlineDIndex = null;
        public static int OnlinewdDeviceType = -1;
        public static string MyTmpOnlineDevice = string.Empty;
        public static string MyMachineCodeMac = string.Empty;
        public static bool FastSearch = false;    // 是否表示全局搜索
        public static bool WaitMore = false;


        // 2014 03 11 New add
        public static List<String> MyTmpName = null;

        /// <summary>
        /// // 0 表示传统模式  1 表示简易编辑模式
        /// </summary>
        public static int MyProgramMode = 0;
        public static int MyEnterProjectWay = 0; // 本地或者远程

        public static int mintCurRmID = -1;  //楼层列表
        public static int mintFHID = -1;  // 房间ID
        
        public static string softwareversonNum1 = "06";
        public static string softwareversonNum2 = "14";
        public static string strcompany1 = "HDL Buspro Setup Tool 2 V";//HDL Buspro Setup Tool 2
        public static string strcompany2 = "Buspro Setup Tool 2 V";
        public static string strcompany3 = "Acematic Buspro Design Tool V";//Acematic Buspro Design Tool II
        public static String softwareverson = strcompany1 + softwareversonNum1 + "." + softwareversonNum2 + "B";
        public static bool isNewSoftwareVerson = false;
        public static int iLanguageId = 0;
        public static bool isKamanli = false;
        // 0 = English 
        // 1 = Chinese

        public static Boolean MyBlnReRead = false; //是不是要重新搜索
        public static Boolean MyBlnExchangePort = false;
        public static int UpgradeID = 0;
        public static Queue<byte[]> myUpgradeQuene = new Queue<byte[]>();//升级存储包号
        public static Boolean MyBlnFinish = false;
        public static Byte CurrentUpgradeSubnetID = 0;
        public static Byte CurrentUpgradeDeviceID = 0;
        public static Byte UpgradSubnetIDForAuto = 0;
        public static Byte UpgradDeviceIDForAuto = 0;
        public static List<string> arayUpgrade = new List<string>();
        public static bool isStopDealUogradeBackground = false;
        public static Byte ModifyDeviceAddressSubNetID = 0;
        public static Byte ModifyDeviceAddressDeviceID = 0;
        public static Boolean isRestore = false;
        public static bool isBackUp = false;
        public static Boolean isBackUpSucceed = false;
        public static bool isStartUploadFile = false;
        public static String RestoreRemark = "";

        public static int ChannelIDForNewIR = 0;
        public static int KeyIDForNewIR = 0;
        public static byte[] arayACParamForNewIR = new byte[6];
        public static int DownloadPictruePageID = 1;

        public static bool isWriteDataToUSB = true;
        public static bool isAutoRefreshCurtainPercent = false;
        public static bool isRightPasswork = false;//校准密码
        public static Boolean bStartReceiveDaliDataA022A003; // 开始接收DALI返回数据

        public static int UploadColorDLPType = 1;
        public static bool isStopDealImageBackground = false;
        public static bool isRestartSoftware = false;

        public static List<Object[]> MyCopyDataGridView = null; // 复制表格内容


        public const Byte AllDeviceGroup = 255;

        public static Int32 SensorMixModuleTotalLogicBlock = 24;
        public static Int32 sumCommandsInSensorMixModuleEveryBlock = 10;

        public static string DownloadSoftwareVerionFromServer = "";
        public static bool isSaveListWhenUpdataSoftware = false;
        public static IntPtr hMutex;

        public static bool isCheckF5orF8 = false;
        public static byte bytParam1;
        public static byte bytParam2;
        public static byte bytParam3;
        public static bool IsCheckParam1 = false;
        public static bool IsCheckParam2 = false;
        public static bool IsCheckParam3 = false;
        public static bool isEndDealTargetsBackground = false;
        public static bool isReadOrSaveTargetFail = false;
        public static byte TargetFailIndex = 0;
        public static Queue<byte[]> TargetsBuf = new Queue<byte[]>();
        public static bool isEndReceiveFile = false;

        public static int[] AudioBoxDeviceTypeList = new int[]{  // 所有的背景音乐设备类型
            901,902,903,904,905,906,907, 910, 911, 913
        };
    }
}
