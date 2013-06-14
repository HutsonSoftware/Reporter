using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Reporter
{
    public partial class ReportCloner : ReporterBase
    {
        private string _reportPath;
        private ReporterBO _reporterBO;

        public ReportCloner(ReporterBO reporterBO)
        {
            InitializeComponent();

            _reporterBO = reporterBO;
            _reportPath = reporterBO.SelectedReportPath;

            this.Text = base.Title + " - Report Cloner";
        }

        private void ReportCloner_Load(object sender, EventArgs e)
        {
            FileInfo existingReport = new FileInfo(_reportPath);
            lblReportClonee.Text = existingReport.Name;
        }

        private void btnCloneReport_Click(object sender, EventArgs e)
        {
            string newReportName = string.Empty;
            newReportName = txtNewReportName.Text;

            if (newReportName.Length != 0)
            {
                if (!newReportName.ToUpper().EndsWith(".RPT"))
                    newReportName = newReportName + ".rpt";

                if (!_reporterBO.IsDuplicateReportName(newReportName))
                {
                    _reporterBO.CloneReport(newReportName);
                    _reporterBO.SendClonedReportFileToServer(newReportName);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
