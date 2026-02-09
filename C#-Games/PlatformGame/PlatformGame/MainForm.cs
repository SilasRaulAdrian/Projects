using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformGame
{
    public partial class MainForm : Form
    {
        bool goLeft, goRight, jumping, isGameOver;
        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;
        int horizontalSpeed = 5;
        int verticalSpeed = 3;
        int enemyOneSpeed = 3;
        int enemyTwoSpeed = 3;

        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;
            player.Top += jumpSpeed;

            if (goLeft)
                player.Left -= playerSpeed;
            if (goRight)
                player.Left += playerSpeed;

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (jumping)
            {
                jumpSpeed = -8;
                force--;
            }
            else
                jumpSpeed = 10;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "platform")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;

                            if((string)x.Name == "horizontalPlatform" && !goLeft || (string)x.Name == "horizontalPlatform" && !goRight)
                            {
                                player.Left -= horizontalSpeed;
                            }
                        }

                        x.BringToFront();
                    }

                    if((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if((string)x.Tag == "enemy")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            lblScore.Text = "Score: " + score + Environment.NewLine + "You were killed in your journey!!";
                        }
                    }
                }
            }

            horizontalPlatform.Left -= horizontalSpeed;

            if(horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            verticalPlatform.Top += verticalSpeed;

            if(verticalPlatform.Top < 200 || verticalPlatform.Top > 500)
            {
                verticalSpeed = -verticalSpeed;
            }

            enemyOne.Left -= enemyOneSpeed;

            if(enemyOne.Left < pictureBox5.Left || enemyOne.Left + enemyOne.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left += enemyTwoSpeed;

            if(enemyTwo.Left < pictureBox2.Left || enemyTwo.Left + enemyTwo.Width > pictureBox2.Left + pictureBox2.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            if(player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                isGameOver = true;
                lblScore.Text = "Score: " + score + Environment.NewLine + "You fell to your death!";
            }

            if(player.Bounds.IntersectsWith(pbDoor.Bounds) && score == 27)
            {
                gameTimer.Stop();
                isGameOver = true;
                lblScore.Text = "Score: " + score + Environment.NewLine + "Your quest is complete!";
            }
            else if (score < 27 && !isGameOver)
                lblScore.Text = "Score: " + score + Environment.NewLine + "Collect all the coins!";
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = true;
            if (e.KeyCode == Keys.Right)
                goRight = true;
            if (e.KeyCode == Keys.Space && !jumping)
                jumping = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
            if (jumping)
                jumping = false;
            if (e.KeyCode == Keys.Enter && isGameOver)
                ResetGame();
        }

        private void ResetGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;
            lblScore.Text = "Score: " + score;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            player.Left = 90;
            player.Top = 558;

            enemyOne.Left = 355;
            enemyTwo.Left = 300;

            horizontalPlatform.Left = 220;
            verticalPlatform.Left = 430;

            gameTimer.Start();
        }
    }
}
