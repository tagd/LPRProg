using System;
using System.Windows.Forms;
using System.IO;

namespace MasterEtUI 
{ 
    public partial class newExistingFont : Form//todo - this code is hard to read fix it
    {
        public newExistingFont()
        {
            InitializeComponent();
        }

        private void OpenFileDialogBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = Properties.Settings.Default.ProjectPath + "Classifications";//path the folder opens in
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)//stops copying path at spaces? //todo - what you mean?
            {
                FilePathDisp.Text = folderBrowser.SelectedPath;//show the user the path they selected in a label
            }
        }

        private void confirmSelect_Click(object sender, EventArgs e)
        {
            string classFile = FilePathDisp.Text+ @"\classifications.xml";
            string imgFile = FilePathDisp.Text + @"\images.xml";
            if ((FilePathDisp.Text == "")&(textBox1.Text == ""))//if either box it empty do this
            {
                FilePathFilled.Text = "Click the select button and choose a file and give your file a name";
            }
            else if ((File.Exists(classFile))&&(File.Exists(imgFile)))
            {
                string sourcePath = FilePathDisp.Text;
                string targetPath = Properties.Settings.Default.ProjectPath + "Classifications\\" + textBox1.Text;
                Directory.CreateDirectory(targetPath);
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);//get the files in sourcepath directory

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);//Copy files from the original font to the file of the new font
                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");//Tell the user if the path they selected does not exist
                }

                Properties.Settings.Default.CPPFontPath = targetPath;//stores path to be used by c++
                Properties.Settings.Default.Save();
                ChangeFontMenu ss = new ChangeFontMenu();
                Settings.changeForm(this, ss);
            }
            else
            {
                FilePathFilled.Text = "Invalid path selected does not contain classifications.xml or images.xml";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChangeFontMenu ss = new ChangeFontMenu();
            Settings.changeForm(this, ss);
        }

        private void newExistingFont_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}