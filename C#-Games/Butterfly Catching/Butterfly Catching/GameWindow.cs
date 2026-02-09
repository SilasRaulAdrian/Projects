using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Butterfly_Catching
{
    public partial class GameWindow : Form
    {
        float timeLeft = 60f;
        int caught = 0;
        int spawnTime = 0;
        int spawnLimit = 30;
        List<Butterfly> butterflyList = new List<Butterfly>();
        Random rand = new Random();
        Image[] butterflyImages = { Properties.Resources._01, Properties.Resources._02,
            Properties.Resources._03, Properties.Resources._04, Properties.Resources._05,
            Properties.Resources._06, Properties.Resources._07, Properties.Resources._08,
            Properties.Resources._09, Properties.Resources._10 };

        public GameWindow()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $"Time Left: {timeLeft.ToString("#")}.s";
            lblCaught.Text = $"Caught: {caught}";
            timeLeft -= 0.03f;

            if (butterflyList.Count < spawnLimit)
            {
                spawnTime--;

                if (spawnTime < 1)
                {
                    MakeButterfly();
                    spawnTime = spawnLimit;
                }
            }

            foreach (Butterfly butterfly in butterflyList)
            {
                butterfly.MoveButterfly();
                butterfly.positionX += butterfly.speedX;

                if (butterfly.positionX < 0 || butterfly.positionX + butterfly.width > this.ClientSize.Width)
                {
                    butterfly.speedX = -butterfly.speedX;

                    if (butterfly.positionX < 0)
                    {
                        butterfly.positionX = butterfly.positionX + 10;
                    }
                    else if (butterfly.positionX + butterfly.width > this.ClientSize.Width)
                    {
                        butterfly.positionX = butterfly.positionX - 10;
                    }
                }

                butterfly.positionY += butterfly.speedY;

                if (butterfly.positionY < 0 || butterfly.positionY + butterfly.height > this.ClientSize.Height - 50)
                {
                    butterfly.speedY = -butterfly.speedY;

                    if (butterfly.positionY < 0)
                    {
                        butterfly.positionY = butterfly.positionY + 10;
                    }
                    else if (butterfly.positionY + butterfly.height > this.ClientSize.Height - 50)
                    {
                        butterfly.positionY = butterfly.positionY - 10;
                    }
                }
            }

            if (timeLeft < 1)
            {
                GameOver();
            }

            this.Invalidate();
        }

        private void GameWindow_Click(object sender, EventArgs e)
        {
            foreach (Butterfly butterfly in butterflyList.ToList())
            {
                MouseEventArgs mouse = (MouseEventArgs)e;

                if (mouse.X >= butterfly.positionX && mouse.Y >= butterfly.positionY &&
                    mouse.X < butterfly.positionX + butterfly.width &&
                    mouse.Y < butterfly.positionY + butterfly.height)
                {
                    butterflyList.Remove(butterfly);
                    caught++;
                }
            }
        }

        private void GameWindow_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();

            foreach (Butterfly butterfly in butterflyList)
            {
                e.Graphics.DrawImage(butterfly.butterflyImage, butterfly.positionX, butterfly.positionY,
                    butterfly.width, butterfly.height);
            }
        }

        private void MakeButterfly()
        {
            int i = rand.Next(butterflyImages.Length);

            Butterfly newButterfly = new Butterfly();
            newButterfly.butterflyImage = butterflyImages[i];
            newButterfly.positionX = rand.Next(50, this.ClientSize.Width - 200);
            newButterfly.positionY = rand.Next(50, this.ClientSize.Height - 200);
            butterflyList.Add(newButterfly);
            ImageAnimator.Animate(newButterfly.butterflyImage, this.OnFrameChangedHandler);
        }

        private void OnFrameChangedHandler(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void RestartGame()
        {
            this.Invalidate();
            butterflyList.Clear();
            caught = 0;
            timeLeft = 60f;
            spawnTime = 0;
            lblTime.Text = "Time Left: 00";
            lblCaught.Text = "Caught: 0";
            gameTimer.Start();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show($"Times Up!! You've Caught {caught} butterflies. Click OK to try again.",
                "Raul Says: ");
            RestartGame();
        }
    }
}
