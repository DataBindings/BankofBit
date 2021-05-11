namespace WindowsApplication
{
    partial class frmClient
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
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label accountNumberLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label descriptionLabel2;
            System.Windows.Forms.Label notesLabel;
            System.Windows.Forms.Label balanceLabel;
            this.gbxClient = new System.Windows.Forms.GroupBox();
            this.dateCreatedMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.postalCodeMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.provinceMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.cityLabel1 = new System.Windows.Forms.Label();
            this.addressLabel1 = new System.Windows.Forms.Label();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.clientNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.lblRFID = new System.Windows.Forms.Label();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbxAccount = new System.Windows.Forms.GroupBox();
            this.balanceLabel1 = new System.Windows.Forms.Label();
            this.notesLabel1 = new System.Windows.Forms.Label();
            this.descriptionLabel3 = new System.Windows.Forms.Label();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.accountNumberComboBox = new System.Windows.Forms.ComboBox();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.serialPortRFID = new System.IO.Ports.SerialPort(this.components);
            this.txtReader = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            clientNumberLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            provinceLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            accountNumberLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            descriptionLabel2 = new System.Windows.Forms.Label();
            notesLabel = new System.Windows.Forms.Label();
            balanceLabel = new System.Windows.Forms.Label();
            this.gbxClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            this.gbxAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientNumberLabel
            // 
            clientNumberLabel.AutoSize = true;
            clientNumberLabel.Location = new System.Drawing.Point(54, 49);
            clientNumberLabel.Name = "clientNumberLabel";
            clientNumberLabel.Size = new System.Drawing.Size(76, 13);
            clientNumberLabel.TabIndex = 1;
            clientNumberLabel.Text = "Client Number:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(54, 79);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(38, 13);
            fullNameLabel.TabIndex = 3;
            fullNameLabel.Text = "Name:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(54, 107);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(48, 13);
            addressLabel.TabIndex = 5;
            addressLabel.Text = "Address:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(54, 135);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(27, 13);
            cityLabel.TabIndex = 7;
            cityLabel.Text = "City:";
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Location = new System.Drawing.Point(325, 135);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(52, 13);
            provinceLabel.TabIndex = 9;
            provinceLabel.Text = "Province:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Cursor = System.Windows.Forms.Cursors.Cross;
            postalCodeLabel.Location = new System.Drawing.Point(445, 135);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(67, 13);
            postalCodeLabel.TabIndex = 11;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(54, 163);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(73, 13);
            dateCreatedLabel.TabIndex = 13;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new System.Drawing.Point(54, 51);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new System.Drawing.Size(90, 13);
            accountNumberLabel.TabIndex = 0;
            accountNumberLabel.Text = "Account Number:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(435, 79);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(77, 13);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Account Type:";
            // 
            // descriptionLabel2
            // 
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Location = new System.Drawing.Point(54, 80);
            descriptionLabel2.Name = "descriptionLabel2";
            descriptionLabel2.Size = new System.Drawing.Size(35, 13);
            descriptionLabel2.TabIndex = 6;
            descriptionLabel2.Text = "State:";
            // 
            // notesLabel
            // 
            notesLabel.AutoSize = true;
            notesLabel.Location = new System.Drawing.Point(54, 113);
            notesLabel.Name = "notesLabel";
            notesLabel.Size = new System.Drawing.Size(38, 13);
            notesLabel.TabIndex = 8;
            notesLabel.Text = "Notes:";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new System.Drawing.Point(445, 51);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new System.Drawing.Size(49, 13);
            balanceLabel.TabIndex = 9;
            balanceLabel.Text = "Balance:";
            // 
            // gbxClient
            // 
            this.gbxClient.Controls.Add(dateCreatedLabel);
            this.gbxClient.Controls.Add(this.dateCreatedMaskedLabel);
            this.gbxClient.Controls.Add(postalCodeLabel);
            this.gbxClient.Controls.Add(this.postalCodeMaskedLabel);
            this.gbxClient.Controls.Add(provinceLabel);
            this.gbxClient.Controls.Add(this.provinceMaskedLabel);
            this.gbxClient.Controls.Add(cityLabel);
            this.gbxClient.Controls.Add(this.cityLabel1);
            this.gbxClient.Controls.Add(addressLabel);
            this.gbxClient.Controls.Add(this.addressLabel1);
            this.gbxClient.Controls.Add(fullNameLabel);
            this.gbxClient.Controls.Add(this.fullNameLabel1);
            this.gbxClient.Controls.Add(clientNumberLabel);
            this.gbxClient.Controls.Add(this.clientNumberMaskedTextBox);
            this.gbxClient.Controls.Add(this.lblRFID);
            this.gbxClient.Location = new System.Drawing.Point(31, 50);
            this.gbxClient.Name = "gbxClient";
            this.gbxClient.Size = new System.Drawing.Size(652, 227);
            this.gbxClient.TabIndex = 0;
            this.gbxClient.TabStop = false;
            this.gbxClient.Text = "Client Data";
            // 
            // dateCreatedMaskedLabel
            // 
            this.dateCreatedMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateCreatedMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "DateCreated", true));
            this.dateCreatedMaskedLabel.Location = new System.Drawing.Point(150, 162);
            this.dateCreatedMaskedLabel.Mask = "0000-00-00";
            this.dateCreatedMaskedLabel.Name = "dateCreatedMaskedLabel";
            this.dateCreatedMaskedLabel.Size = new System.Drawing.Size(169, 23);
            this.dateCreatedMaskedLabel.TabIndex = 14;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(BankOfBIT_JP.Models.Client);
            // 
            // postalCodeMaskedLabel
            // 
            this.postalCodeMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postalCodeMaskedLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.postalCodeMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "PostalCode", true));
            this.postalCodeMaskedLabel.Location = new System.Drawing.Point(518, 135);
            this.postalCodeMaskedLabel.Mask = "AAA AAA";
            this.postalCodeMaskedLabel.Name = "postalCodeMaskedLabel";
            this.postalCodeMaskedLabel.Size = new System.Drawing.Size(89, 23);
            this.postalCodeMaskedLabel.TabIndex = 12;
            // 
            // provinceMaskedLabel
            // 
            this.provinceMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.provinceMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Province", true));
            this.provinceMaskedLabel.Location = new System.Drawing.Point(383, 135);
            this.provinceMaskedLabel.Mask = "LL";
            this.provinceMaskedLabel.Name = "provinceMaskedLabel";
            this.provinceMaskedLabel.Size = new System.Drawing.Size(56, 23);
            this.provinceMaskedLabel.TabIndex = 10;
            // 
            // cityLabel1
            // 
            this.cityLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cityLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "City", true));
            this.cityLabel1.Location = new System.Drawing.Point(150, 134);
            this.cityLabel1.Name = "cityLabel1";
            this.cityLabel1.Size = new System.Drawing.Size(169, 23);
            this.cityLabel1.TabIndex = 8;
            // 
            // addressLabel1
            // 
            this.addressLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "Address", true));
            this.addressLabel1.Location = new System.Drawing.Point(150, 106);
            this.addressLabel1.Name = "addressLabel1";
            this.addressLabel1.Size = new System.Drawing.Size(457, 23);
            this.addressLabel1.TabIndex = 6;
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clientBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(150, 78);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(457, 23);
            this.fullNameLabel1.TabIndex = 4;
            // 
            // clientNumberMaskedTextBox
            // 
            this.clientNumberMaskedTextBox.Location = new System.Drawing.Point(150, 46);
            this.clientNumberMaskedTextBox.Mask = "0000-0000";
            this.clientNumberMaskedTextBox.Name = "clientNumberMaskedTextBox";
            this.clientNumberMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.clientNumberMaskedTextBox.TabIndex = 2;
            this.clientNumberMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.clientNumberMaskedTextBox.Leave += new System.EventHandler(this.clientNumberMaskedTextBox_Leave);
            // 
            // lblRFID
            // 
            this.lblRFID.AutoSize = true;
            this.lblRFID.ForeColor = System.Drawing.Color.Red;
            this.lblRFID.Location = new System.Drawing.Point(311, 49);
            this.lblRFID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(239, 13);
            this.lblRFID.TabIndex = 0;
            this.lblRFID.Text = "RFID Unavailable - Enter Client Number Manually";
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.AllowNew = true;
            this.bankAccountBindingSource.DataSource = typeof(BankOfBIT_JP.Models.BankAccount);
            // 
            // gbxAccount
            // 
            this.gbxAccount.Controls.Add(balanceLabel);
            this.gbxAccount.Controls.Add(this.balanceLabel1);
            this.gbxAccount.Controls.Add(notesLabel);
            this.gbxAccount.Controls.Add(this.notesLabel1);
            this.gbxAccount.Controls.Add(descriptionLabel2);
            this.gbxAccount.Controls.Add(this.descriptionLabel3);
            this.gbxAccount.Controls.Add(descriptionLabel);
            this.gbxAccount.Controls.Add(this.descriptionLabel1);
            this.gbxAccount.Controls.Add(accountNumberLabel);
            this.gbxAccount.Controls.Add(this.accountNumberComboBox);
            this.gbxAccount.Location = new System.Drawing.Point(31, 300);
            this.gbxAccount.Name = "gbxAccount";
            this.gbxAccount.Size = new System.Drawing.Size(652, 216);
            this.gbxAccount.TabIndex = 1;
            this.gbxAccount.TabStop = false;
            this.gbxAccount.Text = "Bank Account Data";
            // 
            // balanceLabel1
            // 
            this.balanceLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Balance", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.balanceLabel1.Location = new System.Drawing.Point(518, 48);
            this.balanceLabel1.Name = "balanceLabel1";
            this.balanceLabel1.Size = new System.Drawing.Size(89, 23);
            this.balanceLabel1.TabIndex = 10;
            this.balanceLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // notesLabel1
            // 
            this.notesLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Notes", true));
            this.notesLabel1.Location = new System.Drawing.Point(150, 113);
            this.notesLabel1.Name = "notesLabel1";
            this.notesLabel1.Size = new System.Drawing.Size(457, 83);
            this.notesLabel1.TabIndex = 9;
            // 
            // descriptionLabel3
            // 
            this.descriptionLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "AccountState.Description", true));
            this.descriptionLabel3.Location = new System.Drawing.Point(150, 79);
            this.descriptionLabel3.Name = "descriptionLabel3";
            this.descriptionLabel3.Size = new System.Drawing.Size(169, 23);
            this.descriptionLabel3.TabIndex = 7;
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bankAccountBindingSource, "Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(518, 78);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(89, 23);
            this.descriptionLabel1.TabIndex = 5;
            // 
            // accountNumberComboBox
            // 
            this.accountNumberComboBox.DataSource = this.bankAccountBindingSource;
            this.accountNumberComboBox.DisplayMember = "AccountNumber";
            this.accountNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountNumberComboBox.FormattingEnabled = true;
            this.accountNumberComboBox.Location = new System.Drawing.Point(150, 48);
            this.accountNumberComboBox.Name = "accountNumberComboBox";
            this.accountNumberComboBox.Size = new System.Drawing.Size(169, 21);
            this.accountNumberComboBox.TabIndex = 1;
            this.accountNumberComboBox.ValueMember = "BankAccountId";
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Enabled = false;
            this.lnkUpdate.Location = new System.Drawing.Point(225, 523);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(102, 13);
            this.lnkUpdate.TabIndex = 2;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Perform Transaction";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(369, 522);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(65, 13);
            this.lnkDetails.TabIndex = 3;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // serialPortRFID
            // 
            this.serialPortRFID.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortRFID_DataReceived);
            // 
            // txtReader
            // 
            this.txtReader.Location = new System.Drawing.Point(137, 12);
            this.txtReader.Name = "txtReader";
            this.txtReader.Size = new System.Drawing.Size(100, 20);
            this.txtReader.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 575);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtReader);
            this.Controls.Add(this.lnkDetails);
            this.Controls.Add(this.lnkUpdate);
            this.Controls.Add(this.gbxAccount);
            this.Controls.Add(this.gbxClient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmClient";
            this.Text = "Client Information";
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.Leave += new System.EventHandler(this.frmClient_Leave);
            this.gbxClient.ResumeLayout(false);
            this.gbxClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            this.gbxAccount.ResumeLayout(false);
            this.gbxAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxClient;
        private System.Windows.Forms.Label lblRFID;
        private System.Windows.Forms.GroupBox gbxAccount;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.Label cityLabel1;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.Label addressLabel1;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.MaskedTextBox clientNumberMaskedTextBox;
        private EWSoftware.MaskedLabelControl.MaskedLabel dateCreatedMaskedLabel;
        private EWSoftware.MaskedLabelControl.MaskedLabel postalCodeMaskedLabel;
        private EWSoftware.MaskedLabelControl.MaskedLabel provinceMaskedLabel;
        private System.Windows.Forms.Label notesLabel1;
        private System.Windows.Forms.Label descriptionLabel3;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.ComboBox accountNumberComboBox;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.Label balanceLabel1;
        private System.IO.Ports.SerialPort serialPortRFID;
        private System.Windows.Forms.TextBox txtReader;
        private System.Windows.Forms.Button button1;
    }
}