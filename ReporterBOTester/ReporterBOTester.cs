using System;
using System.Windows.Forms;
using Reporter;
using System.IO;
using System.Collections.Generic;

namespace ReporterBOTester
{
    public partial class ReporterBOTester : Form
    {
        private ReporterBO _reporterBO;
        public ReporterBOTester()
        {
            InitializeComponent();
            _reporterBO = new ReporterBO();
            GetReports();            
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            string reportName = cboReports.Text.Trim();
            string parameterSetName = cboParameterSetNames.Text.Trim();

            if (reportName.Length > 0)
            {
                FileInfo fileInfo = new FileInfo(reportName);
                
                if (parameterSetName.Length == 0)
                    txtPdfFileName.Text = _reporterBO.ExportReportToPDF(fileInfo.Name);
                else
                    txtPdfFileName.Text = _reporterBO.ExportReportToPDF(fileInfo.Name, parameterSetName);
            }
        }

        private bool _loading = false;

        private void GetReports()
        {
            _loading = true;
            foreach (FileInfo file in _reporterBO.GetReportFiles())
            {
                cboReports.Items.Add(file.FullName);
            }
            _loading = false;
        }

        private List<ParameterSet> _parameterSets;

        private void cboReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                _reporterBO.SetSelectedReportByReportPath(cboReports.SelectedItem.ToString());
                _parameterSets = new List<ParameterSet>(_reporterBO.AvailableParameterSets);
                DisplayParameterSets();
            }
        }

        private void DisplayParameterSets()
        {
            for (int i = cboParameterSetNames.Items.Count; i > 0; i--)
            {
                cboParameterSetNames.Items.RemoveAt(i - 1);
            }

            cboParameterSetNames.Text = string.Empty;

            foreach (ParameterSet ps in _parameterSets)
            {
                cboParameterSetNames.Items.Add(ps.ParameterSetName);
            }

            cboParameterSetNames.SelectedIndex = -1;
        }
    }
}
