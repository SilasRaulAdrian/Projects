using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SlideShow
{
    public partial class MainForm : Form
    {
        List<string> filteredFiles;
        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        int counter = -1;
        int timerInterval = 1000;
        bool isPlaying = false;

        public MainForm()
        {
            InitializeComponent();

            radioButton1.Checked = true;
            gameTimer.Interval = timerInterval;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counter++;

            if(counter >= filteredFiles.Count)
            {
                counter = -1;
            }
            else
            {
                pbImageViewer.Image = Image.FromFile(filteredFiles[counter]);
                lblFileInfo.Text = filteredFiles[counter].ToString();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            counter = -1;
            isPlaying = false;
            gameTimer.Stop();
            btnPlay.Text = "Play";
            DialogResult result = folderBrowser.ShowDialog();
            filteredFiles = Directory.GetFiles(folderBrowser.SelectedPath, "*.*")
                .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("gif")
                || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("bmp")).ToList();

            lblFileInfo.Text = "Folder loaded - Now Press Play!";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(!isPlaying)
            {
                btnPlay.Text = "Stop";
                gameTimer.Start();
                isPlaying = true;
            }
            else
            {
                btnPlay.Text = "Play";
                isPlaying = false;
                gameTimer.Stop();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton tempRadioButton = sender as RadioButton;
            
            switch(tempRadioButton.Text.ToString())
            {
                case "1x":
                    timerInterval = 3000;
                    break;
                case "2x":
                    timerInterval = 2000;
                    break;
                case "3x":
                    timerInterval = 1000;
                    break;
            }

            gameTimer.Interval = timerInterval;
        }
    }
}
