using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace MasterEtUI 
{ 
    public partial class Gallery : Form//improve - get image data straight from db
    {
        List<string> plateImgPath = new List<string>();
        List<string> image = new List<string>();
        List<string> reading = new List<string>();
        List<string> imgDate = new List<string>();
        List<string> imgDateSQL = new List<string>();
        List<string> imgTime = new List<string>();
        int count = -1;

        public Gallery()
        {
            InitializeComponent();
            using (var reader = new StreamReader(Properties.Settings.Default.ProjectPath+ "MasterEtUI\\bin\\Debug\\comingsAndGoings.csv"))
                
                while (!reader.EndOfStream)
                {//todo -check date format matches db //improve
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    plateImgPath.Add(values[0]);//The image path of the plate is the first var
                    image.Add(values[1]);//The full image path is the second var
                    reading.Add(values[2]);//The number plate read is the third var
                    imgDate.Add(File.GetCreationTime(values[1]).ToString("dd/MM/yyyy"));//Extracts the date the image was made from the original image using the path and add it to the imgDate list
                    //with above format SQL reads date as yyyy-dd-mm not yyyy-MM-dd as it is ment to can't find a reason for this in documentation hence below format is needed
                    imgDateSQL.Add(File.GetCreationTime(values[1]).ToString("MM/dd/yyyy"));//Puts the above date in a format which SQL understands and add is to the imgDateSQL list
                    imgTime.Add(File.GetCreationTime(values[1]).ToString("HH:mm:ss.fff")); // Adds the time the image was read to the imageTime list
                }
            
            loadNextImage();
        }

        public void loadNextImage()//loads the next image and it's data into the gallery
        {
            count++;
            plateLbl.Text = reading[count];//Note For Future programers:IF THERES AND ERROR OVER HERE ITS BECAUSE CLASSFICATIONS AND IMAGES HAVE BEEN MODIFIED
            plateImg.Image = Image.FromFile(plateImgPath[count]);
            fullImg.Image = Image.FromFile(image[count]);
            createDate.Text = imgDate[count];
            createTimeTxt.Text = imgTime[count];
        }


        private void button1_Click(object sender, EventArgs e)
        {
         //write updates to db
         ////////////////////////////////
            SqlCommand command;
            string query = "INSERT INTO comingsAndGoings(plateImagePath, imagePath,plateRead, entryTime, Date)VALUES (@PlateImage, @CarImage, @CarPlate, @PicTime, @PicDate)";
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SQLConnectionStr);
            try
            {
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlateImage", plateImgPath[count]);//assign the value of plateImgPath[count] to@PlateImage
                command.Parameters.AddWithValue("@CarImage", image[count]);
                command.Parameters.AddWithValue("@CarPlate", plateLbl.Text);
                command.Parameters.AddWithValue("@PicTime", imgTime[count]);
                command.Parameters.AddWithValue("@PicDate", imgDateSQL[count]);
                command.ExecuteNonQuery();// Execute the command with newly assugned values
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection !" +ex);
            }

            ///////////////////////////////////////////////////
            if (count < reading.Count-1)
            {
                loadNextImage();
            }
            else//all images have been review and gallery can be exited
            {
                ProcessingDatabases ss = new ProcessingDatabases();
                Settings.changeForm(this, ss);
            }
        }

        private void enter_Click(object sender, EventArgs e)                                 
        {
            plateLbl.Text = correctionBox.Text;

        }

        private void fixBtn_Click(object sender, EventArgs e)                                 
        {
            string message = "To improve image recognition enter the boxed character, if the boxed character is not a vaild character enter anykey that is not alphanumeric or the esc key, enter the esc key to ext the  improving chars";
            string caption = "Improve Recognition";
            MessageBox.Show(message, caption);
            string dir = plateImgPath[count];
            string finDir = dir.Replace('\\', '/');//updates the path to a format read by c++
            System.IO.File.WriteAllText(Properties.Settings.Default.ProjectPath + "Recognition\\path.txt", finDir);//writes the directory to a text file 
            Process myProcess = new Process();//creates a new process

            myProcess.StartInfo.FileName = Properties.Settings.Default.ProjectPath + "x64\\Debug\\CorrectionTraining.exe";//set the file being run in the process
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//hides the command line opening the process
            myProcess.Start();
            myProcess.WaitForExit();//wait till the process has exited before doing anything else
        }

        private void Gallery_Load(object sender, EventArgs e)//When Current form has loaded do this
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}
