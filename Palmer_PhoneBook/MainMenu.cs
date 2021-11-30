// PhoneBook application
// by Zach Palmer 10/17/21

// application allows user todo the following
// add, update and delete contacts from a database
// browse all contacts and search by last name
// view a report on their "Phone Book"



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palmer_PhoneBook
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SplashScreen mySplash = new SplashScreen();
            mySplash.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpAbout helpScreen = new HelpAbout();
            helpScreen.ShowDialog();
        }

        private void contactSubBtn_Click(object sender, EventArgs e)
        {
            DataEntry dataEntryScreen = new DataEntry();
            dataEntryScreen.ShowDialog();
        }

        private void reportSubBtn_Click(object sender, EventArgs e)
        {
            ReportForm reportScreen = new ReportForm();
            reportScreen.ShowDialog();
        }

        private void exitMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
