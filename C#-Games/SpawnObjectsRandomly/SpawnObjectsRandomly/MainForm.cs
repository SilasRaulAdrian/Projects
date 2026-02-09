using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpawnObjectsRandomly
{
    public partial class MainForm : Form
    {
        List<PictureBox> items = new List<PictureBox>();
        Random rand = new Random();
        int x, y;
        int playerSpeed = 8;
        int spawnTime = 20;
        Color[] newColor = { Color.Red, Color.Turquoise, Color.Gold, Color.LimeGreen };
        bool goUp, goDown, goLeft, goRight;

        public MainForm()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if(goLeft)
            {
                player.Left -= playerSpeed;
            }
            if(goRight)
            {
                player.Left += playerSpeed;
            }
            if(goUp)
            {
                player.Top -= playerSpeed;
            }
            if(goDown)
            {
                player.Top += playerSpeed;
            }

            lblItems.Text = "Items: " + items.Count();
            spawnTime--;

            if (spawnTime < 1) 
            {
                MakePictureBox();
                spawnTime = 20;
            }

            foreach(PictureBox item in items.ToList())
            {
                if(player.Bounds.IntersectsWith(item.Bounds))
                {
                    items.Remove(item);
                    this.Controls.Remove(item);
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = true;
            if (e.KeyCode == Keys.Right)
                goRight = true;
            if (e.KeyCode == Keys.Up)
                goUp = true;
            if (e.KeyCode == Keys.Down)
                goDown = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
            if (e.KeyCode == Keys.Up)
                goUp = false;
            if (e.KeyCode == Keys.Down)
                goDown = false;
        }

        private void MakePictureBox()
        {
            PictureBox newPic = new PictureBox();
            newPic.Height = 30;
            newPic.Width = 30;
            newPic.BackColor = newColor[rand.Next(0, newColor.Length)];

            x = rand.Next(10, this.ClientSize.Width - newPic.Width);
            y = rand.Next(10, this.ClientSize.Height - newPic.Height);

            newPic.Location = new Point(x, y);

            items.Add(newPic);
            this.Controls.Add(newPic);
        }
    }
}
