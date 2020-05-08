using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.IO;

namespace MasterEtUI 
{ 
    public partial class ProcessingDatabases : Form
    {
        static string connectionString = Properties.Settings.Default.SQLConnectionStr;

        public ProcessingDatabases()
        {
            InitializeComponent();
        }

        private void ProcessingDatabases_Shown(object sender, EventArgs e)
        {
            pairEntryAndExit();
            lableTickets();
            lableStudentsNStaff();
            AddUnpaid();
            csvgen();

            //maybehave all in unpaid and delete as time goes on
            this.Hide();
            string message = "Data has been written to databases";
            string caption = "Success";
            MessageBox.Show(message, caption);
            Main ss = new Main();
            ss.Show();
        }

        private void pairEntryAndExit()//Pair the entrance record in car park track with the exit record
        {
            List<string> platesList = new List<string>();
            string query = "select plateRead from comingsAndGoings";      
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    platesList.Add(reader.GetString(0));
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                List<string> platesListDisti = platesList.Distinct().ToList();
                foreach (string plate in platesListDisti)
                {
                    List<int> instances = new List<int>();
                    List<TimeSpan> times = new List<TimeSpan>();
                    int entry = 0;
                    int exit = 0;
                    TimeSpan entryTime;
                    TimeSpan exitTime;
                    string query2 = "select EntryNum, entryTime from comingsAndGoings where plateRead='" + plate + "' ORDER BY entryTime ASC";//The Sql query that is being run on the database  
                    connection.Open();
                    command = new SqlCommand(query2, connection);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        instances.Add(reader.GetInt32(0));
                        times.Add(reader.GetTimeSpan(1));
                    }
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                    for (int x = 0; x < (instances.Count / 2); x = x + 2)
                    {
                        entry = instances[x];
                        exit = instances[x + 1];
                        entryTime = times[x];
                        exitTime = times[x + 1];
                        TimeSpan duration = exitTime - entryTime;
                        string query3 = "INSERT INTO CarParkTrack(EntryEntryNum, ExitEntryNum, DurationOfStay)VALUES (@Entry, @Exit, @Time)"; 
                        connection.Open();
                        command = new SqlCommand(query3, connection);
                        command.Parameters.AddWithValue("@Entry", entry);
                        command.Parameters.AddWithValue("@Exit", exit);
                        command.Parameters.AddWithValue("@Time", duration);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection !" + ex);
            }
        }

        private void lableTickets()
        {
            List<string> TicketList = new List<string>();
            List<int> TicketID = new List<int>();
        string query = "select TicketNum, NumberPlate from Tickets";   
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TicketID.Add(reader.GetInt32(0));
                    TicketList.Add(reader.GetString(1));
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                var TicketNID = TicketList.Zip(TicketID, (t, i) => new { Ticket = t, ID = i });//TicketNID is a variable that stores both the TicketList and the TicketID lists as one object
                foreach (var ti in TicketNID)
                {
                    string query2 = "SELECT ID, comingsAndGoings.plateRead FROM comingsAndGoings inner JOIN CarParkTrack CPT " +
                        "ON comingsAndGoings.EntryNum = CPT.EntryEntryNum WHERE plateRead = '" + ti.Ticket + "';";
                    connection.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(query2, connection);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    sda.Dispose();
                    connection.Close();
                    foreach (DataRow row in dt.Rows)
                    {
                        string query3 = "UPDATE CarParkTrack SET TicketNum =" + ti.ID + ", PaymentMethod = 'Ticket' WHERE ID = " + row["ID"];
                        connection.Open();
                        command = new SqlCommand(query3, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection !" + ex);
            }
        }

        private void lableStudentsNStaff()
        {
            List<int> ID = new List<int>();
            List<string> VReg = new List<string>();
            List<string> AccessLevel = new List<string>();
            string query = "select ID, VReg, AccessLvl from CollegeDatabase";
            SqlConnection connection = new SqlConnection(connectionString); 
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ID.Add(reader.GetInt32(0));
                    VReg.Add(reader.GetString(1));
                    AccessLevel.Add(reader.GetString(2));
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                var person = ID.Zip(AccessLevel, (i, a) => new { ID = i, AccessLevel = a });//person is a variable that stores both the ID and the AccessLevel lists as one object
                var RegNPerson = VReg.Zip(person, (r, p) => new { VReg = r, person = p });//RegNPerson is a variable that stores both the VReg and the person lists as one object

                foreach (var rp in RegNPerson)//for each variable in RegNPerson loop with that variable
                    {
                    string query2 = "SELECT ID, comingsAndGoings.plateRead FROM comingsAndGoings inner JOIN CarParkTrack CPT ON comingsAndGoings.EntryNum = CPT.EntryEntryNum WHERE plateRead = '" + rp.VReg + "';";//The Sql query that is being run on the database  
                    connection.Open();//opens the new connection object
                    SqlDataAdapter sda = new SqlDataAdapter(query2, connection);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    sda.Dispose();
                    connection.Close();

                    foreach (DataRow row in dt.Rows)
                        {
                        string query3 = "UPDATE CarParkTrack SET CarOwnerID ='" + rp.person.ID + "' WHERE ID = " + row["ID"] + ";";
                        connection.Open();
                        command = new SqlCommand(query3, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                        string payMeth;
                        if (rp.person.AccessLevel.Contains("Student"))
                        {
                            payMeth = "Reigate Pay";
                        }
                        else
                        {
                            payMeth = "gratis";
                        }
                        string query4 = "UPDATE CarParkTrack SET PaymentMethod = '" + payMeth + "' WHERE (ID = " + row["ID"] + " AND TicketNum is NULL)";
                        connection.Open();
                        command = new SqlCommand(query4, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection !" + ex);
            }
        }

        public void AddUnpaid()
        {
            try
            {     
                string query = "UPDATE CarParkTrack SET PaymentMethod ='Unpaid' WHERE PaymentMethod is null";           
                SqlConnection connection = new SqlConnection(connectionString);
                 connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                    connection.Close();
            }     
                catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection !" + ex);

            }
        }

        static void csvgen()
        {
            tableToCSV("CarParkTrack");//untested
            tableToCSV("ComingsAndGoings");
            tableToCSV("Tickets");

            var Query = "SELECT ID, comingsAndGoings.plateRead FROM comingsAndGoings inner JOIN CarParkTrack CPT ON " +
                "comingsAndGoings.EntryNum = CPT.EntryEntryNum WHERE PaymentMethod='Unpaid'";
            var table = ReadTable(connectionString, Query);
            WriteToFile(table, Properties.Settings.Default.ProjectPath + "UnpaidCars.csv");

            Query = "SELECT ID, comingsAndGoings.plateRead FROM comingsAndGoings inner JOIN CarParkTrack CPT ON comingsAndGoings.EntryNum = CPT.EntryEntryNum WHERE PaymentMethod='Reigate Pay'";//The Sql query that is being run on the database  
            table = ReadTable(connectionString, Query);
            WriteToFile(table, Properties.Settings.Default.ProjectPath + "ReigateShouldPay.csv");
        }

        static void tableToCSV(String tableName)//untested
        {
            var Query = "SELECT * FROM " + tableName + ";";
            var table = ReadTable(connectionString, Query);
            WriteToFile(table, Properties.Settings.Default.ProjectPath + tableName + ".csv");
        }

        public static DataTable ReadTable(string connectionString, string selectQuery)
        {
            DataTable returnValue = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(returnValue);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection !" + ex);
            }
            return returnValue;
        }

        public static void WriteToFile(DataTable dataSource, string fileOutputPath)
        {
            string seperator = ",";
            StreamWriter sw = new StreamWriter(fileOutputPath, false);
            int colCount = dataSource.Columns.Count;
                for (int i = 0; i < colCount; i++)
                {
                    sw.Write(dataSource.Columns[i]);
                    if (i < colCount - 1)
                {
                    sw.Write(seperator);
                    }

                sw.Write(sw.NewLine);
            }

            foreach (DataRow drow in dataSource.Rows)
            {
                for (int i = 0; i < colCount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]))
                    {
                        sw.Write(drow[i].ToString());
                    }
                    if (i < colCount - 1)
                    {
                        sw.Write(seperator);
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void ProcessingDatabases_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            //this.Font = Settings.getFont();
        }
    }
}