using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Reporter
{
    public partial class ReportViewer : ReporterBase
    {
        private ReportDocument _reportDocument;
        private string _reportPath;
        private ReporterBO _reporterBO;
        
        public bool TemplateBased { get; set; }

        public ReportViewer(ReporterBO reporterBO)
        {
            InitializeComponent();

            _reporterBO = reporterBO;
            _reportPath = reporterBO.SelectedReportPath;

            this.Text = base.Title + " - Report Viewer";
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                _reportDocument = new ReportDocument();
                _reportDocument.Load(_reportPath);
                _reporterBO.SetCrystalReportLogon(_reportDocument);

                if (TemplateBased)
                {
                    System.Data.DataTable dt = _reporterBO.GetDataTableFromTemplateSqlStmt();

                    _reportDocument.Database.Tables["Command"].SetDataSource(dt);
                    _reportDocument.VerifyDatabase();

                    string groups = string.Empty;
                    for (int i = 0; i < _reporterBO.TemplateGroupFields.Count; i++)
                    {
                        //assign the GroupFields from the form to the Grp1, Grp2, etc formulas in the report
                        _reportDocument.DataDefinition.FormulaFields["Grp" + (i + 1).ToString()].Text = "{Command.G" + (i+1).ToString() + "_" + _reporterBO.TemplateGroupFields[i].ColumnAlias + "}";
                        _reportDocument.DataDefinition.FormulaFields["Grp" + (i + 1).ToString() + "Title"].Text = string.Format("'G{0}_{1}'",(i+1).ToString(),_reporterBO.TemplateGroupFields[i].ColumnAlias);

                        //assign the GroupFields from the form to the Group Conditions in the report
                        //DatabaseFieldDefinition dfd = _reportDocument.Database.Tables["Command"].Fields[string.Format("G{0}_{1}", (i + 1).ToString(), _reporterBO.TemplateGroupFields[i].ColumnAlias)];
                        //_reportDocument.DataDefinition.Groups[i].ConditionField = dfd; 
                        
                        //assign the GroupFields from the form to the Wizard Selection | Groups formula in the report
                        if (groups == string.Empty)
                            groups = _reporterBO.TemplateGroupFields[i].ColumnAlias;
                        else
                            groups = groups + ", " + _reporterBO.TemplateGroupFields[i].ColumnAlias;
                    }
                    _reportDocument.DataDefinition.FormulaFields["Groups"].Text = string.Format("'{0}'", groups);

                    string selectedFields = string.Empty;
                    for (int i = 0; i < _reporterBO.TemplateSelectedFields.Count; i++)
                    {
                        //assign the SelectedFields from the form to the Col1, Col2, etc formulas in the report
                        _reportDocument.DataDefinition.FormulaFields["Col" + (i + 1).ToString()].Text = "{Command." + _reporterBO.TemplateSelectedFields[i].ColumnAlias + "}";
                        _reportDocument.DataDefinition.FormulaFields["Col" + (i + 1).ToString() + "Title"].Text = string.Format("'{0}'",_reporterBO.TemplateSelectedFields[i].ColumnAlias);

                        //assign the SelectedFields from the form to the Wizard Selection | SelectedFields formula in the report
                        if (selectedFields == string.Empty)
                            selectedFields = _reporterBO.TemplateSelectedFields[i].ColumnAlias;
                        else
                            selectedFields = selectedFields + ", " + _reporterBO.TemplateSelectedFields[i].ColumnAlias;
                    }
                    _reportDocument.DataDefinition.FormulaFields["SelectedFields"].Text = string.Format("'{0}'", selectedFields);

                    string filters = string.Empty;
                    string filtersFormula = string.Empty;
                    for (int i = 0; i < _reporterBO.TemplateFilterStatement.Count; i++)
                    {
                        //assign the FilterStatement from the form to the Wizard Selection | Filters formula in the report
                        if (filters == string.Empty)
                            filters = _reporterBO.TemplateFilterStatement[i];
                        else
                            filters = filters + ", " + _reporterBO.TemplateFilterStatement[i];

                        if (filtersFormula == string.Empty)
                            filtersFormula = _reporterBO.TemplateFilterStatement[i];
                        else
                            filtersFormula = filters + ", " + _reporterBO.TemplateFilterStatement[i];
                    }
                    _reportDocument.DataDefinition.FormulaFields["Filters"].Text = string.Format("'{0}'", filters);
                    _reportDocument.DataDefinition.RecordSelectionFormula = filtersFormula;

                    _reportDocument.DataDefinition.FormulaFields["Datasource"].Text = string.Format("'{0}'", _reporterBO.TemplateDataSource.ReportWizardDataSourceName);
                }
                else
                {
                    if (_reporterBO.HasParameterSetNameArg)
                        _reporterBO.CreateParameterCollection(_reportDocument.ParameterFields);
                    else
                        GetParametersFromUser();
                }

                //LeftAlignDetailsReportObjects();

                this.crystalReportViewer.ReportSource = _reportDocument;
            }
            catch (Exception ex)
            {
                _reporterBO.Log(ex.ToString());
            }
        }

        private void LeftAlignDetailsReportObjects()
        {
            foreach (Area area in _reportDocument.ReportDefinition.Areas)
            {
                Sections sections = area.Sections;
                for (int i = 0; i < sections.Count; i++)
                {
                    Section section = sections[i];
                    if (section.Kind == AreaSectionKind.Detail && section.SectionFormat.EnableSuppressIfBlank == false)
                    {
                        ReportObjects reportObjects = section.ReportObjects;

                        for (int j = 0; j < reportObjects.Count; j++)
                        {
                            ReportObject reportObject = reportObjects[j];
                            reportObject.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
                        }
                    }
                }
            }
        }
        
        
        private void GetParametersFromUser()
        {
            if (_reportDocument.ParameterFields.Count > 0)
            {
                ReportParameterSelector form = new ReportParameterSelector(_reportDocument, _reporterBO);
                form.ShowDialog(this);
                form.Dispose();
            }
        }
    }
}
