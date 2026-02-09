using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BalloonPop
{
    public partial class MainForm : Form
    {
        int speed;
        int score;
        Random rand = new Random();
        bool gameOver;

        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;

            if(gameOver)
            {
                gameTimer.Stop();
                lblScore.Text = "Score: " + score + " Game over, press Enter to restart!";
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Top -= speed;

                    if(x.Top < -100)
                    {
                        x.Top = rand.Next(700, 1000);
                        x.Left = rand.Next(5, 400);
                    }

                    if((string)x.Tag == "balloon")
                    {
                        if(x.Top < -50)
                        {
                            gameOver = true;
                        }

                        if(bomb.Bounds.IntersectsWith(x.Bounds))
                        {
                            x.Top = rand.Next(700, 1000);
                            x.Left = rand.Next(5, 400);
                        }
                    }
                }
            }

            if (score > 5)
                speed = 8;
            if (score >= 15 && score < 25)
                speed = 10;
            if (score >= 25)
                speed = 12;
        }

        private void PopBalloon(object sender, EventArgs e)
        {
            if(!gameOver)
            {
                var balloon = (PictureBox)sender;

                balloon.Top = rand.Next(750, 1000);
                balloon.Left = rand.Next(5, 400);
                score++;
            }
        }

        private void bomb_Click(object sender, EventArgs e)
        {
            if(!gameOver)
            {
                bomb.Image = Properties.Resources.boom;
                gameOver = true;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && gameOver)
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            speed = 5;
            score = 0;
            gameOver = false;

            bomb.Image = Properties.Resources.bomb;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Top = rand.Next(750, 1000);
                    x.Left = rand.Next(5, 400);
                }
            }

            gameTimer.Start();
        }
    }
}
