using AnalaizerClassLibrary;

using ErrorLibrary;

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GraphInterface
{
    public partial class Form1 : Form
    {
        public static string Expression = null;
        private int _memory = 0;
        private string _result = "0";
        private bool _nonNumberEntered = false;
        private int _timercount = 0;
        private bool _istimeOut = false;
        private char _sign = ' ';

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "1";
            _istimeOut = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "2";
            _istimeOut = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "3";
            _istimeOut = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "4";
            _istimeOut = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "5";
            _istimeOut = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "6";
            _istimeOut = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "7";
            _istimeOut = false;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "8";
            _istimeOut = false;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "9";
            _istimeOut = false;
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "0";
            _istimeOut = false;
        }

        private void ButtonABS_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            _timercount = 0;
            timer1.Start();
            int count = 0;
            if (_istimeOut == false)
            {
                char temp = Convert.ToChar(textBoxExpression.Text.Substring(textBoxExpression.Text.Length - 1));
                bool check = IsNumber(temp);
                long a = 0;
                string numberToConvert = string.Empty;

                if (check == true)
                {
                    count++;
                    numberToConvert += temp;
                    while (check == true && textBoxExpression.Text.Length > count)
                    {
                        int from = textBoxExpression.Text.Length - count - 1;
                        temp = textBoxExpression.Text.Substring(from).First();
                        check = IsNumber(temp);
                        if (check == true)
                        {
                            numberToConvert = temp + numberToConvert;
                            count++;
                        }
                        else
                        {
                            _sign = temp;
                        }
                    }

                    a = long.Parse(numberToConvert);
                }

                if (_sign == '*' || _sign == '/' || _sign == '(' || _sign == ' ')
                {
                    textBoxExpression.Text = textBoxExpression.Text.Substring(0, textBoxExpression.Text.Length - count) + "-" + a;
                }
                else if (_sign == '+' || _sign == 'p')
                {
                    textBoxExpression.Text = textBoxExpression.Text.Substring(0, textBoxExpression.Text.Length - count - 1) + "-" + a;
                }
                else if (_sign == '-' || _sign == 'm')
                {
                    textBoxExpression.Text = textBoxExpression.Text.Substring(0, textBoxExpression.Text.Length - count - 1) + "+" + a;
                }
                else if (_sign == ')')
                {
                    textBoxExpression.Text = textBoxExpression.Text;
                }
            }
            else
            {
                textBoxExpression.Text += "-";
                timer1.Stop();
                _timercount = 0;
                _istimeOut = false;
            }
        }

        private bool IsNumber(char number)
        {
            if (number == '0' || number == '1' || number == '2' || number == '3' ||
           number == '4' || number == '5' || number == '6' || number == '7' || number == '8' || number == '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ButtonDiv_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "/";
        }

        private void ButtonMult_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "*";
        }

        private void ButtonSub_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "-";
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "+";
        }

        private void ButtonMR_Click(object sender, EventArgs e)
        {
            if (textBoxExpression.Text == string.Empty)
            {
                textBoxExpression.Text += _memory.ToString();
            }
            else if (textBoxExpression.Text.Length > 0)
            {
                bool checkNumber = IsNumber(textBoxExpression.Text.Substring(textBoxExpression.Text.Length - 1).FirstOrDefault());
                if (checkNumber == false)
                {
                    textBoxExpression.Text += _memory.ToString();
                }
            }

            label2.Text = "Memory";
            textBoxResult.Text = _memory.ToString();
        }

        private void ButtonMPlus_Click(object sender, EventArgs e)
        {
            ButtonEqual_Click(sender, e);
            int checkResult = 0;
            if (_result == string.Empty)
            {
                _memory += 0;
            }
            else
            {
                bool isNumber = int.TryParse(_result, out checkResult);

                // TryParse переконвертовує введене стрінгове значення в Int32, та заодно перевіряє чи воно інтове, повертає
                // true або false
                if (isNumber == true)
                {
                    if (checkResult + _memory >= int.MaxValue || checkResult + _memory <= int.MinValue ||
                         checkResult >= int.MaxValue || checkResult <= int.MinValue)
                    {
                        MessageBox.Show(ErrorsExpression.ERROR06);
                    }
                    else
                    {
                        _memory += checkResult;
                    }
                }
                else
                {
                    MessageBox.Show($"Error code can't be written into memory!");
                }
            }
        }

        private void ButtonMC_Click(object sender, EventArgs e)
        {
            _memory = 0;
            textBoxResult.Text = string.Empty;
        }

        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            label2.Text = "Result";
            _timercount = 0;
            _istimeOut = false;
            AnalaizerClass.Expression = textBoxExpression.Text;
            string results = AnalaizerClass.Estimate();
            if (results.StartsWith("&"))
            {
                this.textBoxResult.ForeColor = Color.Red;
                this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)204);
                this.textBoxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            }
            else
            {
                this.textBoxResult.ForeColor = Color.Blue;
                this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)204);
                this.textBoxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            }

            textBoxResult.Text = results;
        }

        private void ButtonOpenBracket_Click(object sender, EventArgs e)
        {
            _istimeOut = false;
            if (textBoxExpression.Text != string.Empty)
            {
                char znak = textBoxExpression.Text.Substring(textBoxExpression.Text.Length - 1).FirstOrDefault();
                bool isZnak = IsNumber(znak);
                if (isZnak == false)
                {
                    textBoxExpression.Text += "(";
                }
                else
                {
                    textBoxExpression.Text += "*(";
                }
            }
            else
            {
                textBoxExpression.Text += "(";
            }
        }

        private void ButtonCloseBracket_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += ")";
        }

        private void ButtonBS_Click(object sender, EventArgs e)
        {
            if (textBoxExpression.Text.Length == 1)
            {
                textBoxExpression.Text = string.Empty;
            }
            else if (textBoxExpression.Text.Length > 1)
            {
                textBoxExpression.Text = textBoxExpression.Text.Substring(0, textBoxExpression.Text.Length - 1);
            }
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text = string.Empty;
            textBoxResult.Text = string.Empty;
        }

        private void ButtonMod_Click(object sender, EventArgs e)
        {
            textBoxExpression.Text += "%";
        }

        private void TextBoxExpression_TextChanged(object sender, EventArgs e)
        {
            Expression = textBoxExpression.Text;
            if (textBoxExpression.Text.Length > 1 && textBoxExpression.Text.StartsWith("0"))
            {
                textBoxExpression.Text = textBoxExpression.Text.Substring(1);
            }

            bool checkNumber = false;
            foreach (char item in textBoxExpression.Text)
            {
                checkNumber = IsNumber(item);
            }

            if (checkNumber == true || textBoxExpression.Text == string.Empty)
            {
                _sign = ' ';
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            textBoxExpression.Focus();
            _nonNumberEntered = false;
            if (e.KeyValue == (char)Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyValue == (char)Keys.Enter)
            {
                textBoxExpression.Focus();
                ButtonEqual_Click(sender, e);
            }

            // If shift key was pressed, it's an alowed symbol.
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (e.KeyCode != Keys.Multiply &&
                    e.KeyCode != Keys.Oemplus &&
                    e.KeyCode != Keys.OemOpenBrackets &&
                    e.KeyCode != Keys.OemCloseBrackets &&
                    e.KeyCode != Keys.Add &&
                    e.KeyCode != Keys.Oem102 &&
                    e.KeyCode != Keys.Oem5)
                {
                    _nonNumberEntered = false;
                }
                else
                {
                    _nonNumberEntered = true;
                }
            }

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is not backspace or operands
                    if (e.KeyCode != Keys.Back &&
                    e.KeyCode != Keys.OemMinus &&
                    e.KeyCode != Keys.Divide &&
                    e.KeyCode != Keys.OemBackslash &&
                    e.KeyCode != Keys.Multiply &&
                    e.KeyCode != Keys.Oemplus &&
                    e.KeyCode != Keys.OemOpenBrackets &&
                    e.KeyCode != Keys.OemCloseBrackets &&
                    e.KeyCode != Keys.Add &&
                    e.KeyCode != Keys.Oem102 &&
                     e.KeyCode != Keys.Oem4 &&
                     e.KeyCode != Keys.Oem5 &&
                     e.KeyCode != Keys.OemQuestion)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        _nonNumberEntered = true;
                    }
                    else
                    {
                        _nonNumberEntered = false;
                    }
                }
            }
        }

        private void TextBoxResult_TextChanged(object sender, EventArgs e)
        {
            _result = textBoxResult.Text;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (_nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (_timercount < 3)
            {
                _istimeOut = false;
                _timercount++;
                this.Text = _timercount.ToString();
            }
            else if (_timercount == 3)
            {
                _istimeOut = true;
                timer1.Stop();
                _timercount = 0;
            }
            else
            {
                timer1.Stop();
                _timercount = 0;
                _istimeOut = false;
            }
        }
    }
}
