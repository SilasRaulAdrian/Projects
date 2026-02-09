using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Penalty_Goal_Shootout_Game
{
    public partial class MainForm : Form
    {
        List<string> keeperPosition = new List<string> { "left", "right", "top", "topLeft", "topRight" };
        List<PictureBox> goalTarget;
        int ballX = 0;
        int ballY = 0;
        int goal = 0;
        int miss = 0;
        string state;
        string playerTarget;
        bool aimSet = false;
        Random rand = new Random();

        public MainForm()
        {
            InitializeComponent();
            goalTarget = new List<PictureBox> { left, right, top, topLeft, topRight };
        }

        private void keeperTimer_Tick(object sender, EventArgs e)
        {
            switch (state)
            {
                case "left":
                    goalkeeper.Left -= 6;
                    goalkeeper.Top = 204;
                    break;
                case "right":
                    goalkeeper.Left += 6;
                    goalkeeper.Top = 204;
                    break;
                case "top":
                    goalkeeper.Top -= 6;
                    break;
                case "topLeft":
                    goalkeeper.Left -= 6;
                    goalkeeper.Top -= 3;
                    break;
                case "topRight":
                    goalkeeper.Left += 6;
                    goalkeeper.Top -= 3;
                    break;
            }

            foreach (PictureBox x in goalTarget)
            {
                if (goalkeeper.Bounds.IntersectsWith(x.Bounds))
                {
                    keeperTimer.Stop();
                    goalkeeper.Location = new Point(300, 120);
                    goalkeeper.Image = Properties.Resources.stand_small;
                }
            }
        }

        private void ballTimer_Tick(object sender, EventArgs e)
        {
            football.Left -= ballX;
            football.Top -= ballY;

            foreach (PictureBox x in goalTarget)
            {
                if (football.Bounds.IntersectsWith(x.Bounds))
                {
                    football.Location = new Point(330, 400);
                    ballX = 0;
                    ballY = 0;
                    aimSet = false;
                    ballTimer.Stop();
                }
            }
        }

        private void SetGoalTargetEvent(object sender, EventArgs e)
        {
            if (aimSet)
                return;

            ballTimer.Start();
            keeperTimer.Start();
            ChangeGoalkeeperImage();

            var senderObject = (PictureBox)sender;
            senderObject.BackColor = Color.Beige;

            if (senderObject.Tag.ToString() == "topRight")
            {
                ballX = -7;
                ballY = 15;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }
            if (senderObject.Tag.ToString() == "right")
            {
                ballX = -11;
                ballY = 15;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }
            if (senderObject.Tag.ToString() == "top")
            {
                ballX = 0;
                ballY = 20;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }
            if (senderObject.Tag.ToString() == "topLeft")
            {
                ballX = 8;
                ballY = 15;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }
            if (senderObject.Tag.ToString() == "left")
            {
                ballX = 7;
                ballY = 8;
                playerTarget = senderObject.Tag.ToString();
                aimSet = true;
            }

            CheckScore();
        }

        private void CheckScore()
        {
            if (state == playerTarget)
            {
                miss++;
                lblMissed.Text = $"Missed: {miss}";
            }
            else
            {
                goal++;
                lblScore.Text = $"Scored: {goal}";
            }
        }

        private void ChangeGoalkeeperImage()
        {
            keeperTimer.Start();
            int i = rand.Next(0, keeperPosition.Count);
            state = keeperPosition[i];

            switch (i)
            {
                case 0:
                    goalkeeper.Image = Properties.Resources.left_save_small;
                    break;
                case 1:
                    goalkeeper.Image = Properties.Resources.right_save_small;
                    break;
                case 2:
                    goalkeeper.Image = Properties.Resources.top_save_small;
                    break;
                case 3:
                    goalkeeper.Image = Properties.Resources.top_left_save_small;
                    break;
                case 4:
                    goalkeeper.Image = Properties.Resources.top_right_save_small;
                    break;
            }

        }
    }
}
