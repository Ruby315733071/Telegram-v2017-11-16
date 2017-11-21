namespace Telegram_Gateway
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSms = new System.Windows.Forms.TabPage();
            this.lvLock = new System.Windows.Forms.ListView();
            this.clStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clChnSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clSubNetId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clDeviceId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.tbSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetUpdates = new System.Windows.Forms.Button();
            this.btnGetMe = new System.Windows.Forms.Button();
            this.rtbTest = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbHdlSetting = new System.Windows.Forms.GroupBox();
            this.rtbToken = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lbServerIp = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.cbIPs = new System.Windows.Forms.ComboBox();
            this.lbActive = new System.Windows.Forms.Label();
            this.tbPC2 = new System.Windows.Forms.TextBox();
            this.lbPC2 = new System.Windows.Forms.Label();
            this.tbPC1 = new System.Windows.Forms.TextBox();
            this.lbPC1 = new System.Windows.Forms.Label();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.rbVingcard = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.rtbRev = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabSms.SuspendLayout();
            this.tsToolBar.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbHdlSetting.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSms);
            this.tabControl1.Controls.Add(this.tabSetup);
            this.tabControl1.Controls.Add(this.tabHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSms
            // 
            this.tabSms.Controls.Add(this.lvLock);
            this.tabSms.Controls.Add(this.tsToolBar);
            this.tabSms.Location = new System.Drawing.Point(4, 23);
            this.tabSms.Name = "tabSms";
            this.tabSms.Size = new System.Drawing.Size(807, 417);
            this.tabSms.TabIndex = 2;
            this.tabSms.Text = "SMS List";
            this.tabSms.UseVisualStyleBackColor = true;
            // 
            // lvLock
            // 
            this.lvLock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clStatus,
            this.clIndex,
            this.clName,
            this.clChnSum,
            this.clSubNetId,
            this.clDeviceId});
            this.lvLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLock.FullRowSelect = true;
            this.lvLock.HideSelection = false;
            this.lvLock.Location = new System.Drawing.Point(0, 48);
            this.lvLock.Name = "lvLock";
            this.lvLock.Size = new System.Drawing.Size(807, 369);
            this.lvLock.TabIndex = 2;
            this.lvLock.UseCompatibleStateImageBehavior = false;
            this.lvLock.View = System.Windows.Forms.View.Details;
            // 
            // clStatus
            // 
            this.clStatus.Text = "";
            this.clStatus.Width = 32;
            // 
            // clIndex
            // 
            this.clIndex.Text = "ID";
            this.clIndex.Width = 32;
            // 
            // clName
            // 
            this.clName.Text = "Remark";
            this.clName.Width = 480;
            // 
            // clChnSum
            // 
            this.clChnSum.Text = "Chn.";
            // 
            // clSubNetId
            // 
            this.clSubNetId.Text = "SubNet ID";
            this.clSubNetId.Width = 80;
            // 
            // clDeviceId
            // 
            this.clDeviceId.Text = "Device ID";
            this.clDeviceId.Width = 80;
            // 
            // tsToolBar
            // 
            this.tsToolBar.AutoSize = false;
            this.tsToolBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSearch,
            this.toolStripSeparator1,
            this.tbSave});
            this.tsToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(807, 48);
            this.tsToolBar.TabIndex = 1;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // tbSearch
            // 
            this.tbSearch.AutoSize = false;
            this.tbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSearch.Image = global::Telegram.Properties.Resources.timg;
            this.tbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(48, 48);
            this.tbSearch.Text = "Search";
            this.tbSearch.Click += new System.EventHandler(this.tbSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // tbSave
            // 
            this.tbSave.AutoSize = false;
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Image = global::Telegram.Properties.Resources.timg1;
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(48, 48);
            this.tbSave.Text = "Save";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.groupBox1);
            this.tabSetup.Controls.Add(this.gbHdlSetting);
            this.tabSetup.Location = new System.Drawing.Point(4, 23);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetup.Size = new System.Drawing.Size(807, 417);
            this.tabSetup.TabIndex = 0;
            this.tabSetup.Text = "Setup";
            this.tabSetup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetUpdates);
            this.groupBox1.Controls.Add(this.btnGetMe);
            this.groupBox1.Controls.Add(this.rtbTest);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbUrl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 192);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HDL Test";
            // 
            // btnGetUpdates
            // 
            this.btnGetUpdates.Location = new System.Drawing.Point(662, 118);
            this.btnGetUpdates.Name = "btnGetUpdates";
            this.btnGetUpdates.Size = new System.Drawing.Size(119, 30);
            this.btnGetUpdates.TabIndex = 82;
            this.btnGetUpdates.Text = "getUpdates";
            this.btnGetUpdates.UseVisualStyleBackColor = true;
            this.btnGetUpdates.Click += new System.EventHandler(this.btnGetUpdates_Click);
            // 
            // btnGetMe
            // 
            this.btnGetMe.AccessibleDescription = "";
            this.btnGetMe.Location = new System.Drawing.Point(662, 73);
            this.btnGetMe.Name = "btnGetMe";
            this.btnGetMe.Size = new System.Drawing.Size(119, 30);
            this.btnGetMe.TabIndex = 81;
            this.btnGetMe.Text = "getMe";
            this.btnGetMe.UseVisualStyleBackColor = true;
            this.btnGetMe.Click += new System.EventHandler(this.btnGetMe_Click);
            // 
            // rtbTest
            // 
            this.rtbTest.Location = new System.Drawing.Point(148, 78);
            this.rtbTest.Name = "rtbTest";
            this.rtbTest.Size = new System.Drawing.Size(508, 108);
            this.rtbTest.TabIndex = 80;
            this.rtbTest.Text = resources.GetString("rtbTest.Text");
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(662, 27);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(119, 30);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(31, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 79;
            this.label1.Text = "CallBack:";
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("Calibri", 10F);
            this.tbUrl.Location = new System.Drawing.Point(148, 31);
            this.tbUrl.MaxLength = 3;
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(508, 24);
            this.tbUrl.TabIndex = 76;
            this.tbUrl.Tag = "2";
            this.tbUrl.Text = "https://api.telegram.org/bot418868770:AAEb-vpxkUU1ZCraDoHrRyESzhMJlQoAtH0/getMe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(31, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "URL:";
            // 
            // gbHdlSetting
            // 
            this.gbHdlSetting.Controls.Add(this.rtbToken);
            this.gbHdlSetting.Controls.Add(this.btnOK);
            this.gbHdlSetting.Controls.Add(this.tbPort);
            this.gbHdlSetting.Controls.Add(this.lbServerIp);
            this.gbHdlSetting.Controls.Add(this.lbPort);
            this.gbHdlSetting.Controls.Add(this.cbIPs);
            this.gbHdlSetting.Controls.Add(this.lbActive);
            this.gbHdlSetting.Controls.Add(this.tbPC2);
            this.gbHdlSetting.Controls.Add(this.lbPC2);
            this.gbHdlSetting.Controls.Add(this.tbPC1);
            this.gbHdlSetting.Controls.Add(this.lbPC1);
            this.gbHdlSetting.Location = new System.Drawing.Point(3, 3);
            this.gbHdlSetting.Name = "gbHdlSetting";
            this.gbHdlSetting.Size = new System.Drawing.Size(796, 192);
            this.gbHdlSetting.TabIndex = 0;
            this.gbHdlSetting.TabStop = false;
            this.gbHdlSetting.Text = "HDL Setting";
            // 
            // rtbToken
            // 
            this.rtbToken.Location = new System.Drawing.Point(423, 32);
            this.rtbToken.Name = "rtbToken";
            this.rtbToken.Size = new System.Drawing.Size(358, 59);
            this.rtbToken.TabIndex = 78;
            this.rtbToken.Text = "418868770\nAAEb-vpxkUU1ZCraDoHrRyESzhMJlQoAtH0";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(662, 122);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(119, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Calibri", 10F);
            this.tbPort.Location = new System.Drawing.Point(148, 148);
            this.tbPort.MaxLength = 3;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(192, 24);
            this.tbPort.TabIndex = 82;
            this.tbPort.Tag = "2";
            this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
            // 
            // lbServerIp
            // 
            this.lbServerIp.AutoSize = true;
            this.lbServerIp.Font = new System.Drawing.Font("Calibri", 10F);
            this.lbServerIp.ForeColor = System.Drawing.Color.Blue;
            this.lbServerIp.Location = new System.Drawing.Point(372, 36);
            this.lbServerIp.Name = "lbServerIp";
            this.lbServerIp.Size = new System.Drawing.Size(45, 17);
            this.lbServerIp.TabIndex = 76;
            this.lbServerIp.Text = "Token:";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Font = new System.Drawing.Font("Calibri", 10F);
            this.lbPort.ForeColor = System.Drawing.Color.Blue;
            this.lbPort.Location = new System.Drawing.Point(31, 153);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(36, 17);
            this.lbPort.TabIndex = 81;
            this.lbPort.Text = "Port:";
            // 
            // cbIPs
            // 
            this.cbIPs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIPs.Font = new System.Drawing.Font("Calibri", 10F);
            this.cbIPs.Location = new System.Drawing.Point(148, 106);
            this.cbIPs.Name = "cbIPs";
            this.cbIPs.Size = new System.Drawing.Size(192, 23);
            this.cbIPs.TabIndex = 80;
            this.cbIPs.SelectedIndexChanged += new System.EventHandler(this.cbIPs_SelectedIndexChanged);
            // 
            // lbActive
            // 
            this.lbActive.AutoSize = true;
            this.lbActive.Font = new System.Drawing.Font("Calibri", 10F);
            this.lbActive.ForeColor = System.Drawing.Color.Blue;
            this.lbActive.Location = new System.Drawing.Point(31, 111);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(60, 17);
            this.lbActive.TabIndex = 79;
            this.lbActive.Text = "Select IP:";
            // 
            // tbPC2
            // 
            this.tbPC2.Font = new System.Drawing.Font("Calibri", 10F);
            this.tbPC2.Location = new System.Drawing.Point(148, 69);
            this.tbPC2.MaxLength = 3;
            this.tbPC2.Name = "tbPC2";
            this.tbPC2.Size = new System.Drawing.Size(192, 24);
            this.tbPC2.TabIndex = 78;
            this.tbPC2.Tag = "2";
            // 
            // lbPC2
            // 
            this.lbPC2.AutoSize = true;
            this.lbPC2.Font = new System.Drawing.Font("Calibri", 10F);
            this.lbPC2.ForeColor = System.Drawing.Color.Blue;
            this.lbPC2.Location = new System.Drawing.Point(31, 73);
            this.lbPC2.Name = "lbPC2";
            this.lbPC2.Size = new System.Drawing.Size(81, 17);
            this.lbPC2.TabIndex = 77;
            this.lbPC2.Text = "PC device ID:";
            // 
            // tbPC1
            // 
            this.tbPC1.Font = new System.Drawing.Font("Calibri", 10F);
            this.tbPC1.Location = new System.Drawing.Point(148, 31);
            this.tbPC1.MaxLength = 3;
            this.tbPC1.Name = "tbPC1";
            this.tbPC1.Size = new System.Drawing.Size(192, 24);
            this.tbPC1.TabIndex = 76;
            this.tbPC1.Tag = "2";
            // 
            // lbPC1
            // 
            this.lbPC1.AutoSize = true;
            this.lbPC1.Font = new System.Drawing.Font("Calibri", 10F);
            this.lbPC1.ForeColor = System.Drawing.Color.Blue;
            this.lbPC1.Location = new System.Drawing.Point(31, 36);
            this.lbPC1.Name = "lbPC1";
            this.lbPC1.Size = new System.Drawing.Size(83, 17);
            this.lbPC1.TabIndex = 75;
            this.lbPC1.Text = "PC subnet ID:";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.rbVingcard);
            this.tabHistory.Controls.Add(this.btnClear);
            this.tabHistory.Controls.Add(this.rtbRev);
            this.tabHistory.Location = new System.Drawing.Point(4, 23);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(807, 417);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // rbVingcard
            // 
            this.rbVingcard.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbVingcard.Location = new System.Drawing.Point(3, 203);
            this.rbVingcard.Name = "rbVingcard";
            this.rbVingcard.Size = new System.Drawing.Size(801, 163);
            this.rbVingcard.TabIndex = 2;
            this.rbVingcard.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(694, 372);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rtbRev
            // 
            this.rtbRev.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbRev.Location = new System.Drawing.Point(3, 3);
            this.rtbRev.Name = "rtbRev";
            this.rtbRev.Size = new System.Drawing.Size(801, 200);
            this.rtbRev.TabIndex = 0;
            this.rtbRev.Text = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 444);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "Telegram Gateway V1.16";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSms.ResumeLayout(false);
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            this.tabSetup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbHdlSetting.ResumeLayout(false);
            this.gbHdlSetting.PerformLayout();
            this.tabHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.GroupBox gbHdlSetting;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.ComboBox cbIPs;
        private System.Windows.Forms.Label lbActive;
        private System.Windows.Forms.TextBox tbPC2;
        private System.Windows.Forms.Label lbPC2;
        private System.Windows.Forms.TextBox tbPC1;
        private System.Windows.Forms.Label lbPC1;
        private System.Windows.Forms.Label lbServerIp;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.RichTextBox rbVingcard;
        private System.Windows.Forms.RichTextBox rtbToken;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbRev;
        private System.Windows.Forms.Button btnGetUpdates;
        private System.Windows.Forms.Button btnGetMe;
        private System.Windows.Forms.TabPage tabSms;
        private System.Windows.Forms.ListView lvLock;
        private System.Windows.Forms.ColumnHeader clStatus;
        private System.Windows.Forms.ColumnHeader clIndex;
        private System.Windows.Forms.ColumnHeader clName;
        private System.Windows.Forms.ToolStrip tsToolBar;
        private System.Windows.Forms.ToolStripButton tbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ColumnHeader clChnSum;
        private System.Windows.Forms.ColumnHeader clSubNetId;
        private System.Windows.Forms.ColumnHeader clDeviceId;
    }
}

