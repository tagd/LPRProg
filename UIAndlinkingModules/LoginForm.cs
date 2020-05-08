using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UIAndlinkingModules
{
    public partial class CollegeLogo : Form
    {
        public static class Global
        {
            public static int incorrectTrys = 0;
        }
        public CollegeLogo()
        {
            InitializeComponent();
        }

        private void PwLbl_Click(object sender, EventArgs e)
        {

        }

        private void UsrNmLbl_Click(object sender, EventArgs e)
        {

        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }

        private void UsrNmBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PwBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3OE800M;Initial Catalog=PlateRecognitionDatabase;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from StaffDatabase where Username='" + UsrNmBox.Text + "' and Password ='" + PwBox.Text + "'", con);
            //con.Open();//
            //SqlCommand cmd = new SqlCommand("Select * from StaffDatabase where Username='" + UsrNmBox.Text + "' and Password ='" + PwBox.Text + "'", con);//
            //SqlDataReader read = cmd.ExecuteReader();//
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (Global.incorrectTrys < 3)
            {
                try
                {
                    if (dt.Rows[0][0].ToString() == "1") { }
                    else
                    {
                        this.Hide();
                        Main ss = new Main();
                        ss.Show();
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Global.incorrectTrys++;
                    Console.WriteLine("Password Incorrect you have " + (3 - Global.incorrectTrys) + " trys remaining");
                }
            }
            else
            {
                Console.WriteLine("You have run out of attempts please contact your system administrator");
}
        }

        private void CollegeLogo_Load(object sender, EventArgs e)
        {

        }
    }
}
