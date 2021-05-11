using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Globalization;
using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;
using Utility;

namespace WindowsApplication
{
    /// <summary>
    /// Represents a banks batch transaction processor.
    /// </summary>
    class Batch
    {
        private BankOfBIT_JP.Data.BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private WebService.TransactionManagerClient bankService = new WebService.TransactionManagerClient();

        private IEnumerable<XElement> transaction;
        private XDocument inputFile;
        private XElement accountUpdate;
        private string inputFileNameEncrypted;
        private string inputFileName;
        private string logFileName;
        private string logData;

        /// <summary>
        /// Checks to see if the number is numeric
        /// </summary>
        /// <param name="val">the number Value</param>
        /// <param name="NumberStyle">The format of the number</param>
        /// <returns></returns>
        bool isNumeric(string val, NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Processes and logs all XML file related errors
        /// </summary>
        /// <param name="beforeQuery">The original query</param>
        /// <param name="afterQuery">The results after the query</param>
        /// <param name="message">The error message</param>
        private void processErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message)
        {
            IEnumerable<XElement> errors = beforeQuery.Except(afterQuery);

            foreach (XElement record in errors)
            {
                logData +=
                    "------ERROR------\r\n" +
                    "File: " + inputFileName + "\r\n" +
                    "Institution: " + record.Element("institution") + "\r\n" +
                    "Account Number: " + record.Element("account_no") + "\r\n" +
                    "Transaction Type: " + record.Element("type") + "\r\n" +
                    "Amount: " + record.Element("amount") + "\r\n" +
                    "Nodes: " + record.Attributes().Count().ToString() + "\r\n" +
                    "Note: " + record.Element("notes") + "\r\n" +
                    "Incorrect " + message + "\r\n";
            }
        }

        /// <summary>
        /// Processes bank transaction headers and filters out bad data.
        /// </summary>
        private void processHeader()
        {
            accountUpdate = inputFile.Element("account_update");

            // 1 Attribute Validation
            if (accountUpdate.Attributes().Count() != 3)
            {
                throw new Exception
                    (String.Format("ERROR: Incorrect number of root Attributes for file {0}", inputFileName));
            }

            // 2 Date validation
            if (!DateTime.Parse(accountUpdate.Attribute("date").Value).Equals(DateTime.Today))
            {
                throw new Exception
                    (String.Format("ERROR: Incorrect date for file {0}", inputFileName));
            }

            // 3 Institution Validation
            int institution = int.Parse(accountUpdate.Attribute("institution").Value);
            Institution institutionQuery = db.Institutions.Where(x => x.InstitutionNumber == institution).SingleOrDefault();

            if (institutionQuery == null)
            {
                throw new Exception
                    (String.Format("ERROR: Incorrect institution for file {0}", inputFileName));
            }

            // 4 Checksum Validation
            int checksumReference = int.Parse(accountUpdate.Attribute("checksum").Value);
            int checksumCalculation = 0;

            IEnumerable<XElement> accountNumbers = inputFile.Descendants("account_no");

            foreach (XElement xele in accountNumbers)
            {
                checksumCalculation += int.Parse(xele.Value);
            }

            if (checksumReference != checksumCalculation)
            {
                throw new Exception
                    (String.Format("ERROR: Incorrect checksum for file {0}", inputFileName));
            }
        }

        /// <summary>
        /// Processes bank transaction details and filters out bad data.
        /// </summary>
        private void processDetails()
        {
            transaction = inputFile.Descendants().Where(x => x.Name == "transaction");

            // 1 Attribute validation
            IEnumerable<XElement> nodeValidation = transaction
                .Where(x => x.Elements().Nodes().Count() == 5);

            processErrors(transaction, nodeValidation, "Attribute validation");

            // 2 Institution validation
            string institution = accountUpdate.Attribute("institution").Value;
            IEnumerable<XElement> institutionValidation = nodeValidation
                .Where(x => x.Element("institution").Value == institution);

            processErrors(nodeValidation, institutionValidation, "Institution validation");

            // 3 Numeric validation
            IEnumerable<XElement> numericValidation = institutionValidation
                .Where(x => isNumeric(x.Element("type").Value, NumberStyles.Integer))
                .Where(x => isNumeric(x.Element("amount").Value, NumberStyles.Integer));

            processErrors(institutionValidation, numericValidation, "Numeric validation");

            // 4 Type validation
            IEnumerable<XElement> typeValidation = numericValidation
                .Where(x => x.Element("type").Value == "2" || x.Element("type").Value == "6");

            processErrors(numericValidation, typeValidation, "Type validation");

            // 5 Amount validation
            IEnumerable<XElement> amountValidation = typeValidation
                .Where(x => int.Parse(x.Element("type").Value) == 2 && double.Parse(x.Element("amount").Value) > 0
                || int.Parse(x.Element("type").Value) == 6 && double.Parse(x.Element("amount").Value) == 0);

            processErrors(typeValidation, amountValidation, "Amount validation");

            // 6 Account number validation
            IEnumerable<long> bankAccounts = db.BankAccounts.Select(x => x.AccountNumber);
            IEnumerable<XElement> accountNumberValidation = amountValidation
                .Where(x => bankAccounts.Contains(long.Parse(x.Element("account_no").Value)));

            processErrors(amountValidation, accountNumberValidation, "Account number validation");

            processTransations(accountNumberValidation);
        }

        /// <summary>
        /// Processes bank batch transaction details and filters out bad data.
        /// </summary>
        /// <param name="transactionRecords"></param>
        private void processTransations(IEnumerable<XElement> transactionRecords)
        {

            foreach (XElement transaction in transactionRecords)
            {
                int account = int.Parse(transaction.Element("account_no").Value);
                int bankaccount = db.BankAccounts.Where(x => x.AccountNumber == account).Select(x => x.BankAccountId).SingleOrDefault();
                double amount = double.Parse(transaction.Element("amount").Value);
                int type = int.Parse(transaction.Element("type").Value);
                string notes = transaction.Element("notes").Value;

                if (type == 2)
                {
                    double? withdrawalReturn;
                    withdrawalReturn = bankService.Withdrawal(bankaccount, amount, notes);

                    if (withdrawalReturn != 0)
                    {
                        logData +=
                            "Transaction completed successfully: Withdrawal - " + amount.ToString("C") + " applied to account " + account + 
                            "\r\n";
                    }
                    else
                    {
                        logData +=
                            "***\r\n" +
                            "Transaction completed unsuccessfully\r\n" +
                            "***\r\n";
                    }

                }

                if (type == 6)
                {
                    double? interestReturn;
                    interestReturn = bankService.CalculateInterest(bankaccount, notes);

                    if (interestReturn != null)
                    {
                        logData +=
                            "Transaction completed successfully: interest - " + "*** applied to account " + account + 
                            "\r\n";
                    }
                    else
                    {
                        logData +=
                            "***\r\n" +
                            "Transaction completed unsuccessfully\r\n" +
                            "***\r\n";
                    }
                }
            }
        }

        /// <summary>
        /// Writes transaction log data.
        /// </summary>
        /// <returns></returns>
        public string WriteLogData()
        {
            string complete = "COMPLETE-" + inputFileName;
            string logReturn = logData;

            if (File.Exists(complete))
            {
                File.Delete(complete);
            }

            if (File.Exists(inputFileName))
            {
                File.Move(inputFileName, complete);
            }
            
            StreamWriter srLog = new StreamWriter(logFileName);
            srLog.Write(logData);
            srLog.Close();

            logData = string.Empty;
            logFileName = string.Empty;

            return logReturn;
        }

        /// <summary>
        /// Processes bank transmissions data.
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="key"></param>
        public void ProcessTransmission(string institution, string key)
        {
            string inputFileNameConvention = DateTime.Today.Year + "-" + DateTime.Today.DayOfYear + "-" + institution;
            inputFileName = inputFileNameConvention + ".xml";
            inputFileNameEncrypted = inputFileName + ".encrypted";
            logFileName = "LOG " + inputFileNameConvention + ".txt";

            if (File.Exists(inputFileNameEncrypted))
            {
                try
                {
                    Encryption.Decrypt(inputFileNameEncrypted, inputFileName, key);

                    if (File.Exists(inputFileName))
                    {
                        inputFile = XDocument.Load(inputFileName);
                        processHeader();
                        processDetails();
                    }
                }
                catch (Exception ex)
                {
                    logData +=
                        "==============\r\n" +
                        ex.Message +
                        "\r\n==============\r\n";
                }
            }
            else
            {
                logData +=
                    "==============\r\n" +
                    "ERROR: Input file " + inputFileNameEncrypted + " does not exist." +
                    "\r\n==============\r\n";
            }
        }
    }
}
