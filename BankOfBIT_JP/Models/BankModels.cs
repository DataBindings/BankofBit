using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;
using BankOfBIT_JP.Data;
using System.Data.SqlClient;
using System.Data;

namespace BankOfBIT_JP.Models
{
    #region Payee
    /// <summary>
    /// Payee Model - Represents Payee table in database.
    /// </summary>
    public class Payee
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PayeeId { get; set; }

        [Required]
        [Display(Name = "Payee")]
        public string Description { get; set; }
    }

    #endregion

    #region Institution

    /// <summary>
    /// Institution Model - Represents Institution table in database.
    /// </summary>
    public class Institution
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InstitutionId { get; set; }

        [Display(Name = "Institution\nNumber")]
        public int InstitutionNumber { get; set; }

        [Display(Name = "Institution")]
        public string Description { get; set; }
    }

    #endregion

    #region Transaction

    /// <summary>
    /// Institution Model - Represents Institution table in database.
    /// </summary>
    public class Transaction
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Display(Name = "Transaction\nNumber")]
        public long TransactionNumber { get; set; }

        [Required]
        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }

        [Required]
        [ForeignKey("TransactionType")]
        [Display(Name = "Transaction\nType")]
        public int TransactionTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Deposit { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Withdrawal { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Date\nCreated")]
        public DateTime DateCreated { get; set; }

        public string Notes { get; set; }

        /// <summary>
        /// Sets the next transaction number
        /// </summary>
        public void SetNextTransactionNumber()
        {
            TransactionNumber = (long)StoredProcedures.NextNumber("NextTransactionNumbers");
        }

        /// <summary>
        /// Navigation property - A transaction can belong to 
        /// a single transaction type (represents 1 on class diagram)
        /// </summary>
        [Display(Name = "Transaction\nType")]
        public virtual TransactionType TransactionType { get; set; }

        /// <summary>
        /// Navigation property - A transaction can belong to 
        /// a single bank account (represents 1 on class diagram)
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }

    }

    /// <summary>
    /// Transaction Type Model - Represents transaction type table in database.
    /// </summary>
    public class TransactionType
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }

        [Display(Name = "Transaction\nType")]
        public string Description { get; set; }

        [Display(Name = "Service\nCharges")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double ServiceCharges { get; set; }

    }

    /// <summary>
    /// NextTransactionNumber Model - Represents next transaction number table in database.
    /// </summary>
    public class NextTransactionNumber
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextTransactionNumberId { get; set; }
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private static NextTransactionNumber nextTransactionNumber;

        /// <summary>
        /// Initializes an instance of a next transaction number class.
        /// </summary>
        private NextTransactionNumber()
        {
            NextAvailableNumber = 700;
        }

        /// <summary>
        /// Gets an instance of a next transaction number class.
        /// </summary>
        /// <returns>The next transaction number instance.</returns>
        public static NextTransactionNumber GetInstance()
        {
            if (nextTransactionNumber == null)
            {
                nextTransactionNumber = db.NextTransactionNumbers.SingleOrDefault();

                if (nextTransactionNumber == null)
                {
                    NextTransactionNumber nextTransactionNumber = new NextTransactionNumber();
                    db.NextTransactionNumbers.Add(nextTransactionNumber);
                    db.SaveChanges();
                }
            }
            return nextTransactionNumber;
        }
    }



    #endregion

    #region BankAccount

    /// <summary>
    /// BankAccount Model - Represents bank account table in database.
    /// </summary>
    public abstract class BankAccount
    {
        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        [Display(Name = "Account\nNumber")]
        public long AccountNumber { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey("AccountState")]
        public int AccountStateId { get; set; }

        [Required]
        [Display(Name = "Current\nBalance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Balance { get; set; }

        [Required]
        [Display(Name = "Opening\nBalance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double OpeningBalance { get; set; }

        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Account\nNotes")]
        public String Notes { get; set; }

        /// <summary>
        /// Gets the account state description.
        /// </summary>
        [Display(Name = "Account\nType")]
        public String Description
        {
            get
            {
                return StringTools.RemovePhrase(GetType().Name, "Account");
            }
        }

        public abstract void SetNextAccountNumber();

        /// <summary>
        /// A check to determine if a state will change.
        /// </summary>
        public void ChangeState()
        {
            AccountState currentAccount = null;

            do
            {
                currentAccount = db.AccountStates.Find(this.AccountStateId);
                currentAccount.StateChangeCheck(this);
            }
            while (!this.AccountStateId.Equals(currentAccount.AccountStateId));
        }

        /// <summary>
        /// Navigation property - A bank account can belong to 
        /// a single client (represents 1 on class diagram)
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Navigation property - A bank account can belong to 
        /// a single account state (represents 1 on class diagram)
        /// </summary>
        public virtual AccountState AccountState { get; set; }

        /// <summary>
        /// Navigation property - A bank account can belong to 
        /// zero or many transactions (represents 0* on class diagram)
        /// </summary>
        public virtual ICollection<Transaction> Transaction { get; set; }

    }

    /// <summary>
    /// ChequingAccount Model - Represents chequing account table in database.
    /// </summary>
    public class ChequingAccount : BankAccount
    {
        [Required]
        [Display(Name = "Service\nCharges")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double ChequingServiceCharges { get; set; }

        /// <summary>
        /// Sets the next chequing account number.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedures.NextNumber("NextChequingAccounts");
        }
    }

    /// <summary>
    /// SavingsAccount Model - Represents savings account table in database.
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        [Required]
        [Display(Name = "Service\nCharges")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double SavingsServiceCharges { get; set; }

        /// <summary>
        /// Sets the next savings account number
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedures.NextNumber("NextSavingsAccounts");
        }
    }

    /// <summary>
    /// InvestmentAccount Model - Represents investment account table in database.
    /// </summary>
    public class InvestmentAccount : BankAccount
    {
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public double InterestRate { get; set; }

        /// <summary>
        /// Sets the next investment account number.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedures.NextNumber("NextInvestmentAccounts");
        }
    }

    /// <summary>
    /// MortgageAccount Model - Represents mortgage account table in database.
    /// </summary>
    public class MortgageAccount : BankAccount
    {
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public double MortgageRate { get; set; }

        [Required]
        [Display(Name = "Amortization")]
        public int Amortization { get; set; }

        /// <summary>
        /// Sets the next mortgage account number.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            AccountNumber = (long)StoredProcedures.NextNumber("NextMortgageAccounts");
        }
    }

    /// <summary>
    /// NextSavingsAccount Model - Represents next savings account table in database.
    /// </summary>
    public class NextSavingsAccount
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextSavingsAccountId { get; set; }
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private static NextSavingsAccount nextSavingsAccount;

        /// <summary>
        /// Initializes an instance of a next savings account class.
        /// </summary>
        private NextSavingsAccount()
        {
            NextAvailableNumber = 20000;
        }

        /// <summary>
        /// Gets an instance of a next savings account class.
        /// </summary>
        /// <returns>The next savings account instance.</returns>
        public static NextSavingsAccount GetInstance()
        {
            if (nextSavingsAccount == null)
            {
                nextSavingsAccount = db.NextSavingsAccounts.SingleOrDefault();

                if (nextSavingsAccount == null)
                {
                    nextSavingsAccount = new NextSavingsAccount();
                    db.NextSavingsAccounts.Add(nextSavingsAccount);
                    db.SaveChanges();
                }
            }
            return nextSavingsAccount;
        }
    }

    /// <summary>
    /// NextMortgageAccount Model - Represents next mortgage account table in database.
    /// </summary>
    public class NextMortgageAccount
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextMortgageAccountId { get; set; }
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private static NextMortgageAccount nextMortgageAccount;

        /// <summary>
        /// Initializes an instance of a next mortgage account class.
        /// </summary>
        private NextMortgageAccount()
        {
            NextAvailableNumber = 200000;
        }

        /// <summary>
        /// Gets an instance of a next mortgage account class.
        /// </summary>
        /// <returns>The next mortgage account instance.</returns>
        public static NextMortgageAccount GetInstance()
        {
            if (nextMortgageAccount == null)
            {
                nextMortgageAccount = db.NextMortgageAccounts.SingleOrDefault();

                if (nextMortgageAccount == null)
                {
                    nextMortgageAccount = new NextMortgageAccount();
                    db.NextMortgageAccounts.Add(nextMortgageAccount);
                    db.SaveChanges();
                }
            }
            return nextMortgageAccount;
        }
    }

    /// <summary>
    /// NextInvestmentAccount Model - Represents next investment account table in database.
    /// </summary>
    public class NextInvestmentAccount
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextInvestmentAccountId { get; set; }
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private static NextInvestmentAccount nextInvestmentAccount;

        /// <summary>
        /// Initializes an instance of a next investment account class.
        /// </summary>
        private NextInvestmentAccount()
        {
            NextAvailableNumber = 2000000;
        }

        /// <summary>
        /// Gets an instance of a next investment account class.
        /// </summary>
        /// <returns>The next investment account instance.</returns>
        public static NextInvestmentAccount GetInstance()
        {
            if (nextInvestmentAccount == null)
            {
                nextInvestmentAccount = db.NextInvestmentAccounts.SingleOrDefault();

                if (nextInvestmentAccount == null)
                {
                    nextInvestmentAccount = new NextInvestmentAccount();
                    db.NextInvestmentAccounts.Add(nextInvestmentAccount);
                    db.SaveChanges();
                }
            }
            return nextInvestmentAccount;
        }
    }

    /// <summary>
    /// NextChequingAccount Model - Represents next chequing account table in database.
    /// </summary>
    public class NextChequingAccount
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextChequingAccountId { get; set; }
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private static NextChequingAccount nextChequingAccount;

        /// <summary>
        /// Initializes an instance of a next chequing account class.
        /// </summary>
        private NextChequingAccount()
        {
            NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Gets an instance of a next chequing account class.
        /// </summary>
        /// <returns>The next chequing account instance.</returns>
        public static NextChequingAccount GetInstance()
        {
            if (nextChequingAccount == null)
            {
                nextChequingAccount = db.NextChequingAccounts.SingleOrDefault();

                if (nextChequingAccount == null)
                {
                    nextChequingAccount = new NextChequingAccount();
                    db.NextChequingAccounts.Add(nextChequingAccount);
                    db.SaveChanges();
                }
            }
            return nextChequingAccount;
        }
    }

    #endregion

    #region AccountState

    /// <summary>
    /// AccountState Model - Represents account state table in database.
    /// </summary>
    public abstract class AccountState
    {
        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountStateId { get; set; }

        [Display(Name = "Lower\nLimit")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double LowerLimit { get; set; }

        [Display(Name = "Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double UpperLimit { get; set; }

        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public double Rate { get; set; }

        /// <summary>
        /// Get the account state description.
        /// </summary>
        [Display(Name = "Account\nState")]
        public String Description
        {
            get
            {
                string name = GetType().Name;
                string phrase = "State";
                return StringTools.RemovePhrase(name, phrase);
            }
        }

        /// <summary>
        /// The current implementation is not complete.
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        public virtual double RateAdjustment(BankAccount bankAccount)
        {
            return 0;
        }

        /// <summary>
        /// The current implementation is not complete.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public virtual void StateChangeCheck(BankAccount bankAccount)
        {

        }

        /// <summary>
        /// Navigation property - An account state can belong to 
        /// zero or many bank accounts (represents 0-* on class diagram)
        /// </summary>
        public virtual ICollection<BankAccount> BankAccount { get; set; }

    }

    /// <summary>
    /// BronzeState Model - Represents bronze state table in database.
    /// </summary>
    public class BronzeState : AccountState
    {
        private static BronzeState bronzeState;

        /// <summary>
        /// Initializes an instance of a bronze state class.
        /// </summary>
        private BronzeState()
        {
            LowerLimit = 0;
            UpperLimit = 5000;
            Rate = 0.01;
        }

        /// <summary>
        /// Gets an instance of a bronze state class.
        /// </summary>
        /// <returns>The state of bronze.</returns>
        public static BronzeState GetInstance()
        {

            if (bronzeState == null)
            {
                bronzeState = db.BronzeState.SingleOrDefault();

                if (bronzeState == null)
                {
                    BronzeState bronzeState = new BronzeState();
                    db.AccountStates.Add(bronzeState);
                    db.SaveChanges();
                }
            }

            return bronzeState;
        }

        /// <summary>
        /// Gets a rate adjustment of a bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The rate adjustment of a bank account.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double rate;
            if (bankAccount.Balance <= 0)
            {
                rate = 0.055;
            }

            else
            {
                rate = 0.01;
            }

            return rate;
        }

        /// <summary>
        /// A check to determine if a state will change.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Description != "Mortgage")
            {
                if (bankAccount.Balance > this.UpperLimit)
                {
                    bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
                }
            }
        }
    }

    /// <summary>
    /// GoldState Model - Represents gold state table in database.
    /// </summary>
    public class GoldState : AccountState
    {
        private static GoldState goldState;

        /// <summary>
        /// Initializes an instance of a gold state class.
        /// </summary>
        private GoldState()
        {
            LowerLimit = 10000;
            UpperLimit = 20000;
            Rate = 0.02;
        }

        /// <summary>
        /// Gets an instance of a gold state class.
        /// </summary>
        /// <returns>The gold state instance.</returns>
        public static GoldState GetInstance()
        {
            if (goldState == null)
            {
                goldState = db.GoldState.SingleOrDefault();

                if (goldState == null)
                {
                    goldState = new GoldState();
                    db.AccountStates.Add(goldState);
                    db.SaveChanges();
                }
            }
            return goldState;
        }

        /// <summary>
        /// Gets the rate adjustment of a bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The rate adjustment of a bank account.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            int numberOfDays = NumberTools.DaysBetween(DateTime.Now, bankAccount.DateCreated);
            double rateAdjust = Rate;

            if (numberOfDays == 3650)
            {
                rateAdjust += 0.01;
            }

            return rateAdjust;
        }

        /// <summary>
        /// A check to determine if a state will change.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Description != "Mortgage")
            {
                if (bankAccount.Balance > this.UpperLimit)
                {
                    bankAccount.AccountStateId = PlatinumState.GetInstance().AccountStateId;
                }

                if (bankAccount.Balance < this.LowerLimit)
                {
                    bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;
                }
            }
        }
    }

    /// <summary>
    /// SilverState Model - Represents silver state table in database.
    /// </summary>
    public class SilverState : AccountState
    {
        private static SilverState silverState;

        /// <summary>
        /// Initializes an instance of a sliver state class.
        /// </summary>
        private SilverState()
        {
            LowerLimit = 5000;
            UpperLimit = 10000;
            Rate = 0.0125;
        }

        /// <summary>
        /// Gets an instance of a silver state class.
        /// </summary>
        /// <returns>The silver state instance.</returns>
        public static SilverState GetInstance()
        {
            if (silverState == null)
            {
                silverState = db.SilverState.SingleOrDefault();

                if (silverState == null)
                {
                    silverState = new SilverState();
                    db.AccountStates.Add(silverState);
                    db.SaveChanges();
                }
            }
            return silverState;
        }

        /// <summary>
        /// Gets a rate adjustment of a bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The rate adjustment of a bank account.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            return base.RateAdjustment(bankAccount);
        }

        /// <summary>
        /// A check to determine if a state will change.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Description != "Mortgage")
            {
                if (bankAccount.Balance > this.UpperLimit)
                {
                    bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
                }

                if (bankAccount.Balance < this.LowerLimit)
                {
                    bankAccount.AccountStateId = BronzeState.GetInstance().AccountStateId;
                }
            }
        }
    }

    /// <summary>
    /// PlatinumState Model - Represents platinum state table in database.
    /// </summary>
    public class PlatinumState : AccountState
    {
        private static PlatinumState platinumState;

        /// <summary>
        /// Initializes an instance of a platinum state class.
        /// </summary>
        private PlatinumState()
        {
            LowerLimit = 20000;
            UpperLimit = 0;
            Rate = 0.0250;
        }

        /// <summary>
        /// Gets an instance of a platinum state class.
        /// </summary>
        /// <returns>The platinum state instance.</returns>
        public static PlatinumState GetInstance()
        {
            if (platinumState == null)
            {
                platinumState = db.PlatinumState.SingleOrDefault();

                if (platinumState == null)
                {
                    platinumState = new PlatinumState();
                    db.AccountStates.Add(platinumState);
                    db.SaveChanges();
                }
            }
            return platinumState;
        }

        /// <summary>
        /// Gets a rate adjustment of a bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns>The rate adjustment of a bank account.</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            bool balanceRate = false;
            double rate = Rate;
            int numberOfDays = NumberTools.DaysBetween(DateTime.Now, bankAccount.DateCreated);
            if (numberOfDays == 3650)
            {
                rate += 0.01;
            }

            if (bankAccount.Balance >= (platinumState.LowerLimit * 2))
            {
                balanceRate = true;
                rate += 0.005;
            }

            if (balanceRate && bankAccount.Balance < (platinumState.LowerLimit * 2))
            {
                balanceRate = false;
                rate -= 0.005;
            }

            return rate;
        }

        /// <summary>
        /// A check to determine if a state will change.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Description != "Mortgage")
            {
                if (bankAccount.Balance < this.LowerLimit)
                {
                    bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;
                }
            }
        }
    }

    #endregion

    #region Client

    /// <summary>
    /// Client Model - Represents client table in database.
    /// </summary>
    public class Client
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Display(Name = "Client")]
        public long ClientNumber { get; set; }

        [Required]
        [Display(Name = "First\nName")]
        [StringLength(35, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last\nName")]
        [StringLength(35, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Street\nAddress")]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Province")]
        [RegularExpression("^[AB|BC|MB|N{BLTSU}|ON|PE|QC|SK|YT]{2}", ErrorMessage = "Invalid Canadian province code.")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Postal\nCode")]
        [RegularExpression("^[ABCEGHJKLMNPRSTVXY][0-9][A-Z] [0-9][A-Z][0-9]", ErrorMessage = "Invalid Canadian postal code.")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Client\nNotes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets the first and last name of a client.
        /// </summary>
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        /// <summary>
        /// Get the full address of a client.
        /// </summary>
        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return String.Format("{0} {1}, {2} {3}", Address, City, Province, PostalCode);
            }
        }

        /// <summary>
        /// Sets the next client number.
        /// </summary>
        public void SetNextClientNumber()
        {
            ClientNumber = (long)StoredProcedures.NextNumber("NextClientNumbers");
        }

        /// <summary>
        /// Navigation property - A client can belong to 
        /// zero or many bank accounts (represents 0-* on class diagram)
        /// </summary>
        public virtual ICollection<BankAccount> BankAccount { get; set; }
    }

    /// <summary>
    /// NextClientNumber Model - Represents next client number table in database.
    /// </summary>
    public class NextClientNumber
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextClientNumberId { get; set; }
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private static NextClientNumber nextClientNumber;

        /// <summary>
        /// Initializes an instance of a next client number class.
        /// </summary>
        private NextClientNumber()
        {
            NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Gets an instance of a next client number class.
        /// </summary>
        /// <returns>The next client number instance.</returns>
        public static NextClientNumber GetInstance()
        {
            if (nextClientNumber == null)
            {
                nextClientNumber = db.NextClientNumbers.SingleOrDefault();

                if (nextClientNumber == null)
                {
                    nextClientNumber = new NextClientNumber();
                    db.NextClientNumbers.Add(nextClientNumber);
                    db.SaveChanges();
                }
            }
            return nextClientNumber;
        }
    }


    #endregion

    #region RFIDTag

    /// <summary>
    /// RFIDTag Model - Represents RFID tag table in database.
    /// </summary>
    public class RFIDTag
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RFIDTagId { get; set; }

        [Display(Name = "CardId")]
        public long CardNumber { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        /// <summary>
        /// Navigation property - A RFID tag can belong to 
        /// a single client (represents 1 on class diagram)
        /// </summary>
        [Display(Name = "Client")]
        public virtual Client Client { get; set; }
    }

    #endregion

    #region StoredProcedures

    /// <summary>
    /// Stored Procedures - Represents stored procedures class.
    /// </summary>
    public static class StoredProcedures
    {
        /// <summary>
        /// Get the next number to increment database table creation
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <returns>The next number of the table</returns>
        public static long? NextNumber(string tableName)
        {
            // sets the default return value 0 to a long data type that is nullable
            long? returnValue = 0;

            try
            {
                // Initializes an instance of sql connection class with the source local host and database BankOfBIT_JPContext
                SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BankOfBIT_JPContext;Integrated Security=True");

                // Initializes an instance of sql command class with the sql script next_number and sql connection to database BankOfBIT_JPContext
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);

                // sets the sql command type to stored procedure
                storedProcedure.CommandType = CommandType.StoredProcedure;

                // adds the stored procedure parameters to include specified table. 
                storedProcedure.Parameters.AddWithValue("@TableName", tableName);

                //  Initializes an instance sql parameter class with the new value as an int
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                {
                    // sets sql parameter direction to output
                    Direction = ParameterDirection.Output
                };

                // adds the output parameter to stored procedure 
                storedProcedure.Parameters.Add(outputParameter);

                // opens the connection to database BankOfBIT_JPContext
                connection.Open();

                // executes sql script next_number against database BankOfBIT_JPContext
                storedProcedure.ExecuteNonQuery();

                // closes the connection to database BankOfBIT_JPContext
                connection.Close();

                // casts output parameter value to long and updates return value
                returnValue = (long?)outputParameter.Value;

            }
            catch
            {
                // If there is an error return the value null
                returnValue = null;
            }

            return returnValue;
        }
    }
    #endregion
}