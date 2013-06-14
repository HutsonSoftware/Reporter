namespace ReporterBOTester
{
    partial class ReporterBOTester
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
            if (disposing && (_reporterBO != null))
            {
                _reporterBO.Dispose();
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
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPdfFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboReports = new System.Windows.Forms.ComboBox();
            this.cboParameterSetNames = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Name";
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToPDF.Location = new System.Drawing.Point(573, 67);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(110, 23);
            this.btnExportToPDF.TabIndex = 2;
            this.btnExportToPDF.Text = "ExportToPDF";
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PDF FileName";
            // 
            // txtPdfFileName
            // 
            this.txtPdfFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPdfFileName.Location = new System.Drawing.Point(120, 95);
            this.txtPdfFileName.Name = "txtPdfFileName";
            this.txtPdfFileName.Size = new System.Drawing.Size(563, 20);
            this.txtPdfFileName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ParameterSet Name";
            // 
            // cboReports
            // 
            this.cboReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReports.FormattingEnabled = true;
            this.cboReports.Location = new System.Drawing.Point(120, 14);
            this.cboReports.Name = "cboReports";
            this.cboReports.Size = new System.Drawing.Size(563, 21);
            this.cboReports.TabIndex = 9;
            this.cboReports.SelectedIndexChanged += new System.EventHandler(this.cboReports_SelectedIndexChanged);
            // 
            // cboParameterSetNames
            // 
            this.cboParameterSetNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboParameterSetNames.FormattingEnabled = true;
            this.cboParameterSetNames.Location = new System.Drawing.Point(120, 40);
            this.cboParameterSetNames.Name = "cboParameterSetNames";
            this.cboParameterSetNames.Size = new System.Drawing.Size(563, 21);
            this.cboParameterSetNames.TabIndex = 10;
            // 
            // ReporterBOTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 127);
            this.Controls.Add(this.cboParameterSetNames);
            this.Controls.Add(this.cboReports);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPdfFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExportToPDF);
            this.Controls.Add(this.label1);
            this.Name = "ReporterBOTester";
            this.Text = "ReporterBO Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportToPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPdfFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboReports;
        private System.Windows.Forms.ComboBox cboParameterSetNames;
    }
}

