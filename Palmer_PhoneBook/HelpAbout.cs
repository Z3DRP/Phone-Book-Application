using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
// needed to use Assembly
using System.Reflection;
using System.Runtime.InteropServices;
using System.Resources;

namespace Palmer_PhoneBook
{
    public partial class HelpAbout : Form
    {
        public HelpAbout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpAbout_Load(object sender, EventArgs e)
        {
            // get the information from AssemblyInfo class

            string prodName = Application.ProductName;
            string compName = Application.CompanyName;
            
            // take assembly info then display it in lbl and textbox
            prodLbl.Text = $"{compName} Software Development, LLC.";
            ProjectTxt.Text = prodName;
            // just gives ok btn focus 
            okBtn.Focus();
        }
    }
}
