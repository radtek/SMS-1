using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bec.TargetFramework.Business.Rules.Validation.Bank;

namespace ValidationExecutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheckAccount_Click(object sender, EventArgs e)
        {
            txtOutput.Text = string.Empty;
            txtErrorOutput.Text = string.Empty;

            BankAccountValidator validator = new BankAccountValidator();

            try
            {
                var result = validator.CheckBankAccount(txtSortCode.Text, txtAccountNumber.Text);

                txtOutput.Text = result.ToString();
            }
            catch (Exception ex)
            {
                txtErrorOutput.Text = ex.Message + ": " + ex.StackTrace;
            }

            
        }
    }
}
