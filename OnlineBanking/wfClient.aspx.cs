using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;
using Utility;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBanking
{
    /// <summary>
    /// Represents a wfClient web form.
    /// </summary>
    public partial class wfClient : System.Web.UI.Page
    {
        protected BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        protected IQueryable<BankAccount> accountQuery;

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
            gvClient.SelectedIndexChanged += new EventHandler(gvClient_SelectedIndexChanged);
        }

        /// <summary>
        /// Preforms database query
        /// </summary>
        public void DatabaseQuery()
        {
            // Grab the client number from users login
            long clientNumber = long.Parse(StringTools.RemovePhrase(User.Identity.Name, "@bank.of.bit"));

            // Query database for client's bank accounts
            accountQuery = db.BankAccounts.Where(result => result.Client.ClientNumber == clientNumber);
            Client client = db.Clients.Where(result => result.ClientNumber == clientNumber).SingleOrDefault();

            Session["ClientId"] = clientNumber;
            Session["FullName"] = client.FullName;
        }

        /// <summary>
        /// Sets event handler subscriptions.
        /// </summary> 
        public void BindControls()
        {
            lblFullName.Text = Session["FullName"].ToString();
            gvClient.DataSource = accountQuery.ToList();
            this.DataBind();
        }

        /// <summary>
        /// Detects when selected gv client index has changed
        /// </summary>
        protected void gvClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            long clientNumber = long.Parse(StringTools.RemovePhrase(User.Identity.Name, "@bank.of.bit"));
            accountQuery = db.BankAccounts.Where(result => result.Client.ClientNumber == clientNumber);

            // Assigning session variables
            Session["AccountNumber"] = gvClient.Rows[gvClient.SelectedIndex].Cells[1].Text;
            Session["Balance"] = gvClient.Rows[gvClient.SelectedIndex].Cells[3].Text;
            Session["BankAccountId"] = accountQuery.Select(result => result.BankAccountId).ToList()[gvClient.SelectedIndex];

            // Redirect to account
            Response.Redirect("~/wfAccount.aspx");
        }
    }
}