using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Dashboard_Lite
{
    public partial class Form1 : Form
    {
        // Notes regarding ClientID and ClientSecret
        // The ClientID here is the one I originally used for Dashboard Lite, when you create an app on twitch, you can
        // just grab your ClientID and pasted it here, it'll use it for the HTTP requests where it's needed.
        // As for the ClientSecret, you'd need to attempt to conceal this somehow, not that anyone who was really out
        // to get it wouldn't be able to do so anyway.
        String ClientID = "client_id_here";
        String ClientSecret = "beefs";

        // I used this StringBuilder to generate the client secret across a bunch of different functions in the
        // application, you might have a better idea on how to handle it.
        StringBuilder buildsecret = new StringBuilder("urrmy");

        // Self-explanatory stuff, the string[] is for the game autocomplete.
        String UserToken = "No token yet.";
        String userName = "None";
        String[] gameListStr;

        // For the version checking stuff, which is very basic.
        int version = 108, newVersion = 108;
        bool newVersionAvailable = false;

        // Default window sizes at base DPI, plus the scaling factor based on system DPI settings.
        // (Why would you change your text DPI? :()
        float chatWinW = 788;
        float chatWinH = 578;
        float winW = 446.0f;
        float winH = 314.0f;
        float sizeScale = 1.0f;

        // Status crap for the application, because I'm stupid and I can't figure out C# VS C
        int authorized = 0;
        int numviewers = 0, maxviewers = 0;

        // This is... for the last played ad timer? Yeah. And the delay crap is for delaying the ads.
        int adseconds = 0, adminutes = 0, adhours = 0;
        int delayseconds = 0, delayminutes = 0, delayed_ad_length = 0;

        // Various stuff from the ini file.
        bool chatShown = false;
        bool showChat = false;
        bool gotViewerCount = false;
        bool adButtonsShown = true;
        bool bigViewerCount = false;
        bool vcountFileOutput = false;
        bool gottaLoadChat = false;

        public Form1() {
            InitializeComponent();

            // Check the system DPI and adjust the window size when chat is enabled.
            Graphics g = this.CreateGraphics();

            sizeScale = g.DpiX / 96.0f;
            chatWinW = chatWinW * sizeScale;
            chatWinH = chatWinH * sizeScale;
        }

        // TERRIFYING NIH STUFF BELOW HERE

        private void RestartAdPlayedTimer() {
            // Reset the "last ad played" timer because balls.
            adseconds = 0; adminutes = 0; adhours = 0;
            adPlayedTimer.Start();
            adPlayedTimer.Enabled = true;

            return;
        }

        private String GetParam(String src, String paramname, int SkipMatches)
        {
            // This is my somewhat useless JSON parsing thing. .NET has its own JSON parsing, but I didn't find
            // out about that until after I had made this one, and then I didn't feel like figuring out how a proper
            // JSON parsing... thing would work, so I just left this as it is. Feel free to replace it.
            int strpos = 0, curcite = 0;
            int pstart = 0, plen = 0;

            int skipParam = SkipMatches;

            String pValue;
            String pName = "NOT FOUND";

            int getPName = 1, getPValue = 0, pValueType = 0;
            int vstart = 0, vlen = 0;

            while (strpos < src.Length) {
                if (getPName == 1) {
                    if (src[strpos] == '\"') {
                        if (curcite == 0) {
                            pstart = strpos + 1; curcite = 1;
                        }
                        else if (curcite == 1) {
                            plen = strpos - pstart;
                            pName = src.Substring(pstart, plen);
                            if (src[strpos+2] == '{')
                                curcite = 0;
                            else {
                                getPValue = 1;
                                getPName = 0;
                                if (src[strpos + 2] == '\"') {
                                    pValue = "";
                                    strpos += 3;
                                    vstart = strpos;
                                    vlen = 0;
                                    pValueType = 1;
                                }
                                else {
                                    pValue = "";
                                    strpos += 2;
                                    pValueType = 2;
                                    vstart = strpos;
                                    vlen = 0;
                                }
                            }
                        }
                    }
                }
                if (getPValue == 1) {
                    if (pValueType == 1) {
                        bool flimps = true;
                        while (flimps) {
                            vlen++;
                            strpos++;
                            if (src[strpos] == '\"') {
                                if(src[strpos-1] != '\\') flimps = false;
                            }
                            if (strpos >= src.Length - 1) {
                                flimps = false;
                            }
                        }
                        pValue = src.Substring(vstart, vlen);
                        if (pName == paramname && skipParam == 0)
                            return pValue;
                        else if (pName == paramname && skipParam > 0) {
                            skipParam--;
                        }
                        getPName = 1; getPValue = 0; curcite = 0;
                    }
                    else if (pValueType == 2) {
                        while (src[strpos] != ',' && src[strpos] != '}' && strpos < src.Length-1) {
                            vlen++;
                            strpos++;
                        }
                        pValue = src.Substring(vstart, vlen);
                        if (pName == paramname)
                            return pValue;
                        getPName = 1; getPValue = 0; curcite = 0;
                    }
                }
                strpos++;
            }
            return "NOT FOUND";
        }

        private String HTTPReq(string reqURL, string reqParams, string reqMethod) {
            String ResponseData = "NOTHING";
            // You will see a lot of try {} catch {} in here, because I personally have no damn idea why C# throws
            // exceptions in your face like it's something that simply should be done.
            // I ended up leaving a bunch of these synchronous HTTP requests in here, because in the return function
            // for an asynchronous HTTP request, you can't access any of the form elements, much like if you spawn
            // a thread yourself. There may be some way to reattach it to the main thread, but I sure don't know it.

            try {
                HttpWebRequest wReq;
                UTF8Encoding encoding = new UTF8Encoding();

                if(reqMethod == "PUT" || reqMethod == "POST")
                     wReq = (HttpWebRequest)WebRequest.Create(reqURL);
                else
                    wReq = (HttpWebRequest)WebRequest.Create(reqURL + reqParams);

                // If you want to use a different version of the Twitch.tv API, edit this line;
                wReq.Accept = "application/vnd.twitchtv.v2+json";
                wReq.Method = reqMethod;
                wReq.ContentType = "application/x-www-form-urlencoded";
                
                if(reqMethod == "PUT" || reqMethod == "POST") {
                    byte[] postData = encoding.GetBytes(reqParams);
                    wReq.ContentLength = postData.Length;

                    using (Stream readWeb = wReq.GetRequestStream()) {
                        readWeb.Write(postData, 0, postData.Length);
                        readWeb.Close();
                    }

                    WebResponse wResp = wReq.GetResponse();
                    using (Stream readWeb = wResp.GetResponseStream()) {
                        TextReader responsereader = new StreamReader(readWeb);
                        ResponseData = responsereader.ReadToEnd() + "\n";
                        responsereader.Close();
                        readWeb.Close();
                    }
                }
                else {
                    WebResponse wResp = wReq.GetResponse();
                    using (Stream readWeb = wResp.GetResponseStream())
                    {
                        TextReader responsereader = new StreamReader(readWeb);
                        ResponseData = responsereader.ReadToEnd() + "\n";
                        responsereader.Close();
                        readWeb.Close();
                    }
                }
            }
            catch (Exception ex) {
                toolStripStatusLabel1.Text = "HTTP " + reqMethod + " request failed: " + ex.Message;
            }

            return ResponseData;
        }

        private String GetHTTPReqA(string Request, string Reqparams, AsyncCallback callbackFunction) {
            // This thing is only used for the viewer count, since that's the only HTTP request that runs
            // regularly anyway, and the way it was locking up the main window was really bothering me.
            // Oh wait, I also use it to check if the stream title was updated successfully.
            // And the updater. I am pro.

            String ResponseData = "NOTHING";

            try {
                HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create(Request + Reqparams);
                ASCIIEncoding encoding = new ASCIIEncoding();

                wReq.Accept = "application/vnd.twitchtv.v2+json";
                wReq.Method = "GET";

                wReq.BeginGetResponse(new AsyncCallback(callbackFunction), wReq);
            }
            catch (Exception ex) {
                return "Error during asynchronous HTTP request: " + ex.Message;
            }

            return ResponseData;
        }

        private void UpdateViewerCount2(IAsyncResult asynchronousResult) {
            // Async response parsing, etc., bleeping blobs.
            if (authorized == 1) {
                String ResponseData = "NOT FOUND", viewersStr = "NOT FOUND";

                try {
                    HttpWebRequest wReq = (HttpWebRequest)asynchronousResult.AsyncState;
                    WebResponse wResp = wReq.EndGetResponse(asynchronousResult);

                    using (Stream readWeb = wResp.GetResponseStream()) {
                        TextReader responsereader = new StreamReader(readWeb);
                        ResponseData = responsereader.ReadToEnd() + "\n";
                        responsereader.Close();
                        readWeb.Close();
                    }
                    ResponseData = ResponseData.Trim('{').Trim('\n').Trim('}');
                }
                catch (Exception ex) {
                    return;
                }

                try {
                    viewersStr = GetParam(ResponseData, "viewers", 0);
                    if (viewersStr == "NOT FOUND")
                        numviewers = 0;
                    else {
                        numviewers = Convert.ToInt32(viewersStr);
                        if (maxviewers < numviewers) maxviewers = numviewers;
                    }
                }
                catch (Exception ex) { }

                if (vcountFileOutput) {
                    try {
                        TextWriter viewersToFile = new StreamWriter("viewer_count.txt", false, System.Text.Encoding.ASCII);
                        viewersToFile.WriteLine(numviewers.ToString());
                        viewersToFile.Close();
                    }
                    catch (Exception ex) {
                        toolStripStatusLabel1.Text = "An error occured while writing viewer count to file.";
                    }
                }
            }

            gotViewerCount = true;
            return;
        }

        private void UpdateViewerCounts() {
            // This gets called after the asynchronous result viewer count function is called, in order to be
            // able to update the form elements. Gets called from a timer1... because I never changed the name
            // of that timer.

            viewersLbl.Text = "|  Viewers: " + numviewers.ToString() + " (Max: " + maxviewers.ToString() + ")";
            curviewersLbl.Text = "Current viewers: " + numviewers.ToString();
            maxviewersLbl.Text = "Peak viewers: " + maxviewers.ToString();

            return;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (gotViewerCount) {
                UpdateViewerCounts();
                gotViewerCount = false;
            }
            if (newVersionAvailable) {
                // Pop up the "new version available" (Form2) window if there's a new version available.
                newVersionAvailable = false;
                Form2 nubHaus = new Form2();
                nubHaus.Show();
                // I know this probably isn't the best way to handle this, or even close to it, but I couldn't
                // figure out how to otherwise share this information between forms.
                nubHaus.versionNum = newVersion;
                nubHaus.UpdateNewVersionLabel();
            }
        }

        private void delayads_Click(object sender, EventArgs e) {
            // Ugly, can probably be automated in some other way, but I thought this functionality (delaying ads)
            // was stupid, so i didn't want to spend a lot of time on it.
            dontDelayToolStripMenuItem.Checked = (sender == dontDelayToolStripMenuItem);
            secondsToolStripMenuItem.Checked = (sender == secondsToolStripMenuItem);
            minuteToolStripMenuItem.Checked = (sender == minuteToolStripMenuItem);
            minutesToolStripMenuItem.Checked = (sender == minutesToolStripMenuItem);
            minutesToolStripMenuItem1.Checked = (sender == minutesToolStripMenuItem1);
        }

        private void authorizebtn_Click(object sender, EventArgs e) {
            try {
                // Get an oauth token. You technically don't have to grab a new one every time you auth, as far as I know,
                // but this was the way I originally implemented it and I never really got around to changing it.
                String AuthString = "client_id=" + ClientID + "&client_secret=" + ClientSecret + "&grant_type=authorization_code&redirect_uri=http://www.apehead.se/twitch_auth" +
                    "&code=" + authCodeBox.Text;
                String ResponseData = HTTPReq("https://api.twitch.tv/kraken/oauth2/token", AuthString, "POST").Trim('{').Trim('\n').Trim('}');

                tokenBox.Text = UserToken = GetParam(ResponseData, "access_token", 0);

                toolStripStatusLabel1.Text = "Getting channel data...";
                statusStrip1.Update();

                // Grab and parse the channel data and update the corresponding fields on the form.
                ResponseData = HTTPReq("https://api.twitch.tv/kraken", "?oauth_token=" + UserToken, "GET").Trim('{').Trim('\n').Trim('}');

                userName = GetParam(ResponseData, "user_name", 0);
                chan_user.Text = "Channel/user name: " + userName;

                ResponseData = HTTPReq("https://api.twitch.tv/kraken/channels/" + userName, "?oauth_token=" + UserToken, "GET").Trim('{').Trim('\n').Trim('}');

                gameBox.Text = GetParam(ResponseData, "game", 0);
                streamtitleBox.Text = GetParam(ResponseData, "status", 0);

                statusStrip1.Update();
                authCodeBox.PasswordChar = tokenBox.PasswordChar = '*';

                // Enable/disable relevant form controls
                clearBtn.Enabled = commercialBtn.Enabled = longCommercial.Enabled = ad_60btn.Enabled = ad_120btn.Enabled = ad_180btn.Enabled = true;
                refreshBtn.Enabled = updateBtn.Enabled = gameBox.Enabled = streamtitleBox.Enabled = getStreamKeyBtn.Enabled = true;
                authCodeBox.Enabled = authorizebtn.Enabled = false;
                getStreamKeyBtn.Text = "Stream key?";

                toolStripStatusLabel1.Text = "All done. Now do things.";
                updateViewersTimer.Enabled = true;
                authorized = 1;

                // YEAH THAT'S RIGHT, GOTTA LOAD CHAT!!! omfg omfg etc.
                if (gottaLoadChat) webChatBrowser.Navigate("http://www.twitch.tv/chat/embed?channel=" + userName + "&popout_chat=true");
            }
            catch (Exception ex) {
                toolStripStatusLabel1.Text = "Authorization failed, verify that your authorization code is correct.";
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            // Because I didn't want to add a menu at the top of the window, I made this right click menu
            // thing instead.
            if (e.Button == MouseButtons.Right)
            {
                rcMenu.Show(new Point(this.Left + e.X-8, this.Top+e.Y+24));
            }
        }

        private void updateViewersTimer_Tick(object sender, EventArgs e) {
            // This thing should actually pause the timer while it's fetching the viewer count, because the Twitch API
            // sometimes takes an obscene amount of time to respond.
            GetHTTPReqA("https://api.twitch.tv/kraken/streams/" + userName, "?oauth_token=" + UserToken, UpdateViewerCount2);

            return;
        }

        private void updateBtn_Click(object sender, EventArgs e) {
            // Update game name and stream title, then check that the update went through successfully, since some people
            // like to put curse words in their stream title and the API likes blocking them from updating when that happens.
            // For the game name/stream title check, look at function below.
            toolStripStatusLabel1.Text = "Updating, please wait...";
            statusStrip1.Update();

            String ResponseData = HTTPReq("https://api.twitch.tv/kraken/channels/" + userName, "oauth_token=" + UserToken +
                "&channel[status]=" +
                streamtitleBox.Text.Replace("%GAME%", gameBox.Text).Replace("%", "%25").Replace("&", "%26").Replace("+", "%2B").Replace("/", "%2F").Replace(";", "%3B") +
                "&channel[game]=" +
                gameBox.Text.Replace("%", "%25").Replace("&", "%26").Replace("+", "%2B").Replace("/", "%2F").Replace(";", "%3B"), "PUT");

            toolStripStatusLabel1.Text = "Checking updated title and game...";
            GetHTTPReqA("https://api.twitch.tv/kraken/channels/" + userName, "?oauth_token=" + UserToken, CheckGameAndTitle);
            statusStrip1.Update();
        }

        private void CheckGameAndTitle(IAsyncResult asynchronousResult) {
            bool updateFailed = false;

            if (authorized == 1) {
                String ResponseData = "NOT FOUND";

                try {
                    HttpWebRequest wReq = (HttpWebRequest)asynchronousResult.AsyncState;
                    WebResponse wResp = wReq.EndGetResponse(asynchronousResult);

                    using (Stream readWeb = wResp.GetResponseStream()) {
                        TextReader responsereader = new StreamReader(readWeb);
                        ResponseData = responsereader.ReadToEnd() + "\n";
                        responsereader.Close();
                        readWeb.Close();
                    }

                    ResponseData = ResponseData.Trim('{').Trim('\n').Trim('}');
                }
                catch (Exception ex) {
                    return;
                }

                try {
                    String gameName = GetParam(ResponseData, "game", 0);
                    if (gameName != gameBox.Text)
                        updateFailed = true;
                    String streamStatus = GetParam(ResponseData, "status", 0);
                    if (streamStatus != streamtitleBox.Text.Replace("%GAME%", gameBox.Text))
                        updateFailed = true;
                }
                catch (Exception ex) { }

                if (!updateFailed)
                    toolStripStatusLabel1.Text = "Stream title and game updated successfully.";
                else
                    toolStripStatusLabel1.Text = "Failed to update stream title and game.";
            }

            return;
        }

        private void clearBtn_Click(object sender, EventArgs e) {
            // I'm not sure if anyone ever use the clear button anymore since the command line switch to use an
            // auth code was added.
            authorized = 0;
            updateViewersTimer.Enabled = false;
            authCodeBox.PasswordChar = '\0';
            tokenBox.PasswordChar = '\0';

            clearBtn.Enabled = commercialBtn.Enabled = longCommercial.Enabled = ad_60btn.Enabled = ad_120btn.Enabled = ad_180btn.Enabled = false;
            refreshBtn.Enabled = updateBtn.Enabled = gameBox.Enabled = streamtitleBox.Enabled = getStreamKeyBtn.Enabled = false;
            authCodeBox.Enabled = authorizebtn.Enabled = true;
            getStreamKeyBtn.Text = "Stream key?";

            tokenBox.Clear();
        }

        public void ToggleAdButtons(bool showAdButtons) {
            // Again, stupid crap because people change their font DPI in Windows for whatever reason.
            int posAdjust = (showAdButtons) ? 0 : 24;

            commercialBtn.Visible = ad_60btn.Visible = longCommercial.Visible = ad_120btn.Visible = ad_180btn.Visible = showAdButtons;

            label3.Top =            (int)((121 - posAdjust) * sizeScale);
            label4.Top =            (int)((149 - posAdjust) * sizeScale);
            refreshBtn.Top =        (int)((117 - posAdjust) * sizeScale);
            gameBox.Top =           (int)((118 - posAdjust) * sizeScale);
            streamtitleBox.Top =    (int)((146 - posAdjust) * sizeScale);
            updateBtn.Top =         (int)((117 - posAdjust) * sizeScale);
            showWebChatBtn.Top =    (int)((169 - posAdjust) * sizeScale);
            getStreamKeyBtn.Top =   (int)((231 - posAdjust) * sizeScale);
            streamkeyBox.Top =      (int)((232 - posAdjust) * sizeScale);
            getAuthCodeBtn.Top =    (int)((199 - posAdjust) * sizeScale);
            curviewersLbl.Top =     (int)((260 - posAdjust) * sizeScale);
            maxviewersLbl.Top =     (int)((286 - posAdjust) * sizeScale);
            adTimerLbl.Visible =    showAdButtons;

            winH = 314.0f - 24.0f + ((bigViewerCount) ? 56 : 0);
            if (!chatShown)
            {
                this.Height = (int)(winH * sizeScale);
                Form1_SizeChanged(this, null);
            }
            toolStripMenuItem1.Checked = showAdButtons;
        }

        private void Form1_Load(object sender, EventArgs e) {
            int authCodeNext = 0;

            if (File.Exists("dashboard_lite.ini"))
                LoadConfig();

            ToggleAdButtons(adButtonsShown);

            if (showChat) {
                chatShown = false;
                showWebChatBtn_Click(this, e);
                gottaLoadChat = true;
                Form1_SizeChanged(this, e);
            }
            else {
                this.Width = (int)(winW * sizeScale);
                this.Height = (int)(winH * sizeScale);
            }

            string[] args = Environment.GetCommandLineArgs();
            foreach (string argStr in args) {
                if (authCodeNext == 1) {
                    authCodeBox.Text = argStr;
                    authCodeNext = 0;
                }
                if (argStr == "-auth")
                    authCodeNext = 1;
            }

            this.Update();
            if (File.Exists("gamelist.ini")) {
                try {
                    // Load the game list (exported from the GiantBomb game database) and enable the
                    // autocomplete crap for the text box.
                    String readstuff;
                    int go = 0;
                    TextReader loadGameList = new StreamReader("gamelist.ini", System.Text.Encoding.UTF8);
                    readstuff = loadGameList.ReadToEnd();
                    gameListStr = readstuff.Split('\n');
                    loadGameList.Close();
                    while (go < gameListStr.Length) {
                        gameListStr[go] = gameListStr[go].Trim('\r');
                        go++;
                    }
                    gameBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    gameBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    gameBox.AutoCompleteCustomSource.AddRange(gameListStr);
                }
                catch (Exception ex) {
                    // There was some error loading the Game list file file, but I'm too lazy to handle it. :|
                }
            }

            // Check for updates.
            GetHTTPReqA("http://www.apehead.se/", "dl_version", CheckForUpdate);
        }

        private void CheckForUpdate(IAsyncResult asynchronousResult) {
            String ResponseData = "NOT FOUND";
            int serverVersion = 0;

            try {
                HttpWebRequest wReq = (HttpWebRequest)asynchronousResult.AsyncState;
                WebResponse wResp = wReq.EndGetResponse(asynchronousResult);

                using (Stream readWeb = wResp.GetResponseStream()) {
                    TextReader responsereader = new StreamReader(readWeb);
                    ResponseData = responsereader.ReadToEnd() + "\n";
                    responsereader.Close();
                    readWeb.Close();
                }

                ResponseData = ResponseData.Trim('{').Trim('\n').Trim('}');

                if (ResponseData != "NOT FOUND") {
                    serverVersion = Convert.ToInt32(ResponseData);
                    if (serverVersion > version) {
                        newVersion = serverVersion;
                        newVersionAvailable = true;
                    }
                }
            }
            catch (Exception ex) { }

            return;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            SaveConfig();
        }

        private void authCodeBox_TextChanged(object sender, EventArgs e) {
            // Enable the get auth code button if the auth code textbox is empty.
            getAuthCodeBtn.Enabled = (authCodeBox.Text.Length == 0) ? true : false;
        }

        private void getAuthCodeBtn_Click(object sender, EventArgs e) {
            String authPageURL = "https://api.twitch.tv/kraken/oauth2/authorize?response_type=code&client_id=q5b73bqjkegtiotp04z5dhx02b6xqa8&redirect_uri=http://www.apehead.se/twitch_auth&scope=channel_read+channel_commercial+channel_editor+chat_login";
            System.Diagnostics.Process.Start(authPageURL);
        }

        private void getStreamKeyBtn_Click(object sender, EventArgs e) {
            if (getStreamKeyBtn.Text == "Stream key!") {
                getStreamKeyBtn.Text = "Stream key?";
                streamkeyBox.Clear();
                streamkeyBox.Enabled = false;
            }
            else {
                String ResponseData;
                String streamKey;

                getStreamKeyBtn.Enabled = false;
                getStreamKeyBtn.Text = "Stream key...";
                getStreamKeyBtn.Update();

                ResponseData = HTTPReq("https://api.twitch.tv/kraken/channel/", "?oauth_token=" + UserToken, "GET").Trim('{').Trim('\n').Trim('}');

                streamkeyBox.Enabled = true;
                streamKey = GetParam(ResponseData, "stream_key", 0);
                // Sometimes, there's a "stream_key" section present, with a link to another API URL that doesn't actually
                // seem to work at all. This is in place to handle that.
                if (streamKey.Substring(0, 4) == "http") {
                    streamKey = GetParam(ResponseData, "stream_key", 1);
                }

                streamkeyBox.Text = streamKey;
                getStreamKeyBtn.Enabled = true;
                getStreamKeyBtn.Text = "Stream key!";
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e) {
            String ResponseData;

            toolStripStatusLabel1.Text = "Refreshing game and stream title...";
            statusStrip1.Update();

            ResponseData = HTTPReq("https://api.twitch.tv/kraken/channels/" + userName, "?oauth_token=" + UserToken, "GET").Trim('{').Trim('\n').Trim('}');

            gameBox.Text = GetParam(ResponseData, "game", 0);
            streamtitleBox.Text = GetParam(ResponseData, "status", 0);

            toolStripStatusLabel1.Text = "Done";
            statusStrip1.Update();
        }

        private void autoAuthTimer_Tick(object sender, EventArgs e) {
            // Auto-auth timer thing, because why not.
            if (authCodeBox.Text != "")
                authorizebtn_Click(this, e);
            autoAuthTimer.Enabled = false;
        }

        private void streamtitleBox_KeyDown(object sender, KeyEventArgs e) {
            // Select all for textboxes and other Windows Forms controls is not base functionality and has to be
            // implemented like this.
            if (e.Control && e.KeyCode == Keys.A) {
                e.SuppressKeyPress = true;
                streamtitleBox.SelectAll();
            }
            else
                e.SuppressKeyPress = false;
        }

        private void gameBox_KeyDown(object sender, KeyEventArgs e) {
            // Another select all handler.
            if (e.Control && e.KeyCode == Keys.A)
                gameBox.SelectAll();
        }

        private void showWebChatBtn_Click(object sender, EventArgs e) {
            if (chatShown) {
                chatShown = false;
                chatWinW = this.Width;
                chatWinH = this.Height;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.MinimumSize = new Size(0, 0);
                this.Width = (int)(winW * sizeScale);
                this.Height = (int)(winH * sizeScale);
                this.MaximizeBox = false;
                showWebChatBtn.Text = "Show web chat";
                webChatBrowser.Navigate("about:blank");
                webChatBrowser.Visible = chatShown;
            }
            else {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.Width = (int)chatWinW;
                this.Height = (int)chatWinH;
                this.MinimumSize = new Size(780, 384);
                this.MaximizeBox = true;
                this.Update();
                showWebChatBtn.Text = "Hide web chat";
                chatShown = true;
                if (authorized == 1)
                    webChatBrowser.Navigate("http://www.twitch.tv/chat/embed?channel=" + userName + "&popout_chat=true");
                else
                    webChatBrowser.Navigate("about:blank");
                webChatBrowser.Visible = chatShown;
                Form1_SizeChanged(this, e);
            }
        }

        private void webChatLogoutBtn_Click(object sender, EventArgs e) {
            webChatBrowser.Navigate("http://www.twitch.tv/user/logout");
        }

        private void button1_Click(object sender, EventArgs e) {
            // This is the "Reload chat" button. I forgot to rename it, and screw the chat.
            webChatBrowser.Navigate("http://www.twitch.tv/chat/embed?channel=" + userName + "&popout_chat=true");
        }

        private void webChatBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            webChatBrowser.ScrollBarsEnabled = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            // Check if the form is minimized. If it is, don't do the other stuff.
            if (this.Top == -32000 || this.Left == -32000) return;
            if (chatShown) {
                if (this.Width < 790) this.Width = 790;
                webChatLogoutBtn.Top = this.Height - 94;
                button1.Top = webChatLogoutBtn.Top - 32;
                webChatBrowser.Width = (this.Width - webChatBrowser.Left) - 28;
                webChatBrowser.Height = (this.Height - webChatBrowser.Top) - 69;
                chatWinW = this.Width;
                chatWinH = this.Height;
            }
        }

        private void LoadConfig() {
            try {
				TextReader loadini = new StreamReader("dashboard_lite.ini", System.Text.Encoding.ASCII);

                String readstuff = loadini.ReadToEnd();
                String[] inicrap = readstuff.Split('\n');
                foreach(String bubens in inicrap) {
                    try {
                        String[] Jonassen = bubens.TrimEnd('\r').TrimEnd('\n').TrimEnd(' ').TrimStart(' ').Split('=');
                        switch (Jonassen[0]) {
                            case "auth code":
                                authCodeBox.Text = Jonassen[1];
                                break;
                            case "show chat":
                                if (Jonassen[1] == "yes") showChat = true;
                                break;
                            case "show ad buttons":
                                if (Jonassen[1] == "no") adButtonsShown = false;
                                break;
                            case "show big viewer count":
                                if (Jonassen[1] == "yes") {
                                    bigViewerCount = false;
                                    toggleBigViewerCountToolStripMenuItem_Click(this, null);
                                }
                                break;
                            case "viewer count file output":
                                if (Jonassen[1] == "yes") {
                                    vcountFileOutput = true;
                                    viewerCountFileOutputOFFToolStripMenuItem.Checked = vcountFileOutput;
                                }
                                break;
                            case "winx":
                                this.Left = Convert.ToInt32(Jonassen[1]);
                                if (this.Left < 0) this.Left = 0;
                                break;
                            case "winy":
                                this.Top = Convert.ToInt32(Jonassen[1]);
                                if (this.Top < 0) this.Top = 0;
                                break;
                            case "winw":
                                chatWinW = Convert.ToInt32(Jonassen[1]);
                                break;
                            case "winh":
                                chatWinH = Convert.ToInt32(Jonassen[1]);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex) {
                        // Ape.
                    }
                }
                loadini.Close();
			}
			catch (Exception ex) { }
        }

        private void SaveConfig() {
            try {
                TextWriter saveini = new StreamWriter("dashboard_lite.ini", false, System.Text.Encoding.ASCII);
                saveini.WriteLine("auth code=" + authCodeBox.Text);
                saveini.WriteLine("winx=" + this.Left.ToString());
                saveini.WriteLine("winy=" + this.Top.ToString());
                saveini.WriteLine("winw=" + chatWinW.ToString());
                saveini.WriteLine("winh=" + chatWinH.ToString());
                saveini.WriteLine("show chat=" + ((chatShown) ? "yes" : "no"));
                saveini.WriteLine("show ad buttons=" + ((adButtonsShown) ? "yes" : "no"));
                saveini.WriteLine("show big viewer count=" + ((bigViewerCount) ? "yes" : "no"));
                saveini.WriteLine("viewer count file output=" + ((vcountFileOutput) ? "yes" : "no"));
                saveini.Close();
            }
            catch (Exception ex) { }
            return;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            // This one ended up with the default name. It's the right click menu option that toggles the
            // commercial buttons.
            adButtonsShown = !adButtonsShown;
            ToggleAdButtons(adButtonsShown);
            toolStripMenuItem1.Checked = adButtonsShown;
        }

        private void resetViewerCountStatsToolStripMenuItem_Click(object sender, EventArgs e) {
            numviewers = 0;
            maxviewers = 0;
            viewersLbl.Text = "|  Viewers: " + numviewers.ToString() + " (Max: " + maxviewers.ToString() + ")";
            curviewersLbl.Text = "Current viewers: " + numviewers.ToString();
            maxviewersLbl.Text = "Peak viewers: " + maxviewers.ToString();
        }

        private void toggleBigViewerCountToolStripMenuItem_Click(object sender, EventArgs e) {
            bigViewerCount = !bigViewerCount;
            curviewersLbl.Visible = maxviewersLbl.Visible = bigViewerCount;
            if (bigViewerCount) winH += (int)(56.0 * sizeScale);
            else winH -= (int)(56.0 * sizeScale);
            if (!chatShown) {
                this.Height = (int)(winH * sizeScale);
                Form1_SizeChanged(this, null);
            }
            toggleBigViewerCountToolStripMenuItem.Checked = bigViewerCount;
        }

        private void viewerCountFileOutputOFFToolStripMenuItem_Click(object sender, EventArgs e) {
            // I don't even
            vcountFileOutput = !vcountFileOutput;
            viewerCountFileOutputOFFToolStripMenuItem.Checked = vcountFileOutput;
        }

        private void adPlayedTimer_Tick(object sender, EventArgs e) {
            // Yeah, this is where I started getting fed up.
            // A timer displaying when you last played an ad? Why don't you just keep track of it yourself?!
            // D:< omfg, etc.
            String bibbers;

            adseconds++;
            if (adseconds > 59) {
                adminutes++;
                adseconds = 0;
            }
            if (adminutes > 59) {
                adhours++;
                adminutes = 0;
            }

            bibbers = "|  Last ad played: ";
            if (adhours != 0) {
                bibbers += adhours.ToString() + ":";
            }
            if (adminutes < 10 && adhours != 0) bibbers += "0";
            bibbers += adminutes.ToString() + ":";
            if (adseconds < 10) bibbers += "0";
            bibbers += adseconds.ToString() + " ago";

            adTimerLbl.Text = bibbers;
        }

        private void adButton_Click(object sender, EventArgs e) {
            int adlength = 0;

            if (delayAdTimer.Enabled) {
                adTimerLbl.Text = "|  Delayed ad canceled.";
                delayAdTimer.Enabled = false;
                return;
            }

            if (sender == commercialBtn) {
                if (dontDelayToolStripMenuItem.Checked == true) toolStripStatusLabel1.Text = "Requesting to run a 30 sec. commercial...";
                statusStrip1.Update();
                adlength = 30;
            }
            if (sender == ad_60btn) {
                if (dontDelayToolStripMenuItem.Checked == true) toolStripStatusLabel1.Text = "Requesting to run a 60 sec. commercial...";
                statusStrip1.Update();
                adlength = 60;
            }
            if (sender == longCommercial) {
                if (dontDelayToolStripMenuItem.Checked == true) toolStripStatusLabel1.Text = "Requesting to run a 90 sec. commercial...";
                statusStrip1.Update();
                adlength = 90;
            }
            if (sender == ad_120btn) {
                if (dontDelayToolStripMenuItem.Checked == true) toolStripStatusLabel1.Text = "Requesting to run a 2 min. commercial break...";
                statusStrip1.Update();
                adlength = 120;
            }
            if (sender == ad_180btn) {
                if (dontDelayToolStripMenuItem.Checked == true) toolStripStatusLabel1.Text = "Requesting to run a 3 min. commercial break...";
                statusStrip1.Update();
                adlength = 180;
            }

            if (dontDelayToolStripMenuItem.Checked == true) {
                HTTPReq("https://api.twitch.tv/kraken/channels/" + userName + "/commercial", "oauth_token=" + UserToken +
                    "&length=" + adlength.ToString(), "POST");

                toolStripStatusLabel1.Text = "Done.";
                RestartAdPlayedTimer();
            }
            else {
                // I don't want to know.
                if (secondsToolStripMenuItem.Checked == true) delayseconds = 30;
                if (minuteToolStripMenuItem.Checked == true) delayminutes = 1;
                if (minutesToolStripMenuItem.Checked == true) delayminutes = 2;
                if (minutesToolStripMenuItem1.Checked == true) delayminutes = 5;
                delayed_ad_length = adlength;
                delayAdTimer.Enabled = true;
                adPlayedTimer.Enabled = false;
            }
        }

        private void delayAdTimer_Tick(object sender, EventArgs e) {
            String bibbers;

            if (delayseconds == 0 && delayminutes > 0) {
                delayminutes--;
                delayseconds = 59;
            }
            else if (delayseconds > 0) {
                delayseconds--;
            }

            bibbers = "|  Ad will play in: ";
            if (delayminutes < 10 && adhours != 0) bibbers += "0";
            bibbers += delayminutes.ToString() + ":";
            if (delayseconds < 10) bibbers += "0";
            bibbers += delayseconds.ToString();

            adTimerLbl.Text = bibbers;

            if (delayseconds == 0 && delayminutes == 0) {
                delayAdTimer.Enabled = false;
                switch (delayed_ad_length) {
                    case 30:
                        toolStripStatusLabel1.Text = "Requesting to run a 30 sec. commercial...";
                        break;
                    case 60:
                        toolStripStatusLabel1.Text = "Requesting to run a 60 sec. commercial...";
                        break;
                    case 90:
                        toolStripStatusLabel1.Text = "Requesting to run a 90 sec. commercial...";
                        break;
                    case 120:
                        toolStripStatusLabel1.Text = "Requesting to run a 2 min. commercial break...";
                        break;
                    case 180:
                        toolStripStatusLabel1.Text = "Requesting to run a 3 min. commercial break...";
                        break;
                }
                statusStrip1.Update();
                HTTPReq("https://api.twitch.tv/kraken/channels/" + userName + "/commercial", "oauth_token=" + UserToken +
                    "&length=" + delayed_ad_length.ToString(), "POST");

                toolStripStatusLabel1.Text = "Done.";
                RestartAdPlayedTimer();
            }
        }

        private void showTokenBtn_Click(object sender, EventArgs e) {
            if (tokenBox.PasswordChar == '*') tokenBox.PasswordChar = '\0';
            else tokenBox.PasswordChar = '*';
        }

        private void tokenBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
                tokenBox.SelectAll();
            }
            else
            {
                e.SuppressKeyPress = false;
            }
        }

    }
}
