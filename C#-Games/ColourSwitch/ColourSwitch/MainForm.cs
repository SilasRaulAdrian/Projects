using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColourSwitch
{
    public partial class MainForm : Form
    {
        List<Color> colors;
        Random rand = new Random();
        Random blockPosition = new Random();
        int i;
        int speed = 5;
        int score = 0;
        int location;
        int blockColor;
        bool gameOver = false;

        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;

            foreach(Control x in pnlGame.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "block")
                {
                    x.Top += speed;

                    if(x.Top + x.Height > this.ClientSize.Height)
                    {
                        location = blockPosition.Next(400, 600) + (3 * blockPosition.Next(150, 250));
                        x.Top = location * -1;
                        blockColor = rand.Next(0, colors.Count);
                        x.BackColor = colors[blockColor];
                        score++;
                    }

                    if(player.Bounds.IntersectsWith(x.Bounds))
                    {
                        if(player.BackColor != x.BackColor)
                        {
                            gameTimer.Stop();
                            lbScore.Items.Insert(0, "Scored: " + score + " @ " + string.Format(" {0:HH:mm tt}", DateTime.Now));
                            gameOver = true;
                        }
                    }
                }
            }

            if(score > 10)
            { 
                speed = 12; 
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Space && !gameOver)
            {
                i++;

                if (i > colors.Count - 1) 
                {
                    i = 0;
                }

                player.BackColor = colors[i];
            }

            if(e.KeyChar == (char)Keys.R && gameOver || e.KeyChar == char.ToLower((char)Keys.R) && gameOver)
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            block1.Top = -200;
            block2.Top = -750;
            gameOver = false;

            colors = new List<Color> { Color.Red, Color.White, Color.Purple, Color.Yellow };
            i = 0;
            speed = 8;
            score = 0;

            lblScore.Text = "Score: " + score;

            gameTimer.Start();
        }
    }
}
