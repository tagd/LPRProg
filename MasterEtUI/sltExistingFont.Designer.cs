namespace MasterEtUI
{
    partial class sltExistingFont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sltExistingFont));
            this.Instructions = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FilePathDisp = new System.Windows.Forms.Label();
            this.FilePathLbl = new System.Windows.Forms.Label();
            this.OpenFileDialogBtn = new System.Windows.Forms.Button();
            this.ColLogo = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FilePathFilled = new System.Windows.Forms.Label();
            this.confirmSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Instructions
            // 
            this.Instructions.AutoSize = true;
            this.Instructions.Location = new System.Drawing.Point(117, 180);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(406, 13);
            this.Instructions.TabIndex = 12;
            this.Instructions.Text = "Please select the file with the classifications and  images xml files you wish to" +
    " use in it";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FilePathDisp
            // 
            this.FilePathDisp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.FilePathDisp.Location = new System.Drawing.Point(104, 274);
            this.FilePathDisp.Name = "FilePathDisp";
            this.FilePathDisp.Size = new System.Drawing.Size(396, 43);
            this.FilePathDisp.TabIndex = 16;
            // 
            // FilePathLbl
            // 
            this.FilePathLbl.AutoSize = true;
            this.FilePathLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FilePathLbl.Location = new System.Drawing.Point(29, 284);
            this.FilePathLbl.Name = "FilePathLbl";
            this.FilePathLbl.Size = new System.Drawing.Size(69, 18);
            this.FilePathLbl.TabIndex = 15;
            this.FilePathLbl.Text = "File Path;";
            // 
            // OpenFileDialogBtn
            // 
            this.OpenFileDialogBtn.Location = new System.Drawing.Point(520, 284);
            this.OpenFileDialogBtn.Name = "OpenFileDialogBtn";
            this.OpenFileDialogBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenFileDialogBtn.TabIndex = 14;
            this.OpenFileDialogBtn.Text = "Select";
            this.OpenFileDialogBtn.UseVisualStyleBackColor = true;
            this.OpenFileDialogBtn.Click += new System.EventHandler(this.OpenFileDialogBtn_Click_1);
            // 
            // ColLogo
            // 
            this.ColLogo.Image = ((System.Drawing.Image)(resources.GetObject("ColLogo.Image")));
            this.ColLogo.Location = new System.Drawing.Point(86, 86);
            this.ColLogo.Name = "ColLogo";
            this.ColLogo.Size = new System.Drawing.Size(464, 72);
            this.ColLogo.TabIndex = 13;
            this.ColLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(556, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // FilePathFilled
            // 
            this.FilePathFilled.AutoSize = true;
            this.FilePathFilled.Location = new System.Drawing.Point(237, 327);
            this.FilePathFilled.Name = "FilePathFilled";
            this.FilePathFilled.Size = new System.Drawing.Size(0, 13);
            this.FilePathFilled.TabIndex = 18;
            // 
            // confirmSelect
            // 
            this.confirmSelect.Location = new System.Drawing.Point(268, 372);
            this.confirmSelect.Name = "confirmSelect";
            this.confirmSelect.Size = new System.Drawing.Size(91, 23);
            this.confirmSelect.TabIndex = 17;
            this.confirmSelect.Text = "Change font";
            this.confirmSelect.UseVisualStyleBackColor = true;
            this.confirmSelect.Click += new System.EventHandler(this.confirmSelect_Click_1);
            // 
            // sltExistingFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(634, 466);
            this.Controls.Add(this.Instructions);
            this.Controls.Add(this.FilePathDisp);
            this.Controls.Add(this.FilePathLbl);
            this.Controls.Add(this.OpenFileDialogBtn);
            this.Controls.Add(this.ColLogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FilePathFilled);
            this.Controls.Add(this.confirmSelect);
            this.Name = "sltExistingFont";
            this.Text = "sltExistingFont";
            this.Load += new System.EventHandler(this.sltExistingFont_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Instructions;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label FilePathDisp;
        private System.Windows.Forms.Label FilePathLbl;
        private System.Windows.Forms.Button OpenFileDialogBtn;
        private System.Windows.Forms.PictureBox ColLogo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label FilePathFilled;
        private System.Windows.Forms.Button confirmSelect;
    }
}