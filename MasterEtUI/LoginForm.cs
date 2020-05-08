using System;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace MasterEtUI 
{ 
    public partial class CollegeLogo : Form
    {
        public static int incorrectTrys = 0;
        
        public CollegeLogo()
        {
            InitializeComponent();
        }

        static string CalculateHash(string pass)
        {
            int alsoTheHash=0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(pass);//get the askii bytes of the password
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] md5Bytes = md5.ComputeHash(asciiBytes);//calculate the MD5 hash of the bytes
            for (int x=0; x<asciiBytes.Length;x++)
            {
                alsoTheHash = alsoTheHash + (asciiBytes[x] % 2);// add remainder of askii bytes div 2 to also the hash
                alsoTheHash = alsoTheHash + (asciiBytes[x] * 2125336);// add askiibytes times 2125336 to thehash
                alsoTheHash = alsoTheHash + (md5Bytes[x]);//add the MD5 hashed values to also the hash
                if (md5Bytes[x]%2==1)
                {
                    alsoTheHash = alsoTheHash + (md5Bytes[x] * (asciiBytes[x])%49564*5382);//add the remainder of MD5Bytes times askiiBytes divided by 49564 times 5383 to also the has
                }
            }
            string theHash = alsoTheHash.ToString();
            return theHash;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
                                                                
        {
            //Main ss = new Main();//todo - remove and switch for real
            //Settings.changeForm(this, ss);

            SqlConnection con = new SqlConnection(Properties.Settings.Default.SQLConnectionStr);
            //Hash password before entry to database
            string hash = CalculateHash(PwBox.Text);
            //Console.WriteLine(hash);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from CollegeDatabase where Username='" + UsrNmBox.Text + "' and Password ='" + hash + "'", con);//use this query on the database connected to by con
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (incorrectTrys < 3)
            {
                try
                {
                    if (dt.Rows[0][0].ToString() != "5")//todo - change to null
                    {
                        Main ss = new Main();
                        Settings.changeForm(this, ss);
                    }
                }
                catch (IndexOutOfRangeException)//catch the exception no matching account is found
                {
                    incorrectTrys++;
                    label.Text="Password Incorrect you have " + (3 - incorrectTrys) + " trys remaining";
                }
            }
            else
            {
                label.Text = "No attempts remaining, please contact your system administrator";
            }
        }

        private void CollegeLogo_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}