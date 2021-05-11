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
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace WindowsApplication
{
    public partial class frmClient : Form
    {
        private BankOfBIT_JP.Data.BankOfBIT_JPContext db;
        private Client clientQuery;
        private IQueryable<BankAccount> bankAccountQuery;

        private SerialPort rfid;
        delegate void SetLeaveCallback(string data);

        /// Given: Client and bank account data will be retrieved
        /// in this form and passed throughout application
        /// These variables will be used to store the current
        /// Client and selected Bank Account
        ConstructorData constructorData = new ConstructorData();

        public frmClient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when returning to frmClient
        /// from another form.  This constructor will pass back
        /// specific information about the Client and Bank Account
        /// based on activities taking place in another form
        /// </summary>
        /// <param name="constructorData">Client data passed among forms</param>
        public frmClient(ConstructorData constructorData)
        {
            InitializeComponent();

            //further code to be added
            this.constructorData.ClientEntity = constructorData.ClientEntity;
            this.constructorData.BankAccountEntity = constructorData.BankAccountEntity;
            clientNumberMaskedTextBox.Text = constructorData.ClientEntity.ClientNumber.ToString();

            SendKeys.Send("{TAB}");
        }

        /// <summary>
        /// Opens serial port with specified settings
        /// </summary>
        /// <param name="portNumber"></param>
        public void OpenPort(string portNumber)
        {
            rfid = new SerialPort();
            rfid.BaudRate = 9600;
            rfid.PortName = portNumber;
            rfid.Parity = Parity.None;
            rfid.DataBits = 8;
            rfid.StopBits = StopBits.One;
            rfid.Handshake = Handshake.None;
            rfid.ReadTimeout = 3000;
            rfid.ReceivedBytesThreshold = 1;
            rfid.DtrEnable = true;
            rfid.Open();
        }

        /// <summary>
        /// evaluates data read from serial port RFID reader.  
        /// </summary>
        /// <param name="strData"></param>
        private void SetLeave(string strData)
        {
            if (this.clientNumberMaskedTextBox.InvokeRequired)
            {
                object[] objArray = new object[] { strData };
                SetLeaveCallback objCallBack = new SetLeaveCallback(SetLeave);
                this.Invoke(objCallBack, objArray);
            }
            else
            {
                try
                {
                    long data = long.Parse(strData);
                    long digits = long.Parse(strData.Substring(strData.Length - 3, 3));
                    long convertToHex = data * digits;
                    string hex = convertToHex.ToString("X");
                    string hexSub = Regex.Replace(hex.Substring(hex.Length - 3, 3), "[^0-9G-Z]", string.Empty);
                    hex = hex.Remove(hex.Length - 3);

                    if (hexSub != "0")
                    {
                        
                        hex += hexSub;
                    }

                    long hexConversions = long.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                    RFIDTag clientCardNumber = db.RFIDTags.Where(x => x.CardNumber == hexConversions).SingleOrDefault();

                    if (clientCardNumber == null)
                    {
                        throw new Exception("RFID tag is invalid");
                    }

                    Client clientRFID = db.Clients.Where(x => x.ClientId == clientCardNumber.ClientId).SingleOrDefault();

                    if (clientRFID == null)
                    {
                        throw new Exception("RFID tag is invalid");
                    }

                    clientNumberMaskedTextBox.Text = clientRFID.ClientNumber.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Handles when the RFID receives data.
        /// </summary>
        private void serialPortRFID_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            SetLeave(indata);
        }

        /// <summary>
        /// Handles the button click event
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string clientNumber = txtReader.Text;
                clientNumber = clientNumber.Substring(1, clientNumber.Length - 2);
                SetLeave(clientNumber);
                clientNumberMaskedTextBox.Focus();
                SendKeys.Send("{TAB}");
            }
            catch { }
        }

        /// <summary>
        /// given: open transaction form passing constructor data
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetConstructorData();

            //instance of frmTransaction passing constructor data
            frmTransaction frmTransaction = new frmTransaction(constructorData);

            //open in frame
            frmTransaction.MdiParent = this.MdiParent;
            //show form
            frmTransaction.Show();
            this.Close();
        }

        /// <summary>
        /// given: open history form passing constructor data
        /// </summary>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetConstructorData();

            //instance of frmHistory passing constructor data
            frmHistory frmHistory = new frmHistory(constructorData);

            //open in frame
            frmHistory.MdiParent = this.MdiParent;
            //show form
            frmHistory.Show();
            this.Close();
        }

        /// <summary>
        /// given: opens form in top right of frame
        /// </summary>
        private void frmClient_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);

            string[] serialDevice = SerialPort.GetPortNames();

            foreach (string portNumber in serialDevice)
            {
                OpenPort(portNumber);
            }
        }

        /// <summary>
        /// Closes open com port when leaving form.
        /// </summary>
        private void frmClient_Leave(object sender, EventArgs e)
        {
            if (rfid.IsOpen)
            {
                rfid.Close();
            }
        }

        /// <summary>
        /// Handles the leave event of client number masked text box
        /// </summary>
        private void clientNumberMaskedTextBox_Leave(object sender, EventArgs e)
        {
            db = new BankOfBIT_JPContext();

            clientBindingSource.Clear();
            bankAccountBindingSource.Clear();

            if (clientNumberMaskedTextBox.MaskCompleted)
            {
                ClientQuery();

                if (clientQuery != null)
                {
                    BankAccountQuery();
                }

                if (constructorData.BankAccountEntity != null)
                {
                    accountNumberComboBox.Text = constructorData.BankAccountEntity.AccountNumber.ToString();
                }
            }
        }

        /// <summary>
        /// Queries the database for clients.
        /// </summary>
        private void ClientQuery()
        {
            long clientNumber = 0;
            long.TryParse(clientNumberMaskedTextBox.Text, out clientNumber);

            try
            {
                clientQuery = db.Clients.Where(x => x.ClientNumber == clientNumber).SingleOrDefault();

                if (clientQuery == null)
                {
                    throw new Exception("Client number entered does not exist");
                }

                clientBindingSource.DataSource = clientQuery;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                LinkButtons(false);
                clientNumberMaskedTextBox.Focus();
                clientNumberMaskedTextBox.Text = "";
            }
        }

        /// <summary>
        /// Queries the database for client's bank accounts.
        /// </summary>
        private void BankAccountQuery()
        {
            bankAccountQuery = db.BankAccounts.Where(x => x.ClientId == clientQuery.ClientId);

            if (bankAccountQuery.Count() != 0)
            {
                bankAccountBindingSource.DataSource = bankAccountQuery.ToList();
                LinkButtons(true);
            }
        }

        /// <summary>
        /// Sets current client and bank account for client navigation 
        /// </summary>
        private void SetConstructorData()
        {
            constructorData.ClientEntity = (Client)clientBindingSource.Current;
            constructorData.BankAccountEntity = (BankAccount)bankAccountBindingSource.Current;
        }

        /// <summary>
        /// Sets the state of client navigation
        /// </summary>
        /// <param name="enabled">The state of the link buttons.</param>
        private void LinkButtons(bool enabled)
        {
            lnkUpdate.Enabled = enabled;
            lnkDetails.Enabled = enabled;
        }
    }
}