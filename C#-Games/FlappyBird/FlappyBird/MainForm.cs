using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class MainForm : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;
        bool gameOver = false;
        Random rand = new Random();
        public MainForm()
        {
            InitializeComponent();

            pbGround.Controls.Add(lblScore);
            lblScore.Left = 20;
            lblScore.Top = 35;

            RestartGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pbBird.Top += gravity;
            pbPipeBottom.Left -= pipeSpeed;
            pbPipeTop.Left -= pipeSpeed;
            lblScore.Text = "Score: " + score;

            if (pbPipeBottom.Left < -150)
            {
                pbPipeBottom.Left = rand.Next(750, 1300);
                score++;
            }

            if (pbPipeTop.Left < -180)
            {
                pbPipeTop.Left = rand.Next(850, 1500);
                score++;
            }

            if(pbBird.Bounds.IntersectsWith(pbPipeBottom.Bounds) ||
                pbBird.Bounds.IntersectsWith(pbPipeTop.Bounds) ||
                pbBird.Bounds.IntersectsWith(pbGround.Bounds))
            {
                EndGame();
            }

            if(score > 5)
            {
                pipeSpeed = 20;
            }

            if (pbBird.Top < -25)
            {
                EndGame();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }

            if (e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            gameOver = false;
            pbBird.Location = new Point(21, 187);
            pbPipeTop.Left = 800;
            pbPipeBottom.Left = 1200;

            score = 0;
            pipeSpeed = 8;
            lblScore.Text = "Score: 0";
            pbRestart.Enabled = false;
            pbRestart.Visible = false;
            gameTimer.Start();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            lblScore.Text += " Game Over!!! Press R to Retry";
            gameOver = true;
            pbRestart.Enabled = true;
            pbRestart.Visible = true;
        }

        private void pbRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
