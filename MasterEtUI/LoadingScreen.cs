using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace MasterEtUI 
{ 
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Shown(object sender, EventArgs e)
        {
            MultiUseFun.writeToVars("rec");
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = Properties.Settings.Default.ProjectPath + "x64\\Debug\\TrainNRecognise.exe";
            //myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//run the process in the background
            myProcess.Start();
            myProcess.WaitForExit();
            Gallery ss = new Gallery();
            Settings.changeForm(this, ss);
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}