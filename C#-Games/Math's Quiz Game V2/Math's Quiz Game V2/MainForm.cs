using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_s_Quiz_Game_V2
{
    public partial class MainForm : Form
    {
        int numA;
        int numB;
        int total;
        Random rand = new Random();
        string[] maths = { "Adunare", "Scadere", "Inmultire" };
        string secretAnswer;
        string userChoice;

        public MainForm()
        {
            InitializeComponent();
            SetupGame();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                userChoice = "Adunare";
                lblSymbol.Text = "+";
                CheckAnswer();
            }
            if (e.KeyCode == Keys.W)
            {
                userChoice = "Scadere";
                lblSymbol.Text = "-";
                CheckAnswer();
            }
            if (e.KeyCode == Keys.E)
            {
                userChoice = "Inmultire";
                lblSymbol.Text = "x";
                CheckAnswer();
            }
        }

        private void SetupGame()
        {
            numA = rand.Next(10, 20);
            numB = rand.Next(0, 9);

            secretAnswer = maths[rand.Next(0, maths.Length)];

            switch (secretAnswer)
            {
                case "Adunare":
                    total = numA + numB;
                    break;
                case "Scadere":
                    total = numA - numB;
                    break;
                case "Inmultire":
                    total = numA * numB;
                    break;
            }

            lblNumA.Text = numA.ToString();
            lblNumB.Text = numB.ToString();
            lblTotal.Text = total.ToString();
            lblSymbol.Text = "?";
        }

        private void CheckAnswer()
        {
            if (userChoice == secretAnswer)
            {
                MessageBox.Show("Correct. Now try again!");
                SetupGame();
            }
            else
            {
                MessageBox.Show("Incorrect, try again!");
                lblSymbol.Text = "?";
            }
        }
    }
}
