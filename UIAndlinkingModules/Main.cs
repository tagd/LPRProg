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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void UploadAndProcess_Click(object sender, EventArgs e)
        {
            this.Hide();
            UploadImages ss = new UploadImages();
            ss.Show();
        }
    }
}
