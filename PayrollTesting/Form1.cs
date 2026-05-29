using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.contractorName.Text))
            {
                MessageBox.Show("Contractor name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.contractorName.Focus();
                return;
            }
            int dependants;
            if (!int.TryParse(this.dependants.Text, out dependants))
            {
                MessageBox.Show("Please enter a valid number for dependants.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dependants.Focus();
                return;
            }
            if (dependants < 0)
            {
                MessageBox.Show("Dependants cannot be negative.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dependants.Focus();
                return;
            }
            double hourlyRate = 950.00;
            double hoursWorked;
            if (!double.TryParse(this.hoursWorked.Text, out hoursWorked))
            {
                MessageBox.Show("Please enter a valid number for hours worked.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hoursWorked.Focus();
                return;
            }
            if (hoursWorked < 0)
            {
                MessageBox.Show("Hours worked cannot be negative.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hoursWorked.Focus();
                return;
            }
            double grossPay = hourlyRate * hoursWorked;
            double payeDeduction = (grossPay - (grossPay * 0.0575 * dependants)) * 0.25;
            double uifDeduction = grossPay * 0.01;
            double membershipFee = grossPay * 0.13;
            double totalDeductions = payeDeduction + uifDeduction + membershipFee;
            double netPay = grossPay - uifDeduction - payeDeduction - membershipFee;

            this.grossPay.Text = grossPay.ToString("C");
            this.payeDeduction.Text = payeDeduction.ToString("C");
            this.uifDeduction.Text = uifDeduction.ToString("C");
            this.membershipFee.Text = membershipFee.ToString("C");
            this.totalDeduction.Text = totalDeductions.ToString("C");
            this.netPay.Text = netPay.ToString("C");
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.contractorName.Text = "";
            this.hoursWorked.Text = "";
            this.dependants.Text = "";
            this.grossPay.Text = "";
            this.payeDeduction.Text = "";
            this.uifDeduction.Text = "";
            this.membershipFee.Text = "";
            this.totalDeduction.Text = "";
            this.netPay.Text = "";
        }
    }
}
