using System;
using System.IO;
using System.Windows.Forms;

namespace MasterEtUI 
{ 
    public partial class UploadImages : Form
    {
        public UploadImages()
        {
            InitializeComponent();
        }

        private void OpenFileDialogBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strfilename = folderBrowserDialog1.SelectedPath;
                FilePathDisp.Text = strfilename;
            }
        }

        private void StartProcess_Click(object sender, EventArgs e)
        {
            if (FilePathDisp.Text == "")
            {
                FilePathFilled.Text = "Click the select button and choose a file";
            }
            else
            {
                string dir = FilePathDisp.Text;
                if //todo from what I could find below most efficient method of chcking no images are in the file - do better
                    ((Directory.GetFiles(dir, "*.bmp").Length == 0)&& (Directory.GetFiles(dir,"*.dib").Length == 0) && (Directory.GetFiles(dir, "*.jpeg").Length == 0)&&//checks there are no .bmp, .dib and .jpeg files in directory
                   (Directory.GetFiles(dir, "*.jpg").Length == 0) && (Directory.GetFiles(dir, "*.jpe").Length == 0) && (Directory.GetFiles(dir, "*.jp2").Length == 0) &&
                   (Directory.GetFiles(dir, "*.pbm").Length == 0) && (Directory.GetFiles(dir, "*.png").Length == 0) && (Directory.GetFiles(dir, "*.pgm").Length == 0) &&
                   (Directory.GetFiles(dir, "*.ppm").Length == 0) && (Directory.GetFiles(dir, "*.sr").Length == 0) && (Directory.GetFiles(dir, "*.ras").Length == 0) &&
                   (Directory.GetFiles(dir, "*.tiff").Length == 0) && (Directory.GetFiles(dir, "*.tif").Length == 0))
                {
                    FilePathFilled.Text = "No valid images found in file, please select a different file";
                }
                else
                {                        
                        string finDir = dir.Replace('\\', '/');//makes the directory name into one that may be understood by  c++
                        System.IO.File.WriteAllText(Properties.Settings.Default.ProjectPath + "Recognition\\path.txt", finDir);//writes path to text file to be retrieved in c++
                        LoadingScreen ss = new LoadingScreen();
                        Settings.changeForm(this, ss);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             Main ss = new Main();
             Settings.changeForm(this, ss);
        }

        private void UploadImages_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}