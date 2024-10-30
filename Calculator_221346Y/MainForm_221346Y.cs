using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator_221346Y
{

    public partial class MainForm_221346Y : Form
    {
        private bool flagOpPressed = false;
        private bool count = false;
        private bool scount = false;
        private bool degree = false;
        string opr = "";
        double operand = 0;
        private bool enableButtonSound = true;
        private bool enableResultAnnouncement = true;

        public MainForm_221346Y()
        {
            InitializeComponent();
            txtEquation.Font = new Font(txtEquation.Font.FontFamily, 9f);
            txtEquation.ForeColor = Color.LightGray;
        }

        private void lblID_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            Clipboard.SetText(attribute.Value.ToString());
        }
        // the sound for the button
        private void PlayButtonClickSound()
        {
            if (enableButtonSound)
            {
                SoundPlayer soundPlayer = new SoundPlayer(@"click.wav");
                soundPlayer.Play();
            }
        }
        // the speech synthesizer built in the windows form, this allows the system to talk
        private void AnnounceResult()
        {
            if (enableResultAnnouncement)
            {
                string result = lblResults.Text;
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Speak(result);
            }
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '9';
            lblResults.Text = temp;
            lblID.Focus();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '8';
            lblResults.Text = temp;
            lblID.Focus();            
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '7';
            lblResults.Text = temp;
            lblID.Focus();           
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '6';
            lblResults.Text = temp;
            lblID.Focus();          
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '5';
            lblResults.Text = temp;
            lblID.Focus();     
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '4';
            lblResults.Text = temp;
            lblID.Focus();           
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '3';
            lblResults.Text = temp;
            lblID.Focus();            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '2';
            lblResults.Text = temp;
            lblID.Focus();            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '1';
            lblResults.Text = temp;
            lblID.Focus();           
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (temp == "0")
                temp = "";
            temp += '0';
            lblResults.Text = temp;
            lblID.Focus();            
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            string temp = lblResults.Text;
            if (!temp.Contains("."))
            {
                temp += '.';
            }
            lblResults.Text = temp;
            lblID.Focus();           
        }
        // inputs of number buttons including dot
        private void numPad_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string num = btn.Text;

            string temp = lblResults.Text;
            if (flagOpPressed == true)
            {
                temp = "";
                flagOpPressed = false;
            }

            switch (num)
            {
                case ".":
                    if (!temp.Contains('.'))
                    {
                        temp += '.';
                    }
                    break;
                default:
                    if (temp == "0")
                        temp = "";
                    temp += num;
                    break;
            }
            PlayButtonClickSound();
            lblResults.Text = temp;
            lblID.Focus();    
        }
        // task A and B basic and unary arithmetic operation 
        private void btnEqual_Click(object sender, EventArgs e)
        {
            double operand2 = Double.Parse(lblResults.Text);
            switch (opr)
            {
                case "+":
                    operand = operand + operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "-":
                    operand = operand - operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "×":
                    operand = operand * operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "÷":
                    operand = operand / operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "%":
                    operand = operand % operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "Square":
                    operand = Math.Pow(operand2, 2);
                    lblResults.Text = operand.ToString();
                    break;

                case "SquareRoot":
                    operand = Math.Sqrt(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Reciprocal":
                    operand = 1 / operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "ToggleSign":
                    operand = -operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "Log10":
                    operand = Math.Log10(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Ln":
                    operand = Math.Log(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Exponentiate":
                    operand = Math.Pow(10, operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Exponential":
                    operand = Math.Exp(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Sin":
                    if (degree == true)
                    {
                        operand = Math.Sin(Math.PI * operand2 / 180.0);
                    }
                    else
                    {
                        operand = Math.Sin(operand2);
                    }
                    lblResults.Text = operand.ToString();
                    break;

                case "Cos":
                    if (degree == true)
                    {
                        operand = Math.Cos(Math.PI * operand2 / 180.0);
                    }
                    else
                    {
                        operand = Math.Cos(operand2);
                    }
                    lblResults.Text = operand.ToString();
                    break;

                case "Tan":
                    if (degree == true)
                    {
                        operand = Math.Tan(Math.PI * operand2 / 180.0);
                    }
                    else
                    {
                        operand = Math.Tan(operand2);
                    }
                    lblResults.Text = operand.ToString();
                    break;

                default:
                    break;
            }
            PlayButtonClickSound();
            AnnounceResult();
            opr = "";
            lblID.Focus();
        }
        // operator click event
        private void operator_Click(object sender, EventArgs e)
        {
            double operand2 = Double.Parse(lblResults.Text);
            switch (opr)
            {
                case "+":
                    operand = operand + operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "-":
                    operand = operand - operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "×":
                    operand = operand * operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "÷":
                    operand = operand / operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "%":
                    operand = operand % operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "Square":
                    operand = Math.Pow(operand2, 2);
                    lblResults.Text = operand.ToString();
                    break;

                case "SquareRoot":
                    operand = Math.Sqrt(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Reciprocal":
                    operand = 1 / operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "ToggleSign":
                    operand = -operand2;
                    lblResults.Text = operand.ToString();
                    break;

                case "Log10":
                    operand = Math.Log10(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Ln":
                    operand = Math.Log(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Exponentiate":
                    operand = Math.Pow(10, operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Exponential":
                    operand = Math.Exp(operand2);
                    lblResults.Text = operand.ToString();
                    break;

                case "Sin":
                    if (degree == true)
                    {
                        operand = Math.Sin(Math.PI * operand2 / 180.0);
                    }
                    else
                    {
                        operand = Math.Sin(operand2);
                    }
                    lblResults.Text = operand.ToString();
                    break;

                case "Cos":
                    if (degree == true)
                    {
                        operand = Math.Cos(Math.PI * operand2 / 180.0);
                    }
                    else
                    {
                        operand = Math.Cos(operand2);
                    }
                    lblResults.Text = operand.ToString();
                    break;

                case "Tan":
                    if (degree == true)
                    {
                        operand = Math.Tan(Math.PI * operand2 / 180.0);
                    }
                    else
                    {
                        operand = Math.Tan(operand2);
                    }
                    lblResults.Text = operand.ToString();
                    break;

                default:
                    break;
            }
            operand = Double.Parse(lblResults.Text);
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string op = btn.Tag.ToString();

            // when u click the operator it combines the current value of lblResults and adds in the number u type into txtEquation and adds in the current operator u click on 
            if (txtEquation.Text == "")
            {
                txtEquation.Text = lblResults.Text + " " + op;
            }
            else
            {
                if (IsOperator(txtEquation.Text[txtEquation.Text.Length - 1]))
                {
                    // remove the last operator
                    txtEquation.Text = txtEquation.Text.Substring(0, txtEquation.Text.Length - 1);
                }
                txtEquation.Text += " " + lblResults.Text + " " + op;
            }

            opr = op;
            flagOpPressed = true;
            PlayButtonClickSound();
            lblID.Focus();
        }
        // checks to see if the cahrecter 'c' is equal to any of the following operators
        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
        // task A clear all button, clears both results display and equation display
        private void btnC_Click(object sender, EventArgs e)
        {
            opr = "";
            operand = 0;
            lblResults.Text = "0"; //results
            txtEquation.Text = ""; //equation
            PlayButtonClickSound();
            lblID.Focus();
        }
        // clears last input 
        private void btnCE_Click(object sender, EventArgs e)
        {
            opr = "";
            operand = 0;
            lblResults.Text = "0";
            flagOpPressed = false;
            PlayButtonClickSound();
            lblID.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // task C clear last digit for Equation Display
            if (txtEquation.Text.Length > 0)
            {
                txtEquation.Text = txtEquation.Text.Substring(0, txtEquation.Text.Length - 1);
            }
            // task C when Equation Display is 0 lblResults resets to 0
            if (lblEquation.Text.Length == 0)
            {
                txtEquation.Text = "";
                lblResults.Text = "0";
            }
            // keeps lblResults at 0 when backspace is pressed when it is at 0
            if (txtEquation.Text.Length == 0)
            {
                lblResults.Text = "0";
            }
            PlayButtonClickSound();
            lblID.Focus();
        }
        // mode Switching Enhancement switches between Scientifc and Standard with the use of panels
        private void btnMode_Click(object sender, EventArgs e)
        {
            count = !count;
            if (count == true)
            {
                pnlSci.Visible = true;
                pnlStd.Visible = false;
                lblMode.Text = "Scientific";
                btnMode.Text = "Std";
            }
            else
            {
                pnlSci.Visible = false;
                pnlStd.Visible = true;
                lblMode.Text = "Standard";
                btnMode.Text = "Sci";
            }
            PlayButtonClickSound();
            lblID.Focus();
        }
        // mode Switching Enhancement switchs sets of operator with the shift button 
        private void btnShift_Click(object sender, EventArgs e)
        {
            scount = !scount;

            if (scount == true)
            {
                btnLog.Text = "Sin";
                btnLog.Tag = "Sin";
                btnLn.Text = "Cos";
                btnLn.Tag = "Cos";
                btnExpo.Text = "Tan";
                btnExpo.Tag = "Tan";
                btnE.Text = "";
                btnE.Tag = "";
                btnSquareRoot.Text = "";
                btnSquareRoot.Tag = "";
                btnSquare.Text = "";
                btnSquare.Tag = "";
                btnReciprocal.Text = "";
                btnReciprocal.Tag = "";
                btnToggle.Text = "";
                btnToggle.Tag = "";
            }
            else
            {
                btnLog.Text = "Log10";
                btnLog.Tag = "Log10";
                btnLn.Text = "Ln";
                btnLn.Tag = "Ln";
                btnExpo.Text = "10˟";
                btnExpo.Tag = "Exponentiate";
                btnE.Text = "e˟";
                btnE.Tag = "Exponential";
                btnSquareRoot.Text = "√";
                btnSquareRoot.Tag = "SquareRoot";
                btnSquare.Text = "x²";
                btnSquare.Tag = "Square";
                btnReciprocal.Text = "1/x";
                btnReciprocal.Tag = "Reciprocal";
                btnToggle.Text = "±";
                btnToggle.Tag = "ToggleSign";
            }
            PlayButtonClickSound();
            lblID.Focus();
        }
        // mode Switching Enhancement switches between Rad and Deg
        private void btnMode2_Click(object sender, EventArgs e)
        {
            degree = !degree;
            if (degree == true)
            {
                lblMode2.Text = "Degree";
                btnMode2.Text = "Rad";
            }
            else
            {
                lblMode2.Text = "Radian";
                btnMode2.Text = "Deg";
            }
            PlayButtonClickSound();
            lblID.Focus();
        }
        // task C Hard Keyboard Input
        private void MainForm_221346Y_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    btn0.PerformClick();
                    break;

                case '1':
                    btn1.PerformClick();
                    break;

                case '2':
                    btn2.PerformClick();
                    break;

                case '3':
                    btn3.PerformClick();
                    break;

                case '4':
                    btn4.PerformClick();
                    break;

                case '5':
                    btn5.PerformClick();
                    break;

                case '6':
                    btn6.PerformClick();
                    break;

                case '7':
                    btn7.PerformClick();
                    break;

                case '8':
                    btn8.PerformClick();
                    break;

                case '9':
                    btn9.PerformClick();
                    break;

                case '+':
                    btnPlus.PerformClick();
                    break;

                case '-':
                    btnMinus.PerformClick();
                    break;

                case '*':
                    btnMulti.PerformClick();
                    break;

                case '/':
                    btnDivide.PerformClick();
                    break;

                case (char)Keys.Enter:
                    btnEqual.PerformClick();
                    break;

                case (char)Keys.Back:
                    btnBack.PerformClick();
                    break;
            }
        }
        // copy button
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblResults.Text);
            PlayButtonClickSound();
            lblID.Focus();
        }
        // toggle bewtween mute and unmute 
        private void btnSound_Click(object sender, EventArgs e)
        {
            enableButtonSound = !enableButtonSound;
            if (enableButtonSound == true) 
            {
                lblSound.Text = "Button On";
                btnSound.Text = "B Off";
            }
            else
            {
                lblSound.Text = "Button Off";
                btnSound.Text = "B On";
            }
            PlayButtonClickSound();
            lblID.Focus();
        }
        // toggle between mute and unmute
        private void btnAnnounce_Click(object sender, EventArgs e)
        {
            enableResultAnnouncement = !enableResultAnnouncement;
            if (enableResultAnnouncement == true)
            {
                lblAnnounce.Text = "Announcer On";
                btnAnnounce.Text = "A Off";
            }
            else
            {
                lblAnnounce.Text = "Announcer Off";
                btnAnnounce.Text = "A On";
            }
            PlayButtonClickSound();
            lblID.Focus();
        }

        private void txtEquation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
