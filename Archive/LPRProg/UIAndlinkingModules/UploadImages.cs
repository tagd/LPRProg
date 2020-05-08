using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAndlinkingModules
{
    public partial class UploadImages : Form
    {
        public UploadImages()
        {
            InitializeComponent();
        }

        private void Instructions_Click(object sender, EventArgs e)
        {

        }

        private void OpenFileDialogBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if(folderBrowserDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                string strfilename = folderBrowserDialog1.SelectedPath;
                FilePathDisp.Text = strfilename;
            }
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    string strfilename = openFileDialog1.FileName;
            //    FilePathDisp.Text = strfilename;
            //}
        }

        private void FilePathDisp_Click(object sender, EventArgs e)
        {

        }
    }
}
