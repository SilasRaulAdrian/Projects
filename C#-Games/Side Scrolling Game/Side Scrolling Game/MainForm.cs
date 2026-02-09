using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Side_Scrolling_Game
{
    public partial class MainForm : Form
    {
        bool goLeft, goRight, jumping, hasKey;
        int jumpSpeed = 10;
        int force = 8;
        int score = 0;
        int playerSpeed = 10;
        int backgroundSpeed = 8;

        public MainForm()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = $"Score: {score}";
            player.Top += jumpSpeed;

            if (goLeft && player.Left > 60)
            {
                player.Left -= playerSpeed;
            }
            if (goRight && player.Left + (player.Width + 60) < this.ClientSize.Width)
            {
                player.Left += playerSpeed;
            }

            if (goLeft && background.Left < 0)
            {
                background.Left += backgroundSpeed;
                MoveGameElements("forward");
            }
            if (goRight && background.Left > -1372)
            {
                background.Left -= backgroundSpeed;
                MoveGameElements("back");
            }

            if (jumping)
            {
                jumpSpeed = -12;
                force--;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (jumping && force < 0)
            {
                jumping = false;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                        jumpSpeed = 0;
                    }

                    x.BringToFront();
                }

                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score++;
                    }
                }
            }

            if (player.Bounds.IntersectsWith(key.Bounds))
            {
                key.Visible = false;
                hasKey = true;
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && hasKey)
            {
                door.Image = Properties.Resources.door_open;
                gameTimer.Stop();
                MessageBox.Show($"Well done, your journey is complete!{Environment.NewLine}Click OK to play again!");
                RestartGame();
            }

            if (player.Top + player.Height > this.ClientSize.Height)
            {
                gameTimer.Stop();
                MessageBox.Show($"You died!{Environment.NewLine}Click OK to play again!");
                RestartGame();
            }
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
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RestartGame()
        {
            MainForm newWindow = new MainForm();
            newWindow.Show();
            this.Hide();
        }

        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" ||
                    x is PictureBox && (string)x.Tag == "coin" ||
                    x is PictureBox && (string)x.Tag == "key" ||
                    x is PictureBox && (string)x.Tag == "door")
                {
                    if (direction == "back")
                    {
                        x.Left -= backgroundSpeed;
                    }
                    if (direction == "forward")
                    {
                        x.Left += backgroundSpeed;
                    }
                }
            }
        }
    }
}
