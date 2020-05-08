namespace MasterEtUI
{
    partial class UploadImages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadImages));
            this.Instructions = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ColLogo = new System.Windows.Forms.PictureBox();
            this.OpenFileDialogBtn = new System.Windows.Forms.Button();
            this.FilePathLbl = new System.Windows.Forms.Label();
            this.FilePathDisp = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.StartProcess = new System.Windows.Forms.Button();
            this.FilePathFilled = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Instructions
            // 
            this.Instructions.AutoSize = true;
            this.Instructions.Location = new System.Drawing.Point(111, 132);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(323, 13);
            this.Instructions.TabIndex = 0;
            this.Instructions.Text = "Press select and choose the file you wish to use images from below";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ColLogo
            // 
            this.ColLogo.Image = ((System.Drawing.Image)(resources.GetObject("ColLogo.Image")));
            this.ColLogo.Location = new System.Drawing.Point(80, 38);
            this.ColLogo.Name = "ColLogo";
            this.ColLogo.Size = new System.Drawing.Size(464, 72);
            this.ColLogo.TabIndex = 5;
            this.ColLogo.TabStop = false;
            // 
            // OpenFileDialogBtn
            // 
            this.OpenFileDialogBtn.Location = new System.Drawing.Point(514, 236);
            this.OpenFileDialogBtn.Name = "OpenFileDialogBtn";
            this.OpenFileDialogBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenFileDialogBtn.TabIndex = 6;
            this.OpenFileDialogBtn.Text = "Select";
            this.OpenFileDialogBtn.UseVisualStyleBackColor = true;
            this.OpenFileDialogBtn.Click += new System.EventHandler(this.OpenFileDialogBtn_Click);
            // 
            // FilePathLbl
            // 
            this.FilePathLbl.AutoSize = true;
            this.FilePathLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FilePathLbl.Location = new System.Drawing.Point(23, 236);
            this.FilePathLbl.Name = "FilePathLbl";
            this.FilePathLbl.Size = new System.Drawing.Size(69, 18);
            this.FilePathLbl.TabIndex = 7;
            this.FilePathLbl.Text = "File Path;";
            // 
            // FilePathDisp
            // 
            this.FilePathDisp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.FilePathDisp.Location = new System.Drawing.Point(98, 236);
            this.FilePathDisp.Name = "FilePathDisp";
            this.FilePathDisp.Size = new System.Drawing.Size(396, 23);
            this.FilePathDisp.TabIndex = 8;
            // 
            // StartProcess
            // 
            this.StartProcess.Location = new System.Drawing.Point(262, 324);
            this.StartProcess.Name = "StartProcess";
            this.StartProcess.Size = new System.Drawing.Size(91, 23);
            this.StartProcess.TabIndex = 9;
            this.StartProcess.Text = "Process images";
            this.StartProcess.UseVisualStyleBackColor = true;
            this.StartProcess.Click += new System.EventHandler(this.StartProcess_Click);
            // 
            // FilePathFilled
            // 
            this.FilePathFilled.AutoSize = true;
            this.FilePathFilled.Location = new System.Drawing.Point(231, 279);
            this.FilePathFilled.Name = "FilePathFilled";
            this.FilePathFilled.Size = new System.Drawing.Size(0, 13);
            this.FilePathFilled.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(550, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UploadImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(639, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FilePathFilled);
            this.Controls.Add(this.StartProcess);
            this.Controls.Add(this.FilePathDisp);
            this.Controls.Add(this.FilePathLbl);
            this.Controls.Add(this.OpenFileDialogBtn);
            this.Controls.Add(this.ColLogo);
            this.Controls.Add(this.Instructions);
            this.Name = "UploadImages";
            this.Text = "UploadImages";
            this.Load += new System.EventHandler(this.UploadImages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Instructions;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox ColLogo;
        private System.Windows.Forms.Button OpenFileDialogBtn;
        private System.Windows.Forms.Label FilePathLbl;
        private System.Windows.Forms.Label FilePathDisp;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button StartProcess;
        private System.Windows.Forms.Label FilePathFilled;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}