using System;
using System.Windows.Forms;

namespace MasterEtUI 
{ 
    public partial class Main : Form
    { 
        public Main()
        {
            InitializeComponent();
        }

        private void UploadAndProcess_Click(object sender, EventArgs e)
        {
            UploadImages ss = new UploadImages();
            Settings.changeForm(this, ss);
        }

        private void changeFontBtn_Click(object sender, EventArgs e)
        {
            ChangeFontMenu ss = new ChangeFontMenu();
            Settings.changeForm(this, ss);
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            Settings ss = new Settings();
            Settings.changeForm(this, ss);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}