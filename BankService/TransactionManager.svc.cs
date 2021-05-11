using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;
using Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    /// <summary>
    /// Represents a transaction manager class.
    /// </summary>
    public class TransactionManager : ITransactionManager
    {
        private BankOfBIT_JPContext db = new BankOfBIT_JPContext();

        /// <summary>
        /// Edits a client's bank account.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="amount">The amount of a transaction.</param>
        /// <returns>A client's bank account.</returns>
        private BankAccount EditBankAccount(int accountId, double amount, TransactionTypeValues type)
        {
            BankAccount bankAccount = db.BankAccounts.Where(result => result.BankAccountId == accountId).SingleOrDefault();

            switch (type)
            {
                case TransactionTypeValues.Deposit:
                case TransactionTypeValues.TransferRecipient:
                    bankAccount.Balance += amount;
                    break;
                case TransactionTypeValues.Withdrawal:
                case TransactionTypeValues.BillPayment:
                case TransactionTypeValues.Transfer:
                    bankAccount.Balance -= amount;
                    break;
                case TransactionTypeValues.CalculateInterest:
                    if (bankAccount.Balance < 0)
                    {
                        bankAccount.Balance -= amount;
                    }
                    if (bankAccount.Balance > 0)
                    {
                        bankAccount.Balance += amount;
                    }
                    break;
            }

            return bankAccount;
        }

        /// <summary>
        /// Creates a client's bank account transaction.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="type">The type of transaction.</param>
        /// <param name="amount">The amount of a transaction.</param>
        /// <param name="notes">The note of a transaction.</param>
        /// <returns>A client's bank transaction.</returns>
        private Transaction CreateTransaction(int accountId, TransactionTypeValues type, double amount, string notes)
        {
            Transaction transaction = new Transaction();
            transaction.BankAccountId = accountId;
            transaction.SetNextTransactionNumber();
            transaction.TransactionTypeId = (int)type;
            transaction.Notes = notes;
            transaction.DateCreated = DateTime.Today;
            transaction.Deposit = 0;
            transaction.Withdrawal = 0;

            switch (type)
            {
                case TransactionTypeValues.Deposit:
                case TransactionTypeValues.TransferRecipient:
                    transaction.Deposit = amount;
                    break;
                case TransactionTypeValues.Withdrawal:
                case TransactionTypeValues.BillPayment:
                case TransactionTypeValues.Transfer:
                case TransactionTypeValues.CalculateInterest:
                    transaction.Withdrawal = amount;
                    break;
            }
            return transaction;
        }

        /// <summary>
        /// Updates the database after a client's transaction.
        /// </summary>
        /// <param name="bankAccount">The bank account of a client.</param>
        /// <param name="transaction">The transaction of a client.</param>
        private void UpdateDatabase(BankAccount bankAccount, Transaction transaction)
        {
            bankAccount.ChangeState();
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        /// <summary>
        /// Deposit transaction of a client.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="amount">The amount of a deposit.</param>
        /// <param name="notes">The notes of a deposit.</param>
        /// <returns>A client's bank account balance.</returns>
        public double? Deposit(int accountId, double amount, string notes)
        {
            BankAccount bankAccount;
            Transaction transaction;
            try
            {
                bankAccount = EditBankAccount(accountId, amount, TransactionTypeValues.Deposit);
                transaction = CreateTransaction(accountId, TransactionTypeValues.Deposit, amount, notes);
                UpdateDatabase(bankAccount, transaction);
            }

            catch
            {
                return null;
            }

            return bankAccount.Balance;
        }

        /// <summary>
        /// Withdrawal transaction of a client.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="amount">The amount of a withdrawal.</param>
        /// <param name="notes">The notes of a withdrawal.</param>
        /// <returns>A client's bank account balance.</returns>
        public double? Withdrawal(int accountId, double amount, string notes)
        {
            BankAccount bankAccount;
            Transaction transaction;
            try
            {
                bankAccount = EditBankAccount(accountId, amount, TransactionTypeValues.Transfer);
                transaction = CreateTransaction(accountId, TransactionTypeValues.Withdrawal, amount, notes);
                UpdateDatabase(bankAccount, transaction);
            }
            catch
            {
                return null;
            }
            return bankAccount.Balance;
        }

        /// <summary>
        /// Bill payment transaction of a client.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="amount">The amount of a bill payment.</param>
        /// <param name="notes">The notes of a bill payment.</param>
        /// <returns>A client's bank account balance.</returns>
        public double? BillPayment(int accountId, double amount, string notes)
        {
            BankAccount bankAccount;
            Transaction transaction;
            try
            {
                bankAccount = EditBankAccount(accountId, amount, TransactionTypeValues.BillPayment);
                transaction = CreateTransaction(accountId, TransactionTypeValues.BillPayment, amount, notes);
                UpdateDatabase(bankAccount, transaction);
            }
            catch
            {
                return null;
            }

            return bankAccount.Balance;
        }

        /// <summary>
        /// Transfer between a client's accounts.
        /// </summary>
        /// <param name="fromAccountId">A client's origin account id.</param>
        /// <param name="toAccountId">A client's destination account id.</param>
        /// <param name="amount">The amount of a transfer.</param>
        /// <param name="notes">The note of a transfer.</param>
        /// <returns>The client's origin bank account balance.</returns>
        public double? Transfers(int fromAccountId, int toAccountId, double amount, string notes)
        {
            BankAccount bankAccount;
            Transaction transaction;
            BankAccount toBankAccount;
            Transaction toTransaction;

            try
            {
                bankAccount = EditBankAccount(fromAccountId, amount, TransactionTypeValues.Transfer);
                transaction = CreateTransaction(fromAccountId, TransactionTypeValues.Transfer, amount, notes);
                UpdateDatabase(bankAccount, transaction);

                toBankAccount = EditBankAccount(toAccountId, amount, TransactionTypeValues.TransferRecipient);
                toTransaction = CreateTransaction(toAccountId, TransactionTypeValues.TransferRecipient, amount, notes);
                UpdateDatabase(toBankAccount, toTransaction);
            }

            catch
            {
                return null;
            }

            return bankAccount.Balance;
        }

        /// <summary>
        /// Calculates interest of a client's account.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="notes">The note of a interest calculation.</param>
        /// <returns>A client's bank account balance.</returns>
        public double? CalculateInterest(int accountId, string notes)
        {
            BankAccount bankAccount;
            BankAccount bankAccountReturn;
            Transaction transaction;
            
            try
            {
                double amount;

                bankAccount = db.BankAccounts.Where(result => result.BankAccountId == accountId).SingleOrDefault();
                amount = bankAccount.AccountState.Rate * bankAccount.Balance * 1 / 12;
                bankAccountReturn = EditBankAccount(accountId, amount, TransactionTypeValues.CalculateInterest);
                transaction = CreateTransaction(accountId, TransactionTypeValues.CalculateInterest, amount, notes);
                UpdateDatabase(bankAccountReturn, transaction);
            }
            catch
            {
                return null;
            }
            return bankAccountReturn.Balance;
        }
    }
}
