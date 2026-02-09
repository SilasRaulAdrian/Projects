using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Rex_Google_Game
{
    public partial class MainForm : Form
    {
        bool jumping = false;
        int jumpSpeed = 12;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pbTrex.Top += jumpSpeed;
            lblScore.Text = "Score: " + score;

            if(jumping && force < 0)
            {
                jumping = false;
            }

            if(jumping)
            {
                jumpSpeed = -12;
                force--;
            }
            else
            {
                jumpSpeed = 12;
            }

            if(pbTrex.Top > 289 && !jumping)
            {
                force = 12;
                pbTrex.Top = 290;
                jumpSpeed = 0;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if(x.Left < -100)
                    {
                        x.Left = rand.Next(200, 500) + (x.Width * 15);
                        score++;
                    }

                    if(pbTrex.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        pbTrex.Image = Properties.Resources.dead;
                        lblScore.Text += " Press R to restart the game!";
                        isGameOver = true;
                    }
                }
            }

            if(score > 10)
            {
                obstacleSpeed = 15;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !jumping)
            { 
                jumping = true; 
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(jumping)
            {
                jumping = false;
            }

            if(e.KeyCode == Keys.R && isGameOver)
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            lblScore.Text = "Score: " + score;
            pbTrex.Image = Properties.Resources.running;
            isGameOver = false;
            pbTrex.Top = 290;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "obstacle")
                {
                    position = rand.Next(500, 800) + (x.Width * 10);

                    x.Left = position;
                }
            }

            gameTimer.Start();
        }
    }
}
