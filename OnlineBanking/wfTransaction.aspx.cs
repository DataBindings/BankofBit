using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;
using Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking
{
    /// <summary>
    /// Represents a wfTransfer web form.
    /// </summary>
    public partial class wfTransaction : System.Web.UI.Page
    {
        protected BankOfBIT_JP.Data.BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private WebService.TransactionManagerClient bankService = new WebService.TransactionManagerClient();
        private IQueryable<TransactionType> transactionTypeQuery;
        private IQueryable<Payee> payeeQuery;
        private IQueryable<BankAccount> accountQuery;
        
        /// <summary>
        /// Handles the page load event
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    try
                    {
                        DatabaseQuery();
                        BindControls();
                    }
                    catch (Exception ex)
                    {
                        lblError.Visible = true;
                        lblError.Text = ex.Message;
                    }
                }
            }
        }

        /// <summary>
        /// Preforms database query
        /// </summary>
        public void DatabaseQuery()
        {
            payeeQuery = db.Payees;
            transactionTypeQuery = db.TransactionTypes.Where(x => x.TransactionTypeId >= 3 
                                                               && x.TransactionTypeId <= 4);
        }

        /// <summary>
        /// Sets event handler subscriptions.
        /// </summary>
        public void BindControls()
        {
            lblAccountNumber.Text = "Account Number:  " + Session["AccountNumber"].ToString();
            lblBalance.Text = "Balance:  " + Session["Balance"].ToString();
            tbAmount.Style.Add("text-align", "right");

            ddlTransferType.DataSource = transactionTypeQuery.ToList();
            ddlTransferType.DataTextField = "Description";
            ddlTransferType.DataValueField = "TransactionTypeId";

            ddlPayee.DataSource = payeeQuery.ToList();
            ddlPayee.DataTextField = "Description";
            ddlPayee.DataValueField = "PayeeID";

            this.DataBind();
        }

        /// <summary>
        /// Handles the index changed event of the transfer type drop down list
        /// </summary>
        protected void ddlTransferType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long clientId = (long)Session["ClientId"];
                int accountId = (int)Session["BankAccountId"];

                ddlPayee.DataSource = null;
                ddlPayee.DataTextField = null;
                ddlPayee.DataValueField = null;

                switch (int.Parse(ddlTransferType.SelectedValue))
                {
                    case (int)TransactionTypeValues.BillPayment:
                        payeeQuery = db.Payees;
                        ddlPayee.DataSource = payeeQuery.ToList();
                        ddlPayee.DataTextField = "Description";
                        ddlPayee.DataValueField = "PayeeID";
                        break;
                    case (int)TransactionTypeValues.Transfer:
                        accountQuery = db.BankAccounts.Where(x => x.Client.ClientNumber == clientId)
                                                      .Where(x => x.BankAccountId != accountId);
                        ddlPayee.DataSource = accountQuery.ToList();
                        ddlPayee.DataTextField = "AccountNumber";
                        ddlPayee.DataValueField = "BankAccountId";
                        break;
                }
                this.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }

        /// <summary>
        /// Handles the click event of the account history link button
        /// </summary>
        protected void lnkbtnAccountHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/wfAccount.aspx");
        }

        /// <summary>
        /// Handles the click event of the complete transaction link button
        /// </summary>
        protected void lnkbtnCompleteTransaction_Click(object sender, EventArgs e)
        {
            if (tbAmount.Text != string.Empty)
            {
                try
                {
                    int bankAccountId = int.Parse(StringTools.RemoveSpecialCharactors(Session["BankAccountId"].ToString()));
                    double currentBalance = double.Parse(StringTools.RemoveSpecialCharactors(Session["Balance"].ToString()));
                    double amount = double.Parse(tbAmount.Text);
                    double? accountBalance = null;

                    if (currentBalance < amount)
                    {
                        throw new Exception("Insufficient Funds");
                    }
                    switch (int.Parse(ddlTransferType.SelectedValue))
                    {
                        case (int)TransactionTypeValues.BillPayment:
                            string billPaymentNote = "Bill Payment to " + ddlPayee.SelectedItem.Text;
                            accountBalance = bankService.BillPayment(bankAccountId, amount, billPaymentNote);
                            break;
                        case (int)TransactionTypeValues.Transfer:
                            int toAccountNumber = int.Parse(ddlPayee.SelectedValue);
                            string moneyTransferNote = "Money Transfer from " + Session["AccountNumber"].ToString() + " to " + ddlPayee.SelectedItem.Text;
                            accountBalance = bankService.Transfers(bankAccountId, toAccountNumber, amount, moneyTransferNote);
                            break;
                    }
                    if (accountBalance != null)
                    {
                        Session["Balance"] = String.Format("{0:C}", accountBalance);
                        lblBalance.Text = "Balance:  " + Session["Balance"].ToString();
                    }
                    else
                    {
                        throw new Exception("Transaction Failed");
                    }
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = ex.Message;
                }
            }
        }
    }
}
