//this is also a notes pages a first alpahbetical doc
////improve means could be improved want whole thing working first
////todo is also used
///get consistant connection to db then make connection string dynamic


using System;//Allows code to uses types in the system namespace without having to write System before them eg EventArgs not System.EventArgs
using System.Windows.Forms;

namespace MasterEtUI 
{ 
    public partial class ChangeFontMenu : Form
    {
        public ChangeFontMenu()//First method initialized with form 
        {
            InitializeComponent();//Initalizes all methods in this componant(form)
        }

        private void pictureBox1_Click(object sender, EventArgs e)//eventArgs and sender mean the method knows if the event specified in the method name happens in the form
        {
            Main ss = new Main();
            Settings.changeForm(this, ss);
        }

        private void extFontBtn_Click(object sender, EventArgs e)
        {
            sltExistingFont ss = new sltExistingFont();
            Settings.changeForm(this, ss);
        }

        private void baseExistingBtn_Click(object sender, EventArgs e)
        {
            newExistingFont ss = new newExistingFont();
            Settings.changeForm(this, ss);
        }

        private void fromScratchBtn_Click(object sender, EventArgs e)
        {
            createNewFont ss = new createNewFont();
            Settings.changeForm(this, ss);
        }

        private void ChangeFontMenu_Load(object sender, EventArgs e)//When Current form has loaded do this
        {
            this.BackColor = Settings.getBackColor();
            this.Font = Settings.getFont();
        }
    }
}