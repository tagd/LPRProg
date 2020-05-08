namespace MasterEtUI
{
    partial class Gallery
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
            this.fullImg = new System.Windows.Forms.PictureBox();
            this.plateImg = new System.Windows.Forms.PictureBox();
            this.plateLbl = new System.Windows.Forms.Label();
            this.correctionBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fixBtn = new System.Windows.Forms.Button();
            this.createDate = new System.Windows.Forms.Label();
            this.pltLbl = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.Prompt1 = new System.Windows.Forms.Label();
            this.Prompt2 = new System.Windows.Forms.Label();
            this.enter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.createTimeTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fullImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plateImg)).BeginInit();
            this.SuspendLayout();
            // 
            // fullImg
            // 
            this.fullImg.Location = new System.Drawing.Point(211, 44);
            this.fullImg.Name = "fullImg";
            this.fullImg.Size = new System.Drawing.Size(304, 200);
            this.fullImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fullImg.TabIndex = 0;
            this.fullImg.TabStop = false;
            // 
            // plateImg
            // 
            this.plateImg.Location = new System.Drawing.Point(211, 296);
            this.plateImg.Name = "plateImg";
            this.plateImg.Size = new System.Drawing.Size(304, 50);
            this.plateImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.plateImg.TabIndex = 1;
            this.plateImg.TabStop = false;
            // 
            // plateLbl
            // 
            this.plateLbl.AutoSize = true;
            this.plateLbl.Location = new System.Drawing.Point(470, 377);
            this.plateLbl.Name = "plateLbl";
            this.plateLbl.Size = new System.Drawing.Size(116, 13);
            this.plateLbl.TabIndex = 2;
            this.plateLbl.Text = "Should be numberplate";
            // 
            // correctionBox
            // 
            this.correctionBox.Location = new System.Drawing.Point(436, 479);
            this.correctionBox.Name = "correctionBox";
            this.correctionBox.Size = new System.Drawing.Size(100, 20);
            this.correctionBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fixBtn
            // 
            this.fixBtn.Location = new System.Drawing.Point(511, 450);
            this.fixBtn.Name = "fixBtn";
            this.fixBtn.Size = new System.Drawing.Size(75, 23);
            this.fixBtn.TabIndex = 5;
            this.fixBtn.Text = "Improve reading";
            this.fixBtn.UseVisualStyleBackColor = true;
            this.fixBtn.Click += new System.EventHandler(this.fixBtn_Click);
            // 
            // createDate
            // 
            this.createDate.AutoSize = true;
            this.createDate.Location = new System.Drawing.Point(218, 414);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(113, 13);
            this.createDate.TabIndex = 6;
            this.createDate.Text = "Date image was taken";
            // 
            // pltLbl
            // 
            this.pltLbl.AutoSize = true;
            this.pltLbl.Location = new System.Drawing.Point(121, 377);
            this.pltLbl.Name = "pltLbl";
            this.pltLbl.Size = new System.Drawing.Size(116, 13);
            this.pltLbl.TabIndex = 7;
            this.pltLbl.Text = "Predicted numberplate;";
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(374, 414);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(61, 13);
            this.timeLbl.TabIndex = 8;
            this.timeLbl.Text = "Image time;";
            // 
            // Prompt1
            // 
            this.Prompt1.AutoSize = true;
            this.Prompt1.Location = new System.Drawing.Point(121, 447);
            this.Prompt1.Name = "Prompt1";
            this.Prompt1.Size = new System.Drawing.Size(189, 26);
            this.Prompt1.TabIndex = 9;
            this.Prompt1.Text = "Right Numberplate but wrong reading?\r\nTrain the program to fix this in future";
            // 
            // Prompt2
            // 
            this.Prompt2.AutoSize = true;
            this.Prompt2.Location = new System.Drawing.Point(121, 489);
            this.Prompt2.Name = "Prompt2";
            this.Prompt2.Size = new System.Drawing.Size(184, 13);
            this.Prompt2.TabIndex = 10;
            this.Prompt2.Text = "Enter the correct number plate below;";
            // 
            // enter
            // 
            this.enter.Location = new System.Drawing.Point(535, 479);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(51, 23);
            this.enter.TabIndex = 11;
            this.enter.Text = "Enter";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Image date;";
            // 
            // createTimeTxt
            // 
            this.createTimeTxt.AutoSize = true;
            this.createTimeTxt.Location = new System.Drawing.Point(473, 414);
            this.createTimeTxt.Name = "createTimeTxt";
            this.createTimeTxt.Size = new System.Drawing.Size(113, 13);
            this.createTimeTxt.TabIndex = 13;
            this.createTimeTxt.Text = "Time image was taken";
            // 
            // Gallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 597);
            this.Controls.Add(this.createTimeTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.Prompt2);
            this.Controls.Add(this.Prompt1);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.pltLbl);
            this.Controls.Add(this.createDate);
            this.Controls.Add(this.fixBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.correctionBox);
            this.Controls.Add(this.plateLbl);
            this.Controls.Add(this.plateImg);
            this.Controls.Add(this.fullImg);
            this.Name = "Gallery";
            this.Text = "Gallery";
            this.Load += new System.EventHandler(this.Gallery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fullImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plateImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fullImg;
        private System.Windows.Forms.PictureBox plateImg;
        private System.Windows.Forms.Label plateLbl;
        private System.Windows.Forms.TextBox correctionBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button fixBtn;
        private System.Windows.Forms.Label createDate;
        private System.Windows.Forms.Label pltLbl;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Label Prompt1;
        private System.Windows.Forms.Label Prompt2;
        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label createTimeTxt;
    }
}