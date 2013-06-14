using System;
using System.IO;
using System.Windows.Forms;

namespace Reporter
{
    public partial class ReportSelector : ReporterBase
    {
        ReporterBO _reporterBO;

        public ReportSelector(ReporterBO reporterBO)
        {
            InitializeComponent();
            _reporterBO = reporterBO;
            this.Text = base.Title + " - Report Selector";
        }

        private void ReportSelector_Load(object sender, EventArgs e)
        {
            LoadReportFiles();            
        }

        private void LoadReportFiles()
        {
            lstSystemReports.Items.Clear();

            try
            {
                FileInfo[] files = _reporterBO.GetReportFiles();

                foreach (FileInfo file in files)
                {
                    ListViewItem item = new ListViewItem(file.Name);
                    item.SubItems.Add(file.FullName);
                    lstSystemReports.Items.Add(item);
                }

                lstSystemReports.View = View.List;
                lstSystemReports.Sort();
                lstSystemReports.Items[0].Selected = true;

            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
        }

        private void lstSystemReports_DoubleClick(object sender, EventArgs e)
        {
            ViewReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            ViewReport();
        }

        private void ViewReport()
        {
            ReportViewer rv = null;
            try
            {
                this.UseWaitCursor = true;
                if (lstSystemReports.SelectedIndices.Count > 0)
                {
                    string reportPath = lstSystemReports.SelectedItems[0].SubItems[1].Text;
                    _reporterBO.SetSelectedReportByReportPath(reportPath);
                    rv = new ReportViewer(_reporterBO);
                    rv.ShowDialog(this);                    
                }
            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
            finally
            {
                if (rv != null)
                    rv.Dispose();

                this.UseWaitCursor = false;
            }
        }

        private void mnuFileConfig_Click(object sender, EventArgs e)
        {
            ViewConfig();
        }

        private void ViewConfig()
        {
            SettingsEditor editor = new SettingsEditor(_reporterBO.Settings);
            editor.ShowDialog();

            if (editor.IsDirty)
            {
                _reporterBO.Settings = editor.Settings;
                LoadReportFiles();
            }

            editor.Dispose();
        }

        private void btnCloneReport_Click(object sender, EventArgs e)
        {
            CloneReport();
        }

        private void CloneReport()
        {
            ReportCloner rc = null;
            try
            {
                this.UseWaitCursor = true;
                if (lstSystemReports.SelectedIndices.Count > 0)
                {
                    string reportPath = lstSystemReports.SelectedItems[0].SubItems[1].Text;
                    _reporterBO.SetSelectedReportByReportPath(reportPath);
                    rc = new ReportCloner(_reporterBO);
                    rc.ShowDialog(this);

                    LoadReportFiles();
                }
            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
            finally
            {
                if (rc != null)
                    rc.Dispose();

                this.UseWaitCursor = false;
            }
        }

        private void btnReportWizard_Click(object sender, EventArgs e)
        {
            ReportWizard();
        }

        private void ReportWizard()
        {
            ReportGenerator rg = null;
            try
            {
                this.UseWaitCursor = true;
                rg = new ReportGenerator(_reporterBO);
                rg.ShowDialog(this);
                LoadReportFiles();
            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
            finally
            {
                if (rg != null)
                    rg.Dispose();

                this.UseWaitCursor = false;
            }
        }
    }
}
