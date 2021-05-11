using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;
using Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApplication
{
    public partial class frmHistory : Form
    {
        private BankOfBIT_JP.Data.BankOfBIT_JPContext db = new BankOfBIT_JPContext();

        ///given:  client and bank account data will passed throughout 
        ///application. This object will be used to store the current
        ///client and selected bank account
        ConstructorData constructorData;

        public frmHistory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when called from 
        /// frmClient.  This constructor will receive 
        /// specific information about the client and bank account
        /// further code required:  
        /// </summary>
        /// <param name="constructorData">specific student and bank account instances</param>
        public frmHistory(ConstructorData constructorData)
        {
            InitializeComponent();
            this.constructorData = constructorData;

            try
            {
                clientBindingSource.DataSource = (Client)constructorData.ClientEntity;
                bankAccountBindingSource.DataSource = (BankAccount)constructorData.BankAccountEntity;
                TransactionQuery();
                accountNumberMaskedLabel.Mask = BusinessRules.AccountFormat(constructorData.BankAccountEntity.Description);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        /// given:  open in top left of frame
        /// further code required:
        /// </summary>
        private void frmHistory_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// Get transactions for customers bank account
        /// </summary>
        private void TransactionQuery()
        {
            var query = 
            from t in db.Transactions
            join tt in db.TransactionTypes on t.TransactionTypeId equals tt.TransactionTypeId
            where t.BankAccountId == constructorData.BankAccountEntity.BankAccountId
            select new
            {
                t.DateCreated,
                tt.Description,
                t.Deposit,
                t.Withdrawal,
                t.Notes
            };

            transactionBindingSource.DataSource = query.ToList();
        }
    }
}
