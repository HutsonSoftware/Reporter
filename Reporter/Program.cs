using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Reporter
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ReporterBO reporterBO = new ReporterBO();
            reporterBO.UpdateLocalReportFilesFromServer();

            CommandLineParser parser = new CommandLineParser(args);
            string reportName = parser["reportName"];
                        
            if (reportName != null)
            {
                string localReportPath = reporterBO.Settings.LocalReportFolder + reportName;
                
                if (File.Exists(localReportPath))
                {
                    reporterBO.SetSelectedReportByReportPath(localReportPath);
                    reporterBO.SetParameterSetNameArg(parser["parameterSetName"]);
                    
                    Application.Run(new ReportViewer(reporterBO));
                }
                else
                    Application.Run(new ReportSelector(reporterBO));
            }
            else
                Application.Run(new ReportSelector(reporterBO));

            parser = null;
            reporterBO.Dispose();
        }
    }
}
