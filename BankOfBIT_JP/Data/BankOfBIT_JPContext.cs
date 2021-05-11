using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankOfBIT_JP.Data
{
    public class BankOfBIT_JPContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public BankOfBIT_JPContext() : base("name=BankOfBIT_JPContext")
        {
        }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.AccountState> AccountStates { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.BronzeState> BronzeState { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.SilverState> SilverState { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.GoldState> GoldState { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.PlatinumState> PlatinumState { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.BankAccount> BankAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.SavingsAccount> SavingsAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.InvestmentAccount> InvestmentAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.MortgageAccount> MortgageAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.ChequingAccount> ChequingAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.TransactionType> TransactionTypes { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.RFIDTag> RFIDTags { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.Payee> Payees { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.Institution> Institutions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.NextTransactionNumber> NextTransactionNumbers { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.NextClientNumber> NextClientNumbers { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.NextSavingsAccount> NextSavingsAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.NextMortgageAccount> NextMortgageAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.NextInvestmentAccount> NextInvestmentAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_JP.Models.NextChequingAccount> NextChequingAccounts { get; set; }
    }
}
