namespace Reporter
{
    partial class ReportCloner
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
            this.lblReportClonee = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewReportName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCloneReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblReportClonee
            // 
            this.lblReportClonee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportClonee.AutoSize = true;
            this.lblReportClonee.Location = new System.Drawing.Point(130, 9);
            this.lblReportClonee.Name = "lblReportClonee";
            this.lblReportClonee.Size = new System.Drawing.Size(109, 13);
            this.lblReportClonee.TabIndex = 0;
            this.lblReportClonee.Text = "Existing Report Name";
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Report Name:";
            // 
            // txtNewReportName
            // 
            this.txtNewReportName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewReportName.Location = new System.Drawing.Point(133, 35);
            this.txtNewReportName.Name = "txtNewReportName";
            this.txtNewReportName.Size = new System.Drawing.Size(322, 20);
            this.txtNewReportName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Existing Report Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(380, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCloneReport
            // 
            this.btnCloneReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloneReport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloneReport.Location = new System.Drawing.Point(282, 61);
            this.btnCloneReport.Name = "btnCloneReport";
            this.btnCloneReport.Size = new System.Drawing.Size(92, 23);
            this.btnCloneReport.TabIndex = 5;
            this.btnCloneReport.Text = "Clone Report";
            this.btnCloneReport.UseVisualStyleBackColor = true;
            this.btnCloneReport.Click += new System.EventHandler(this.btnCloneReport_Click);
            // 
            // ReportCloner
            // 
            this.AcceptButton = this.btnCloneReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 91);
            this.Controls.Add(this.btnCloneReport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewReportName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReportClonee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(470, 115);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 115);
            this.Name = "ReportCloner";
            this.Text = "ReportCloner";
            this.Load += new System.EventHandler(this.ReportCloner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReportClonee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewReportName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCloneReport;
    }
}