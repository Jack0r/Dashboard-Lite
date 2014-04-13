namespace Dashboard_Lite
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.authCodeBox = new System.Windows.Forms.TextBox();
            this.tokenBox = new System.Windows.Forms.TextBox();
            this.authorizebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.viewersLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.adTimerLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.chan_user = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gameBox = new System.Windows.Forms.TextBox();
            this.streamtitleBox = new System.Windows.Forms.TextBox();
            this.commercialBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.updateViewersTimer = new System.Windows.Forms.Timer(this.components);
            this.longCommercial = new System.Windows.Forms.Button();
            this.getAuthCodeBtn = new System.Windows.Forms.Button();
            this.streamkeyBox = new System.Windows.Forms.TextBox();
            this.getStreamKeyBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.autoAuthTimer = new System.Windows.Forms.Timer(this.components);
            this.ad_60btn = new System.Windows.Forms.Button();
            this.ad_120btn = new System.Windows.Forms.Button();
            this.ad_180btn = new System.Windows.Forms.Button();
            this.gameList = new System.Windows.Forms.ListBox();
            this.showWebChatBtn = new System.Windows.Forms.Button();
            this.webChatLogoutBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.webChatBrowser = new System.Windows.Forms.WebBrowser();
            this.rcMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetViewerCountStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleBigViewerCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewerCountFileOutputOFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delayCommercialsByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minutesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.curviewersLbl = new System.Windows.Forms.Label();
            this.maxviewersLbl = new System.Windows.Forms.Label();
            this.adPlayedTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.delayAdTimer = new System.Windows.Forms.Timer(this.components);
            this.showTokenBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.rcMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // authCodeBox
            // 
            this.authCodeBox.Location = new System.Drawing.Point(113, 12);
            this.authCodeBox.Name = "authCodeBox";
            this.authCodeBox.Size = new System.Drawing.Size(205, 20);
            this.authCodeBox.TabIndex = 0;
            this.authCodeBox.TextChanged += new System.EventHandler(this.authCodeBox_TextChanged);
            // 
            // tokenBox
            // 
            this.tokenBox.Location = new System.Drawing.Point(113, 38);
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.ReadOnly = true;
            this.tokenBox.Size = new System.Drawing.Size(176, 20);
            this.tokenBox.TabIndex = 1;
            this.tokenBox.Text = "No token acquired yet";
            this.tokenBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tokenBox_KeyDown);
            // 
            // authorizebtn
            // 
            this.authorizebtn.Location = new System.Drawing.Point(324, 11);
            this.authorizebtn.Name = "authorizebtn";
            this.authorizebtn.Size = new System.Drawing.Size(106, 21);
            this.authorizebtn.TabIndex = 2;
            this.authorizebtn.Text = "Authorize";
            this.authorizebtn.UseVisualStyleBackColor = true;
            this.authorizebtn.Click += new System.EventHandler(this.authorizebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Authorization code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Your access token:";
            // 
            // clearBtn
            // 
            this.clearBtn.Enabled = false;
            this.clearBtn.Location = new System.Drawing.Point(324, 37);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(106, 21);
            this.clearBtn.TabIndex = 6;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.viewersLbl,
            this.adTimerLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // viewersLbl
            // 
            this.viewersLbl.Name = "viewersLbl";
            this.viewersLbl.Size = new System.Drawing.Size(113, 17);
            this.viewersLbl.Text = "|  Viewers: 0 (Max: 0)";
            // 
            // adTimerLbl
            // 
            this.adTimerLbl.Name = "adTimerLbl";
            this.adTimerLbl.Size = new System.Drawing.Size(105, 17);
            this.adTimerLbl.Text = "|  No ad played yet";
            // 
            // chan_user
            // 
            this.chan_user.AutoSize = true;
            this.chan_user.Location = new System.Drawing.Point(9, 69);
            this.chan_user.Name = "chan_user";
            this.chan_user.Size = new System.Drawing.Size(158, 13);
            this.chan_user.TabIndex = 8;
            this.chan_user.Text = "Channel/user name: Not loaded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Game name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stream title:";
            // 
            // gameBox
            // 
            this.gameBox.Enabled = false;
            this.gameBox.Location = new System.Drawing.Point(113, 118);
            this.gameBox.Name = "gameBox";
            this.gameBox.Size = new System.Drawing.Size(205, 20);
            this.gameBox.TabIndex = 11;
            this.gameBox.Text = "Nuthin\'";
            this.gameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameBox_KeyDown);
            // 
            // streamtitleBox
            // 
            this.streamtitleBox.Enabled = false;
            this.streamtitleBox.Location = new System.Drawing.Point(113, 146);
            this.streamtitleBox.Multiline = true;
            this.streamtitleBox.Name = "streamtitleBox";
            this.streamtitleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.streamtitleBox.Size = new System.Drawing.Size(205, 79);
            this.streamtitleBox.TabIndex = 12;
            this.streamtitleBox.Text = "I be play game";
            this.streamtitleBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.streamtitleBox_KeyDown);
            // 
            // commercialBtn
            // 
            this.commercialBtn.Enabled = false;
            this.commercialBtn.Location = new System.Drawing.Point(80, 92);
            this.commercialBtn.Name = "commercialBtn";
            this.commercialBtn.Size = new System.Drawing.Size(64, 20);
            this.commercialBtn.TabIndex = 13;
            this.commercialBtn.Text = "30 sec ad";
            this.commercialBtn.UseVisualStyleBackColor = true;
            this.commercialBtn.Click += new System.EventHandler(this.adButton_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Enabled = false;
            this.updateBtn.Location = new System.Drawing.Point(324, 117);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(106, 47);
            this.updateBtn.TabIndex = 14;
            this.updateBtn.Text = "Update\r\ntitle/game\r\n";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // updateViewersTimer
            // 
            this.updateViewersTimer.Interval = 5000;
            this.updateViewersTimer.Tick += new System.EventHandler(this.updateViewersTimer_Tick);
            // 
            // longCommercial
            // 
            this.longCommercial.Enabled = false;
            this.longCommercial.Location = new System.Drawing.Point(223, 92);
            this.longCommercial.Name = "longCommercial";
            this.longCommercial.Size = new System.Drawing.Size(64, 20);
            this.longCommercial.TabIndex = 15;
            this.longCommercial.Text = "90 sec ad";
            this.longCommercial.UseVisualStyleBackColor = true;
            this.longCommercial.Click += new System.EventHandler(this.adButton_Click);
            // 
            // getAuthCodeBtn
            // 
            this.getAuthCodeBtn.Location = new System.Drawing.Point(324, 199);
            this.getAuthCodeBtn.Name = "getAuthCodeBtn";
            this.getAuthCodeBtn.Size = new System.Drawing.Size(106, 26);
            this.getAuthCodeBtn.TabIndex = 16;
            this.getAuthCodeBtn.Text = "Get auth code";
            this.getAuthCodeBtn.UseVisualStyleBackColor = true;
            this.getAuthCodeBtn.Click += new System.EventHandler(this.getAuthCodeBtn_Click);
            // 
            // streamkeyBox
            // 
            this.streamkeyBox.Enabled = false;
            this.streamkeyBox.Location = new System.Drawing.Point(113, 232);
            this.streamkeyBox.Name = "streamkeyBox";
            this.streamkeyBox.Size = new System.Drawing.Size(317, 20);
            this.streamkeyBox.TabIndex = 17;
            // 
            // getStreamKeyBtn
            // 
            this.getStreamKeyBtn.Enabled = false;
            this.getStreamKeyBtn.Location = new System.Drawing.Point(12, 231);
            this.getStreamKeyBtn.Name = "getStreamKeyBtn";
            this.getStreamKeyBtn.Size = new System.Drawing.Size(95, 21);
            this.getStreamKeyBtn.TabIndex = 18;
            this.getStreamKeyBtn.Text = "Stream key?";
            this.getStreamKeyBtn.UseVisualStyleBackColor = true;
            this.getStreamKeyBtn.Click += new System.EventHandler(this.getStreamKeyBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Enabled = false;
            this.refreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshBtn.Image")));
            this.refreshBtn.Location = new System.Drawing.Point(80, 117);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(26, 22);
            this.refreshBtn.TabIndex = 19;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // autoAuthTimer
            // 
            this.autoAuthTimer.Enabled = true;
            this.autoAuthTimer.Tick += new System.EventHandler(this.autoAuthTimer_Tick);
            // 
            // ad_60btn
            // 
            this.ad_60btn.Enabled = false;
            this.ad_60btn.Location = new System.Drawing.Point(152, 92);
            this.ad_60btn.Name = "ad_60btn";
            this.ad_60btn.Size = new System.Drawing.Size(64, 20);
            this.ad_60btn.TabIndex = 20;
            this.ad_60btn.Text = "60 sec ad";
            this.ad_60btn.UseVisualStyleBackColor = true;
            this.ad_60btn.Click += new System.EventHandler(this.adButton_Click);
            // 
            // ad_120btn
            // 
            this.ad_120btn.Enabled = false;
            this.ad_120btn.Location = new System.Drawing.Point(295, 92);
            this.ad_120btn.Name = "ad_120btn";
            this.ad_120btn.Size = new System.Drawing.Size(64, 20);
            this.ad_120btn.TabIndex = 21;
            this.ad_120btn.Text = "2 min ad";
            this.ad_120btn.UseVisualStyleBackColor = true;
            this.ad_120btn.Click += new System.EventHandler(this.adButton_Click);
            // 
            // ad_180btn
            // 
            this.ad_180btn.Enabled = false;
            this.ad_180btn.Location = new System.Drawing.Point(366, 92);
            this.ad_180btn.Name = "ad_180btn";
            this.ad_180btn.Size = new System.Drawing.Size(64, 20);
            this.ad_180btn.TabIndex = 22;
            this.ad_180btn.Text = "3 min ad";
            this.ad_180btn.UseVisualStyleBackColor = true;
            this.ad_180btn.Click += new System.EventHandler(this.adButton_Click);
            // 
            // gameList
            // 
            this.gameList.FormattingEnabled = true;
            this.gameList.Location = new System.Drawing.Point(52, 445);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(60, 17);
            this.gameList.TabIndex = 23;
            this.gameList.Visible = false;
            // 
            // showWebChatBtn
            // 
            this.showWebChatBtn.Location = new System.Drawing.Point(324, 169);
            this.showWebChatBtn.Name = "showWebChatBtn";
            this.showWebChatBtn.Size = new System.Drawing.Size(106, 26);
            this.showWebChatBtn.TabIndex = 24;
            this.showWebChatBtn.Text = "Show web chat";
            this.showWebChatBtn.UseVisualStyleBackColor = true;
            this.showWebChatBtn.Click += new System.EventHandler(this.showWebChatBtn_Click);
            // 
            // webChatLogoutBtn
            // 
            this.webChatLogoutBtn.Location = new System.Drawing.Point(324, 484);
            this.webChatLogoutBtn.Name = "webChatLogoutBtn";
            this.webChatLogoutBtn.Size = new System.Drawing.Size(106, 26);
            this.webChatLogoutBtn.TabIndex = 26;
            this.webChatLogoutBtn.Text = "Log out from chat";
            this.webChatLogoutBtn.UseVisualStyleBackColor = true;
            this.webChatLogoutBtn.Click += new System.EventHandler(this.webChatLogoutBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 452);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 26);
            this.button1.TabIndex = 27;
            this.button1.Text = "Reload chat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webChatBrowser
            // 
            this.webChatBrowser.Location = new System.Drawing.Point(442, 11);
            this.webChatBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webChatBrowser.Name = "webChatBrowser";
            this.webChatBrowser.ScriptErrorsSuppressed = true;
            this.webChatBrowser.ScrollBarsEnabled = false;
            this.webChatBrowser.Size = new System.Drawing.Size(320, 500);
            this.webChatBrowser.TabIndex = 28;
            this.webChatBrowser.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webChatBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webChatBrowser_DocumentCompleted);
            // 
            // rcMenu
            // 
            this.rcMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.resetViewerCountStatsToolStripMenuItem,
            this.toggleBigViewerCountToolStripMenuItem,
            this.viewerCountFileOutputOFFToolStripMenuItem,
            this.delayCommercialsByToolStripMenuItem});
            this.rcMenu.Name = "rcMenu";
            this.rcMenu.Size = new System.Drawing.Size(217, 114);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.toolStripMenuItem1.Text = "Show commercial buttons";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // resetViewerCountStatsToolStripMenuItem
            // 
            this.resetViewerCountStatsToolStripMenuItem.Name = "resetViewerCountStatsToolStripMenuItem";
            this.resetViewerCountStatsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.resetViewerCountStatsToolStripMenuItem.Text = "Reset viewer count stats";
            this.resetViewerCountStatsToolStripMenuItem.Click += new System.EventHandler(this.resetViewerCountStatsToolStripMenuItem_Click);
            // 
            // toggleBigViewerCountToolStripMenuItem
            // 
            this.toggleBigViewerCountToolStripMenuItem.Name = "toggleBigViewerCountToolStripMenuItem";
            this.toggleBigViewerCountToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.toggleBigViewerCountToolStripMenuItem.Text = "Show big viewer count";
            this.toggleBigViewerCountToolStripMenuItem.Click += new System.EventHandler(this.toggleBigViewerCountToolStripMenuItem_Click);
            // 
            // viewerCountFileOutputOFFToolStripMenuItem
            // 
            this.viewerCountFileOutputOFFToolStripMenuItem.Name = "viewerCountFileOutputOFFToolStripMenuItem";
            this.viewerCountFileOutputOFFToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.viewerCountFileOutputOFFToolStripMenuItem.Text = "Output viewer count to file";
            this.viewerCountFileOutputOFFToolStripMenuItem.Click += new System.EventHandler(this.viewerCountFileOutputOFFToolStripMenuItem_Click);
            // 
            // delayCommercialsByToolStripMenuItem
            // 
            this.delayCommercialsByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dontDelayToolStripMenuItem,
            this.secondsToolStripMenuItem,
            this.minuteToolStripMenuItem,
            this.minutesToolStripMenuItem,
            this.minutesToolStripMenuItem1});
            this.delayCommercialsByToolStripMenuItem.Name = "delayCommercialsByToolStripMenuItem";
            this.delayCommercialsByToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.delayCommercialsByToolStripMenuItem.Text = "Delay commercials by:";
            // 
            // dontDelayToolStripMenuItem
            // 
            this.dontDelayToolStripMenuItem.Checked = true;
            this.dontDelayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dontDelayToolStripMenuItem.Name = "dontDelayToolStripMenuItem";
            this.dontDelayToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.dontDelayToolStripMenuItem.Text = "Don\'t delay";
            this.dontDelayToolStripMenuItem.Click += new System.EventHandler(this.delayads_Click);
            // 
            // secondsToolStripMenuItem
            // 
            this.secondsToolStripMenuItem.Name = "secondsToolStripMenuItem";
            this.secondsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.secondsToolStripMenuItem.Text = "30 seconds";
            this.secondsToolStripMenuItem.Click += new System.EventHandler(this.delayads_Click);
            // 
            // minuteToolStripMenuItem
            // 
            this.minuteToolStripMenuItem.Name = "minuteToolStripMenuItem";
            this.minuteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.minuteToolStripMenuItem.Text = "1 minute";
            this.minuteToolStripMenuItem.Click += new System.EventHandler(this.delayads_Click);
            // 
            // minutesToolStripMenuItem
            // 
            this.minutesToolStripMenuItem.Name = "minutesToolStripMenuItem";
            this.minutesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.minutesToolStripMenuItem.Text = "2 minutes";
            this.minutesToolStripMenuItem.Click += new System.EventHandler(this.delayads_Click);
            // 
            // minutesToolStripMenuItem1
            // 
            this.minutesToolStripMenuItem1.Name = "minutesToolStripMenuItem1";
            this.minutesToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.minutesToolStripMenuItem1.Text = "5 minutes";
            this.minutesToolStripMenuItem1.Click += new System.EventHandler(this.delayads_Click);
            // 
            // curviewersLbl
            // 
            this.curviewersLbl.AutoSize = true;
            this.curviewersLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curviewersLbl.Location = new System.Drawing.Point(12, 260);
            this.curviewersLbl.Name = "curviewersLbl";
            this.curviewersLbl.Size = new System.Drawing.Size(161, 24);
            this.curviewersLbl.TabIndex = 30;
            this.curviewersLbl.Text = "Current viewers: 0";
            this.curviewersLbl.Visible = false;
            // 
            // maxviewersLbl
            // 
            this.maxviewersLbl.AutoSize = true;
            this.maxviewersLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxviewersLbl.Location = new System.Drawing.Point(12, 286);
            this.maxviewersLbl.Name = "maxviewersLbl";
            this.maxviewersLbl.Size = new System.Drawing.Size(141, 24);
            this.maxviewersLbl.TabIndex = 31;
            this.maxviewersLbl.Text = "Peak viewers: 0";
            this.maxviewersLbl.Visible = false;
            // 
            // adPlayedTimer
            // 
            this.adPlayedTimer.Interval = 1000;
            this.adPlayedTimer.Tick += new System.EventHandler(this.adPlayedTimer_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // delayAdTimer
            // 
            this.delayAdTimer.Interval = 1000;
            this.delayAdTimer.Tick += new System.EventHandler(this.delayAdTimer_Tick);
            // 
            // showTokenBtn
            // 
            this.showTokenBtn.Location = new System.Drawing.Point(295, 37);
            this.showTokenBtn.Name = "showTokenBtn";
            this.showTokenBtn.Size = new System.Drawing.Size(23, 21);
            this.showTokenBtn.TabIndex = 32;
            this.showTokenBtn.Text = "!";
            this.showTokenBtn.UseVisualStyleBackColor = true;
            this.showTokenBtn.Click += new System.EventHandler(this.showTokenBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 541);
            this.Controls.Add(this.showTokenBtn);
            this.Controls.Add(this.maxviewersLbl);
            this.Controls.Add(this.curviewersLbl);
            this.Controls.Add(this.webChatBrowser);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webChatLogoutBtn);
            this.Controls.Add(this.showWebChatBtn);
            this.Controls.Add(this.gameList);
            this.Controls.Add(this.ad_180btn);
            this.Controls.Add(this.ad_120btn);
            this.Controls.Add(this.ad_60btn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.getStreamKeyBtn);
            this.Controls.Add(this.streamkeyBox);
            this.Controls.Add(this.getAuthCodeBtn);
            this.Controls.Add(this.longCommercial);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.commercialBtn);
            this.Controls.Add(this.streamtitleBox);
            this.Controls.Add(this.gameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chan_user);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authorizebtn);
            this.Controls.Add(this.tokenBox);
            this.Controls.Add(this.authCodeBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Twitch Dashboard Lite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.rcMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox authCodeBox;
        private System.Windows.Forms.TextBox tokenBox;
        private System.Windows.Forms.Button authorizebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label chan_user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox gameBox;
        private System.Windows.Forms.TextBox streamtitleBox;
        private System.Windows.Forms.Button commercialBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Timer updateViewersTimer;
        private System.Windows.Forms.ToolStripStatusLabel viewersLbl;
        private System.Windows.Forms.Button longCommercial;
        private System.Windows.Forms.Button getAuthCodeBtn;
        private System.Windows.Forms.TextBox streamkeyBox;
        private System.Windows.Forms.Button getStreamKeyBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Timer autoAuthTimer;
        private System.Windows.Forms.Button ad_60btn;
        private System.Windows.Forms.Button ad_120btn;
        private System.Windows.Forms.Button ad_180btn;
        private System.Windows.Forms.ListBox gameList;
        private System.Windows.Forms.Button showWebChatBtn;
        private System.Windows.Forms.Button webChatLogoutBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webChatBrowser;
        private System.Windows.Forms.ContextMenuStrip rcMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetViewerCountStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleBigViewerCountToolStripMenuItem;
        private System.Windows.Forms.Label curviewersLbl;
        private System.Windows.Forms.Label maxviewersLbl;
        private System.Windows.Forms.ToolStripMenuItem viewerCountFileOutputOFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel adTimerLbl;
        private System.Windows.Forms.Timer adPlayedTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem delayCommercialsByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontDelayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minutesToolStripMenuItem1;
        private System.Windows.Forms.Timer delayAdTimer;
        private System.Windows.Forms.Button showTokenBtn;
    }
}

