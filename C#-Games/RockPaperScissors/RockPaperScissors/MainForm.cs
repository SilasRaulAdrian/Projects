using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors
{
    public partial class MainForm : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool gameOver = false;
        string[] CPUchoiceList = { "rock", "paper", "scissor", "paper", "scissor", "rock" };
        int randomNumber = 0;
        Random rand = new Random();
        string CPUChoice;
        string playerChoice;
        int playerScore;
        int CPUScore;
        public MainForm()
        {
            InitializeComponent();

            countdownTimer.Enabled = true;
            playerChoice = "none";
            lblCountdown.Text = "5";
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            pbPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            pbPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            pbPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playerScore = 0;
            CPUScore = 0;
            rounds = 3;
            lblScore.Text = "Player: " + playerScore + " - " + "CPU: " + CPUScore;
            playerChoice = "none";
            countdownTimer.Enabled = true;
            pbPlayer.Image = Properties.Resources.qq;
            pbCpu.Image = Properties.Resources.qq;

            gameOver = false;
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            timerPerRound--;
            lblCountdown.Text = timerPerRound.ToString();
            lblRounds.Text = "Rounds: " + rounds;

            if(timerPerRound == 0)
            {
                countdownTimer.Enabled = false;
                timerPerRound = 6;
                randomNumber = rand.Next(0, CPUchoiceList.Length);
                CPUChoice = CPUchoiceList[randomNumber];

                switch(CPUChoice)
                {
                    case "rock":
                        pbCpu.Image = Properties.Resources.rock;
                        break;
                    case "paper":
                        pbCpu.Image = Properties.Resources.paper;
                        break;
                    case "scissor":
                        pbCpu.Image = Properties.Resources.scissors;
                        break;
                }

                if (rounds > 0)
                {
                    CheckGame();
                }
                else
                {
                    if(playerScore > CPUScore)
                    {
                        MessageBox.Show("Player won the game");
                    }
                    else
                    {
                        MessageBox.Show("CPU won the game");
                    }

                    gameOver = true;
                }
            }

        }

        private void CheckGame()
        {
            if(playerChoice == "rock" && CPUChoice == "paper")
            {
                rounds--;
                CPUScore++;
                MessageBox.Show("CPU Wins, Paper Covers Rock");
            }
            else if (playerChoice == "scissor" && CPUChoice == "rock")
            {
                rounds--;
                CPUScore++;
                MessageBox.Show("CPU Wins, Rock Breaks Scissor");
            }
            else if (playerChoice == "paper" && CPUChoice == "scissor")
            {
                rounds--;
                CPUScore++;
                MessageBox.Show("CPU Wins, Scissor Cuts Paper");
            }
            else if (playerChoice == "rock" && CPUChoice == "scissor")
            {
                rounds--;
                playerScore++;
                MessageBox.Show("Player Wins, Rock Breaks Scissor");
            }
            else if (playerChoice == "paper" && CPUChoice == "rock")
            {
                rounds--;
                playerScore++;
                MessageBox.Show("Player Wins, Paper Covers Rock");
            }
            else if (playerChoice == "scissor" && CPUChoice == "paper")
            {
                rounds--;
                playerScore++;
                MessageBox.Show("Player Wins, Scissor Cuts Paper");
            }
            else if(playerChoice == "none")
            {
                MessageBox.Show("Make a choice");
            }
            else
            {
                MessageBox.Show("Draw!!!");
            }

            StartNextRound();
        }

        private void StartNextRound()
        {
            if (gameOver)
                return;

            lblScore.Text = "Player: " + playerScore + " - " + "CPU: " + CPUScore;
            playerChoice = "none";
            countdownTimer.Enabled = true;
            pbPlayer.Image = Properties.Resources.qq;
            pbCpu.Image = Properties.Resources.qq;
        }
    }
}
