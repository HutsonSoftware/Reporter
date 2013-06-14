using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Reporter
{
    public partial class ReportParameterSelector : ReporterBase
    {
        private ReportDocument _reportDocument;
        private ParameterFields _parameterFields;
        private ReporterBO _reporterBO;
        private List<ParameterSet> _parameterSets;
        private bool _loadingData = false;
        private bool _saveNeeded = false;
        private bool _newParameterSet = false;

        public ReportParameterSelector(ReportDocument reportDocument, ReporterBO reporterBO)
        {
            InitializeComponent();

            this.Text = base.Title + " - Report Parameters";

            _reportDocument = reportDocument;
            _parameterFields = reportDocument.ParameterFields;
            _reporterBO = reporterBO;
        }

        private void ReportParameterSelector_Load(object sender, EventArgs e)
        {
            LoadData();
            DisableControls();
            lvwParameters.Items[0].Selected = true;

            _parameterSets = new List<ParameterSet>(_reporterBO.AvailableParameterSets);
             DisplayParameterSets();
        }

        private void LoadData()
        {
            _loadingData = true;

            string value = string.Empty;

            foreach (ParameterField parameterField in _parameterFields)
            {
                if (parameterField.ParameterValueType == ParameterValueKind.DateParameter)
                {
                    if (parameterField.PromptingType == DiscreteOrRangeKind.RangeValue)
                    {
                        DateTime today = DateTime.Today;
                        value = today.ToShortDateString() + " - " + today.ToShortDateString();
                        dtpFromDate.Value = today;
                        dtpToDate.Value = today;
                    }
                    else if (parameterField.PromptingType == DiscreteOrRangeKind.DiscreteValue)
                    {
                        DateTime today = DateTime.Today;
                        value = today.ToShortDateString();
                        dtpFromDate.Value = today;
                    }
                }
                else if (parameterField.ParameterValueType == ParameterValueKind.DateTimeParameter)
                {
                    if (parameterField.PromptingType == DiscreteOrRangeKind.RangeValue)
                    {
                        DateTime today = DateTime.Today;
                        value = string.Format("{0} {1} - {2} {3}", today.ToShortDateString(), today.ToShortTimeString(), today.ToShortDateString(), today.ToShortTimeString());
                        dtpFromDate.Value = today;
                        dtpFromTime.Value = today;
                        dtpToDate.Value = today;
                        dtpToTime.Value = today;
                    }
                    else if (parameterField.PromptingType == DiscreteOrRangeKind.DiscreteValue)
                    {
                        DateTime today = DateTime.Today;
                        value = string.Format("{0} {1}", today.ToShortDateString(), today.ToShortTimeString());
                        dtpFromDate.Value = today;
                        dtpFromTime.Value = today;
                    }
                }
                else
                {
                    if (parameterField.DefaultValues.Count > 0)
                    {
                        CrystalDecisions.Shared.ParameterValue parameterValue = parameterField.DefaultValues[0];
                        value = parameterValue.ToString();
                    }
                    else
                    {
                        value = string.Empty;
                    }
                }

                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = parameterField.Name;
                listViewItem.SubItems.Add(value);
                lvwParameters.Items.Add(listViewItem);
            }

            _loadingData = false;
            AdjustColumnWidth("Parameters");
        }

        private void DisableControls()
        {
            dtpFromDate.Visible = false;
            dtpFromTime.Visible = false;
            dtpToDate.Visible = false;
            dtpToTime.Visible = false;
            cboValue.Visible = false;
            txtValue.Visible = false;
        }

        private void btnApplyChange_Click(object sender, EventArgs e)
        {
            SaveChanges();
            lvwParameters.Focus();
        }

        private void SaveChanges()
        {
            int selectedIndex = -1;

            for (int i = 0; i < lvwParameters.Items.Count; i++)
            {
                if (lvwParameters.Items[i].SubItems[0].Text == txtParameter.Text)
                    selectedIndex = i;
            }

            if (cboValue.Visible && !lvwValues.Visible)
            {
                lvwParameters.Items[selectedIndex].SubItems[1].Text = cboValue.Text; 
            }
            else
            {
                if (dtpFromDate.Visible)
                {
                    if (dtpToDate.Visible)
                    {
                        if (dtpToTime.Visible)
                        {
                            lvwParameters.Items[selectedIndex].SubItems[1].Text =
                                (dtpFromDate.Checked ? dtpFromDate.Value.ToShortDateString() + " " + dtpFromTime.Value.ToShortDateString() : "up to") + " - " +
                                (dtpToDate.Checked ? dtpToDate.Value.ToShortDateString() + " " + dtpToTime.Value.ToShortDateString() : "and up");
                        }
                        else
                        {
                            lvwParameters.Items[selectedIndex].SubItems[1].Text =
                                (dtpFromDate.Checked ? dtpFromDate.Value.ToShortDateString() : "up to") + " - " +
                                (dtpToDate.Checked ? dtpToDate.Value.ToShortDateString() : "and up");
                        }

                    }
                    else
                    {
                        if (dtpFromTime.Visible)
                        {
                            lvwParameters.Items[selectedIndex].SubItems[1].Text = dtpFromDate.Checked ? dtpFromDate.Value.ToShortDateString() + " " + dtpFromTime.Value.ToShortDateString() : "up to";
                        }
                        else
                        {
                            lvwParameters.Items[selectedIndex].SubItems[1].Text = dtpFromDate.Checked ? dtpFromDate.Value.ToShortDateString() : "up to";
                        }
                    }
                }
                else
                {
                    string value = string.Empty;
                    
                    if (lvwValues.Items.Count > 0)
                    {
                        for (int i = 0; i < lvwValues.Items.Count; i++)
                        {
                            if (i > 0)
                            {
                                value = value + ";";
                            }
                            value = value + lvwValues.Items[i].Text.Trim();
                        }
                    }
                    else
                    {
                        value = "All";
                    }

                    lvwParameters.Items[selectedIndex].SubItems[1].Text = value;
                }
            }

            _saveNeeded = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;

            if (_saveNeeded)
                SaveChanges();

            Dictionary<string, string> paramValuesDictionary = new Dictionary<string, string>();
            for (int i = 0; i < lvwParameters.Items.Count; i++)
            {
                ListViewItem currentItem = lvwParameters.Items[i];
                paramValuesDictionary.Add(currentItem.Text, currentItem.SubItems[1].Text);
            }

            _reporterBO.CreateParameterCollection(_parameterFields, paramValuesDictionary);

            this.UseWaitCursor = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwValues.SelectedItems.Count - 1; i++)
            {
                lvwValues.SelectedItems[0].Remove();
            }

            if (lvwValues.Items.Count == 0)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = "All";
                lvwValues.Items.Add(listViewItem);
            }

            txtValue.Focus();
        }

        private void LoadCombo(string p)
        {
            _loadingData = true;

            cboValue.Enabled = true;
            cboValue.Items.Clear();
            cboValue.DisplayMember = "text";
            cboValue.ValueMember = "tag";

            for (int i = 0; i < _parameterFields[p].DefaultValues.Count; i++)
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue = (ParameterDiscreteValue)_parameterFields[p].DefaultValues[i];
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = parameterDiscreteValue.Value.ToString();
                cboValue.Items.Add(listViewItem);
            }

            cboValue.Text = string.Empty;

            _loadingData = false;
        }

        private void cboValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingData)
                return;

            _saveNeeded = true;

            if (cboValue.SelectedIndex > -1)
            {
                btnOK.Enabled = true;
                if (lvwValues.Visible)
                    AddValueListItem();
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            _saveNeeded = true;
            if (!dtpFromDate.Checked)
                if (!dtpToDate.Checked)
                    dtpToDate.Checked = true;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            _saveNeeded = true;
            if (!dtpToDate.Checked)
                if (!dtpFromDate.Checked)
                    dtpFromDate.Checked = true;
        }

        private void lvwParameters_DoubleClick(object sender, EventArgs e)
        {
            if (cboValue.Enabled)
                cboValue.Focus();
            else
                dtpFromDate.Focus();
        }

        private void lvwParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwParameters.SelectedItems.Count > 0)
            {
                btnApplyChange.Enabled = true;
                btnApplyChange.Visible = true;
                txtParameter.Text = lvwParameters.SelectedItems[0].Text;
                lvwValues.Items.Clear();
            }

            lvwValues.Visible = _parameterFields[lvwParameters.SelectedItems[0].Text].EnableAllowMultipleValue;
            txtDescription.Text = _parameterFields[lvwParameters.SelectedItems[0].Text].PromptText;

            if (_parameterFields[lvwParameters.SelectedItems[0].Text].ParameterValueType == ParameterValueKind.DateParameter)
            {
                DisableControls();

                if (_parameterFields[lvwParameters.SelectedItems[0].Text].DiscreteOrRangeKind == DiscreteOrRangeKind.RangeValue)
                {
                    dtpToDate.Visible = true;
                }

                dtpFromDate.Visible = true;
                dtpFromDate.Focus();
            }
            else if (_parameterFields[lvwParameters.SelectedItems[0].Text].ParameterValueType == ParameterValueKind.DateTimeParameter)
            {
                DisableControls();

                if (_parameterFields[lvwParameters.SelectedItems[0].Text].DiscreteOrRangeKind == DiscreteOrRangeKind.RangeValue)
                {
                    dtpToDate.Visible = true;
                    dtpToTime.Visible = true;
                }

                dtpFromDate.Visible = true;
                dtpFromTime.Visible = true;
                dtpFromDate.Focus();
            }
            else if (_parameterFields[lvwParameters.SelectedItems[0].Text].EnableAllowMultipleValue)
            {
                LoadValueListView();
                DisableControls();

                if (_parameterFields[lvwParameters.SelectedItems[0].Text].DefaultValues.Count > 1)
                {
                    LoadCombo(lvwParameters.SelectedItems[0].Text);
                    cboValue.Visible = true;
                    cboValue.Focus();
                }
                else
                {
                    txtValue.Visible = true;
                    txtValue.Focus();
                }
            }
            else
            {
                DisableControls();
                LoadCombo(lvwParameters.SelectedItems[0].Text);
                cboValue.Visible = true;
                cboValue.Focus();
            }
        }

        private void lvwValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwValues.SelectedItems.Count > 0)
                btnRemove.Enabled = (lvwValues.SelectedItems[0].Text == "All" ? false : true);
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {
            if (lvwValues.Visible && txtValue.TextLength > 0)
                AddValueListItem();
        }

        private void AddValueListItem()
        {
            bool proceed = true;

            for (int i = 0; i < lvwValues.Items.Count; i++)
            {
                if (lvwValues.Items[i].Text.ToUpper() == "ALL")
                {
                    lvwValues.Items[i].Remove();
                }
                else if (lvwValues.Items[i].Text.ToUpper() == (txtValue.Visible ? txtValue.Text.ToUpper() : cboValue.Text.ToUpper()))
                {
                    proceed = false;
                    break;
                }
            }

            if (proceed)
            {
                if (txtValue.Visible && txtValue.Text.ToUpper() == "All")
                    lvwValues.Items.Clear();

                for (int i = 0; i < lvwValues.Items.Count; i++)
                {
                    if (lvwValues.Items[i].Text.ToUpper() == (txtValue.Visible ? txtValue.Text.ToUpper() : cboValue.Text.ToUpper()))
                    {
                        proceed = false;
                        break;
                    }
                }
            }

            if (proceed)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = (txtValue.Visible ? txtValue.Text : cboValue.Text);
                if (listViewItem.Text == string.Empty)
                    listViewItem.Text = cboValue.Text;

                lvwValues.Items.Add(listViewItem);

                txtValue.Text = string.Empty;
                cboValue.Text = string.Empty;
                cboValue.SelectedIndex = -1;
            }

            btnApplyChange.Enabled = true;
            AdjustColumnWidth("Values");
            txtValue.Focus();
        }

        private void AdjustColumnWidth(string whichColumn)
        {
            switch (whichColumn)
            {
                case "Values":
                    lvwParameters.Columns[0].Width = (lvwParameters.Items.Count > 5 ? 185 : 200);
                    break;
                case "Parameters":
                    lvwParameters.Columns[1].Width = (lvwParameters.Items.Count > 12 ? 175 : 190);
                    break;
                default:
                    break;
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            _saveNeeded = true;
            if (lvwValues.Visible)
                btnRemove.Enabled = lvwValues.SelectedItems.Count > 0 ? true : false;
        }

        private void LoadValueListView()
        {
            btnRemove.Enabled = false;
            btnRemove.Visible = true;

            int position = 0;
            int startPosition = 0;
            lvwValues.Items.Clear();

            while (true)
            {
                position = lvwParameters.SelectedItems[0].SubItems[1].Text.IndexOf(";", startPosition);
                if (position == 0)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = lvwParameters.SelectedItems[0].SubItems[1].Text.Substring(startPosition, lvwParameters.SelectedItems[0].SubItems[1].Text.Length - startPosition);
                    lvwValues.Items.Add(listViewItem);
                    break;
                }
                else
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = lvwParameters.SelectedItems[0].SubItems[1].Text.Substring(startPosition, position - startPosition);
                    lvwValues.Items.Add(listViewItem);
                    startPosition = position + 1;
                }
            }
            AdjustColumnWidth("Values");
            txtValue.Focus();
        }

        private void DisplayParameterSets()
        {
            for (int i = cboParameterSetName.Items.Count; i > 0 ; i--)
            {
                cboParameterSetName.Items.RemoveAt(i - 1);
            }

            cboParameterSetName.Text = string.Empty;
            txtParameterSetDescription.Text = string.Empty;

            for (int i = 0; i < lvwParameters.Items.Count; i++)
            {
                lvwParameters.Items[i].SubItems[1].Text = string.Empty;
            }


            foreach (ParameterSet ps in _parameterSets)
            {
                cboParameterSetName.Items.Add(new ComboBoxItem(ps.ParameterSetName, ps));
            }

            cboParameterSetName.SelectedIndex = -1;
        }

        private void btnNewParameterSet_Click(object sender, EventArgs e)
        {
            _loadingData = true;

            cboParameterSetName.Text = "New Parameter Set Name";
            txtParameterSetDescription.Text = string.Empty;
            cboParameterSetName.Focus();

            _newParameterSet = true;
            btnNewParameterSet.Enabled = false;            

            _loadingData = false;
        }

        private void btnSaveParameterSet_Click(object sender, EventArgs e)
        {
            if (IsParameterSetBlankOrDuplicate())
            {
                lblParamSetNameError.Visible = true;
                cboParameterSetName.Focus();
            }
            else if (cboParameterSetName.Text.Length > 0)
            {
                ParameterSet parameterSet;

                if (_newParameterSet)
                {
                    parameterSet = new ParameterSet();
                    parameterSet.ParameterSetName = cboParameterSetName.Text;
                }
                else
                {
                    parameterSet = (((ComboBoxItem)cboParameterSetName.SelectedItem).ParameterSet);
                }

                parameterSet.ParameterSetDescription = txtParameterSetDescription.Text;
                parameterSet.ReportID = _reporterBO.SelectedReport.ReportID;

                parameterSet.Parameters.Clear();
                
                foreach (ListViewItem item in lvwParameters.Items)
                {
                    Parameter parameter = new Parameter();
                    parameter.ParameterID = Convert.ToInt32(item.Tag);
                    parameter.ParameterName = item.Text;
                    parameter.ParameterValue = item.SubItems[1].Text;
                    parameterSet.Parameters.Add(parameter);
                }

                parameterSet = _reporterBO.SaveParameterSet(parameterSet);
                
                _parameterSets = _reporterBO.AvailableParameterSets;

                DisplayParameterSets();

                for (int i = 0; i < cboParameterSetName.Items.Count; i++)
                {
                    if (parameterSet.ParameterSetName == cboParameterSetName.Items[i].ToString())
                    {
                        cboParameterSetName.SelectedIndex = i;
                    }
                }

                lblParamSetNameError.Visible = false;
                btnNewParameterSet.Enabled = true;
                _newParameterSet = false;
            }
        }

        private bool IsParameterSetBlankOrDuplicate()
        {
            bool blankOrDuplicate = false;

            if (cboParameterSetName.Text.Trim() == string.Empty)
            {
                blankOrDuplicate = true;
                lblParamSetNameError.Text = "Blank Parameter Set Name";
            }

            if (!blankOrDuplicate && _newParameterSet)
            {
                //dup of another ParameterSetName for this reportid
                foreach (ParameterSet ps in _parameterSets)
                {
                    if (cboParameterSetName.Text == ps.ParameterSetName)
                    {
                        blankOrDuplicate = true;
                        lblParamSetNameError.Text = "Duplicate Parameter Set Name";
                        break;
                    }
                }
            }
           
            return blankOrDuplicate;
        }

        private void btnDeleteParameterSet_Click(object sender, EventArgs e)
        {
            lblParamSetNameError.Visible = false;
            _reporterBO.DeleteParameterSet(((ComboBoxItem)cboParameterSetName.SelectedItem).ParameterSet);
            _parameterSets = new List<ParameterSet>(_reporterBO.AvailableParameterSets);
            DisplayParameterSets();
            btnNewParameterSet.Enabled = true;
        }

        private void cboParameterSetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loadingData)
            {
                if (cboParameterSetName.SelectedIndex != -1)
                {
                    ParameterSet parameterSet = ((ComboBoxItem)cboParameterSetName.SelectedItem).ParameterSet;
                    txtParameterSetDescription.Text = parameterSet.ParameterSetDescription;

                    lvwParameters.Items.Clear();

                    foreach (Parameter p in parameterSet.Parameters)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.Text = p.ParameterName;
                        listViewItem.Tag = p.ParameterID;
                        listViewItem.SubItems.Add(p.ParameterValue);
                        lvwParameters.Items.Add(listViewItem);
                    }
                }
            }
        }

        private void cboParameterSetName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_newParameterSet)
                e.Handled = true;
        }

        private void txtParameterSetDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_newParameterSet)
                e.Handled = true;
        }
    }
}
