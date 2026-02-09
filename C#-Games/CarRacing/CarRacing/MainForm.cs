using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CarRacing
{
    public partial class MainForm : Form
    {
        int roadSpeed, trafficSpeed, playerSpeed = 12, score, carImage;
        Random rand = new Random();
        Random carPosition = new Random();
        bool goLeft, goRight;
        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;
            score++;

            if (goLeft && player.Left > 10)
                player.Left -= playerSpeed;
            if (goRight && player.Left < 295)
                player.Left += playerSpeed;

            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;

            if(roadTrack2.Top > 519)
            {
                roadTrack2.Top = -519;
            }
            if(roadTrack1.Top > 519)
            {
                roadTrack1.Top = -519;
            }

            AI1.Top += trafficSpeed;
            AI2.Top += playerSpeed;

            if(AI1.Top > 530)
            {
                ChangeAICars(AI1);
            }
            if(AI2.Top > 530)
            {
                ChangeAICars(AI2);
            }

            if(player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                GameOver();
            }

            if(score >= 0 && score <= 500)
            {
                award.Image = Properties.Resources.bronze;
            }
            if(score > 500 && score <= 1000)
            {
                award.Image = Properties.Resources.silver;
                roadSpeed = 20;
                trafficSpeed = 22;
            }
            if(score > 1000)
            {
                award.Image = Properties.Resources.gold;
                trafficSpeed = 27;
                roadSpeed = 25;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = true;
            if (e.KeyCode == Keys.Right)
                goRight = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
        }

        private void ChangeAICars(PictureBox tempCar)
        {
            carImage = rand.Next(1, 9);
            switch(carImage)
            {
                case 1:
                    tempCar.Image = Properties.Resources.ambulance;
                    break;
                case 2:
                    tempCar.Image = Properties.Resources.carGreen;
                    break;
                case 3:
                    tempCar.Image = Properties.Resources.carGrey;
                    break;
                case 4:
                    tempCar.Image = Properties.Resources.carOrange;
                    break;
                case 5:
                    tempCar.Image = Properties.Resources.carPink;
                    break;
                case 6:
                    tempCar.Image = Properties.Resources.CarRed;
                    break;
                case 7:
                    tempCar.Image = Properties.Resources.carYellow;
                    break;
                case 8:
                    tempCar.Image = Properties.Resources.TruckBlue;
                    break;
                case 9:
                    tempCar.Image = Properties.Resources.TruckWhite;
                    break;
            }

            tempCar.Top = carPosition.Next(100, 400) * -1;

            if((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(5, 150);
            }
            if((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(150, 310);
            }
        }

        private void GameOver()
        {
            PlaySound();
            gameTimer.Stop();
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;

            award.Visible = true;
            award.BringToFront();

            btnStart.Enabled = true;
        }

        private void ResetGame()
        {
            btnStart.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goLeft = false;
            goRight = false;
            score = 0;
            award.Image = Properties.Resources.bronze;
            roadSpeed = 12;
            trafficSpeed = 15;
            AI1.Top = carPosition.Next(200, 500) * -1;
            AI1.Left = carPosition.Next(5, 150);
            AI2.Top = carPosition.Next(200, 500) * -1;
            AI2.Left = carPosition.Next(150, 310);

            gameTimer.Start();

        }

        private void PlaySound()
        {
            SoundPlayer playCrash = new SoundPlayer(Properties.Resources.hit);
            playCrash.Play();
        }
    }
}
