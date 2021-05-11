namespace WindowsApplication
{
    partial class frmBatch
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.institutionNumberComboBox = new System.Windows.Forms.ComboBox();
            this.institutionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radSelect = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.lnkProcess = new System.Windows.Forms.LinkLabel();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.institutionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.institutionNumberComboBox);
            this.groupBox1.Controls.Add(this.radSelect);
            this.groupBox1.Controls.Add(this.radAll);
            this.groupBox1.Controls.Add(this.lnkProcess);
            this.groupBox1.Controls.Add(this.txtKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(37, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(533, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transmission Selection";
            // 
            // institutionNumberComboBox
            // 
            this.institutionNumberComboBox.DataSource = this.institutionBindingSource;
            this.institutionNumberComboBox.DisplayMember = "Description";
            this.institutionNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.institutionNumberComboBox.FormattingEnabled = true;
            this.institutionNumberComboBox.Location = new System.Drawing.Point(33, 86);
            this.institutionNumberComboBox.Name = "institutionNumberComboBox";
            this.institutionNumberComboBox.Size = new System.Drawing.Size(139, 21);
            this.institutionNumberComboBox.TabIndex = 6;
            this.institutionNumberComboBox.ValueMember = "InstitutionNumber";
            // 
            // institutionBindingSource
            // 
            this.institutionBindingSource.DataSource = typeof(BankOfBIT_JP.Models.Institution);
            // 
            // radSelect
            // 
            this.radSelect.AutoSize = true;
            this.radSelect.Checked = true;
            this.radSelect.Location = new System.Drawing.Point(33, 50);
            this.radSelect.Margin = new System.Windows.Forms.Padding(2);
            this.radSelect.Name = "radSelect";
            this.radSelect.Size = new System.Drawing.Size(128, 17);
            this.radSelect.TabIndex = 4;
            this.radSelect.TabStop = true;
            this.radSelect.Text = "Select a Transmission";
            this.radSelect.UseVisualStyleBackColor = true;
            this.radSelect.CheckedChanged += new System.EventHandler(this.radSelect_CheckedChanged);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(33, 28);
            this.radAll.Margin = new System.Windows.Forms.Padding(2);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(128, 17);
            this.radAll.TabIndex = 3;
            this.radAll.Text = "Run All Transmissions";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // lnkProcess
            // 
            this.lnkProcess.AutoSize = true;
            this.lnkProcess.Location = new System.Drawing.Point(31, 159);
            this.lnkProcess.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkProcess.Name = "lnkProcess";
            this.lnkProcess.Size = new System.Drawing.Size(109, 13);
            this.lnkProcess.TabIndex = 2;
            this.lnkProcess.TabStop = true;
            this.lnkProcess.Text = "Process Transmission";
            this.lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProcess_LinkClicked);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(404, 44);
            this.txtKey.Margin = new System.Windows.Forms.Padding(2);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(76, 20);
            this.txtKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Key:";
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(37, 249);
            this.rtxtLog.Margin = new System.Windows.Forms.Padding(2);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(534, 166);
            this.rtxtLog.TabIndex = 1;
            this.rtxtLog.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 225);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transmission Log:";
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 458);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBatch";
            this.Text = "Batch";
            this.Load += new System.EventHandler(this.frmBatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.institutionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lnkProcess;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radSelect;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.ComboBox institutionNumberComboBox;
        private System.Windows.Forms.BindingSource institutionBindingSource;
    }
}