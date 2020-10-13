namespace CSVFromSQL
{
    partial class Form1
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
            this.rdStoredProcedure = new System.Windows.Forms.RadioButton();
            this.rdSqlStatement = new System.Windows.Forms.RadioButton();
            this.grpCommandType = new System.Windows.Forms.GroupBox();
            this.pnlStoredProcedure = new System.Windows.Forms.Panel();
            this.v = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSPName = new System.Windows.Forms.Label();
            this.pnlSQLStatement = new System.Windows.Forms.Panel();
            this.txtSQLCommandText = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.grpCommandType.SuspendLayout();
            this.pnlStoredProcedure.SuspendLayout();
            this.pnlSQLStatement.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdStoredProcedure
            // 
            this.rdStoredProcedure.AutoSize = true;
            this.rdStoredProcedure.Enabled = false;
            this.rdStoredProcedure.Location = new System.Drawing.Point(6, 19);
            this.rdStoredProcedure.Name = "rdStoredProcedure";
            this.rdStoredProcedure.Size = new System.Drawing.Size(108, 17);
            this.rdStoredProcedure.TabIndex = 0;
            this.rdStoredProcedure.TabStop = true;
            this.rdStoredProcedure.Text = "Stored Procedure";
            this.rdStoredProcedure.UseVisualStyleBackColor = true;
            this.rdStoredProcedure.CheckedChanged += new System.EventHandler(this.rdStoredProcedure_CheckedChanged);
            // 
            // rdSqlStatement
            // 
            this.rdSqlStatement.AutoSize = true;
            this.rdSqlStatement.Location = new System.Drawing.Point(5, 42);
            this.rdSqlStatement.Name = "rdSqlStatement";
            this.rdSqlStatement.Size = new System.Drawing.Size(77, 17);
            this.rdSqlStatement.TabIndex = 1;
            this.rdSqlStatement.TabStop = true;
            this.rdSqlStatement.Text = "SQL Query";
            this.rdSqlStatement.UseVisualStyleBackColor = true;
            this.rdSqlStatement.CheckedChanged += new System.EventHandler(this.rdSqlStatement_CheckedChanged);
            // 
            // grpCommandType
            // 
            this.grpCommandType.Controls.Add(this.rdStoredProcedure);
            this.grpCommandType.Controls.Add(this.rdSqlStatement);
            this.grpCommandType.Location = new System.Drawing.Point(12, 12);
            this.grpCommandType.Name = "grpCommandType";
            this.grpCommandType.Size = new System.Drawing.Size(128, 67);
            this.grpCommandType.TabIndex = 2;
            this.grpCommandType.TabStop = false;
            this.grpCommandType.Text = "Query Option";
            this.grpCommandType.Enter += new System.EventHandler(this.grpCommandType_Enter);
            // 
            // pnlStoredProcedure
            // 
            this.pnlStoredProcedure.Controls.Add(this.v);
            this.pnlStoredProcedure.Controls.Add(this.textBox1);
            this.pnlStoredProcedure.Controls.Add(this.lblSPName);
            this.pnlStoredProcedure.Location = new System.Drawing.Point(3, 3);
            this.pnlStoredProcedure.Name = "pnlStoredProcedure";
            this.pnlStoredProcedure.Size = new System.Drawing.Size(405, 110);
            this.pnlStoredProcedure.TabIndex = 3;
            // 
            // v
            // 
            this.v.Location = new System.Drawing.Point(289, 2);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(24, 23);
            this.v.TabIndex = 2;
            this.v.Text = "...";
            this.v.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lblSPName
            // 
            this.lblSPName.AutoSize = true;
            this.lblSPName.Location = new System.Drawing.Point(2, 10);
            this.lblSPName.Name = "lblSPName";
            this.lblSPName.Size = new System.Drawing.Size(52, 13);
            this.lblSPName.TabIndex = 0;
            this.lblSPName.Text = "SP Name";
            // 
            // pnlSQLStatement
            // 
            this.pnlSQLStatement.Controls.Add(this.txtSQLCommandText);
            this.pnlSQLStatement.Location = new System.Drawing.Point(3, 119);
            this.pnlSQLStatement.Name = "pnlSQLStatement";
            this.pnlSQLStatement.Size = new System.Drawing.Size(405, 100);
            this.pnlSQLStatement.TabIndex = 4;
            // 
            // txtSQLCommandText
            // 
            this.txtSQLCommandText.Location = new System.Drawing.Point(5, 4);
            this.txtSQLCommandText.Multiline = true;
            this.txtSQLCommandText.Name = "txtSQLCommandText";
            this.txtSQLCommandText.Size = new System.Drawing.Size(400, 93);
            this.txtSQLCommandText.TabIndex = 0;
            this.txtSQLCommandText.Text = "Type your sql statement here";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlStoredProcedure);
            this.flowLayoutPanel1.Controls.Add(this.pnlSQLStatement);
            this.flowLayoutPanel1.Controls.Add(this.btnExecute);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 85);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(419, 259);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(3, 225);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(125, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(147, 25);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(47, 13);
            this.lblDelimiter.TabIndex = 6;
            this.lblDelimiter.Text = "Delimiter";
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(212, 20);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(32, 20);
            this.txtDelimiter.TabIndex = 7;
            this.txtDelimiter.Text = ",";
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.Location = new System.Drawing.Point(147, 58);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(67, 13);
            this.lblFileLocation.TabIndex = 8;
            this.lblFileLocation.Text = "File Location";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Enabled = false;
            this.txtFileLocation.Location = new System.Drawing.Point(212, 53);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(189, 20);
            this.txtFileLocation.TabIndex = 9;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(407, 51);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(304, 21);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(127, 20);
            this.txtFilename.TabIndex = 12;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(252, 24);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(49, 13);
            this.lblFilename.TabIndex = 11;
            this.lblFilename.Text = "Filename";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 346);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.lblFileLocation);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.lblDelimiter);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.grpCommandType);
            this.Name = "Form1";
            this.Text = "SQL to CSV";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCommandType.ResumeLayout(false);
            this.grpCommandType.PerformLayout();
            this.pnlStoredProcedure.ResumeLayout(false);
            this.pnlStoredProcedure.PerformLayout();
            this.pnlSQLStatement.ResumeLayout(false);
            this.pnlSQLStatement.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdStoredProcedure;
        private System.Windows.Forms.RadioButton rdSqlStatement;
        private System.Windows.Forms.GroupBox grpCommandType;
        private System.Windows.Forms.Panel pnlStoredProcedure;
        private System.Windows.Forms.Panel pnlSQLStatement;
        private System.Windows.Forms.Button v;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblSPName;
        private System.Windows.Forms.TextBox txtSQLCommandText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label lblFileLocation;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblFilename;
    }
}

