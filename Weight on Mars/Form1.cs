using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weight_on_Mars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidatePositiveDouble(txtWeightEarth.Text, out double earthWeight, out string weighErrorMessage)) 
            {
                MessageBox.Show(weighErrorMessage, "Earth weight Error");
                txtWeightEarth.Focus();
                return;
            }

            if (!ValidatePositiveDouble(txtWeightEarth.Text, out double objectName, out string nameErrorMessage))
            {
                MessageBox.Show(nameErrorMessage, "Object Name Error");
                txtObject.Focus();
                return;
            }

                double conversionFactor = 0.377;
            double marsWeight = earthWeight * conversionFactor;
            txtWeightMars.Text = marsWeight.ToString();



            /*{
                double earthWeight = Double.Parse(txtWeightEarth.Text);
                double conversionFactor = 0.377;
                double marsWeight = earthWeight * conversionFactor;
                txtWeightMars.Text = marsWeight.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter Numbers only", "Error");
            }
             catch (OverflowException)
            {
                MessageBox.Show("Enter a smaller number", "Error");
            }
           
           
               
        }*/

        }
        private bool ValidateName(string text, out string name, out string errorMessage)
        {
            errorMessage = null;
            name = text;


            if (string.IsNullOrEmpty(text))
            {
                errorMessage = "Can`t be empty";
                return false;
            }
            {
             if (text.Length < 2)
                {
                    errorMessage = "Enter at least 2 letters";
                    return false;
                }

                return true;
            }

        }


        private bool ValidatePositiveDouble(string text, out double number, out string errorMessage)
        {
            errorMessage = null;
            number = 0;

            try
            {
                number = double.Parse(text);

                if (number >= 0)
                {
                    return true;
                }
                else
                {
                    errorMessage = "Enter a Positive number";
                    return false;
                }
            }

            catch (FormatException)
            {
                errorMessage = "Enter a Number";
                return false;
            }
            catch (OverflowException)
            {
                errorMessage = "Enter a smaller number";
                return false;
            }

        }

    }
}

