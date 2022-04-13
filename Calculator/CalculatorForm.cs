using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed;

        public CalculatorForm()
        {
            InitializeComponent();

            this.btnZero.Click += BtnNumber_Click;
            this.btnOne.Click += BtnNumber_Click;
            this.btnTwo.Click += BtnNumber_Click;
            this.btnThree.Click += BtnNumber_Click;
            this.btnFour.Click += BtnNumber_Click;
            this.btnFive.Click += BtnNumber_Click;
            this.btnSix.Click += BtnNumber_Click;
            this.btnSeven.Click += BtnNumber_Click;
            this.btnEight.Click += BtnNumber_Click;
            this.btnNine.Click += BtnNumber_Click;

            this.btnDivide.Click += BtnOperator_Click;
            this.btnMultiply.Click += BtnOperator_Click;
            this.btnSubtract.Click += BtnOperator_Click;
            this.btnAdd.Click += BtnOperator_Click;

            this.btnBackspace.Click += BtnBackspace_Click;

            this.btnClear.Click += BtnClear_Click;

            this.btnCalculate.Click += BtnCalculate_Click;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "/":
                    this.lblCalculated.Text = (resultValue / double.Parse(this.lblCurrentFormula.Text)).ToString();
                    break;
                case "*":
                    this.lblCalculated.Text = (resultValue * double.Parse(this.lblCurrentFormula.Text)).ToString();
                    break;
                case "+":
                    this.lblCalculated.Text = (resultValue + double.Parse(this.lblCurrentFormula.Text)).ToString();
                    break;
                case "-":
                    this.lblCalculated.Text = (resultValue - double.Parse(this.lblCurrentFormula.Text)).ToString();
                    break;
            }
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            if (this.lblCurrentFormula.Text == "0" || isOperationPerformed)
            {
                this.lblCurrentFormula.Text = "";
            }

            isOperationPerformed = false;

            Button numberButton = (Button)sender;
            this.lblCurrentFormula.Text += numberButton.Text;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.lblCurrentFormula.Text = "0";
            this.lblCalculated.Text = "";
        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (lblCurrentFormula.Text.Length > 0)
            {
                this.lblCurrentFormula.Text = this.lblCurrentFormula.Text.Remove(this.lblCurrentFormula.Text.Length - 1);
            }
        }

        private void BtnOperator_Click(object sender, EventArgs e)
        {
            Button buttonOperator = (Button)sender;

            operationPerformed = buttonOperator.Text;
            resultValue = double.Parse(this.lblCurrentFormula.Text);
            this.lblCalculated.Text = resultValue + " " + operationPerformed;

            isOperationPerformed = true;
        }
    }
}
