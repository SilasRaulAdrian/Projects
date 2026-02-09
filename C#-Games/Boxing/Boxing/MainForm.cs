using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boxing
{
    public partial class MainForm : Form
    {
        bool playerBlock = false;
        bool enemyBlock = false;
        Random rand = new Random();
        int enemySpeed = 5;
        int index = 0;
        int playerHealth = 100;
        int enemyHealth = 100;
        List<string> enemyAttack = new List<string> { "left", "right", "block" };

        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void boxerAttackTimer_Tick(object sender, EventArgs e)
        {
            index = rand.Next(0, enemyAttack.Count);
            switch (enemyAttack[index].ToString())
            {
                case "left":
                    boxer.Image = Properties.Resources.enemy_punch1;
                    enemyBlock = false;
                    if (boxer.Bounds.IntersectsWith(player.Bounds) && !playerBlock)
                    {
                        playerHealth -= 5;
                    }
                    break;
                case "right":
                    boxer.Image = Properties.Resources.enemy_punch2;
                    enemyBlock = false;
                    if (boxer.Bounds.IntersectsWith(player.Bounds) && !playerBlock)
                    {
                        playerHealth -= 5;
                    }
                    break;
                case "block":
                    boxer.Image = Properties.Resources.enemy_block;
                    enemyBlock = true;
                    break;
            }
        }

        private void boxerMoveTimer_Tick(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                playerHealthBar.Value = playerHealth;
            }
            if (enemyHealth > 1)
            {
                boxerHealthBar.Value = enemyHealth;
            }

            boxer.Left += enemySpeed;
            if (boxer.Left > 400)
            {
                enemySpeed = -5;
            }
            if (boxer.Left < 150)
            {
                enemySpeed = 5;
            }

            if (enemyHealth < 1)
            {
                boxerAttackTimer.Stop();
                boxerMoveTimer.Stop();
                MessageBox.Show("You Win, Click OK to Play Again", "Raul Says: ");
                ResetGame();
            }
            if (playerHealth < 1)
            {
                boxerAttackTimer.Stop();
                boxerMoveTimer.Stop();
                MessageBox.Show("Tough Rob Wins, Click OK to Play Again", "Raul Says: ");
                ResetGame();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.Image = Properties.Resources.boxer_left_punch;
                playerBlock = false;

                if (player.Bounds.IntersectsWith(boxer.Bounds) && !enemyBlock)
                {
                    enemyHealth -= 5;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                player.Image = Properties.Resources.boxer_right_punch;
                playerBlock = false;

                if (player.Bounds.IntersectsWith(boxer.Bounds) && !enemyBlock)
                {
                    enemyHealth -= 5;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                player.Image = Properties.Resources.boxer_block;
                playerBlock = true;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            player.Image = Properties.Resources.boxer_stand;
            playerBlock = false;
        }

        private void ResetGame()
        {
            boxerAttackTimer.Start();
            boxerMoveTimer.Start();
            playerHealth = 100;
            enemyHealth = 100;

            boxer.Left = 400;
        }
    }
}
