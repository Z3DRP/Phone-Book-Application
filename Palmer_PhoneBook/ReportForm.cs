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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Palmer_PhoneBookDataSet.PhoneBook' table. You can move, or remove it, as needed.
            this.PhoneBookTableAdapter.Fill(this.Palmer_PhoneBookDataSet.PhoneBook);

            this.contactReportView.RefreshReport();
        }
    }
}
