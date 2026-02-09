using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Math_s_Quiz_Game
{
    public partial class MainForm : Form
    {
        Random rand = new Random();
        string[] maths = { "Adunare", "Scadere", "Inmultire" };
        int total;
        int score;

        public MainForm()
        {
            InitializeComponent();
            SetupGame();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int userEntered = Convert.ToInt32(txtAnswer.Text);

            if (userEntered == total)
            {
                lblAnswer.Text = "Correct";
                lblAnswer.ForeColor = Color.Green;
                score++;
                lblScore.Text = "Score: " + score;
                SetupGame();
            }
            else
            {
                lblAnswer.Text = "Incorrect";
                lblAnswer.ForeColor = Color.Red;
                txtAnswer.Text = "";
            }
        }

        private void SetupGame()
        {
            int numA = rand.Next(10, 20);
            int numB = rand.Next(0, 9);

            txtAnswer.Text = null;

            switch (maths[rand.Next(0, maths.Length)])
            {
                case "Adunare":
                    total = numA + numB;
                    lblSymbol.Text = "+";
                    lblSymbol.ForeColor = Color.DarkGreen;
                    break;
                case "Scadere":
                    total = numA - numB;
                    lblSymbol.Text = "-";
                    lblSymbol.ForeColor = Color.Maroon;
                    break;

                case "Inmultire":
                    total = numA * numB;
                    lblSymbol.Text = "x";
                    lblSymbol.ForeColor = Color.Purple;
                    break;
            }

            lblNumA.Text = numA.ToString();
            lblNumB.Text = numB.ToString();
        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtAnswer.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!");
                txtAnswer.Text = txtAnswer.Text.Remove(txtAnswer.Text.Length - 1);
            }
        }
    }
}
