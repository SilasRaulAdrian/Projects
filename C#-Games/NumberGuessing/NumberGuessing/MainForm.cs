using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuessing
{
    public partial class MainForm : Form
    {
        Random rand = new Random();
        int number = 0;
        int guesses = 0;

        public MainForm()
        {
            InitializeComponent();
            LoadQuestions();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txtNumber.Text);
            guesses++;
            lblGuessed.Text = $"You guessed {guesses} times";

            if(i == number)
            {
                MessageBox.Show("Nice, you guessed it. Try another");
                LoadQuestions();
                txtNumber.Text = "";
                guesses = 0;
            }
            else if(i < number)
            {
                MessageBox.Show("Too Low");
            }
            else
            {
                MessageBox.Show("Too High");
            }
        }

        private void LoadQuestions()
        {
            number = rand.Next(0, 10);
            lblQuestion.Text = "I am thinking of a number between: 0 and 10";
        }
    }
}
