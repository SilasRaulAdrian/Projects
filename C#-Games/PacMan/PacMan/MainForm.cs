using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class MainForm : Form
    {
        bool goLeft, goRight, goUp, goDown, isGameOver;
        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;
        public MainForm()
        {
            InitializeComponent();

            ResetGame();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goUp = true;
            if (e.KeyCode == Keys.Down)
                goDown = true;
            if (e.KeyCode == Keys.Left)
                goLeft = true;
            if (e.KeyCode == Keys.Right)
                goRight = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goUp = false;
            if (e.KeyCode == Keys.Down)
                goDown = false;
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;

            if (e.KeyCode == Keys.Enter && isGameOver)
                ResetGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;

            if(goLeft)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.left;
            }
            if(goRight)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.right;
            }
            if(goDown)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.down;
            }
            if(goUp)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.Up;
            }

            if (pacman.Left < -10)
                pacman.Left = 480;
            if (pacman.Left > 480)
                pacman.Left = -10;
            if (pacman.Top < -10)
                pacman.Top = 450;
            if (pacman.Top > 450)
                pacman.Top = 0;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score++;
                            x.Visible = false;
                        }
                    }

                    if((string)x.Tag == "wall")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You Lose!");
                        }

                        if(pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }
                    }

                    if((string)x.Tag == "ghost")
                    {
                        if(pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver("You Lose!");
                        }
                    }
                }
            }

            redGhost.Left += redGhostSpeed;
            if(redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowGhost.Left -= yellowGhostSpeed;
            if (yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;
            if(pinkGhost.Top < 0 || pinkGhost.Top > 400) 
            {
                pinkGhostY = -pinkGhostY;
            }
            if(pinkGhost.Left < 0 || pinkGhost.Left > 480)
            {
                pinkGhostX = -pinkGhostX;
            }

            if (score == 43)
            {
                GameOver("You Win!");
            }
        }

        private void ResetGame()
        {
            lblScore.Text = "Score: 0";
            score = 0;
            redGhostSpeed = 3;
            yellowGhostSpeed = 3;
            pinkGhostX = 3;
            pinkGhostY = 3;
            playerSpeed = 8;
            isGameOver = false;
            pacman.Left = 31;
            pacman.Top = 46;
            redGhost.Left = 180;
            redGhost.Top = 50;
            yellowGhost.Left = 360;
            yellowGhost.Top = 345;
            pinkGhost.Left = 440;
            pinkGhost.Top = 130;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gameTimer.Start();
        }

        private void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            lblScore.Text = "Score: " + score + Environment.NewLine + message;
        }
    }
}
