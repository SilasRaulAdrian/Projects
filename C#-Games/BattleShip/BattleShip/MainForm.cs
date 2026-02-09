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

namespace BattleShip
{
    public partial class MainForm : Form
    {
        List<Button> playerPositionButtons;
        List<Button> enemyPositionButtons;
        Random rand = new Random();
        int totalShips = 3;
        int round = 10;
        int playerScore;
        int enemyScore;

        public MainForm()
        {
            InitializeComponent();
            ResetGame();
        }

        private void enemyPlayTimer_Tick(object sender, EventArgs e)
        {
            if(playerPositionButtons.Count > 0 && round > 0)
            {
                round--;
                lblRounds.Text = "Rounds: " + round;
                int index = rand.Next(playerPositionButtons.Count);

                if ((string)playerPositionButtons[index].Tag == "playerShip")
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.fireIcon;
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.DarkBlue;
                    playerPositionButtons.RemoveAt(index);
                    enemyScore++;
                    lblEnemy.Text = enemyScore.ToString();
                    enemyPlayTimer.Stop();
                }
                else
                {
                    playerPositionButtons[index].BackgroundImage = Properties.Resources.missIcon;
                    enemyMove.Text = playerPositionButtons[index].Text;
                    playerPositionButtons[index].Enabled = false;
                    playerPositionButtons[index].BackColor = Color.DarkBlue;
                    playerPositionButtons.RemoveAt(index);
                    enemyPlayTimer.Stop();
                }
            }

            if (round < 1 || enemyScore > 2 || playerScore > 2)
            {
                if (playerScore > enemyScore)
                {
                    MessageBox.Show("You win!!", "Winning");
                    ResetGame();
                }
                else if (enemyScore > playerScore)
                {
                    MessageBox.Show("Haha, I sunk your battle ship", "Lost");
                    ResetGame();
                }
                else if (enemyScore == playerScore)
                {
                    MessageBox.Show("No one wins this game", "Draw");
                    ResetGame();
                }
            }
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (EnemyLocationListBox.Text != "")
            {
                var attackPosition = EnemyLocationListBox.Text.ToLower();
                int index = enemyPositionButtons.FindIndex(a => a.Name == attackPosition);

                if (enemyPositionButtons[index].Enabled && round > 0)
                {
                    round--;
                    lblRounds.Text = "Rounds: " + round;

                    if ((string)enemyPositionButtons[index].Tag == "enemyShip")
                    {
                        enemyPositionButtons[index].Enabled = false;
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.fireIcon;
                        enemyPositionButtons[index].BackColor = Color.DarkBlue;
                        playerScore++;
                        lblPlayer.Text = playerScore.ToString();
                        enemyPlayTimer.Start();
                    }
                    else
                    {
                        enemyPositionButtons[index].Enabled = false;
                        enemyPositionButtons[index].BackgroundImage = Properties.Resources.missIcon;
                        enemyPositionButtons[index].BackColor = Color.DarkBlue;
                        enemyPlayTimer.Start();
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose a location from the drop down first!", "Information");
            }
        }

        private void PlayerPositionButtonsEvent(object sender, EventArgs e)
        {
            if(totalShips > 0)
            {
                var button = (Button)sender;
                button.Enabled = false;
                button.Tag = "playerShip";
                button.BackColor = Color.Orange;
                totalShips--;
            }

            if(totalShips == 0)
            {
                btnAttack.Enabled = true;
                btnAttack.BackColor = Color.Red;
                btnAttack.ForeColor = Color.White;

                lblHelp.Text = "2) Now pick the attack position from the drop down!";
            }
        }

        private void ResetGame()
        {
            playerPositionButtons = new List<Button> { w1, w2, w3, w4, x1, x2, x3, x4, y1, y2, y3, y4, z1, z2, z3, z4 };
            enemyPositionButtons = new List<Button> { a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4, d1, d2, d3, d4 };

            EnemyLocationListBox.Items.Clear();
            EnemyLocationListBox.Text = null;
            lblHelp.Text = "1) Click on 3 different locations from above to start!";

            for (int i = 0; i < enemyPositionButtons.Count; ++i)
            {
                enemyPositionButtons[i].Enabled = true;
                enemyPositionButtons[i].Tag = null;
                enemyPositionButtons[i].BackColor = Color.White;
                enemyPositionButtons[i].BackgroundImage = null;
                EnemyLocationListBox.Items.Add(enemyPositionButtons[i].Text);
            }

            for (int i = 0; i < playerPositionButtons.Count; ++i)
            {
                playerPositionButtons[i].Enabled = true;
                playerPositionButtons[i].Tag = null;
                playerPositionButtons[i].BackColor = Color.White;
                playerPositionButtons[i].BackgroundImage= null;
            }

            playerScore = 0;
            enemyScore = 0;
            round = 10;
            totalShips = 3;

            lblPlayer.Text = playerScore.ToString();
            lblEnemy.Text = enemyScore.ToString();
            enemyMove.Text = "A1";

            btnAttack.Enabled = false;

            EnemyLocationPicker();
        }

        private void EnemyLocationPicker()
        {
            for (int i = 0; i < 3; ++i)
            {
                int index = rand.Next(enemyPositionButtons.Count);

                if (enemyPositionButtons[index].Enabled == true && (string)enemyPositionButtons[index].Tag == null)
                {
                    enemyPositionButtons[index].Tag = "enemyShip";
                    Debug.WriteLine("Enemy Position: " + enemyPositionButtons[index].Text);
                }
                else
                {
                    index = rand.Next(enemyPositionButtons.Count);
                }
            }
        }
    }
}
