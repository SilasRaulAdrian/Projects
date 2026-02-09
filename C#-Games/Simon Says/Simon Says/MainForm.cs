using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Simon_Says
{
    public partial class MainForm : Form
    {
        int blocksX = 160;
        int blocksY = 80;
        int score = 0;
        int level = 3;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PictureBox> chosenBoxes = new List<PictureBox>();
        Random rand = new Random();
        Color temp;
        int index = 0;
        int tries = 0;
        int timeLimit = 0;
        bool selectingColours = false;
        string correctOrder = string.Empty;
        string playerOrder = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            SetUpBlocks();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (selectingColours)
            {
                timeLimit++;

                switch (timeLimit)
                {
                    case 10:
                        temp = chosenBoxes[index].BackColor;
                        chosenBoxes[index].BackColor = Color.White;
                        break;
                    case 20:
                        chosenBoxes[index].BackColor = temp;
                        break;
                    case 30:
                        chosenBoxes[index].BackColor = Color.White;
                        break;
                    case 40:
                        chosenBoxes[index].BackColor = temp;
                        break;
                    case 50:
                        if (index < chosenBoxes.Count - 1)
                        {
                            index++;
                            timeLimit = 0;
                        }
                        else
                        {
                            selectingColours = false;
                        }
                        break;
                }
            }

            if (tries >= level)
            {
                if (correctOrder == playerOrder)
                {
                    tries = 0;
                    gameTimer.Stop();
                    MessageBox.Show("Well done, you got them correctly.", "Simon Says: ");
                    score++;
                }
                else
                {
                    tries = 0;
                    gameTimer.Stop();
                    MessageBox.Show("Your guesses did not match, try again.", "Simon Says: ");
                }
            }

            lblInfo.Text = $"CLick on {level} blocks in the same sequence.";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (score == 3 && level < 7)
            {
                level++;
                score = 0;
            }

            correctOrder = string.Empty;
            playerOrder = string.Empty;
            chosenBoxes.Clear();
            chosenBoxes = pictureBoxes.OrderBy(x => rand.Next()).Take(level).ToList();

            for (int i = 0; i < chosenBoxes.Count; ++i)
            {
                correctOrder += chosenBoxes[i].Name + " ";
            }

            foreach (PictureBox x in pictureBoxes)
            {
                x.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            Debug.WriteLine(correctOrder);
            index = 0;
            timeLimit = 0;
            selectingColours = true;
            gameTimer.Start();
        }

        private void SetUpBlocks()
        {
            for (int i = 1; i < 17; ++i)
            {
                PictureBox newPic = new PictureBox();
                newPic.Name = $"pic_{i}";
                newPic.Height = 60;
                newPic.Width = 60;
                newPic.BackColor = Color.Black;
                newPic.Left = blocksX;
                newPic.Top = blocksY;
                newPic.Click += ClickOnPictureBox;

                if (i == 4 || i == 8 || i == 12)
                {
                    blocksY += 65;
                    blocksX = 160;
                }
                else
                {
                    blocksX += 65;
                }

                this.Controls.Add(newPic);
                pictureBoxes.Add(newPic);
            }
        }

        private void ClickOnPictureBox(object sender, EventArgs e)
        {
            if (!selectingColours && chosenBoxes.Count > 1)
            {
                PictureBox temp = sender as PictureBox;
                temp.BackColor = Color.Black;
                playerOrder += temp.Name + " ";
                Debug.WriteLine(playerOrder);
                tries++;
            }
            else
            {
                return;
            }
        }
    }
}
