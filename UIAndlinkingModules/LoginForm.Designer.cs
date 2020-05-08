namespace UIAndlinkingModules
{
    partial class CollegeLogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollegeLogo));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.UsrNmLbl = new System.Windows.Forms.Label();
            this.PwLbl = new System.Windows.Forms.Label();
            this.UsrNmBox = new System.Windows.Forms.TextBox();
            this.PwBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(12, 13);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(260, 50);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(181, 203);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 1;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // UsrNmLbl
            // 
            this.UsrNmLbl.AutoSize = true;
            this.UsrNmLbl.Location = new System.Drawing.Point(29, 95);
            this.UsrNmLbl.Name = "UsrNmLbl";
            this.UsrNmLbl.Size = new System.Drawing.Size(61, 13);
            this.UsrNmLbl.TabIndex = 2;
            this.UsrNmLbl.Text = "User name;";
            this.UsrNmLbl.Click += new System.EventHandler(this.UsrNmLbl_Click);
            // 
            // PwLbl
            // 
            this.PwLbl.AutoSize = true;
            this.PwLbl.Location = new System.Drawing.Point(29, 144);
            this.PwLbl.Name = "PwLbl";
            this.PwLbl.Size = new System.Drawing.Size(56, 13);
            this.PwLbl.TabIndex = 3;
            this.PwLbl.Text = "Password;";
            this.PwLbl.Click += new System.EventHandler(this.PwLbl_Click);
            // 
            // UsrNmBox
            // 
            this.UsrNmBox.Location = new System.Drawing.Point(150, 95);
            this.UsrNmBox.Name = "UsrNmBox";
            this.UsrNmBox.Size = new System.Drawing.Size(122, 20);
            this.UsrNmBox.TabIndex = 4;
            this.UsrNmBox.TextChanged += new System.EventHandler(this.UsrNmBox_TextChanged);
            // 
            // PwBox
            // 
            this.PwBox.Location = new System.Drawing.Point(150, 144);
            this.PwBox.Name = "PwBox";
            this.PwBox.Size = new System.Drawing.Size(122, 20);
            this.PwBox.TabIndex = 5;
            this.PwBox.TextChanged += new System.EventHandler(this.PwBox_TextChanged);
            // 
            // CollegeLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.PwBox);
            this.Controls.Add(this.UsrNmBox);
            this.Controls.Add(this.PwLbl);
            this.Controls.Add(this.UsrNmLbl);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.Logo);
            this.Name = "CollegeLogo";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.CollegeLogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label UsrNmLbl;
        private System.Windows.Forms.Label PwLbl;
        private System.Windows.Forms.TextBox UsrNmBox;
        private System.Windows.Forms.TextBox PwBox;
    }
}

