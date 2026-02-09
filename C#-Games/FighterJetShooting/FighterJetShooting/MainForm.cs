using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FighterJetShooting
{
    public partial class MainForm : Form
    {
        bool goLeft, goRight, shooting, isGameOver;
        int score;
        int playerSpeed = 12;
        int enemySpeed;
        int bulletSpeed;
        Random rand = new Random();

        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = score.ToString();

            pbEnemy1.Top += enemySpeed;
            pbEnemy2.Top += enemySpeed;
            pbEnemy3.Top += enemySpeed;

            if(pbEnemy1.Top > 710 || pbEnemy2.Top > 710 || pbEnemy3.Top > 710)
            {
                GameOver();
            }

            if(goLeft && pbPlayer.Left > 0)
            {
                pbPlayer.Left -= playerSpeed;
            }
            if(goRight && pbPlayer.Left < 500)
            {
                pbPlayer.Left += playerSpeed;
            }

            if(shooting)
            {
                bulletSpeed = 20;
                pbBullet.Top -= bulletSpeed;
            }
            else
            {
                pbBullet.Left = -300;
                bulletSpeed = 0;
            }

            if(pbBullet.Top < -30)
            {
                shooting = false;
            }

            if(pbBullet.Bounds.IntersectsWith(pbEnemy1.Bounds))
            {
                score++;
                pbEnemy1.Top = -450;
                pbEnemy1.Left = rand.Next(20, 500);
                shooting = false;
            }
            if (pbBullet.Bounds.IntersectsWith(pbEnemy2.Bounds))
            {
                score++;
                pbEnemy2.Top = -650;
                pbEnemy2.Left = rand.Next(20, 500);
                shooting = false;
            }
            if (pbBullet.Bounds.IntersectsWith(pbEnemy3.Bounds))
            {
                score++;
                pbEnemy3.Top = -750;
                pbEnemy3.Left = rand.Next(20, 500);
                shooting = false;
            }

            /*if (pbPlayer.Bounds.IntersectsWith(pbEnemy1.Bounds))
                GameOver();
            if (pbPlayer.Bounds.IntersectsWith(pbEnemy2.Bounds))
                GameOver();
            if (pbPlayer.Bounds.IntersectsWith(pbEnemy3.Bounds))
                GameOver();*/

            if(score == 5)
            {
                enemySpeed = 10;
            }
            if(score == 10)
            {
                enemySpeed = 15;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if(e.KeyCode == Keys.Space && shooting == false)
            {
                shooting = true;
                pbBullet.Top = pbPlayer.Top - 30;
                pbBullet.Left = pbPlayer.Left + (pbPlayer.Width / 2);
            }
            if(e.KeyCode == Keys.Enter && isGameOver) 
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            gameTimer.Start();
            enemySpeed = 6;

            pbEnemy1.Left = rand.Next(20, 500);
            pbEnemy2.Left = rand.Next(20, 500);
            pbEnemy3.Left = rand.Next(20, 500);

            pbEnemy1.Top = rand.Next(0, 200) * -1;
            pbEnemy2.Top = rand.Next(0, 500) * -1;
            pbEnemy3.Top = rand.Next(0, 900) * -1;

            score = 0;
            bulletSpeed = 0;
            pbBullet.Left = -300;
            shooting = false;

            lblScore.Text = score.ToString();
        }

        private void GameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            lblScore.Text += Environment.NewLine + "Game Over!!" + Environment.NewLine + "Press Enter to try again.";
        }
    }
}
