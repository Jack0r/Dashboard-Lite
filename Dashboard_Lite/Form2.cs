using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dashboard_Lite
{
    public partial class Form2 : Form
    {
        public int versionNum = 0;

        public Form2() {
            InitializeComponent();
        }

        public void UpdateNewVersionLabel() {
            newVersionLbl.Text = "A new version (" + versionNum.ToString() + ") of Twitch Dashboard Lite is available. If clicking the \"Visit homepage\" button doesn't work, copy the link and paste it in your web browser.";
        }

        private void openHomepageBtn_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://www.apehead.se/dashboard_lite.php");
        }

        private void closeBtn_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
