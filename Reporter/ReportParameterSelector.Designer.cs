﻿namespace Reporter
{
    partial class ReportParameterSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cboValue = new System.Windows.Forms.ComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnApplyChange = new System.Windows.Forms.Button();
            this.lvwParameters = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwValues = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSavedParameterSets = new System.Windows.Forms.GroupBox();
            this.btnSaveParameterSet = new System.Windows.Forms.Button();
            this.lblParamSetNameError = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteParameterSet = new System.Windows.Forms.Button();
            this.btnNewParameterSet = new System.Windows.Forms.Button();
            this.txtParameterSetDescription = new System.Windows.Forms.TextBox();
            this.cboParameterSetName = new System.Windows.Forms.ComboBox();
            this.grpSavedParameterSets.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtParameter
            // 
            this.txtParameter.Location = new System.Drawing.Point(12, 28);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.ReadOnly = true;
            this.txtParameter.Size = new System.Drawing.Size(207, 20);
            this.txtParameter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parameter";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(225, 28);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(211, 20);
            this.txtValue.TabIndex = 2;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // cboValue
            // 
            this.cboValue.FormattingEnabled = true;
            this.cboValue.Location = new System.Drawing.Point(225, 28);
            this.cboValue.Name = "cboValue";
            this.cboValue.Size = new System.Drawing.Size(211, 21);
            this.cboValue.TabIndex = 3;
            this.cboValue.SelectedIndexChanged += new System.EventHandler(this.cboValue_SelectedIndexChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(225, 29);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(102, 20);
            this.dtpFromDate.TabIndex = 4;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Value";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(225, 52);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(102, 20);
            this.dtpToDate.TabIndex = 6;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFromTime.Location = new System.Drawing.Point(333, 29);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.Size = new System.Drawing.Size(103, 20);
            this.dtpFromTime.TabIndex = 7;
            // 
            // dtpToTime
            // 
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpToTime.Location = new System.Drawing.Point(333, 52);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.Size = new System.Drawing.Size(103, 20);
            this.dtpToTime.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 76);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(207, 51);
            this.txtDescription.TabIndex = 9;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(442, 76);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(92, 23);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnApplyChange
            // 
            this.btnApplyChange.Location = new System.Drawing.Point(442, 102);
            this.btnApplyChange.Name = "btnApplyChange";
            this.btnApplyChange.Size = new System.Drawing.Size(92, 23);
            this.btnApplyChange.TabIndex = 13;
            this.btnApplyChange.Text = "Apply Change";
            this.btnApplyChange.UseVisualStyleBackColor = true;
            this.btnApplyChange.Click += new System.EventHandler(this.btnApplyChange_Click);
            // 
            // lvwParameters
            // 
            this.lvwParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwParameters.Location = new System.Drawing.Point(12, 133);
            this.lvwParameters.Name = "lvwParameters";
            this.lvwParameters.Size = new System.Drawing.Size(424, 128);
            this.lvwParameters.TabIndex = 14;
            this.lvwParameters.UseCompatibleStateImageBehavior = false;
            this.lvwParameters.View = System.Windows.Forms.View.Details;
            this.lvwParameters.SelectedIndexChanged += new System.EventHandler(this.lvwParameters_SelectedIndexChanged);
            this.lvwParameters.DoubleClick += new System.EventHandler(this.lvwParameters_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Parameter";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 190;
            // 
            // lvwValues
            // 
            this.lvwValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvwValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwValues.Location = new System.Drawing.Point(225, 76);
            this.lvwValues.Name = "lvwValues";
            this.lvwValues.Size = new System.Drawing.Size(211, 51);
            this.lvwValues.TabIndex = 15;
            this.lvwValues.UseCompatibleStateImageBehavior = false;
            this.lvwValues.View = System.Windows.Forms.View.Details;
            this.lvwValues.SelectedIndexChanged += new System.EventHandler(this.lvwValues_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(190, 380);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(282, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpSavedParameterSets
            // 
            this.grpSavedParameterSets.Controls.Add(this.btnSaveParameterSet);
            this.grpSavedParameterSets.Controls.Add(this.lblParamSetNameError);
            this.grpSavedParameterSets.Controls.Add(this.label5);
            this.grpSavedParameterSets.Controls.Add(this.label4);
            this.grpSavedParameterSets.Controls.Add(this.btnDeleteParameterSet);
            this.grpSavedParameterSets.Controls.Add(this.btnNewParameterSet);
            this.grpSavedParameterSets.Controls.Add(this.txtParameterSetDescription);
            this.grpSavedParameterSets.Controls.Add(this.cboParameterSetName);
            this.grpSavedParameterSets.Location = new System.Drawing.Point(12, 267);
            this.grpSavedParameterSets.Name = "grpSavedParameterSets";
            this.grpSavedParameterSets.Size = new System.Drawing.Size(523, 100);
            this.grpSavedParameterSets.TabIndex = 18;
            this.grpSavedParameterSets.TabStop = false;
            this.grpSavedParameterSets.Text = "Saved Parameter Sets";
            // 
            // btnSaveParameterSet
            // 
            this.btnSaveParameterSet.Location = new System.Drawing.Point(430, 42);
            this.btnSaveParameterSet.Name = "btnSaveParameterSet";
            this.btnSaveParameterSet.Size = new System.Drawing.Size(87, 23);
            this.btnSaveParameterSet.TabIndex = 23;
            this.btnSaveParameterSet.Text = "Save";
            this.btnSaveParameterSet.UseVisualStyleBackColor = true;
            this.btnSaveParameterSet.Click += new System.EventHandler(this.btnSaveParameterSet_Click);
            // 
            // lblDupParamSetName
            // 
            this.lblParamSetNameError.AutoSize = true;
            this.lblParamSetNameError.ForeColor = System.Drawing.Color.Red;
            this.lblParamSetNameError.Location = new System.Drawing.Point(6, 57);
            this.lblParamSetNameError.Name = "lblDupParamSetName";
            this.lblParamSetNameError.Size = new System.Drawing.Size(153, 13);
            this.lblParamSetNameError.TabIndex = 22;
            this.lblParamSetNameError.Text = "Duplicate Parameter Set Name";
            this.lblParamSetNameError.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Parameter Set Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Parameter Set Description";
            // 
            // btnDeleteParameterSet
            // 
            this.btnDeleteParameterSet.Location = new System.Drawing.Point(430, 68);
            this.btnDeleteParameterSet.Name = "btnDeleteParameterSet";
            this.btnDeleteParameterSet.Size = new System.Drawing.Size(87, 23);
            this.btnDeleteParameterSet.TabIndex = 19;
            this.btnDeleteParameterSet.Text = "Delete";
            this.btnDeleteParameterSet.UseVisualStyleBackColor = true;
            this.btnDeleteParameterSet.Click += new System.EventHandler(this.btnDeleteParameterSet_Click);
            // 
            // btnNewParameterSet
            // 
            this.btnNewParameterSet.Location = new System.Drawing.Point(430, 16);
            this.btnNewParameterSet.Name = "btnNewParameterSet";
            this.btnNewParameterSet.Size = new System.Drawing.Size(87, 23);
            this.btnNewParameterSet.TabIndex = 18;
            this.btnNewParameterSet.Text = "New";
            this.btnNewParameterSet.UseVisualStyleBackColor = true;
            this.btnNewParameterSet.Click += new System.EventHandler(this.btnNewParameterSet_Click);
            // 
            // txtParameterSetDescription
            // 
            this.txtParameterSetDescription.Location = new System.Drawing.Point(213, 33);
            this.txtParameterSetDescription.Multiline = true;
            this.txtParameterSetDescription.Name = "txtParameterSetDescription";
            this.txtParameterSetDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParameterSetDescription.Size = new System.Drawing.Size(205, 58);
            this.txtParameterSetDescription.TabIndex = 1;
            this.txtParameterSetDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParameterSetDescription_KeyPress);
            // 
            // cboParameterSetName
            // 
            this.cboParameterSetName.FormattingEnabled = true;
            this.cboParameterSetName.Location = new System.Drawing.Point(6, 33);
            this.cboParameterSetName.Name = "cboParameterSetName";
            this.cboParameterSetName.Size = new System.Drawing.Size(198, 21);
            this.cboParameterSetName.TabIndex = 0;
            this.cboParameterSetName.SelectedIndexChanged += new System.EventHandler(this.cboParameterSetName_SelectedIndexChanged);
            this.cboParameterSetName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboParameterSetName_KeyPress);
            // 
            // ReportParameterSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 415);
            this.Controls.Add(this.grpSavedParameterSets);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lvwValues);
            this.Controls.Add(this.lvwParameters);
            this.Controls.Add(this.btnApplyChange);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dtpToTime);
            this.Controls.Add(this.dtpFromTime);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cboValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParameter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportParameterSelector";
            this.Text = "ReportParameters";
            this.Load += new System.EventHandler(this.ReportParameterSelector_Load);
            this.grpSavedParameterSets.ResumeLayout(false);
            this.grpSavedParameterSets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cboValue;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromTime;
        private System.Windows.Forms.DateTimePicker dtpToTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnApplyChange;
        private System.Windows.Forms.ListView lvwParameters;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvwValues;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpSavedParameterSets;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteParameterSet;
        private System.Windows.Forms.Button btnNewParameterSet;
        private System.Windows.Forms.TextBox txtParameterSetDescription;
        private System.Windows.Forms.ComboBox cboParameterSetName;
        private System.Windows.Forms.Label lblParamSetNameError;
        private System.Windows.Forms.Button btnSaveParameterSet;
    }
}