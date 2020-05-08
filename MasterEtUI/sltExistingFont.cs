using System;
using System.IO;
using System.Windows.Forms;

namespace MasterEtUI 
{ 
    public partial class sltExistingFont : Form
    {
        public sltExistingFont()
        {
            InitializeComponent();
        }

        private void OpenFileDialogBtn_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = Properties.Settings.Default.ProjectPath + "Classifications";
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                @FilePathDisp.Text = @folderBrowser.SelectedPath;//set the FilePathDisp lable to the pointer of file browser dialog
            }
        }

        private void confirmSelect_Click_1(object sender, EventArgs e)
        {
            string classFile = FilePathDisp.Text + @"\classifications.xml";
            string imgFile = FilePathDisp.Text + @"\images.xml";
            if (FilePathDisp.Text == "")
            {
                FilePathFilled.Text = "Click the select button and choose a file";
            }
            else if ((File.Exists(classFile)) && (File.Exists(imgFile)))
            {
                string dir = FilePathDisp.Text;
                Console.WriteLine(dir);
                string finDir = dir.Replace('\\', '/');//put the directory in a form c++ can understand
                Properties.Settings.Default.CPPFontPath = finDir;//stores path of font to be used by c++
                Properties.Settings.Default.Save();
                MultiUseFun.writeToVars("Test");//todo remove
                ChangeFontMenu ss = new ChangeFontMenu();//create new instance of 'ChangeFontMenu' form
                Settings.changeForm(this, ss);
            }
            else
            {
                FilePathFilled.Text = "Invalid path selected does not contain classifications.xml or images.xml";
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            ChangeFontMenu ss = new ChangeFontMenu();
            Settings.changeForm(this, ss);
        }

        private void sltExistingFont_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}