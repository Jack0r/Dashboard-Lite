namespace Dashboard_Lite
{
    partial class Form2
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
            this.newVersionLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openHomepageBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newVersionLbl
            // 
            this.newVersionLbl.Location = new System.Drawing.Point(12, 9);
            this.newVersionLbl.Name = "newVersionLbl";
            this.newVersionLbl.Size = new System.Drawing.Size(396, 30);
            this.newVersionLbl.TabIndex = 0;
            this.newVersionLbl.Text = "A new version (###) of Twitch Dashboard Lite is available. If clicking the \"Visit" +
    " homepage\" button doesn\'t work, copy the link and paste it in your web browser.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(382, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "http://www.apehead.se/dashboard_lite.php";
            // 
            // openHomepageBtn
            // 
            this.openHomepageBtn.Location = new System.Drawing.Point(12, 79);
            this.openHomepageBtn.Name = "openHomepageBtn";
            this.openHomepageBtn.Size = new System.Drawing.Size(99, 25);
            this.openHomepageBtn.TabIndex = 2;
            this.openHomepageBtn.Text = "Visit homepage";
            this.openHomepageBtn.UseVisualStyleBackColor = true;
            this.openHomepageBtn.Click += new System.EventHandler(this.openHomepageBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(295, 79);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(99, 25);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 115);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.openHomepageBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.newVersionLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "New version available";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newVersionLbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button openHomepageBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}