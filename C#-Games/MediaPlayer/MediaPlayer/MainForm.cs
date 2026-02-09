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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MediaPlayer
{
    public partial class MainForm : Form
    {
        List<string> filteredFiles = new List<string>();
        FolderBrowserDialog browser = new FolderBrowserDialog();
        int currentFile = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoPlayer.Ctlcontrols.stop();

            if(filteredFiles.Count > 1)
            {
                filteredFiles.Clear();
                filteredFiles = null;
                listPlay.Items.Clear();
                currentFile = 0;
            }

            DialogResult result = browser.ShowDialog();
            if (result == DialogResult.OK)
            {
                filteredFiles = Directory.GetFiles(browser.SelectedPath, "*.*").
                    Where(file => file.ToLower().EndsWith("webm") || 
                    file.ToLower().EndsWith("mp4") || 
                    file.ToLower().EndsWith("wmv") || 
                    file.ToLower().EndsWith("mkv") || 
                    file.ToLower().EndsWith("avi")).ToList();
                LoadPlaylist();
            }
        }

        private void videoPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 0)
            {
                lblDuration.Text = "Media Player is Ready to be loaded";
            }
            else if (e.newState == 1)
            {
                lblDuration.Text = "Media Player stopped";
            }
            else if (e.newState == 3)
            {
                lblDuration.Text = "Duration: " + videoPlayer.currentMedia.durationString;
            }
            else if (e.newState == 8)
            {
                if (currentFile >= filteredFiles.Count - 1)
                {
                    currentFile = 0;
                }
                else
                {
                    currentFile += 1;
                }
                listPlay.SelectedIndex = currentFile;
                ShowFileName(lblFileName);
            }
            else if (e.newState == 9)
            {
                lblDuration.Text = "Loading new video";
            }
            else if (e.newState == 10)
            {
                timer1.Start();
            }
        }

        private void listPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFile = listPlay.SelectedIndex;
            PlayFile(listPlay.SelectedItem.ToString());
            ShowFileName(lblFileName);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            videoPlayer.Ctlcontrols.play();
            timer1.Stop();
        }

        private void LoadPlaylist()
        {
            videoPlayer.currentPlaylist = videoPlayer.newPlaylist("Playlist", "");

            foreach (string videos in filteredFiles)
            {
                videoPlayer.currentPlaylist.appendItem(videoPlayer.newMedia(videos));
                listPlay.Items.Add(videos);  
            }

            if (filteredFiles.Count > 0)
            {
                lblFileName.Text = "Files Found " + filteredFiles.Count;
                listPlay.SelectedIndex = currentFile;
                PlayFile(listPlay.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("No Video Files Found in this folder");
            }
        }

        private void PlayFile(string url)
        {
            videoPlayer.URL = url;
        }

        private void ShowFileName(Label name)
        {
            string file = Path.GetFileName(listPlay.SelectedItem.ToString());
            name.Text = "Currently Playing: " + file;
        }
    }
}
