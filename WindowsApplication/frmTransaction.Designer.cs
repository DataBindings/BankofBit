namespace WindowsApplication
{
    partial class frmTransaction
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
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label balanceLabel;
            this.gbxClient = new System.Windows.Forms.GroupBox();
            this.balanceLabel1 = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.gbxTransaction = new System.Windows.Forms.GroupBox();
            this.lblPayee = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblTransactionType = new System.Windows.Forms.Label();
            this.cboPayee = new System.Windows.Forms.ComboBox();
            this.payeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.transactionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lblExisting = new System.Windows.Forms.Label();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            this.gbxClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.gbxTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(15, 29);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(76, 13);
            clientNumberLabel.TabIndex = 0;
            clientNumberLabel.Text = "Client Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(348, 29);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(38, 13);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Name:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(15, 74);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 4;
            accountNumberLabel.Text = "Account Number:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(300, 75);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(86, 13);
            balanceLabel.TabIndex = 6;
            balanceLabel.Text = "Current Balance:";
            // 
            // gbxClient
            // 
            this.gbxClient.Controls.Add(balanceLabel);
            this.gbxClient.Controls.Add(this.balanceLabel1);
            this.gbxClient.Controls.Add(accountNumberLabel);
            this.gbxClient.Controls.Add(this.accountNumberMaskedLabel);
            this.gbxClient.Controls.Add(fullNameLabel);
            this.gbxClient.Controls.Add(this.fullNameLabel1);
            this.gbxClient.Controls.Add(clientNumberLabel);
            this.gbxClient.Controls.Add(this.clientNumberMaskedLabel);
            this.gbxClient.Location = new System.Drawing.Point(27, 26);
            this.gbxClient.Name = "gbxClient";
            this.gbxClient.Size = new System.Drawing.Size(561, 117);
            this.gbxClient.TabIndex = 0;
            this.gbxClient.TabStop = false;
            this.gbxClient.Text = "Client Data";
            // 
            // balanceLabel1
            // 
            this.balanceLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.balanceLabel1.Location = new System.Drawing.Point(401, 73);
            this.balanceLabel1.Name = "balanceLabel1";
            this.balanceLabel1.Size = new System.Drawing.Size(137, 23);
            this.balanceLabel1.TabIndex = 7;
            this.balanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_JP.Models.BankAccount);
            // 
            // accountNumberMaskedLabel
            // 
            this.accountNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountNumber", true));
            this.accountNumberMaskedLabel.Location = new System.Drawing.Point(121, 74);
            this.accountNumberMaskedLabel.Name = "accountNumberMaskedLabel";
            this.accountNumberMaskedLabel.Size = new System.Drawing.Size(137, 23);
            this.accountNumberMaskedLabel.TabIndex = 5;
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(401, 28);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(137, 23);
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
            this.clientNumberMaskedLabel.Location = new System.Drawing.Point(121, 28);
            this.clientNumberMaskedLabel.Mask = "0000-0000";
            this.clientNumberMaskedLabel.Name = "clientNumberMaskedLabel";
            this.clientNumberMaskedLabel.Size = new System.Drawing.Size(137, 23);
            this.clientNumberMaskedLabel.TabIndex = 1;
            // 
            // gbxTransaction
            // 
            this.gbxTransaction.Controls.Add(this.lblPayee);
            this.gbxTransaction.Controls.Add(this.lblBalance);
            this.gbxTransaction.Controls.Add(this.lblTransactionType);
            this.gbxTransaction.Controls.Add(this.cboPayee);
            this.gbxTransaction.Controls.Add(this.cboTransactionType);
            this.gbxTransaction.Controls.Add(this.txtAmount);
            this.gbxTransaction.Controls.Add(this.lnkReturn);
            this.gbxTransaction.Controls.Add(this.lnkUpdate);
            this.gbxTransaction.Controls.Add(this.lblExisting);
            this.gbxTransaction.Location = new System.Drawing.Point(102, 186);
            this.gbxTransaction.Name = "gbxTransaction";
            this.gbxTransaction.Size = new System.Drawing.Size(436, 234);
            this.gbxTransaction.TabIndex = 1;
            this.gbxTransaction.TabStop = false;
            this.gbxTransaction.Text = "Transaction Data";
            // 
            // lblPayee
            // 
            this.lblPayee.AutoSize = true;
            this.lblPayee.Location = new System.Drawing.Point(39, 121);
            this.lblPayee.Name = "lblPayee";
            this.lblPayee.Size = new System.Drawing.Size(40, 13);
            this.lblPayee.TabIndex = 24;
            this.lblPayee.Text = "Payee:";
            this.lblPayee.Visible = false;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(39, 86);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(49, 13);
            this.lblBalance.TabIndex = 23;
            this.lblBalance.Text = "Balance:";
            // 
            // lblTransactionType
            // 
            this.lblTransactionType.AutoSize = true;
            this.lblTransactionType.Location = new System.Drawing.Point(39, 50);
            this.lblTransactionType.Name = "lblTransactionType";
            this.lblTransactionType.Size = new System.Drawing.Size(93, 13);
            this.lblTransactionType.TabIndex = 22;
            this.lblTransactionType.Text = "Transaction Type:";
            // 
            // cboPayee
            // 
            this.cboPayee.DataSource = this.payeeBindingSource;
            this.cboPayee.DisplayMember = "Description";
            this.cboPayee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayee.FormattingEnabled = true;
            this.cboPayee.Location = new System.Drawing.Point(171, 121);
            this.cboPayee.Name = "cboPayee";
            this.cboPayee.Size = new System.Drawing.Size(169, 21);
            this.cboPayee.TabIndex = 21;
            this.cboPayee.Visible = false;
            // 
            // payeeBindingSource
            // 
            this.payeeBindingSource.DataSource = typeof(BankOfBIT_JP.Models.Payee);
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DataSource = this.transactionTypeBindingSource;
            this.cboTransactionType.DisplayMember = "Description";
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(171, 47);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(169, 21);
            this.cboTransactionType.TabIndex = 20;
            this.cboTransactionType.SelectedIndexChanged += new System.EventHandler(this.cboTransactionType_SelectedIndexChanged);
            // 
            // transactionTypeBindingSource
            // 
            this.transactionTypeBindingSource.DataSource = typeof(BankOfBIT_JP.Models.TransactionType);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(171, 83);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(169, 20);
            this.txtAmount.TabIndex = 17;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(234, 193);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(106, 13);
            this.lnkReturn.TabIndex = 12;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Client Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Location = new System.Drawing.Point(88, 193);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(104, 13);
            this.lnkUpdate.TabIndex = 2;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Process Transaction";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lblExisting
            // 
            this.lblExisting.AutoSize = true;
            this.lblExisting.Location = new System.Drawing.Point(106, 160);
            this.lblExisting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Size = new System.Drawing.Size(204, 13);
            this.lblExisting.TabIndex = 10;
            this.lblExisting.Text = "No additional accounts to receive transfer";
            this.lblExisting.Visible = false;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 453);
            this.Controls.Add(this.gbxTransaction);
            this.Controls.Add(this.gbxClient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTransaction";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.frmTransaction_Load);
            this.gbxClient.ResumeLayout(false);
            this.gbxClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.gbxTransaction.ResumeLayout(false);
            this.gbxTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxClient;
        private System.Windows.Forms.GroupBox gbxTransaction;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblExisting;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label balanceLabel1;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel accountNumberMaskedLabel;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel clientNumberMaskedLabel;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.BindingSource transactionTypeBindingSource;
        private System.Windows.Forms.ComboBox cboPayee;
        private System.Windows.Forms.BindingSource payeeBindingSource;
        private System.Windows.Forms.Label lblPayee;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblTransactionType;
    }
}