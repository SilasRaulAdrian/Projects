using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors
{
    public partial class MainForm : Form
    {
        string playerChoice;
        string computerChoice;
        string[] options = { "R", "P", "S", "P", "S", "R" };
        Random rand = new Random();
        int computerScore;
        int playerScore;
        string draw;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MakeChoiceEvent(object sender, EventArgs e)
        {
            Button tempButton = sender as Button;
            playerChoice = (string)tempButton.Tag;
            int i = rand.Next(0, options.Length);
            computerChoice = options[i];
            lblPlayerChoice.Text = $"Player is: {UpdateTextAndImage(playerChoice, PLAYER_PIC)}";
            lblCPUchoice.Text = $"Computer is: {UpdateTextAndImage(computerChoice, CPU_PIC)}";
            CheckGame();
        }

        private string UpdateTextAndImage(string text, PictureBox pic)
        {
            string word = null;

            switch (text)
            {
                case "R":
                    word = "Rock";
                    pic.Image = Properties.Resources.ROCK;
                    break;
                case "P":
                    word = "Paper";
                    pic.Image = Properties.Resources.PAPER;
                    break;
                case "S":
                    word = "Scissors";
                    pic.Image = Properties.Resources.SCISSORS;
                    break;
            }

            return word;
        }

        private void CheckGame()
        {
            if (computerChoice == playerChoice)
            {
                draw = "Draw!";
            }
            else if (playerChoice == "R" && computerChoice == "P" ||
                playerChoice == "P" && computerChoice == "S" ||
                playerChoice == "S" && computerChoice == "R")
            {
                computerScore++;
                draw = null;
            }
            else
            {
                playerScore++; 
                draw = null;
            }

            lblCPUresult.Text = $"Computer Score: {computerScore} {Environment.NewLine} {draw}";
            lblPlayerResult.Text = $"Player Score: {playerScore} {Environment.NewLine} {draw}";
        }
    }
}
