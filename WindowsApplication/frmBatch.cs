using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankOfBIT_JP.Data;
using BankOfBIT_JP.Models;
using Utility;

namespace WindowsApplication
{
    public partial class frmBatch : Form
    {
        private BankOfBIT_JP.Data.BankOfBIT_JPContext db = new BankOfBIT_JPContext();
        private IQueryable<Institution> institutions;
        private Batch batch;

        /// <summary>
        /// given:  This constructor will be used when called from 
        /// frmClient.  This constructor will receive 
        /// specific information about the client and bank account
        /// further code required:  
        /// </summary>
        public frmBatch()
        {
            InitializeComponent();

        }

        /// <summary>
        /// given:  open in top left of frame
        /// further code required:
        /// </summary>
        private void frmBatch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            institutions = db.Institutions;
            institutionBindingSource.DataSource = institutions.ToList();
            batch = new Batch();
        }

        /// <summary>
        /// Given:  Further code required
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string log = string.Empty;

            if (txtKey.Text.Length != 8)
            {
                MessageBox.Show("A 64 bit key is required");
            }

            if (radAll.Checked)
            {
                foreach (Institution selected in institutions)
                {
                    batch.ProcessTransmission(selected.InstitutionNumber.ToString(), txtKey.Text);
                    log = batch.WriteLogData();
                    rtxtLog.Text += log;
                }
            }

            if (radSelect.Checked)
            {
                batch.ProcessTransmission(institutionNumberComboBox.SelectedValue.ToString(), txtKey.Text);
                log = batch.WriteLogData();
                rtxtLog.Text += log;
            }
        }

        /// <summary>
        /// Sets combo box viability based on radio button.
        /// </summary>
        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            institutionNumberComboBox.Visible = false;

            if (radSelect.Checked)
            {
                institutionNumberComboBox.Visible = true;
            }
        }
    }
}
