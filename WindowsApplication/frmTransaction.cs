using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace WindowsApplication
{
    public partial class frmTransaction : Form
    {
        private BankOfBIT_JP.Data.BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private WebService.TransactionManagerClient bankService;
        private IQueryable<Payee> payeeQuery;
        private IQueryable<BankAccount> bankAccountQuery;

        ///given:  client and bank account data will passed throughout 
        ///application. This object will be used to store the current
        ///client and selected bank account
        ConstructorData constructorData;

        public frmTransaction()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when called from 
        /// frmClient.  This constructor will receive 
        /// specific information about the client and bank account
        /// further code required:  
        /// </summary>
        /// <param name="constructorData">specific client and bank account instances</param>
        public frmTransaction(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;

            try
            {
                bankService = new WebService.TransactionManagerClient();
                accountNumberMaskedLabel.Mask = BusinessRules.AccountFormat(constructorData.BankAccountEntity.Description);
                BindControls();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required:
        /// </summary>
        private void frmTransaction_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// given: this code will navigate back to frmClient with
        /// the specific client and bank account data that launched
        /// this form.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to client with the data selected for this form
            frmClient frmClient = new frmClient(constructorData);
            frmClient.MdiParent = this.MdiParent;
            frmClient.Show();
            this.Close();
        }

        /// <summary>
        /// Handles update link click
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtAmount.Text != string.Empty)
            {
                try
                {
                    int bankAccountId = constructorData.BankAccountEntity.BankAccountId;
                    long accountNumber = constructorData.BankAccountEntity.AccountNumber;
                    double amount = 0; 
                    bool isNumberic = double.TryParse(txtAmount.Text, out amount);
                    double currentBalance = constructorData.BankAccountEntity.Balance;
                    double? accountBalance = null;

                    if (!isNumberic)
                    {
                        throw new Exception("Amount is non-numeric");
                    }

                    if (currentBalance < amount && ((int)cboTransactionType.SelectedValue != (int)TransactionTypeValues.Deposit))
                    {
                        throw new Exception("Insufficient Funds");
                    }

                    switch (cboTransactionType.SelectedValue)
                    {
                        case (int)TransactionTypeValues.Deposit:
                            accountBalance = bankService.Deposit(bankAccountId, amount, "Deposit");
                            break;
                        case (int)TransactionTypeValues.Withdrawal:
                            accountBalance = bankService.Withdrawal(bankAccountId, amount, "Withdrawal");
                            break;
                        case (int)TransactionTypeValues.BillPayment:
                            accountBalance = bankService.BillPayment(bankAccountId, amount, "Bill Payment to " + cboPayee.Text);
                            break;
                        case (int)TransactionTypeValues.Transfer:
                            int toAccountNumber = (int)cboPayee.SelectedValue;
                            accountBalance = bankService.Transfers(bankAccountId, toAccountNumber, amount, "Money Transfer from " + accountNumber + " to " + cboPayee.Text);
                            break;
                    }

                    if (accountBalance != null)
                    {
                        balanceLabel1.Text = String.Format("{0:C2}", accountBalance);                  
                    }
                    else
                    {
                        throw new Exception("Transaction Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        ///  Handles the index changed event of the transaction type drop down list
        /// </summary>
        private void cboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransactionType.SelectedValue != null)
            {
                PayeeBind((int)cboTransactionType.SelectedValue);
            }
        }

        /// <summary>
        /// Preforms data binding to database query
        /// </summary>
        private void BindControls()
        {
            long accountNumber = constructorData.BankAccountEntity.AccountNumber;
            int clientId = constructorData.ClientEntity.ClientId;

            clientBindingSource.DataSource = (Client)constructorData.ClientEntity;
            bankAccountBindingSource.DataSource = (BankAccount)constructorData.BankAccountEntity;

            transactionTypeBindingSource.DataSource = db.TransactionTypes.Where(x => x.TransactionTypeId >= 1
                                                                                  && x.TransactionTypeId <= 4).ToList();
            cboTransactionType.DisplayMember = "Description";
            cboTransactionType.ValueMember = "TransactionTypeId";

            payeeQuery = db.Payees;

            bankAccountQuery = db.BankAccounts.Where(x => x.Client.ClientId == clientId)
                                           .Where(x => x.AccountNumber != accountNumber);
        }

        /// <summary>
        /// Preforms data binding for transactions
        /// </summary>
        /// <param name="transaction">the type of transaction</param>
        private void PayeeBind(int transaction)
        {
            EnablePayee(true);
            payeeBindingSource.Clear();
            payeeBindingSource.Clear();

            switch (transaction)
            {
                case (int)TransactionTypeValues.BillPayment:
                    payeeBindingSource.DataSource = payeeQuery.ToList();
                    cboPayee.DisplayMember = "Description";
                    cboPayee.ValueMember = "PayeeId";
                    break;
                case (int)TransactionTypeValues.Transfer:
                    if (bankAccountQuery.Count() == 0)
                    {
                        EnablePayee(false);
                        lblExisting.Visible = true;
                    }
                    else
                    {
                        payeeBindingSource.DataSource = bankAccountQuery.ToList();
                        cboPayee.DisplayMember = "AccountNumber";
                        cboPayee.ValueMember = "BankAccountId";
                    }
                    break;
                default:
                    EnablePayee(false);
                    break;
            }
        }

        /// <summary>
        /// Sets the state of payee options
        /// </summary>
        /// <param name="enabled">The state of payee options.</param>
        private void EnablePayee(bool enabled)
        {
            cboPayee.Visible = enabled;
            lblPayee.Visible = enabled;
        }
    }
}
