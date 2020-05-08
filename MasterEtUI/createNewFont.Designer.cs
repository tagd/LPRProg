namespace MasterEtUI
{
    partial class createNewFont
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createNewFont));
            this.Instructions = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FilePathDisp = new System.Windows.Forms.Label();
            this.fontNameLbl = new System.Windows.Forms.Label();
            this.ColLogo = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FilePathFilled = new System.Windows.Forms.Label();
            this.confirmSelect = new System.Windows.Forms.Button();
            this.baseFont = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OpenFileDialogBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ColLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Instructions
            // 
            this.Instructions.AutoSize = true;
            this.Instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.Instructions.Location = new System.Drawing.Point(143, 256);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(0, 22);
            this.Instructions.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FilePathDisp
            // 
            this.FilePathDisp.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.FilePathDisp.Location = new System.Drawing.Point(154, 322);
            this.FilePathDisp.Name = "FilePathDisp";
            this.FilePathDisp.Size = new System.Drawing.Size(396, 41);
            this.FilePathDisp.TabIndex = 24;
            // 
            // fontNameLbl
            // 
            this.fontNameLbl.AutoSize = true;
            this.fontNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.fontNameLbl.Location = new System.Drawing.Point(51, 186);
            this.fontNameLbl.Name = "fontNameLbl";
            this.fontNameLbl.Size = new System.Drawing.Size(244, 20);
            this.fontNameLbl.TabIndex = 23;
            this.fontNameLbl.Text = "Name the font you are creating;";
            // 
            // ColLogo
            // 
            this.ColLogo.Image = ((System.Drawing.Image)(resources.GetObject("ColLogo.Image")));
            this.ColLogo.Location = new System.Drawing.Point(126, 86);
            this.ColLogo.Name = "ColLogo";
            this.ColLogo.Size = new System.Drawing.Size(464, 72);
            this.ColLogo.TabIndex = 21;
            this.ColLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(605, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FilePathFilled
            // 
            this.FilePathFilled.AutoSize = true;
            this.FilePathFilled.Location = new System.Drawing.Point(277, 370);
            this.FilePathFilled.Name = "FilePathFilled";
            this.FilePathFilled.Size = new System.Drawing.Size(0, 13);
            this.FilePathFilled.TabIndex = 26;
            // 
            // confirmSelect
            // 
            this.confirmSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.confirmSelect.Location = new System.Drawing.Point(299, 394);
            this.confirmSelect.Name = "confirmSelect";
            this.confirmSelect.Size = new System.Drawing.Size(91, 26);
            this.confirmSelect.TabIndex = 25;
            this.confirmSelect.Text = "Create font";
            this.confirmSelect.UseVisualStyleBackColor = true;
            this.confirmSelect.Click += new System.EventHandler(this.confirmSelect_Click);
            // 
            // baseFont
            // 
            this.baseFont.AutoSize = true;
            this.baseFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.baseFont.Location = new System.Drawing.Point(51, 291);
            this.baseFont.Name = "baseFont";
            this.baseFont.Size = new System.Drawing.Size(363, 20);
            this.baseFont.TabIndex = 28;
            this.baseFont.Text = "Choose the image the font is to be based off of;";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox1.Location = new System.Drawing.Point(154, 229);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(396, 23);
            this.textBox1.TabIndex = 29;
            // 
            // OpenFileDialogBtn
            // 
            this.OpenFileDialogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.OpenFileDialogBtn.Location = new System.Drawing.Point(580, 322);
            this.OpenFileDialogBtn.Name = "OpenFileDialogBtn";
            this.OpenFileDialogBtn.Size = new System.Drawing.Size(75, 25);
            this.OpenFileDialogBtn.TabIndex = 30;
            this.OpenFileDialogBtn.Text = "Select";
            this.OpenFileDialogBtn.UseVisualStyleBackColor = true;
            this.OpenFileDialogBtn.Click += new System.EventHandler(this.OpenFileDialogBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 31;
            // 
            // createNewFont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(714, 463);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenFileDialogBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.baseFont);
            this.Controls.Add(this.Instructions);
            this.Controls.Add(this.FilePathDisp);
            this.Controls.Add(this.fontNameLbl);
            this.Controls.Add(this.ColLogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FilePathFilled);
            this.Controls.Add(this.confirmSelect);
            this.Name = "createNewFont";
            this.Text = "createNewFont";
            this.Load += new System.EventHandler(this.createNewFont_Load);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label FilePathFilled;
        private System.Windows.Forms.Button confirmSelect;
        private System.Windows.Forms.Label baseFont;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OpenFileDialogBtn;
        private System.Windows.Forms.Label label1;
    }
}