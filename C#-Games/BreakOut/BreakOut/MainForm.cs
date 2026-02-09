using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut
{
    public partial class MainForm : Form
    {
        bool goLeft, goRight, isGameOver;
        int score, ballX, ballY;
        int playerSpeed;
        Random rand = new Random();
        PictureBox[] blockArray;

        public MainForm()
        {
            InitializeComponent();
            PlaceBlocks();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;

            if(goLeft && pbPlayer.Left > 0)
            {
                pbPlayer.Left -= playerSpeed;
            }
            if(goRight && pbPlayer.Left < 515)
            {
                pbPlayer.Left += playerSpeed;
            }

            pbBall.Left += ballX;
            pbBall.Top += ballY;

            if(pbBall.Left < 0 || pbBall.Left > 580)
            {
                ballX = -ballX;
            }
            if(pbBall.Top < 0)
            {
                ballY = -ballY;
            }

            if(pbBall.Bounds.IntersectsWith(pbPlayer.Bounds))
            {
                //pbBall.Top = 463;
                ballY = rand.Next(5, 12) * -1;  

                if(ballX < 0)
                {
                    ballX = rand.Next(5, 12) * -1;
                }
                else
                {
                    ballX = rand.Next(5, 12);
                }
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {
                    if(pbBall.Bounds.IntersectsWith(x.Bounds))
                    {
                        score++;
                        ballY = -ballY;
                        this.Controls.Remove(x);
                    }
                }
            }

            if(score == 15)
            {
                GameOver("You Win!! Press Enter to play again");
            }

            if(pbBall.Top > 580)
            {
                GameOver("You Lose!! Press Enter to try again");
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = true;
            if (e.KeyCode == Keys.Right)
                goRight = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
            if(e.KeyCode == Keys.Enter && isGameOver)
            {
                RemoveBlocks();
                PlaceBlocks();
            }
        }

        private void SetupGame()
        {
            isGameOver = false;
            score = 0;
            ballX = 5;
            ballY = 5;
            playerSpeed = 12;
            lblScore.Text = "Score: " + score;
            pbBall.Left = 376;
            pbBall.Top = 328;
            pbPlayer.Left = 347;

            gameTimer.Start();

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                }
            }
        }

        private void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();

            lblScore.Text = "Score: " + score + " " + message;
        }

        private void PlaceBlocks()
        {
            blockArray = new PictureBox[15];

            int a = 0;
            int top = 50;
            int left = 20;

            for(int i = 0; i < blockArray.Length; ++i)
            {
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 80;
                blockArray[i].Tag = "blocks";
                blockArray[i].BackColor = Color.White;

                if(a == 5)
                {
                    top += 50;
                    left = 20;
                    a = 0;
                }

                if(a < 5)
                {
                    ++a;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    this.Controls.Add(blockArray[i]);
                    left += 120;
                }
            }

            SetupGame();
        }

        private void RemoveBlocks()
        {
            foreach(PictureBox x in blockArray)
            {
                this.Controls.Remove(x);
            }
        }
    }
}
