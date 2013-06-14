using System.Collections.Generic;

namespace Reporter
{
    public class Report 
    {
        public Report()
        {
            ReportID = 0;
            FileName = string.Empty;
            IsActive = false;
            IsClone = false;
            IsCustom = false;
            Override = false;
            ClonedReportID = 0;
        }
        public int ReportID { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
        public bool IsClone { get; set; }
        public bool IsCustom { get; set; }
        public bool Override { get; set; }
        public int ClonedReportID { get; set; }
    }

    public class ParameterSet 
    {
        public ParameterSet()
        {
            ParameterSetID = 0;
            Parameters = new List<Parameter>();
        }
        public int ParameterSetID { get; set; }
        public int ReportID { get; set; }
        public string ParameterSetName { get; set; }
        public string ParameterSetDescription { get; set; }
        public List<Parameter> Parameters { get; set; }
    }

    public class Parameter 
    {
        public Parameter() { ParameterID = 0; }
        public int ParameterID { get; set; }
        public int ParameterSetID { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
    }

    public class ReportWizardDataSource
    {
        public ReportWizardDataSource() { ReportWizardDataSourceID = 0; }
        public int ReportWizardDataSourceID { get; set; }
        public string ReportWizardDataSourceName { get; set; }
        public string ReportWizardDataSourceDescription { get; set; }
        public List<AvailableField> AvailableFields { get; set; }
    }

    public class AvailableField
    {
        public AvailableField() { }
        public string AvailableFieldName { get; set; }
    }

    public class SelectedField
    {
        public SelectedField() { }
        public SelectedField(AvailableField availableField) 
        { 
            AvailableField = availableField;
            AvailableFieldName = availableField.AvailableFieldName;
            ColumnAlias = availableField.AvailableFieldName;
        }
        private AvailableField AvailableField { get; set; }
        public string AvailableFieldName { get; set; }
        public string ColumnAlias { get; set; }
    }

    public enum SortOrder 
    { 
        Ascending, 
        Descending,
        None
    }

    public class GroupField 
    {
        public GroupField() { }
        public GroupField(AvailableField availableField)
        {
            AvailableField = availableField;
            AvailableFieldName = availableField.AvailableFieldName;
            ColumnAlias = availableField.AvailableFieldName;
        }
        private AvailableField AvailableField { get; set; }
        public string AvailableFieldName { get; set; }
        public string ColumnAlias { get; set; }
        public SortOrder SortOrder { get; set; }
        public string AvailableFieldNameWithSortOrder { get { return AvailableField.AvailableFieldName + " - " + (SortOrder == SortOrder.Ascending ? "A" : "D"); } }
    }
}