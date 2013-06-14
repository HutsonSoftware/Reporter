using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reporter
{
    public partial class ReportGenerator : ReporterBase
    {
        private ReporterBO _reporterBO;
        private List<ReportWizardDataSource> _reportWizardDataSources;
        private bool _loading;

        public ReportGenerator(ReporterBO reporterBO)
        {
            InitializeComponent();
            
            _reporterBO = reporterBO;
            _reportWizardDataSources = new List<ReportWizardDataSource>();

            this.Text = base.Title + " - Report Wizard";

            LoadCombos();
            
        }

        private void LoadCombos()
        {
            _loading = true;

            ClearAll();

            _reportWizardDataSources = _reporterBO.LoadReportWizardDataSources();
            
            cboAvailDataSources.DataSource = _reportWizardDataSources;
            cboAvailDataSources.DisplayMember = "ReportWizardDataSourceName";
            cboAvailDataSources.SelectedIndex = -1;

            cboOperator.Items.Add("Equal To (= )");
            cboOperator.Items.Add("Not Equal To (<>)");
            cboOperator.Items.Add("Greater Than or Equal To (>=)");
            cboOperator.Items.Add("Greater Than (> )");
            cboOperator.Items.Add("Less Than or Equal To (<=)");
            cboOperator.Items.Add("Less Than (< )");
            cboOperator.SelectedIndex = -1;
            cboOperator.Enabled = false;

            btnAddSelectedField.Enabled = (lstAvailFields.Items.Count > 0 ? true : false);
            btnAddGroup.Enabled = (lstAvailFields.Items.Count > 0 ? true : false);

            ResetFilterControls();

            _loading = false;
        }

        private void cboAvailDataSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                _loading = true;

                ClearAll();

                ReportWizardDataSource reportWizardDataSource;
                reportWizardDataSource = (ReportWizardDataSource)cboAvailDataSources.SelectedItem;
                txtDataSourceDesc.Text = reportWizardDataSource.ReportWizardDataSourceDescription;
                
                lstAvailFields.DataSource = reportWizardDataSource.AvailableFields;
                lstAvailFields.DisplayMember = "AvailableFieldName";

                foreach (AvailableField availableField in reportWizardDataSource.AvailableFields)
                {
                    cboAvailFilters.Items.Add(availableField);
                    cboFilterFields.Items.Add(availableField);
                }

                btnAddSelectedField.Enabled = (lstAvailFields.Items.Count > 0 ? true : false);
                btnAddGroup.Enabled = (lstAvailFields.Items.Count > 0 ? true : false);

                ResetFilterControls();

                btnAddFilter.Enabled = false;
                btnRemoveFilter.Enabled = false;
               
                _loading = false;
            }
        }

        private void ResetFilterControls()
        {
            cboAvailFilters.DisplayMember = "AvailableFieldName";
            cboAvailFilters.Enabled = (lstAvailFields.Items.Count > 0 ? true : false);
            cboAvailFilters.SelectedIndex = -1;
            
            cboOperator.Enabled = false;
            cboOperator.SelectedIndex = -1;

            cboFilterFields.DisplayMember = "AvailableFieldName";
            cboFilterFields.Enabled = false;

            optValue.Checked = false;
            optValue.Enabled = false;

            txtFilterValue.Text = string.Empty;
            txtFilterValue.Enabled = false;

            optField.Checked = false;
            optField.Enabled = false;

            btnAddFilter.Enabled = false;
            btnRemoveFilter.Enabled = false;

            optAND.Checked = false;
            optAND.Enabled = false;

            optOR.Checked = false;
            optOR.Enabled = false;
        }

        private void ClearAll()
        {
            ClearAvailableFields();
            ClearSelectedFields();
            ClearGroupFields();
            ClearAvailFilters();
        }

        private void ClearAvailableFields()
        {
            lstAvailFields.DataSource = null;
            lstAvailFields.Items.Clear();
        }
        
        private void ClearSelectedFields()
        {
            lstSelectedFields.Items.Clear();
            txtSelectedFieldColumnAlias.Text = string.Empty;
            txtSelectedFieldColumnAlias.Enabled = false;
            btnRemoveSelectedField.Enabled = false;
        }

        private void ClearGroupFields()
        {
            lstGroups.Items.Clear();
            txtGroupsColumnAlias.Text = string.Empty;
            txtGroupsColumnAlias.Enabled = false;
            SetSortOrderOption(SortOrder.None);
            optAscending.Enabled = false;
            optDescending.Enabled = false;
            btnRemoveGroup.Enabled = false;
        }

        private void ClearAvailFilters()
        {
            cboAvailFilters.Items.Clear();
            cboAvailFilters.SelectedIndex = -1;
            
            cboOperator.SelectedIndex = -1;
            cboOperator.Enabled = false;            
        }
        

        private void btnAddSelectedField_Click(object sender, EventArgs e)
        {
            if (!_loading && lstAvailFields.Items.Count > 0 && lstAvailFields.SelectedIndex >= 0 && lstSelectedFields.Items.Count < 8)
            {
                _loading = true;
                SelectedField selectedField = new SelectedField((AvailableField)lstAvailFields.SelectedItem);

                for (int i = 0; i < lstSelectedFields.Items.Count; i++)
                {
                    if (((SelectedField)lstSelectedFields.Items[i]).ColumnAlias == selectedField.ColumnAlias)
                    {
                        selectedField.ColumnAlias = selectedField.ColumnAlias + "_1";
                        break;
                    }
                }

                lstSelectedFields.Items.Add(selectedField);
                lstSelectedFields.SelectedIndex = lstSelectedFields.Items.Count - 1;
                lstSelectedFields.DisplayMember = "AvailableFieldName";
                
                txtSelectedFieldColumnAlias.Enabled = true;
                txtSelectedFieldColumnAlias.Text = selectedField.ColumnAlias;

                btnRemoveSelectedField.Enabled = (lstSelectedFields.Items.Count > 0 ? true : false);

                if (lstAvailFields.SelectedIndex + 1 == lstAvailFields.Items.Count)
                    lstAvailFields.SelectedIndex = 0;
                else
                    lstAvailFields.SelectedIndex++;
                
                _loading = false;
            }
        }

        private void btnRemoveSelectedField_Click(object sender, EventArgs e)
        {
            if (!_loading && lstSelectedFields.Items.Count > 0 && lstSelectedFields.SelectedIndex >= 0)
            {
                _loading = true;
                int selectedIndex = lstSelectedFields.SelectedIndex;
                lstSelectedFields.Items.RemoveAt(selectedIndex);
                lstSelectedFields.SelectedIndex = Math.Min(selectedIndex, lstSelectedFields.Items.Count - 1);
                if (lstSelectedFields.Items.Count == 0) { ClearSelectedFields(); }
                _loading = false;
            }
        }

        private void lstSelectedFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading && lstSelectedFields.Items.Count > 0 && lstSelectedFields.SelectedIndex >= 0)
            {
                SelectedField selectedField = (SelectedField)lstSelectedFields.SelectedItem;
                txtSelectedFieldColumnAlias.Text = selectedField.ColumnAlias;
            }
        }

        private void txtSelectedFieldColumnAlias_TextChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                ((SelectedField)lstSelectedFields.SelectedItem).ColumnAlias = txtSelectedFieldColumnAlias.Text;
            }
        }

        private void txtGroupsColumnAlias_TextChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                ((GroupField)lstGroups.SelectedItem).ColumnAlias = txtGroupsColumnAlias.Text;
            }
        } 

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (!_loading && lstAvailFields.Items.Count > 0 && lstAvailFields.SelectedIndex >= 0 && lstGroups.Items.Count < 3)
            {
                _loading = true;
                GroupField groupField = new GroupField((AvailableField)lstAvailFields.SelectedItem);
                groupField.SortOrder = SortOrder.Ascending;
                lstGroups.Items.Add(groupField);
                lstGroups.SelectedIndex = lstGroups.Items.Count - 1;
                lstGroups.DisplayMember = "AvailableFieldNameWithSortOrder";

                txtGroupsColumnAlias.Enabled = true;
                txtGroupsColumnAlias.Text = groupField.ColumnAlias;

                optAscending.Enabled = (lstGroups.Items.Count > 0 ? true : false);
                optDescending.Enabled = (lstGroups.Items.Count > 0 ? true : false);
                btnRemoveGroup.Enabled = (lstGroups.Items.Count > 0 ? true : false);
                
                SetSortOrderOption(groupField.SortOrder);

                if (lstAvailFields.SelectedIndex + 1 == lstAvailFields.Items.Count)
                    lstAvailFields.SelectedIndex = 0;
                else
                    lstAvailFields.SelectedIndex++;

                _loading = false;
            }
        }

        private void SetSortOrderOption(SortOrder sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    optAscending.Checked = true;
                    optDescending.Checked = false;
                    break;
                case SortOrder.Descending:
                    optAscending.Checked = false;
                    optDescending.Checked = true;
                    break;
                default:
                    optAscending.Checked = false;
                    optDescending.Checked = false;
                    break;
            }
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (!_loading && lstGroups.Items.Count > 0 && lstGroups.SelectedIndex >= 0)
            {
                _loading = true;
                int selectedIndex = lstGroups.SelectedIndex;
                lstGroups.Items.RemoveAt(selectedIndex);
                lstGroups.SelectedIndex = Math.Min(selectedIndex, lstGroups.Items.Count - 1);
                if (lstGroups.Items.Count == 0) { ClearGroupFields(); }
                _loading = false;
            }
        }

        private void lstGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading && lstGroups.Items.Count > 0 && lstGroups.SelectedIndex >= 0)
            {
                _loading = true;
                GroupField groupField = (GroupField)lstGroups.SelectedItem;
                txtGroupsColumnAlias.Text = groupField.ColumnAlias;
                SetSortOrderOption(groupField.SortOrder);
                _loading = false;
            }
        }

        private void optAscending_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loading && optAscending.Checked == true)
            {
                ((GroupField)lstGroups.SelectedItem).SortOrder = SortOrder.Ascending;
                lstGroups.DisplayMember = "";
                lstGroups.DisplayMember = "AvailableFieldNameWithSortOrder";
            }
        }

        private void optDescending_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loading && optDescending.Checked == true)
            {
                ((GroupField)lstGroups.SelectedItem).SortOrder = SortOrder.Descending;
                lstGroups.DisplayMember = "";
                lstGroups.DisplayMember = "AvailableFieldNameWithSortOrder";
            }
        }

        private void cboAvailFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading && cboAvailFilters.Items.Count > 0 && cboAvailFilters.SelectedIndex >= 0)
            {
                cboOperator.Enabled = true;
            }
        }

        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            optValue.Enabled = (cboOperator.SelectedIndex >= 0 ? true : false);
            optValue.Checked = (cboOperator.SelectedIndex >= 0 ? true : false);
            optField.Enabled = (cboOperator.SelectedIndex >= 0 ? true : false);
        }

        private void optValue_CheckedChanged(object sender, EventArgs e)
        {
            txtFilterValue.Enabled = optValue.Checked;
            if (optValue.Checked == false) txtFilterValue.Text = string.Empty;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            btnAddFilter.Enabled = (txtFilterValue.Text == string.Empty ? false : true);
            SetJoinOptions();
        }

        private void SetJoinOptions()
        {
            if (lstFilterStatement.Items.Count > 0)
            {
                optAND.Enabled = true;
                optAND.Checked = true;
                optOR.Enabled = true;
            }
        }

        private void optField_CheckedChanged(object sender, EventArgs e)
        {
            cboFilterFields.Enabled = optField.Checked;
            if (optField.Checked == false) cboFilterFields.SelectedIndex = -1;
        }

        private void cboFilterFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddFilter.Enabled = (cboFilterFields.SelectedIndex >= 0 ? true : false);
            SetJoinOptions();
        }

        private void lstFilterStatement_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveFilter.Enabled = (lstFilterStatement.SelectedIndex > -1 ? true : false);
        } 

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            AvailableField availableField;

            availableField = (AvailableField)cboAvailFilters.SelectedItem;
            string filterField = availableField.AvailableFieldName;
            filterField = "{Command." + filterField + "}";
            
            string filterOperator = cboOperator.SelectedItem.ToString();
            filterOperator = filterOperator.Substring(filterOperator.IndexOf("(") + 1, 2).TrimEnd();
            
            string filterEquivalent;
            if (optValue.Checked == true)
                filterEquivalent = txtFilterValue.Text; 
            else
            {
                availableField = (AvailableField)cboFilterFields.SelectedItem;
                filterEquivalent = availableField.AvailableFieldName;
            }
            
            double num;
            bool isNum = double.TryParse(filterEquivalent, out num);
            if (!isNum)
                filterEquivalent = "'" + filterEquivalent + "'";

            string filter;
            if (optAND.Enabled)
                filter = string.Format("{0} {1} {2} {3}", (optAND.Checked ? "AND" : "OR"), filterField, filterOperator, filterEquivalent);
            else
                filter = string.Format("{0} {1} {2}", filterField, filterOperator, filterEquivalent);

            lstFilterStatement.Items.Add(filter);

            ResetFilterControls();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            lstFilterStatement.Items.RemoveAt(lstFilterStatement.SelectedIndex);
            btnRemoveFilter.Enabled = (lstFilterStatement.SelectedIndex > -1 ? true : false);
            RemoveAndOrInFirstItem();
        }

        private void RemoveAndOrInFirstItem()
        {
            if (lstFilterStatement.Items.Count > 0)
            {
                string filter = lstFilterStatement.Items[0].ToString();
                string newFilter = filter;

                if (newFilter.StartsWith("AND")) newFilter = newFilter.Replace("AND ", "");
                else if (newFilter.StartsWith("OR ")) newFilter = newFilter.Replace("OR ", "");

                if (filter != newFilter)
                { 
                    //re-add all the filters
                    List<string> filters = new List<string>();
                    for (int i = 0; i < lstFilterStatement.Items.Count ; i++)
                    {
                        filters.Add(lstFilterStatement.Items[i].ToString());
                    }
                    lstFilterStatement.Items.Clear();
                    for (int i = 0; i < filters.Count; i++)
                    {
                        if (i == 0) lstFilterStatement.Items.Add(newFilter);
                        else lstFilterStatement.Items.Add(filters[i]);
                    }
                }
            }
        }

        private void btnPreviewReport_Click(object sender, EventArgs e)
        {
            if (!_loading && cboAvailDataSources.SelectedIndex >= 0 && lstSelectedFields.Items.Count > 0)
            {
                ReportWizardDataSource dataSource = (ReportWizardDataSource)cboAvailDataSources.SelectedItem;

                List<SelectedField> selectedFields = new List<SelectedField>();
                foreach (SelectedField sf in lstSelectedFields.Items)
                {
                    selectedFields.Add(sf);
                }

                List<GroupField> groupFields = new List<GroupField>();
                foreach (GroupField gf in lstGroups.Items)
                {
                    groupFields.Add(gf);
                }
                
                List<string> filterStatements = new List<string>();
                foreach(string s in lstFilterStatement.Items)
                {
                    filterStatements.Add(s);
                }

                ReportViewer rv = null;
                try
                {
                    this.UseWaitCursor = true;

                    _reporterBO.TemplateDataSource = dataSource;
                    _reporterBO.TemplateSelectedFields = selectedFields;
                    _reporterBO.TemplateGroupFields = groupFields;
                    _reporterBO.TemplateFilterStatement = filterStatements;
                    _reporterBO.SetTemplateReportPath(selectedFields.Count);

                    rv = new ReportViewer(_reporterBO);
                    rv.TemplateBased = true;
                    rv.ShowDialog(this);
                    
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!_loading)
            {

            }
        }      
    }
}
