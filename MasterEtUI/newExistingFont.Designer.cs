namespace MasterEtUI
{
    partial class newExistingFont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newExistingFont));
            this.Instructions = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FilePathDisp = new System.Windows.Forms.Label();
            this.fontNameLbl = new System.Windows.Forms.Label();
            this.ColLogo = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenFileDialogBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.baseFont = new System.Windows.Forms.Label();
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
            this.Instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.Instructions.Location = new System.Drawing.Point(127, 222);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(0, 22);
            this.Instructions.TabIndex = 32;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            //this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // FilePathDisp
            // 
            this.FilePathDisp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.FilePathDisp.Location = new System.Drawing.Point(141, 332);
            this.FilePathDisp.Name = "FilePathDisp";
            this.FilePathDisp.Size = new System.Drawing.Size(393, 44);
            this.FilePathDisp.TabIndex = 35;
            // 
            // fontNameLbl
            // 
            this.fontNameLbl.AutoSize = true;
            this.fontNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.fontNameLbl.Location = new System.Drawing.Point(35, 204);
            this.fontNameLbl.Name = "fontNameLbl";
            this.fontNameLbl.Size = new System.Drawing.Size(214, 18);
            this.fontNameLbl.TabIndex = 34;
            this.fontNameLbl.Text = "Name the font you are creating;";
            // 
            // ColLogo
            // 
            this.ColLogo.Image = ((System.Drawing.Image)(resources.GetObject("ColLogo.Image")));
            this.ColLogo.Location = new System.Drawing.Point(110, 95);
            this.ColLogo.Name = "ColLogo";
            this.ColLogo.Size = new System.Drawing.Size(464, 72);
            this.ColLogo.TabIndex = 33;
            this.ColLogo.TabStop = false;
            // 
            // folderBrowserDialog1
            // 
            //this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 42;
            // 
            // OpenFileDialogBtn
            // 
            this.OpenFileDialogBtn.Location = new System.Drawing.Point(555, 353);
            this.OpenFileDialogBtn.Name = "OpenFileDialogBtn";
            this.OpenFileDialogBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenFileDialogBtn.TabIndex = 41;
            this.OpenFileDialogBtn.Text = "Select";
            this.OpenFileDialogBtn.UseVisualStyleBackColor = true;
            this.OpenFileDialogBtn.Click += new System.EventHandler(this.OpenFileDialogBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox1.Location = new System.Drawing.Point(138, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(396, 23);
            this.textBox1.TabIndex = 40;
            // 
            // baseFont
            // 
            this.baseFont.AutoSize = true;
            this.baseFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.baseFont.Location = new System.Drawing.Point(35, 295);
            this.baseFont.Name = "baseFont";
            this.baseFont.Size = new System.Drawing.Size(260, 18);
            this.baseFont.TabIndex = 39;
            this.baseFont.Text = "Choose the file of the font to duplicate;";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(580, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FilePathFilled
            // 
            this.FilePathFilled.AutoSize = true;
            this.FilePathFilled.Location = new System.Drawing.Point(199, 396);
            this.FilePathFilled.Name = "FilePathFilled";
            this.FilePathFilled.Size = new System.Drawing.Size(0, 13);
            this.FilePathFilled.TabIndex = 37;
            // 
            // confirmSelect
            // 
            this.confirmSelect.Location = new System.Drawing.Point(289, 420);
            this.confirmSelect.Name = "confirmSelect";
            this.confirmSelect.Size = new System.Drawing.Size(91, 23);
            this.confirmSelect.TabIndex = 36;
            this.confirmSelect.Text = "Create font";
            this.confirmSelect.UseVisualStyleBackColor = true;
            this.confirmSelect.Click += new System.EventHandler(this.confirmSelect_Click);
            // 
            // newExistingFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(664, 501);
            this.Controls.Add(this.Instructions);
            this.Controls.Add(this.FilePathDisp);
            this.Controls.Add(this.fontNameLbl);
            this.Controls.Add(this.ColLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenFileDialogBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.baseFont);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FilePathFilled);
            this.Controls.Add(this.confirmSelect);
            this.Name = "newExistingFont";
            this.Text = "newExistingFont";
            this.Load += new System.EventHandler(this.newExistingFont_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Instructions;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label FilePathDisp;
        private System.Windows.Forms.Label fontNameLbl;
        private System.Windows.Forms.PictureBox ColLogo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OpenFileDialogBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label baseFont;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label FilePathFilled;
        private System.Windows.Forms.Button confirmSelect;
    }
}