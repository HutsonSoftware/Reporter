namespace Reporter
{
    partial class ReportGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboAvailDataSources = new System.Windows.Forms.ComboBox();
            this.txtDataSourceDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstAvailFields = new System.Windows.Forms.ListBox();
            this.txtSelectedFieldColumnAlias = new System.Windows.Forms.TextBox();
            this.btnAddSelectedField = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnRemoveSelectedField = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.lstSelectedFields = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optOR = new System.Windows.Forms.RadioButton();
            this.optAND = new System.Windows.Forms.RadioButton();
            this.lstFilterStatement = new System.Windows.Forms.ListBox();
            this.btnRemoveFilter = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboFilterFields = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.optField = new System.Windows.Forms.RadioButton();
            this.optValue = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.cboAvailFilters = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPreviewReport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.optDescending = new System.Windows.Forms.RadioButton();
            this.optAscending = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGroupsColumnAlias = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Data Sources";
            // 
            // cboAvailDataSources
            // 
            this.cboAvailDataSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAvailDataSources.FormattingEnabled = true;
            this.cboAvailDataSources.Location = new System.Drawing.Point(10, 25);
            this.cboAvailDataSources.Name = "cboAvailDataSources";
            this.cboAvailDataSources.Size = new System.Drawing.Size(256, 21);
            this.cboAvailDataSources.TabIndex = 1;
            this.cboAvailDataSources.SelectedIndexChanged += new System.EventHandler(this.cboAvailDataSources_SelectedIndexChanged);
            // 
            // txtDataSourceDesc
            // 
            this.txtDataSourceDesc.BackColor = System.Drawing.SystemColors.Control;
            this.txtDataSourceDesc.Location = new System.Drawing.Point(272, 25);
            this.txtDataSourceDesc.Name = "txtDataSourceDesc";
            this.txtDataSourceDesc.ReadOnly = true;
            this.txtDataSourceDesc.Size = new System.Drawing.Size(391, 20);
            this.txtDataSourceDesc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Available Fields";
            // 
            // lstAvailFields
            // 
            this.lstAvailFields.FormattingEnabled = true;
            this.lstAvailFields.Location = new System.Drawing.Point(10, 65);
            this.lstAvailFields.Name = "lstAvailFields";
            this.lstAvailFields.Size = new System.Drawing.Size(256, 186);
            this.lstAvailFields.TabIndex = 4;
            // 
            // txtSelectedFieldColumnAlias
            // 
            this.txtSelectedFieldColumnAlias.Location = new System.Drawing.Point(529, 65);
            this.txtSelectedFieldColumnAlias.Name = "txtSelectedFieldColumnAlias";
            this.txtSelectedFieldColumnAlias.Size = new System.Drawing.Size(134, 20);
            this.txtSelectedFieldColumnAlias.TabIndex = 7;
            this.txtSelectedFieldColumnAlias.TextChanged += new System.EventHandler(this.txtSelectedFieldColumnAlias_TextChanged);
            // 
            // btnAddSelectedField
            // 
            this.btnAddSelectedField.Location = new System.Drawing.Point(272, 65);
            this.btnAddSelectedField.Name = "btnAddSelectedField";
            this.btnAddSelectedField.Size = new System.Drawing.Size(30, 23);
            this.btnAddSelectedField.TabIndex = 12;
            this.btnAddSelectedField.Text = ">>";
            this.btnAddSelectedField.UseVisualStyleBackColor = true;
            this.btnAddSelectedField.Click += new System.EventHandler(this.btnAddSelectedField_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(272, 195);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(30, 23);
            this.btnAddGroup.TabIndex = 13;
            this.btnAddGroup.Text = ">>";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnRemoveSelectedField
            // 
            this.btnRemoveSelectedField.Location = new System.Drawing.Point(272, 94);
            this.btnRemoveSelectedField.Name = "btnRemoveSelectedField";
            this.btnRemoveSelectedField.Size = new System.Drawing.Size(30, 23);
            this.btnRemoveSelectedField.TabIndex = 14;
            this.btnRemoveSelectedField.Text = "<<";
            this.btnRemoveSelectedField.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedField.Click += new System.EventHandler(this.btnRemoveSelectedField_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Location = new System.Drawing.Point(272, 224);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(30, 23);
            this.btnRemoveGroup.TabIndex = 15;
            this.btnRemoveGroup.Text = "<<";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // lstSelectedFields
            // 
            this.lstSelectedFields.FormattingEnabled = true;
            this.lstSelectedFields.Location = new System.Drawing.Point(308, 65);
            this.lstSelectedFields.Name = "lstSelectedFields";
            this.lstSelectedFields.Size = new System.Drawing.Size(180, 108);
            this.lstSelectedFields.TabIndex = 18;
            this.lstSelectedFields.SelectedIndexChanged += new System.EventHandler(this.lstSelectedFields_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Selected Fields";
            // 
            // lstGroups
            // 
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.Location = new System.Drawing.Point(308, 195);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(180, 56);
            this.lstGroups.TabIndex = 20;
            this.lstGroups.SelectedIndexChanged += new System.EventHandler(this.lstGroups_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Groups";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.lstFilterStatement);
            this.groupBox2.Controls.Add(this.btnRemoveFilter);
            this.groupBox2.Controls.Add(this.btnAddFilter);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboOperator);
            this.groupBox2.Controls.Add(this.cboAvailFilters);
            this.groupBox2.Location = new System.Drawing.Point(4, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 187);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optOR);
            this.groupBox1.Controls.Add(this.optAND);
            this.groupBox1.Location = new System.Drawing.Point(579, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(73, 65);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // optOR
            // 
            this.optOR.AutoSize = true;
            this.optOR.Location = new System.Drawing.Point(10, 36);
            this.optOR.Name = "optOR";
            this.optOR.Size = new System.Drawing.Size(41, 17);
            this.optOR.TabIndex = 1;
            this.optOR.TabStop = true;
            this.optOR.Text = "OR";
            this.optOR.UseVisualStyleBackColor = true;
            // 
            // optAND
            // 
            this.optAND.AutoSize = true;
            this.optAND.Location = new System.Drawing.Point(10, 13);
            this.optAND.Name = "optAND";
            this.optAND.Size = new System.Drawing.Size(48, 17);
            this.optAND.TabIndex = 0;
            this.optAND.TabStop = true;
            this.optAND.Text = "AND";
            this.optAND.UseVisualStyleBackColor = true;
            // 
            // lstFilterStatement
            // 
            this.lstFilterStatement.FormattingEnabled = true;
            this.lstFilterStatement.Location = new System.Drawing.Point(8, 81);
            this.lstFilterStatement.Name = "lstFilterStatement";
            this.lstFilterStatement.Size = new System.Drawing.Size(564, 95);
            this.lstFilterStatement.TabIndex = 9;
            this.lstFilterStatement.SelectedIndexChanged += new System.EventHandler(this.lstFilterStatement_SelectedIndexChanged);
            // 
            // btnRemoveFilter
            // 
            this.btnRemoveFilter.Location = new System.Drawing.Point(578, 110);
            this.btnRemoveFilter.Name = "btnRemoveFilter";
            this.btnRemoveFilter.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFilter.TabIndex = 8;
            this.btnRemoveFilter.Text = "Remove";
            this.btnRemoveFilter.UseVisualStyleBackColor = true;
            this.btnRemoveFilter.Click += new System.EventHandler(this.btnRemoveFilter_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Location = new System.Drawing.Point(578, 81);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddFilter.TabIndex = 7;
            this.btnAddFilter.Text = "Add";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboFilterFields);
            this.groupBox3.Controls.Add(this.txtFilterValue);
            this.groupBox3.Controls.Add(this.optField);
            this.groupBox3.Controls.Add(this.optValue);
            this.groupBox3.Location = new System.Drawing.Point(268, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 66);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // cboFilterFields
            // 
            this.cboFilterFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterFields.FormattingEnabled = true;
            this.cboFilterFields.Location = new System.Drawing.Point(64, 35);
            this.cboFilterFields.Name = "cboFilterFields";
            this.cboFilterFields.Size = new System.Drawing.Size(229, 21);
            this.cboFilterFields.TabIndex = 9;
            this.cboFilterFields.SelectedIndexChanged += new System.EventHandler(this.cboFilterFields_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(64, 12);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(229, 20);
            this.txtFilterValue.TabIndex = 8;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // optField
            // 
            this.optField.AutoSize = true;
            this.optField.Location = new System.Drawing.Point(6, 36);
            this.optField.Name = "optField";
            this.optField.Size = new System.Drawing.Size(47, 17);
            this.optField.TabIndex = 3;
            this.optField.TabStop = true;
            this.optField.Text = "Field";
            this.optField.UseVisualStyleBackColor = true;
            this.optField.CheckedChanged += new System.EventHandler(this.optField_CheckedChanged);
            // 
            // optValue
            // 
            this.optValue.AutoSize = true;
            this.optValue.Location = new System.Drawing.Point(6, 13);
            this.optValue.Name = "optValue";
            this.optValue.Size = new System.Drawing.Size(52, 17);
            this.optValue.TabIndex = 2;
            this.optValue.TabStop = true;
            this.optValue.Text = "Value";
            this.optValue.UseVisualStyleBackColor = true;
            this.optValue.CheckedChanged += new System.EventHandler(this.optValue_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Operator";
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Location = new System.Drawing.Point(66, 46);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(196, 21);
            this.cboOperator.TabIndex = 3;
            this.cboOperator.SelectedIndexChanged += new System.EventHandler(this.cboOperator_SelectedIndexChanged);
            // 
            // cboAvailFilters
            // 
            this.cboAvailFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAvailFilters.FormattingEnabled = true;
            this.cboAvailFilters.Location = new System.Drawing.Point(6, 19);
            this.cboAvailFilters.Name = "cboAvailFilters";
            this.cboAvailFilters.Size = new System.Drawing.Size(256, 21);
            this.cboAvailFilters.TabIndex = 2;
            this.cboAvailFilters.SelectedIndexChanged += new System.EventHandler(this.cboAvailFilters_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(588, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPreviewReport
            // 
            this.btnPreviewReport.Location = new System.Drawing.Point(454, 450);
            this.btnPreviewReport.Name = "btnPreviewReport";
            this.btnPreviewReport.Size = new System.Drawing.Size(128, 23);
            this.btnPreviewReport.TabIndex = 23;
            this.btnPreviewReport.Text = "Preview Report";
            this.btnPreviewReport.UseVisualStyleBackColor = true;
            this.btnPreviewReport.Click += new System.EventHandler(this.btnPreviewReport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(494, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Alias";
            // 
            // optDescending
            // 
            this.optDescending.AutoSize = true;
            this.optDescending.Location = new System.Drawing.Point(581, 221);
            this.optDescending.Name = "optDescending";
            this.optDescending.Size = new System.Drawing.Size(82, 17);
            this.optDescending.TabIndex = 28;
            this.optDescending.TabStop = true;
            this.optDescending.Text = "Descending";
            this.optDescending.UseVisualStyleBackColor = true;
            this.optDescending.CheckedChanged += new System.EventHandler(this.optDescending_CheckedChanged);
            // 
            // optAscending
            // 
            this.optAscending.AutoSize = true;
            this.optAscending.Location = new System.Drawing.Point(497, 221);
            this.optAscending.Name = "optAscending";
            this.optAscending.Size = new System.Drawing.Size(75, 17);
            this.optAscending.TabIndex = 27;
            this.optAscending.TabStop = true;
            this.optAscending.Text = "Ascending";
            this.optAscending.UseVisualStyleBackColor = true;
            this.optAscending.CheckedChanged += new System.EventHandler(this.optAscending_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Alias";
            // 
            // txtGroupsColumnAlias
            // 
            this.txtGroupsColumnAlias.Location = new System.Drawing.Point(529, 195);
            this.txtGroupsColumnAlias.Name = "txtGroupsColumnAlias";
            this.txtGroupsColumnAlias.Size = new System.Drawing.Size(134, 20);
            this.txtGroupsColumnAlias.TabIndex = 29;
            this.txtGroupsColumnAlias.TextChanged += new System.EventHandler(this.txtGroupsColumnAlias_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "(8 max)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(447, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "(3 max)";
            // 
            // ReportGenerator
            // 
            this.AcceptButton = this.btnPreviewReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(675, 482);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGroupsColumnAlias);
            this.Controls.Add(this.optDescending);
            this.Controls.Add(this.optAscending);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPreviewReport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lstGroups);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstSelectedFields);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoveGroup);
            this.Controls.Add(this.btnRemoveSelectedField);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnAddSelectedField);
            this.Controls.Add(this.txtSelectedFieldColumnAlias);
            this.Controls.Add(this.lstAvailFields);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDataSourceDesc);
            this.Controls.Add(this.cboAvailDataSources);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportGenerator";
            this.Text = "ReportGenerator";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAvailDataSources;
        private System.Windows.Forms.TextBox txtDataSourceDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstAvailFields;
        private System.Windows.Forms.TextBox txtSelectedFieldColumnAlias;
        private System.Windows.Forms.Button btnAddSelectedField;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnRemoveSelectedField;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.ListBox lstSelectedFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveFilter;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboFilterFields;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.RadioButton optField;
        private System.Windows.Forms.RadioButton optValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.ComboBox cboAvailFilters;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPreviewReport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton optDescending;
        private System.Windows.Forms.RadioButton optAscending;
        private System.Windows.Forms.ListBox lstFilterStatement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optOR;
        private System.Windows.Forms.RadioButton optAND;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGroupsColumnAlias;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}