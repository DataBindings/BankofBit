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
    /// Represents a wfAccount web form.
    /// </summary>
    public partial class wfAccount : System.Web.UI.Page
    {
        protected BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        protected IQueryable<Transaction> transactionQuery;

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
                        SetEventsHandlerSubscriptions();
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
        /// Sets event handler subscriptions.
        /// </summary>
        public void SetEventsHandlerSubscriptions()
        {
            lnkbtnClientWebForm.Click += new EventHandler(lnkbtnClientWebForm_Click);
            lnkbtnTransactionWebForm.Click += new EventHandler(lnkbtnTransactionWebForm_Click);
        }

        /// <summary>
        /// Preforms database query
        /// </summary>
        public void DatabaseQuery()
        {
            // Query database for client's transactions
            int bankAccountId = (int)Session["BankAccountId"];
            transactionQuery = db.Transactions.Where(result => result.BankAccountId == bankAccountId);
        }

        /// <summary>
        /// Sets event handler subscriptions.
        /// </summary>
        public void BindControls()
        {
            lblFullName.Text = Session["FullName"].ToString();
            lblAccountNumber.Text = "Account Number:  " + Session["AccountNumber"].ToString();
            lblBalance.Text = "Balance:  " + Session["Balance"].ToString();
            gvAccount.DataSource = transactionQuery.ToList();
            this.DataBind();
        }

        /// <summary>
        /// Detects when selected link button has been clicked
        /// </summary>
        protected void lnkbtnClientWebForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/wfClient.aspx");
        }

        /// <summary>
        /// Detects when selected link button has been clicked
        /// </summary>
        protected void lnkbtnTransactionWebForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/wfTransaction.aspx");
        }
    }
}
    
