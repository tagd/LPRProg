using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MasterEtUI 
{ //todo -Make every screen the same size
    //todo make setters and getter classes
    public partial class Settings : Form
    {
        public static List<int> List = new List<int>();

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }

        private void DysColor_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.dyslBackground;
            Properties.Settings.Default.SelectedBackground = "dyslBackground";
            Properties.Settings.Default.Save();
        }

        private void stdColor_Click(object sender, EventArgs e)
        {
            this.BackColor = Properties.Settings.Default.nonDysBack;
            Properties.Settings.Default.SelectedBackground = "nonDysBack";
            Properties.Settings.Default.Save();//Save the selected setting to settings under default
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Font = Properties.Settings.Default.nonDysFont;
            Properties.Settings.Default.SelectedFont = "nonDysFont";
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Font = Properties.Settings.Default.dyslFont;//set font to font in setting.Default.dyslFont
            Properties.Settings.Default.SelectedFont = "dyslFont";//sets default to the selected font forsaving
            Properties.Settings.Default.Save();//Save the selected setting to settings under default
        }

        public static System.Drawing.Font getFont()
        {
            System.Drawing.Font setFont;
            switch (Properties.Settings.Default.SelectedFont)//Checks the project propertysfile and retrieves the default value of SelectedBackground
            {
                case "nonDysFont"://if the value of selected background is 'nonDysFont' (short for non-dyslexic font) do this 
                    setFont = Properties.Settings.Default.nonDysFont;//set the background colour equal to the color stored in defaults
                    break;
                case "dyslFont"://if the value of selected background is 'dyslFont' (short dyslexic font) do this 
                    setFont = Properties.Settings.Default.dyslFont;//set the background colour equal to the color stored in defaults
                    break;
                default://If neither of the other options apply font is the font the project is originally
                    setFont = Properties.Settings.Default.nonDysFont;
                    break;
            }
            return setFont;
        }

        public static System.Drawing.Color getBackColor()
        {
            System.Drawing.Color setColor;
            switch (Properties.Settings.Default.SelectedBackground)//Checks the project propertysfile and retrieves the default value of SelectedBackground
            {
                case "nonDysBack"://if the value of selected background is 'nonDysBack' (short for non-dyslexic background) do this 
                    setColor = Properties.Settings.Default.nonDysBack;//set the background colour equal to the color stored in defaults
                    break;
                case "dyslBackground"://if the value of selected background is 'dyslBackground' (short dyslexic background) do this 
                    setColor = Properties.Settings.Default.dyslBackground;//set the background colour equal to the color stored in defaults
                    break;
                default://If neither of the other options apply background color is the color the project is originally
                    setColor = Properties.Settings.Default.nonDysBack;
                    break;
            }
            return setColor;
        }

        public static void changeForm(Form start, Form end)
        {
            start.Hide();
            end.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main ss = new Main();
            Settings.changeForm(this, ss);
        }
    }
}
 