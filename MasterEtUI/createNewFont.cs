using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MasterEtUI 
{ 
    public partial class createNewFont : Form
    {
        public createNewFont()
        {
            InitializeComponent();
        }

        private void createNewFont_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }

        private void OpenFileDialogBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();//create a new file dialog for the user to select the file containing an image of the text being used
            if (file.ShowDialog() == DialogResult.OK)//if a valid file is selected
            {
                FilePathDisp.Text = file.FileName;//show the user in a lable the path of the file they selected
            }
        }

        private void confirmSelect_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label1.Text = "Please enter a valid Filename";
            }
            else
            {//improve - store vars in a csv instead

                //Send a message to the user telling them how to add new font
                string message = "To create a new font enter the boxed character, if the boxed character is not a valid character enter anykey that is not alphanumeric or the esc key, enter the esc key to ext the  improving chars";
                string caption = "Create new font info";
                MessageBox.Show(message, caption);


                string classDir = Properties.Settings.Default.ProjectPath + "Classifications\\" + textBox1.Text;
                Directory.CreateDirectory(classDir);//create directory for storing data made by process

                //write directorys to files so c++ knows where to look
                Properties.Settings.Default.CPPFontPath = classDir;//store above directory retrieve it and continue with same text definitions
                string dir = FilePathDisp.Text;//copy the directory name stored in FilePathDisp to a string
                Properties.Settings.Default.CPPImgPath = dir;//stores path to be used by c++
                Properties.Settings.Default.Save();


                //Run the program to create new font
                MultiUseFun.writeToVars("chT");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = Properties.Settings.Default.ProjectPath + "x64\\Debug\\TrainNRecognise.exe";
                //myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//hides the process that starts the program
                myProcess.Start();//start the process
                myProcess.WaitForExit();//wait till the process has finished to continue

                Main ss = new Main();
                Settings.changeForm(this, ss);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChangeFontMenu ss = new ChangeFontMenu();
            Settings.changeForm(this, ss);
        }
    }
}