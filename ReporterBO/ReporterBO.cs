using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Reporter
{
    public class ReporterBO : IDisposable
    {
        public ReporterBO()
        {
            InitializeSettings();
            InitializeDataAccess();
        }

        private Settings _settings;

        public Settings Settings
        {
            get { return _settings; }
            set { SettingsUtility.SaveSettingsToFile(value); }
        }

        private void InitializeSettings()
        {
            if (_settings == null)
                GetSettings();
        }

        private void GetSettings()
        {
            string filePath = FileUtility.GetAssemblyDirectory() + "\\Settings.xml";

            if (!File.Exists(filePath))
                CreateSettingsFile(filePath);

            _settings = SettingsUtility.GetSettingsFromFile(filePath);
        }

        private void CreateSettingsFile(string filePath)
        {
            Assembly assembly = this.GetType().Assembly;
            BinaryReader reader = new BinaryReader(assembly.GetManifestResourceStream("Reporter.Settings.xml"));
            FileStream stream = new FileStream(filePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            try
            {
                byte[] buffer = new byte[64 * 1024];
                int numread = reader.Read(buffer, 0, buffer.Length);

                while (numread > 0)
                {
                    writer.Write(buffer, 0, numread);
                    numread = reader.Read(buffer, 0, buffer.Length);
                }

                writer.Flush();
            }
            finally 
            {
                if (stream != null)
                    stream.Dispose();
                if (reader != null) 
                    reader.Close();
            }
        }

        public string ExportReportToPDF(string reportName, string parameterSetName)
        {
            string pdfFile = string.Empty;

            if (parameterSetName.Equals(string.Empty))
                Log("ExportReportToPDF - Param [parameterSetName] must have a value.");
            else
            {
                SetParameterSetNameArg(parameterSetName);
                pdfFile = ExportReportToPDF(reportName);
            }

            return pdfFile;
        }

        public string ExportReportToPDF(string reportName)
        {
            string pdfFile = string.Empty;

            if (reportName.Equals(string.Empty))
            {
                Log("ExportReportToPDF - Param [reportName] must have a value.");
            }
            else
            {
                ReportDocument reportDocument = new ReportDocument();
                try
                {
                    reportDocument.Load(Settings.LocalReportFolder + reportName);
                    SetCrystalReportLogon(reportDocument);
                    
                    pdfFile = GetNewPDFFileName();
                    
                    if (HasParameterSetNameArg)
                        CreateParameterCollection(reportDocument.ParameterFields);

                    reportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile);
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
                finally
                {
                    reportDocument.Dispose();
                }
            }

            return pdfFile;
        }

        private string GetNewPDFFileName()
        {
            string directory = FileUtility.GetAssemblyDirectory() + "\\Exports";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string pdfFile = directory + "\\" + DateTime.Now.ToFileTimeUtc() + ".pdf";

            return pdfFile;
        }

        private LogUtility _log;
        
        public void Log(string logInfo)
        {
            if (_log == null)
                _log = new LogUtility();

            _log.Log(logInfo);
        }

        public FileInfo[] GetReportFiles()
        {
            FileInfo[] files = new FileInfo[0];
            try
            {
                FileUtility.SyncReportsFromServer(Settings.ServerReportFolder, Settings.LocalReportFolder);
                DirectoryInfo dirInfo = new DirectoryInfo(Settings.LocalReportFolder);
                files = dirInfo.GetFiles("*.rpt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return files;
        }

        public void UpdateLocalReportFilesFromServer()
        {
            DirectoryInfo di = new DirectoryInfo(Settings.ServerReportFolder);
            FileInfo[] files = di.GetFiles();

            foreach (FileInfo file in files)
            {
                if (!File.Exists(Settings.LocalReportFolder + file.Name))
                    File.Copy(Settings.ServerReportFolder + file.Name, Settings.LocalReportFolder + file.Name);
                else
                    UpdateLocalReportFileFromServer(file.Name);
            }
        }

        public void UpdateLocalReportFileFromServer(string reportName)
        {
            string serverReportPath = Settings.ServerReportFolder + reportName;
            string localReportPath = Settings.LocalReportFolder + reportName;

            if (Directory.Exists(Settings.ServerReportFolder) && Directory.Exists(Settings.LocalReportFolder))
                if (File.Exists(serverReportPath) && File.Exists(localReportPath))
                    FileUtility.CompareServerFileToLocalFile(serverReportPath, localReportPath);
        }

        public void SetCrystalReportLogon(ReportDocument reportDocument)
        {
            try
            {
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = Settings.DsnName;
                connectionInfo.DatabaseName = Settings.DatabaseName;
                connectionInfo.IntegratedSecurity = Settings.IntegratedSecurity;
                connectionInfo.UserID = Settings.UserID;
                connectionInfo.Password = Settings.Password;

                foreach (Table table in reportDocument.Database.Tables)
                {
                    TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                    tableLogOnInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(tableLogOnInfo);
                }

                foreach (ReportDocument subReportDocument in reportDocument.Subreports)
                {
                    foreach (Table table in subReportDocument.Database.Tables)
                    {
                        TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                        tableLogOnInfo.ConnectionInfo = connectionInfo;
                        table.ApplyLogOnInfo(tableLogOnInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private ReporterDA _reporterDA;

        public Report SelectedReport { get; set; }
        public string SelectedReportPath { get; set; }

        public List<ParameterSet> AvailableParameterSets
        {
            get { return _reporterDA.GetParameterSetsByReportID(SelectedReport.ReportID); }
        }

        private void InitializeDataAccess()
        {
            _reporterDA = new ReporterDA(_settings);
        }

        public void SetSelectedReportByReportPath(string reportPath)
        {
            SelectedReportPath = reportPath;

            SelectedReport = null;
            SelectedReport = _reporterDA.GetReportByFileName(Path.GetFileName(reportPath));
        }

        public ParameterSet SaveParameterSet(ParameterSet parameterSet)
        {
            if (parameterSet.ParameterSetID == 0)
                parameterSet = _reporterDA.InsertParameterSet(parameterSet);
            else
                parameterSet = _reporterDA.UpdateParameterSet(parameterSet);

            return parameterSet;
        }
        
        public void DeleteParameterSet(ParameterSet parameterSet)
        {
            _reporterDA.DeleteParameterSet(parameterSet);
        }

        public bool HasParameterSetNameArg { get; set; }
        private ParameterSet _parameterSetArg;

        public void SetParameterSetNameArg(string parameterSetName)
        {
            _parameterSetArg = _reporterDA.GetParameterSetByReportIDParameterSetName(SelectedReport.ReportID, parameterSetName);

            HasParameterSetNameArg = true;
        }

        public void CreateParameterCollection(ParameterFields parameterFields)
        {
            Dictionary<string, string> paramValuesDictionary = new Dictionary<string, string>();
            foreach (Parameter parameter in _parameterSetArg.Parameters)
            {
                paramValuesDictionary.Add(parameter.ParameterName, parameter.ParameterValue);
            }
            
            CreateParameterCollection(parameterFields, paramValuesDictionary);
        }

        public void CreateParameterCollection(ParameterFields parameterFields, Dictionary<string, string> paramValuesdictionary)
        {
            ParameterValues parameterValues;
            ParameterDiscreteValue parameterDiscreteValue;
            ParameterField parameterField;

            foreach (KeyValuePair<string, string> keyValuePair in paramValuesdictionary)
            {
                parameterValues = parameterFields[keyValuePair.Key].CurrentValues;
                string parameterSubText = keyValuePair.Value;

                if (parameterFields[keyValuePair.Key].DiscreteOrRangeKind == DiscreteOrRangeKind.RangeValue
                    && (parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateParameter
                        || parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateTimeParameter)
                    )
                {
                    ParameterRangeValue parameterRangeValue = new ParameterRangeValue();
                    int position = parameterSubText.IndexOf(" - ");

                    parameterRangeValue.EndValue = parameterSubText.Substring(position, parameterSubText.Length - position);
                    if (parameterRangeValue.EndValue.ToString() == "and up")
                    {
                        parameterRangeValue.EndValue = DateTime.Today;
                        parameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive;
                    }
                    else
                    {
                        parameterRangeValue.EndValue = Convert.ToDateTime(parameterRangeValue.EndValue);
                        parameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive;
                    }

                    parameterRangeValue.StartValue = parameterSubText.Substring(0, position - 1);
                    if (parameterRangeValue.StartValue.ToString() == "up to")
                    {
                        parameterRangeValue.StartValue = DateTime.Today;
                        parameterRangeValue.UpperBoundType = RangeBoundType.NoBound;
                    }
                    else
                    {
                        parameterRangeValue.StartValue = Convert.ToDateTime(parameterRangeValue.StartValue);
                        parameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive;
                    }

                    parameterValues.Add(parameterRangeValue);
                }
                else
                {
                    if (parameterFields[keyValuePair.Key].EnableAllowMultipleValue &&
                        keyValuePair.Value.Trim() != "All")
                    {
                        bool valid = true;
                        int position = 0;
                        int startPosition = 1;

                        if (parameterFields[keyValuePair.Key].ReportParameterType == ParameterType.StoreProcedureParameter)
                        {
                            string commaDelimList = string.Empty;
                            while (valid)
                            {
                                position = keyValuePair.Value.ToString().IndexOf(";", startPosition);
                                if (position == 0)
                                {
                                    parameterDiscreteValue = new ParameterDiscreteValue();
                                    commaDelimList += keyValuePair.Value.Substring(startPosition, keyValuePair.Value.Length);
                                    parameterDiscreteValue.Value = commaDelimList;

                                    parameterValues.Add(parameterDiscreteValue);
                                    return;
                                }
                                else
                                {
                                    commaDelimList += keyValuePair.Value.Substring(startPosition, position - startPosition) + ",";
                                    startPosition = position + 1;
                                }
                            }
                        }
                        else
                        {
                            while (valid)
                            {
                                position = keyValuePair.Value.ToString().IndexOf(";", startPosition);
                                if (position == 0)
                                {
                                    parameterDiscreteValue = new ParameterDiscreteValue();
                                    parameterDiscreteValue.Value = keyValuePair.Value.Substring(startPosition, keyValuePair.Value.Length);

                                    parameterValues.Add(parameterDiscreteValue);
                                    return;
                                }
                                else
                                {
                                    parameterDiscreteValue = new ParameterDiscreteValue();
                                    parameterDiscreteValue.Value = keyValuePair.Value.Substring(startPosition, position - startPosition);

                                    parameterValues.Add(parameterDiscreteValue);
                                    startPosition = position + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        parameterField = parameterFields[keyValuePair.Key];
                        parameterValues = parameterField.CurrentValues;
                        parameterDiscreteValue = new ParameterDiscreteValue();

                        if (
                            (parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateParameter ||
                            parameterFields[keyValuePair.Key].ParameterValueType == ParameterValueKind.DateTimeParameter)
                            &&
                            (parameterSubText == "up to" || parameterSubText == "and up")
                            )
                        {
                            parameterDiscreteValue.Value = "1/1/1900";
                        }
                        else
                        {
                            parameterDiscreteValue.Value = parameterSubText;
                        }

                        parameterValues.Add(parameterDiscreteValue);
                    }
                }
            }
        }

        public bool IsDuplicateReportName(string reportName)
        {
            return _reporterDA.IsDuplicateFileName(reportName);
        }

        public void CloneReport(string newReportName)
        {
            FileInfo sourceFileInfo = new FileInfo(SelectedReportPath);
            FileInfo destFileInfo = new FileInfo(Path.Combine(sourceFileInfo.DirectoryName, newReportName));

            File.Copy(sourceFileInfo.FullName, destFileInfo.FullName);

            Report report = new Report();
            report.FileName = destFileInfo.Name;
            report.IsClone = true;
            report.ClonedReportID = (SelectedReport.ClonedReportID == 0 ? SelectedReport.ReportID : SelectedReport.ClonedReportID);

            report.ReportID = _reporterDA.InsertReport(report);
        }

        public void SendClonedReportFileToServer(string reportName)
        {
            string localReportPath = Settings.LocalReportFolder + reportName;
            string serverReportPath = Settings.ServerReportFolder + reportName;

            if (Directory.Exists(Settings.LocalReportFolder) && Directory.Exists(Settings.ServerReportFolder))
            {
                if (File.Exists(localReportPath) && !File.Exists(serverReportPath))
                    FileUtility.CopyLocalFileToServer(localReportPath, serverReportPath);
            }
        }

        private bool _disposed = false;

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        public List<ReportWizardDataSource> LoadReportWizardDataSources()
        {
            List<ReportWizardDataSource> reportWizardDataSources;
            reportWizardDataSources = new List<ReportWizardDataSource>();

            reportWizardDataSources = _reporterDA.GetReportWizardDataSources();

            return reportWizardDataSources;
        }

        public ReportWizardDataSource TemplateDataSource { get; set; }
        public List<SelectedField> TemplateSelectedFields { get; set; }
        public List<GroupField> TemplateGroupFields { get; set; }
        public List<string> TemplateFilterStatement { get; set; }

        public void SetTemplateReportPath(int numberOfColumns)
        {
            SelectedReportPath = Settings.LocalReportFolder + "templates\\" + _reporterDA.GetTemplateReportName(numberOfColumns);
        }

        public string GetTemplateSqlStmt()
        {
            string from = TemplateDataSource.ReportWizardDataSourceName;

            int counter = 0;

            string groups = string.Empty;
            string orderBy = string.Empty;
            for (int i = 0; i < TemplateGroupFields.Count; i++)
            {
                GroupField gf = TemplateGroupFields[i];
                counter = i + 1;
                groups = (groups.Length == 0 ? 
                    gf.AvailableFieldName + " AS 'G" + (i+1).ToString() + "_" + gf.ColumnAlias + "'" :
                    groups + ", " + gf.AvailableFieldName + " AS 'G" + (i + 1).ToString() + "_" + gf.ColumnAlias + "'");

                string sort = (gf.SortOrder == SortOrder.Descending ? "DESC" : "ASC");
                orderBy = (orderBy.Length == 0 ? 
                    gf.AvailableFieldName + " " + sort :
                    orderBy + ", " + gf.AvailableFieldName + " " + sort);
            }

            string columns = string.Empty;
            counter = 0;
            for (int i = 0; i < TemplateSelectedFields.Count; i++)
            {
                SelectedField sf = TemplateSelectedFields[i];
                counter = i + 1;
                columns = (columns.Length == 0 ? sf.AvailableFieldName + " AS '" + sf.ColumnAlias + "'" : columns + ", " + sf.AvailableFieldName + " AS '" + sf.ColumnAlias + "'");
            }

            string where = string.Empty;
            foreach (string s in TemplateFilterStatement)
            {
                where = (where.Length == 0 ? s : where + s);
            }

            string sqlStmt;
            if (groups.Length > 0)
            {
                sqlStmt = "SELECT {0}, {1} FROM {2};";
                sqlStmt = string.Format(sqlStmt, groups, columns, from);
            }
            else
            {
                sqlStmt = "SELECT {0} FROM {1};";
                sqlStmt = string.Format(sqlStmt, columns, from);
            }
            if (where.Length > 0)
            {
                sqlStmt = sqlStmt.Replace(';', ' ') + " WHERE {0};";
                sqlStmt = string.Format(sqlStmt, where);
            }
            if (orderBy.Length > 0)
            { 
                sqlStmt = sqlStmt.Replace(';', ' ') + " ORDER BY {0};";
                sqlStmt = string.Format(sqlStmt, orderBy);
            }

            return sqlStmt;
        }
        
        public DataTable GetDataTableFromTemplateSqlStmt()
        {
            return _reporterDA.GetDataTable(GetTemplateSqlStmt());
        }


        ~ReporterBO()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_log != null)
                    _log.Dispose();
            }
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}