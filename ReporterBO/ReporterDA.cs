using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

namespace Reporter
{
    public class ReporterDA
    {
        private Settings _settings;

        internal ReporterDA(Settings settings)
        {
            _settings = settings;
        }

        private string GetConnectionString()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3}", _settings.ServerName, _settings.DatabaseName, _settings.UserID, _settings.Password);
        }

        private void AddSqlParameter(MySqlCommand cmd, string parameterName, MySqlDbType MySqlDbType, object parameterValue)
        {
            MySqlParameter param = cmd.Parameters.Add(parameterName, MySqlDbType);
            param.Value = parameterValue;
        }

        private void AddSqlParameter(MySqlCommand cmd, string parameterName, MySqlDbType MySqlDbType, int size, object parameterValue)
        {
            MySqlParameter param = cmd.Parameters.Add(parameterName, MySqlDbType, size);
            param.Value = parameterValue;
        }

        internal Report GetReportByFileName(string fileName)
        {
            Report report = new Report();

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("usp_GetReportByFileName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iFileName", MySqlDbType.VarChar, 8000, Path.GetFileName(fileName));
                
                connection.Open();
                dr = cmd.ExecuteReader();
                cmd.Dispose();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        report.ReportID = (int)dr["ReportID"];
                        report.FileName = dr["FileName"].ToString();
                        report.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        report.IsClone = Convert.ToBoolean(dr["IsClone"]);
                        report.IsCustom = Convert.ToBoolean(dr["IsCustom"]);
                        report.Override = Convert.ToBoolean(dr["Override"]);
                        report.ClonedReportID = (int)dr["ClonedReportID"];
                        break;
                    }
                }
                else
                { 
                    Report newReport = new Report();
                    newReport.FileName = fileName;
                    newReport.IsActive = true;
                    
                    newReport.ReportID = InsertReport(newReport);
                    report = GetReportByFileName(fileName);
                }
            }

            return report;
        }

        internal List<ParameterSet> GetParameterSetsByReportID(int reportID)
        {
            List<ParameterSet> parameterSets = new List<ParameterSet>();

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("usp_GetParameterSetsByReportID", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iReportID", MySqlDbType.Int32, reportID);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ParameterSet parameterSet = new ParameterSet();

                    parameterSet.ParameterSetID = (int)dr["ParameterSetID"];
                    parameterSet.ReportID = (int)dr["ReportID"];
                    parameterSet.ParameterSetName = dr["ParameterSetName"].ToString();
                    parameterSet.ParameterSetDescription = dr["ParameterSetDescription"].ToString();

                    parameterSet.Parameters = GetParametersByParameterSetID(parameterSet.ParameterSetID);

                    parameterSets.Add(parameterSet);
                }
                cmd.Dispose();
            }

            return parameterSets;
        }

        internal ParameterSet GetParameterSetByReportIDParameterSetName(int reportID, string parameterSetName)
        {
            ParameterSet parameterSet = new ParameterSet();

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("usp_GetParameterSetByReportIDParameterSetName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iReportID", MySqlDbType.Int32, reportID);
                AddSqlParameter(cmd, "iParameterSetName", MySqlDbType.VarChar, 45, parameterSetName);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    parameterSet.ParameterSetID = (int)dr["ParameterSetID"];
                    parameterSet.ReportID = (int)dr["ReportID"];
                    parameterSet.ParameterSetName = dr["ParameterSetName"].ToString();
                    parameterSet.ParameterSetDescription = dr["ParameterSetDescription"].ToString();

                    parameterSet.Parameters = GetParametersByParameterSetID(parameterSet.ParameterSetID);

                    break;
                }
                cmd.Dispose();
            }
            return parameterSet;
        }

        internal List<Parameter> GetParametersByParameterSetID(int parameterSetID)
        {
            List<Parameter> parameters = new List<Parameter>();

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("usp_GetParametersByParameterSetID", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iParameterSetID", MySqlDbType.Int32, parameterSetID);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Parameter parameter = new Parameter();
                    parameter.ParameterID = (int)dr["ParameterID"];
                    parameter.ParameterSetID = (int)dr["ParameterSetID"];
                    parameter.ParameterName = dr["ParameterName"].ToString();
                    parameter.ParameterValue = dr["ParameterValue"].ToString();

                    parameters.Add(parameter);
                }
                cmd.Dispose();
            }

            return parameters;
        }

        internal List<ReportWizardDataSource> GetReportWizardDataSources()
        {
            List<ReportWizardDataSource> reportWizardDataSources = new List<ReportWizardDataSource>();
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("usp_GetReportWizardDataSources", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ReportWizardDataSource reportWizardDataSource = new ReportWizardDataSource();
                    reportWizardDataSource.ReportWizardDataSourceID = (int)dr["ReportWizardDataSourceID"];
                    reportWizardDataSource.ReportWizardDataSourceName = dr["ReportWizardDataSourceName"].ToString();
                    reportWizardDataSource.ReportWizardDataSourceDescription = dr["ReportWizardDataSourceDescription"].ToString();
                    reportWizardDataSource.AvailableFields = GetAvailableFields(dr["ReportWizardDataSourceName"].ToString());

                    reportWizardDataSources.Add(reportWizardDataSource);
                }
                cmd.Dispose();
            }

            return reportWizardDataSources;
        }

        internal List<AvailableField> GetAvailableFields(string reportWizardDataSourceName)
        {
            List<AvailableField> availableFields = new List<AvailableField>();
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("usp_GetAvailableFieldsByReportWizardDataSourceName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iReportWizardDataSourceName", MySqlDbType.String, reportWizardDataSourceName);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    AvailableField availableField = new AvailableField();
                    availableField.AvailableFieldName = dr["AvailableFieldName"].ToString();
                    
                    availableFields.Add(availableField);
                }
                cmd.Dispose();
            }

            return availableFields;
        }

        internal string GetTemplateReportName(int numberOfColumns)
        {
            string reportName = string.Empty;
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand("usp_GetTemplateReportName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iNumberOfColumns", MySqlDbType.Int32, numberOfColumns);

                connection.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    reportName = dr["ReportName"].ToString();
                    break;
                }
                cmd.Dispose();
            }

            return reportName;
        }

        internal int InsertReport(Report report)
        {
            int reportID = 0;

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_InsertReport", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iFileName", MySqlDbType.VarChar, 4000, report.FileName);
                AddSqlParameter(cmd, "iIsActive", MySqlDbType.Bit, report.IsActive);
                AddSqlParameter(cmd, "iIsClone", MySqlDbType.Bit, report.IsClone);
                AddSqlParameter(cmd, "iIsCustom", MySqlDbType.Bit, report.IsCustom);
                AddSqlParameter(cmd, "iOverride", MySqlDbType.Bit, report.Override);
                AddSqlParameter(cmd, "iClonedReportID", MySqlDbType.Int32, report.ClonedReportID);

                connection.Open();

                reportID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            return reportID;
        }

        internal ParameterSet InsertParameterSet(ParameterSet parameterSet)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_InsertParameterSet", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iReportID", MySqlDbType.Int32, parameterSet.ReportID);
                AddSqlParameter(cmd, "iParameterSetName", MySqlDbType.VarChar, 4000, parameterSet.ParameterSetName);
                AddSqlParameter(cmd, "iParameterSetDescription", MySqlDbType.VarChar, 4000, parameterSet.ParameterSetDescription);

                connection.Open();

                parameterSet.ParameterSetID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            for (int i = 0; i < parameterSet.Parameters.Count; i++)
            {
                parameterSet.Parameters[i].ParameterSetID = parameterSet.ParameterSetID;
                parameterSet.Parameters[i] = InsertParameter(parameterSet.Parameters[i]);
            }
           
            return parameterSet;
        }

        internal Parameter InsertParameter(Parameter parameter)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_InsertParameter", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iParameterSetID", MySqlDbType.Int32, parameter.ParameterSetID);
                AddSqlParameter(cmd, "iParameterName", MySqlDbType.VarChar, 4000, parameter.ParameterName);
                AddSqlParameter(cmd, "iParameterValue", MySqlDbType.VarChar, 4000, parameter.ParameterValue);

                connection.Open();

                parameter.ParameterID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            return parameter;
        }

        internal Report UpdateReport(Report report)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_UpdateReport", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iReportID", MySqlDbType.Int32, report.ReportID);
                AddSqlParameter(cmd, "iFileName", MySqlDbType.VarChar, 4000, report.FileName);
                AddSqlParameter(cmd, "iIsActive", MySqlDbType.Bit, report.IsActive);
                AddSqlParameter(cmd, "iIsClone", MySqlDbType.Bit, report.IsClone);
                AddSqlParameter(cmd, "iIsCustom", MySqlDbType.Bit, report.IsCustom);
                AddSqlParameter(cmd, "iOverride", MySqlDbType.Bit, report.Override);
                AddSqlParameter(cmd, "iClonedReportID", MySqlDbType.Int32, report.ClonedReportID);

                connection.Open();

                cmd.ExecuteScalar();
                cmd.Dispose();
            }
            return report;
        }

        internal ParameterSet UpdateParameterSet(ParameterSet parameterSet)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_UpdateParameterSet", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iParameterSetID", MySqlDbType.Int32, parameterSet.ParameterSetID);
                AddSqlParameter(cmd, "iReportID", MySqlDbType.Int32, parameterSet.ReportID);
                AddSqlParameter(cmd, "iParameterSetName", MySqlDbType.VarChar, 4000, parameterSet.ParameterSetName);
                AddSqlParameter(cmd, "iParameterSetDescription", MySqlDbType.VarChar, 4000, parameterSet.ParameterSetDescription);

                connection.Open();

                cmd.ExecuteScalar();
                cmd.Dispose();
            }
            for (int i = 0; i < parameterSet.Parameters.Count; i++)
            {
                parameterSet.Parameters[i].ParameterSetID = parameterSet.ParameterSetID;
                if (parameterSet.Parameters[i].ParameterID == 0)
                    parameterSet.Parameters[i] = InsertParameter(parameterSet.Parameters[i]);
                else
                    parameterSet.Parameters[i] = UpdateParameter(parameterSet.Parameters[i]);

            }

            return parameterSet;
        }

        internal Parameter UpdateParameter(Parameter parameter)
        {
            int result = 0;

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_UpdateParameter", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iParameterID", MySqlDbType.Int32, parameter.ParameterID);
                AddSqlParameter(cmd, "iParameterSetID", MySqlDbType.Int32, parameter.ParameterSetID);
                AddSqlParameter(cmd, "iParameterName", MySqlDbType.VarChar, 4000, parameter.ParameterName);
                AddSqlParameter(cmd, "iParameterValue", MySqlDbType.VarChar, 4000, parameter.ParameterValue);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
            return parameter;
        }

        internal void DeleteReport(Report report)
        {
            int result = 0;

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_DeleteReport", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iReportID", MySqlDbType.Int32, report.ReportID);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
        }

        internal void DeleteParameterSet(ParameterSet parameterSet)
        {
            int result = 0;

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_DeleteParameterSet", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iParameterSetID", MySqlDbType.Int32, parameterSet.ParameterSetID);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
        }

        internal void DeleteParameter(Parameter parameter)
        {
            int result = 0;

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_DeleteParameter", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iParameterID", MySqlDbType.Int32, parameter.ParameterID);

                connection.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
            }
        }

        internal bool IsDuplicateFileName(string fileName)
        {
            bool result = false;

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand cmd = new MySqlCommand("usp_IsDuplicateFileName", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                AddSqlParameter(cmd, "iFileName", MySqlDbType.VarChar, 4000, fileName);

                connection.Open();

                result = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.Dispose();
            }

            return result;
        }

        internal DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                MySqlDataReader dr = null;

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;

                connection.Open();
                dr = cmd.ExecuteReader();

                dt.Columns.Clear();
                DataTable schema = dr.GetSchemaTable();
                foreach (DataRowView row in schema.DefaultView)
                {
                    string columnName = (string)row["ColumnName"];
                    Type type = (Type)row["DataType"];
                    dt.Columns.Add(columnName, type);
                }

                dt.Load(dr);

                cmd.Dispose();
            }

            return dt;
        }
    }
}
