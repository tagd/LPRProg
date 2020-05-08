﻿namespace UIAndlinkingModules
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.UploadAndProcess = new System.Windows.Forms.Button();
            this.ViewAndEdit = new System.Windows.Forms.Button();
            this.ErrorCheck = new System.Windows.Forms.Button();
            this.Setting = new System.Windows.Forms.Button();
            this.ColLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // UploadAndProcess
            // 
            this.UploadAndProcess.Location = new System.Drawing.Point(148, 128);
            this.UploadAndProcess.Name = "UploadAndProcess";
            this.UploadAndProcess.Size = new System.Drawing.Size(104, 65);
            this.UploadAndProcess.TabIndex = 0;
            this.UploadAndProcess.Text = "Upload and process images";
            this.UploadAndProcess.UseVisualStyleBackColor = true;
            this.UploadAndProcess.Click += new System.EventHandler(this.UploadAndProcess_Click);
            // 
            // ViewAndEdit
            // 
            this.ViewAndEdit.Location = new System.Drawing.Point(381, 128);
            this.ViewAndEdit.Name = "ViewAndEdit";
            this.ViewAndEdit.Size = new System.Drawing.Size(104, 65);
            this.ViewAndEdit.TabIndex = 1;
            this.ViewAndEdit.Text = "View and edit databases";
            this.ViewAndEdit.UseVisualStyleBackColor = true;
            // 
            // ErrorCheck
            // 
            this.ErrorCheck.Location = new System.Drawing.Point(148, 226);
            this.ErrorCheck.Name = "ErrorCheck";
            this.ErrorCheck.Size = new System.Drawing.Size(104, 65);
            this.ErrorCheck.TabIndex = 2;
            this.ErrorCheck.Text = "Check for errors and improve recognition";
            this.ErrorCheck.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.Setting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Setting.BackgroundImage")));
            this.Setting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Setting.Location = new System.Drawing.Point(587, 12);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(50, 50);
            this.Setting.TabIndex = 3;
            this.Setting.UseVisualStyleBackColor = true;
            // 
            // ColLogo
            // 
            this.ColLogo.Image = ((System.Drawing.Image)(resources.GetObject("ColLogo.Image")));
            this.ColLogo.Location = new System.Drawing.Point(105, 12);
            this.ColLogo.Name = "ColLogo";
            this.ColLogo.Size = new System.Drawing.Size(464, 72);
            this.ColLogo.TabIndex = 4;
            this.ColLogo.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(647, 419);
            this.Controls.Add(this.ColLogo);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.ErrorCheck);
            this.Controls.Add(this.ViewAndEdit);
            this.Controls.Add(this.UploadAndProcess);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UploadAndProcess;
        private System.Windows.Forms.Button ViewAndEdit;
        private System.Windows.Forms.Button ErrorCheck;
        private System.Windows.Forms.Button Setting;
        private System.Windows.Forms.PictureBox ColLogo;
    }
}