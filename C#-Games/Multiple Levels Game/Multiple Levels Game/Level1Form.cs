using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Levels_Game
{
    public partial class Level1Form : Form
    {
        bool goUp, goDown, goLeft, goRight;
        int playerSpeed = 8;
        bool gotKey;

        public Level1Form()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (goLeft)
            {
                player.Left -= playerSpeed;
            }
            if (goRight)
            {
                player.Left += playerSpeed;
            }
            if (goDown)
            {
                player.Top += playerSpeed;
            }
            if (goUp)
            {
                player.Top -= playerSpeed;
            }

            if (key.Bounds.IntersectsWith(player.Bounds))
            {
                gotKey = true;
                key.Visible = false;
            }

            if (door.Bounds.IntersectsWith(player.Bounds) && gotKey)
            {
                Level2Form newLevel = new Level2Form();
                this.Hide();
                gameTimer.Stop();
                gotKey = false;
                newLevel.Show();
            }
        }

        private void Level1Form_KeyDown(object sender, KeyEventArgs e)
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

        private void Level1Form_KeyUp(object sender, KeyEventArgs e)
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

        private void Level1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
