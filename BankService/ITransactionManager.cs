using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    /// <summary>
    /// Represents a transaction manager interface.
    /// </summary>
    [ServiceContract]
    public interface ITransactionManager
    {
        /// <summary>
        /// Deposit transaction of a client.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="amount">The amount of a deposit.</param>
        /// <param name="notes">The notes of a deposit.</param>
        /// <returns>A client's bank account balance.</returns>
        [OperationContract]
        double? Deposit(int accountId, double amount, string notes);

        /// <summary>
        /// Withdrawal transaction of a client.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="amount">The amount of a withdrawal.</param>
        /// <param name="notes">The notes of a withdrawal.</param>
        /// <returns>A client's bank account balance.</returns>
        [OperationContract]
        double? Withdrawal(int accountId, double amount, string notes);

        /// <summary>
        /// Bill payment transaction of a client.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="amount">The amount of a bill payment.</param>
        /// <param name="notes">The notes of a bill payment.</param>
        /// <returns>A client's bank account balance.</returns>
        [OperationContract]
        double? BillPayment(int accountId, double amount, string notes);

        /// <summary>
        /// Transfer between a client's accounts.
        /// </summary>
        /// <param name="fromAccountId">A client's origin account id.</param>
        /// <param name="toAccountId">A client's destination account id.</param>
        /// <param name="amount">The amount of a transfer.</param>
        /// <param name="notes">The note of a transfer.</param>
        /// <returns>The client's origin bank account balance.</returns>
        [OperationContract]
        double? Transfers(int fromAccountId, int toAccountId, double amount, string notes);

        /// <summary>
        /// This method is a place holder and currently not implemented
        /// Calculates interest of a client's account.
        /// </summary>
        /// <param name="accountId">A client's account id.</param>
        /// <param name="notes">The note of a interest calculation.</param>
        /// <returns>Default of 0</returns>
        [OperationContract]
        double? CalculateInterest(int accountId, string notes);
    }
}
