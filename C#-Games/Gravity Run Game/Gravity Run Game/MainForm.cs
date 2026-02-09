using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gravity_Run_Game
{
    public partial class MainForm : Form
    {
        int gravity;
        int gravityValue = 8;
        int obstacleSpeed = 10;
        int score = 0;
        int highScore = 0;
        bool gameOver = false;
        Random rand = new Random();

        public MainForm()
        {
            InitializeComponent();
            RestartGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = $"Score: {score}";
            lblHighScore.Text = $"High Score: {highScore}";
            player.Top += gravity;

            if (player.Top > 250)
            {
                gravity = 0;
                player.Top = 250;
                player.Image = Properties.Resources.run_down0;
            }
            else if (player.Top < 40)
            {
                gravity = 0;
                player.Top = 40;
                player.Image = Properties.Resources.run_up0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = rand.Next(1200, 3000);
                        score++;
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        gameTimer.Stop();
                        lblScore.Text += "  Game Over!! Press Enter to restart.";
                        gameOver = true;

                        if (score > highScore)
                        {
                            highScore = score;
                        }
                    }
                }
            }

            if (score > 10)
            {
                obstacleSpeed = 20;
                gravityValue = 12;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (player.Top == 250)
                {
                    player.Top -= 10;
                    gravity = -gravityValue;
                }
                else if (player.Top == 40)
                {
                    player.Top += 10;
                    gravity = gravityValue;
                }
            }

            if (e.KeyCode == Keys.Enter && gameOver)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            lblScore.Parent = pictureBox1;
            lblHighScore.Parent = pictureBox2;
            lblHighScore.Top = 0;
            player.Location = new Point(95, 254);
            player.Image = Properties.Resources.run_down0;
            score = 0;
            gravityValue = 8;
            gravity = gravityValue;
            obstacleSpeed = 10;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left = rand.Next(1200, 3000);
                }
            }

            gameTimer.Start();
        }
    }
}
