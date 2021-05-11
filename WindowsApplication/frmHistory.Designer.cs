namespace WindowsApplication
{
    partial class frmHistory
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
            System.Windows.Forms.Label clientNumberLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label balanceLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxAccount = new System.Windows.Forms.GroupBox();
            this.accountNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.balanceLabel1 = new System.Windows.Forms.Label();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionDataGridView = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Withdrawal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            this.gbxAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(77, 35);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(76, 13);
            clientNumberLabel.TabIndex = 0;
            clientNumberLabel.Text = "Client Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(387, 35);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(38, 13);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Name:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(339, 73);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(86, 13);
            balanceLabel.TabIndex = 4;
            balanceLabel.Text = "Current Balance:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(77, 73);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 6;
            accountNumberLabel.Text = "Account Number:";
            // 
            // gbxAccount
            // 
            this.gbxAccount.Controls.Add(accountNumberLabel);
            this.gbxAccount.Controls.Add(this.accountNumberMaskedLabel);
            this.gbxAccount.Controls.Add(balanceLabel);
            this.gbxAccount.Controls.Add(this.balanceLabel1);
            this.gbxAccount.Controls.Add(fullNameLabel);
            this.gbxAccount.Controls.Add(this.fullNameLabel1);
            this.gbxAccount.Controls.Add(clientNumberLabel);
            this.gbxAccount.Controls.Add(this.clientNumberMaskedLabel);
            this.gbxAccount.Location = new System.Drawing.Point(43, 23);
            this.gbxAccount.Name = "gbxAccount";
            this.gbxAccount.Size = new System.Drawing.Size(635, 129);
            this.gbxAccount.TabIndex = 0;
            this.gbxAccount.TabStop = false;
            this.gbxAccount.Text = "Account Data";
            // 
            // accountNumberMaskedLabel
            // 
            this.accountNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.accountNumberMaskedLabel.Location = new System.Drawing.Point(173, 72);
            this.accountNumberMaskedLabel.Name = "accountNumberMaskedLabel";
            this.accountNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.accountNumberMaskedLabel.TabIndex = 7;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_JP.Models.BankAccount);
            // 
            // balanceLabel1
            // 
            this.balanceLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.balanceLabel1.Location = new System.Drawing.Point(441, 71);
            this.balanceLabel1.Name = "balanceLabel1";
            this.balanceLabel1.Size = new System.Drawing.Size(100, 23);
            this.balanceLabel1.TabIndex = 5;
            this.balanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(441, 34);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(100, 23);
            this.fullNameLabel1.TabIndex = 3;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT_JP.Models.Client);
            // 
            // clientNumberMaskedLabel
            // 
            this.clientNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clientNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "ClientNumber", true));
            this.clientNumberMaskedLabel.Location = new System.Drawing.Point(173, 33);
            this.clientNumberMaskedLabel.Mask = "0000-0000";
            this.clientNumberMaskedLabel.Name = "clientNumberMaskedLabel";
            this.clientNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.clientNumberMaskedLabel.TabIndex = 1;
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(307, 428);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(106, 13);
            this.lnkReturn.TabIndex = 4;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // transactionBindingSource
            // 
            this.transactionBindingSource.AllowNew = false;
            this.transactionBindingSource.DataSource = typeof(BankOfBIT_JP.Models.Transaction);
            // 
            // transactionDataGridView
            // 
            this.transactionDataGridView.AllowUserToOrderColumns = true;
            this.transactionDataGridView.AutoGenerateColumns = false;
            this.transactionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.TransactionType,
            this.Deposit,
            this.Withdrawal,
            this.Notes});
            this.transactionDataGridView.DataSource = this.transactionBindingSource;
            this.transactionDataGridView.Location = new System.Drawing.Point(43, 177);
            this.transactionDataGridView.Name = "transactionDataGridView";
            this.transactionDataGridView.Size = new System.Drawing.Size(635, 224);
            this.transactionDataGridView.TabIndex = 4;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "DateCreated";
            dataGridViewCellStyle4.Format = "D";
            dataGridViewCellStyle4.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle4;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 140;
            // 
            // TransactionType
            // 
            this.TransactionType.DataPropertyName = "Description";
            this.TransactionType.HeaderText = "TransactionType";
            this.TransactionType.Name = "TransactionType";
            // 
            // Deposit
            // 
            this.Deposit.DataPropertyName = "Deposit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.Deposit.DefaultCellStyle = dataGridViewCellStyle5;
            this.Deposit.HeaderText = "Amount In";
            this.Deposit.Name = "Deposit";
            this.Deposit.Width = 70;
            // 
            // Withdrawal
            // 
            this.Withdrawal.DataPropertyName = "Withdrawal";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.Withdrawal.DefaultCellStyle = dataGridViewCellStyle6;
            this.Withdrawal.HeaderText = "Amount Out";
            this.Withdrawal.Name = "Withdrawal";
            this.Withdrawal.Width = 70;
            // 
            // Notes
            // 
            this.Notes.DataPropertyName = "Notes";
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.Width = 195;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 527);
            this.Controls.Add(this.transactionDataGridView);
            this.Controls.Add(this.lnkReturn);
            this.Controls.Add(this.gbxAccount);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHistory";
            this.Text = "Registration History";
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.gbxAccount.ResumeLayout(false);
            this.gbxAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAccount;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private EWSoftware.MaskedLabelControl.MaskedLabel accountNumberMaskedLabel;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label balanceLabel1;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel clientNumberMaskedLabel;
        private System.Windows.Forms.BindingSource transactionBindingSource;
        private System.Windows.Forms.DataGridView transactionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Withdrawal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}