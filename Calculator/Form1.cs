using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string _firstValue = string.Empty;
        private string _secondValue = string.Empty;
        private string _calcOperator = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private double Calculate(string firstValue, string calcOperator, string secondValue)
        {
            double a = Convert.ToDouble(firstValue);
            double b = Convert.ToDouble(secondValue);
            double result = 0;

            switch (calcOperator)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "x":
                    result = a * b;
                    break;
                case "÷":
                    if (b == 0)
                    {
                        Error();
                    }
                    result = a / b;
                    break;
            }

            return result;
        }

        private void Error()
        {
            throw new NotImplementedException();
        }

        private void ButtonNumeric_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                pictureBoxWaiting.Visible = true;

                Button button = (Button)sender;
                if (_calcOperator == string.Empty)
                {
                    textBox.Text += button.Text;
                }
                else
                {
                    if (textBox.Text.Contains(_calcOperator))
                    {
                        textBox.Text = string.Empty;
                    }
                    textBox.Text += button.Text;
                }
            }
        }

        private void ButtonOperator_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                if (!(_firstValue is null))
                {
                    _firstValue = textBox.Text;
                    _calcOperator = button.Text;
                    textBox.Text = button.Text;
                }
                else
                {
                    _calcOperator = button.Text;
                    _secondValue = textBox.Text;
                    double result = Calculate(_firstValue, _calcOperator, _secondValue);
                    textBox.Text = result.ToString();
                    _secondValue = string.Empty;
                    _firstValue = result.ToString();
                }
            }
        }

        private void buttonEqually_Click(object sender, EventArgs e)
        {
            _secondValue = textBox.Text;
            double result = Calculate(_firstValue, _calcOperator, _secondValue);
            textBox.Text = result.ToString();
            _secondValue = string.Empty;
            _firstValue = result.ToString();
            pictureBoxWaiting.Visible = false;
            pictureBoxResult.Visible = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Empty;
            _firstValue = string.Empty;
            _secondValue = string.Empty;
            _calcOperator = string.Empty;
            pictureBoxWaiting.Visible = false;
            pictureBoxResult.Visible = false;
            pictureBoxError.Visible = false;
        }
    }
}
