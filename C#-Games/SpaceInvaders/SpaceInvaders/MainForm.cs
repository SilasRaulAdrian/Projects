using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class MainForm : Form
    {
        bool goLeft, goRight;
        int playerSpeed = 12;
        int enemySpeed = 5;
        int score = 0;
        int enemyBulletTimer = 300;
        PictureBox[] sadInvadersArray;
        bool shooting;
        bool isGameOver;

        public MainForm()
        {
            InitializeComponent();
            GameSetup();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;

            if(goLeft)
            {
                pbPlayer.Left -= playerSpeed;
            }
            if(goRight)
            {
                pbPlayer.Left += playerSpeed;
            }

            enemyBulletTimer -= 10;

            if(enemyBulletTimer < 1)
            {
                enemyBulletTimer = 300;
                MakeBullet("sadBullet");
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "sadInvaders")
                {
                    x.Left += enemySpeed;

                    if(x.Left > 730)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if(x.Bounds.IntersectsWith(pbPlayer.Bounds))
                    {
                        GameOver("You've been invaded by the sad invaders, you are now sad!");
                    }

                    foreach(Control y in this.Controls)
                    {
                        if(y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if(y.Bounds.IntersectsWith(x.Bounds))
                            {
                                this.Controls.Remove(x);
                                this.Controls.Remove(y);
                                score++;
                                shooting = false;
                            }
                        }
                    }
                }

                if(x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;

                    if(x.Top < 15)
                    {
                        this.Controls.Remove(x);
                        shooting = false;
                    }
                }

                if(x is PictureBox && (string)x.Tag == "sadBullet")
                {
                    x.Top += 20;

                    if(x.Top > 620)
                    {
                        this.Controls.Remove(x);
                    }

                    if(x.Bounds.IntersectsWith(pbPlayer.Bounds))
                    {
                        this.Controls.Remove(x);
                        GameOver("You've been killed by the sad bullet. Now you are sad forever!");
                    }
                }
            }

            if(score > 8)
            {
                enemySpeed = 12;
            }

            if(score == sadInvadersArray.Length)
            {
                GameOver("Woohoo Happiness Found, Keep it safe!");
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

            if(e.KeyCode == Keys.Space && !shooting)
            {
                shooting = true;
                MakeBullet("bullet");
            }

            if(e.KeyCode == Keys.Enter && isGameOver)
            {
                RemoveAll();
                GameSetup();
            }
        }

        private void MakeInvaders()
        {
            sadInvadersArray = new PictureBox[15];
            int left = 0;

            for(int i = 0; i < sadInvadersArray.Length; ++i)
            {
                sadInvadersArray[i] = new PictureBox();
                sadInvadersArray[i].Size = new Size(60, 50);
                sadInvadersArray[i].Image = Properties.Resources.sadFace;
                sadInvadersArray[i].Top = 5;
                sadInvadersArray[i].Tag = "sadInvaders";
                sadInvadersArray[i].Left = left;
                sadInvadersArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(sadInvadersArray[i]);
                left -= 80;
            }
        }

        private void GameSetup()
        {
            lblScore.Text = "Score: 0";
            score = 0;
            isGameOver = false;

            enemyBulletTimer = 300;
            enemySpeed = 5;
            shooting = false;

            MakeInvaders();
            gameTimer.Start();
        }

        private void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            lblScore.Text = "Score: " + score + " " + message;
        }

        private void RemoveAll()
        {
            foreach(PictureBox i in sadInvadersArray)
            {
                this.Controls.Remove(i);
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "bullet" || (string)x.Tag == "sadBullet")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

        private void MakeBullet(string bulletTag)
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = bulletTag;
            bullet.Left = pbPlayer.Left + pbPlayer.Width / 2;

            if((string)bullet.Tag == "bullet")
            {
                bullet.Top = pbPlayer.Top - 20;
            }
            else if((string)bullet.Tag == "sadBullet")
            {
                bullet.Top = -100;
            }

            this.Controls.Add(bullet);
            bullet.BringToFront();
        }
    }
}
