/*
 * Leo Kay
 * February 20, 2018
 * Course Code: ICS3U
 * This program calculates the height of an object that has been dropped 100 meters and the user inputs the number of seconds since it has fallen.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FallingObjectsLeoK
{
    public partial class frmFallingObjects : Form
    {
        public frmFallingObjects()
        {
            InitializeComponent();

            //hide some labels
            lblTooSmall.Hide();
            lblGround.Hide();
            lblLetter.Hide();
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            //close the program
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

            //allow these words to store numbers
            double seconds, answer;

            //Store the users input in the word seconds
            seconds = double.Parse(txtInput.Text);

            //calculate the answer
            answer = (100 - 0.5 * 9.81 * Math.Pow(seconds, 2));

            //Round the answer
            answer = Math.Round(answer, 2);

            //convert the answer to a string
            this.lblAnswer.Text = Convert.ToString(answer) + " meters";

            /*If the number is less than 0, tell them not to enter negative numbers
             * If the number is greater than 0, hide the too small label and show the answer
             * If the number is equal to 0, show the answer and hide the too small label.
             */
            if (seconds < 0)
            {
                lblTooSmall.Show();
                lblAnswer.Hide();
                lblGround.Hide();
                lblLetter.Hide();
            }
            else
            {
                if (seconds > 0)
                {
                    lblAnswer.Show();
                    lblTooSmall.Hide();
                    lblGround.Hide();
                    lblLetter.Hide();
                }

                if (seconds == 0)
                {
                    lblAnswer.Show();
                    lblTooSmall.Hide();
                    lblLetter.Hide();
                }

                //If the answer is 0 or less, say the object has hit the ground
                if (answer < 0)
                {
                    lblGround.Show();
                    lblAnswer.Hide();
                    lblTooSmall.Hide();
                    lblLetter.Hide();
                }
            }
        }

        //Make it so that the user can only enter numbers
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '-') && (e.KeyChar != '.'))
            {
                e.Handled = true;
                lblLetter.Show();
                lblGround.Hide();
                lblAnswer.Hide();
                lblTooSmall.Hide();
            }
        }
    }
}


