namespace MasterEtUI
{
    partial class ChangeFontMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeFontMenu));
            this.extFontBtn = new System.Windows.Forms.Button();
            this.baseExistingBtn = new System.Windows.Forms.Button();
            this.fromScratchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // extFontBtn
            // 
            this.extFontBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.extFontBtn.Location = new System.Drawing.Point(50, 232);
            this.extFontBtn.Name = "extFontBtn";
            this.extFontBtn.Size = new System.Drawing.Size(134, 93);
            this.extFontBtn.TabIndex = 0;
            this.extFontBtn.Text = "Select existing font";
            this.extFontBtn.UseVisualStyleBackColor = true;
            this.extFontBtn.Click += new System.EventHandler(this.extFontBtn_Click);
            // 
            // baseExistingBtn
            // 
            this.baseExistingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.baseExistingBtn.Location = new System.Drawing.Point(222, 232);
            this.baseExistingBtn.Name = "baseExistingBtn";
            this.baseExistingBtn.Size = new System.Drawing.Size(134, 93);
            this.baseExistingBtn.TabIndex = 1;
            this.baseExistingBtn.Text = "Create new font based on existing";
            this.baseExistingBtn.UseVisualStyleBackColor = true;
            this.baseExistingBtn.Click += new System.EventHandler(this.baseExistingBtn_Click);
            // 
            // fromScratchBtn
            // 
            this.fromScratchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.fromScratchBtn.Location = new System.Drawing.Point(390, 232);
            this.fromScratchBtn.Name = "fromScratchBtn";
            this.fromScratchBtn.Size = new System.Drawing.Size(134, 93);
            this.fromScratchBtn.TabIndex = 2;
            this.fromScratchBtn.Text = "Create new font from scratch";
            this.fromScratchBtn.UseVisualStyleBackColor = true;
            this.fromScratchBtn.Click += new System.EventHandler(this.fromScratchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(29, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 120);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(483, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ChangeFontMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 393);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromScratchBtn);
            this.Controls.Add(this.baseExistingBtn);
            this.Controls.Add(this.extFontBtn);
            this.Name = "ChangeFontMenu";
            this.Text = "ChangeFontMenu";
            this.Load += new System.EventHandler(this.ChangeFontMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button extFontBtn;
        private System.Windows.Forms.Button baseExistingBtn;
        private System.Windows.Forms.Button fromScratchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}