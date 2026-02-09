using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;

namespace OneLineJokes
{
    public partial class MainForm : Form
    {
        int lineNum = -1;
        PrivateFontCollection newFont = new PrivateFontCollection();
        bool playing = false;

        public MainForm()
        {
            InitializeComponent();

            newFont.AddFontFile("Rainbow Paper.ttf");
            lblJoke.Font = new Font(newFont.Families[0], 24, FontStyle.Bold);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (playing && lineNum < listBox1.Items.Count - 1)
            {
                lineNum++;
                listBox1.SetSelected(lineNum, true);
            }
            else
            {
                lineNum = -1;
                playing = false;
                gameTimer.Stop();
                btnStart.Text = "Start";
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"D:\INFORMATICA\C#\Games\OneLineJokes\OneLineJokes\Resurse\txt";
            openFile.Title = "Browse Text Files Only";
            openFile.Filter = "Text Files Only (*.txt) | *.txt";
            openFile.DefaultExt = "txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();

                var fileLocation = File.ReadAllLines(openFile.FileName);
                List<string> lines = new List<string>(fileLocation);

                for (int i = 0; i < lines.Count; ++i)
                {
                    listBox1.Items.Add(lines[i]);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                if (listBox1.Items.Count > 0)
                {
                    playing = true;
                    gameTimer.Start();
                    btnStart.Text = "Stop";
                }
                else
                {
                    MessageBox.Show("Select a text file first! ", "Raul Says: ");
                }
            }
            else
            {
                gameTimer.Stop();
                btnStart.Text = "Start";
                playing = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblJoke.Text = listBox1.SelectedItem.ToString();
        }
    }
}
