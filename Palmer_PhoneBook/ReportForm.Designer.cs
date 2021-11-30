
namespace Palmer_PhoneBook
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.PhoneBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Palmer_PhoneBookDataSet = new Palmer_PhoneBook.Palmer_PhoneBookDataSet();
            this.contactReportView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PhoneBookTableAdapter = new Palmer_PhoneBook.Palmer_PhoneBookDataSetTableAdapters.PhoneBookTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneBookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Palmer_PhoneBookDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PhoneBookBindingSource
            // 
            this.PhoneBookBindingSource.DataMember = "PhoneBook";
            this.PhoneBookBindingSource.DataSource = this.Palmer_PhoneBookDataSet;
            // 
            // Palmer_PhoneBookDataSet
            // 
            this.Palmer_PhoneBookDataSet.DataSetName = "Palmer_PhoneBookDataSet";
            this.Palmer_PhoneBookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contactReportView
            // 
            this.contactReportView.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ContactsData";
            reportDataSource1.Value = this.PhoneBookBindingSource;
            this.contactReportView.LocalReport.DataSources.Add(reportDataSource1);
            this.contactReportView.LocalReport.ReportEmbeddedResource = "Palmer_PhoneBook.ContactsReport.rdlc";
            this.contactReportView.Location = new System.Drawing.Point(0, 0);
            this.contactReportView.Name = "contactReportView";
            this.contactReportView.ServerReport.BearerToken = null;
            this.contactReportView.Size = new System.Drawing.Size(973, 450);
            this.contactReportView.TabIndex = 0;
            // 
            // PhoneBookTableAdapter
            // 
            this.PhoneBookTableAdapter.ClearBeforeFill = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 450);
            this.Controls.Add(this.contactReportView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phone Book Report";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhoneBookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Palmer_PhoneBookDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer contactReportView;
        private System.Windows.Forms.BindingSource PhoneBookBindingSource;
        private Palmer_PhoneBookDataSet Palmer_PhoneBookDataSet;
        private Palmer_PhoneBookDataSetTableAdapters.PhoneBookTableAdapter PhoneBookTableAdapter;
    }
}