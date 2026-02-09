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

namespace Play_Multiple_Sound_File
{
    public partial class MainForm : Form
    {
        SoundPlayer backgroundMusic;
        SoundPlayer laserSound;
        bool bgPlaying = false;
        public MainForm()
        {
            InitializeComponent();

            MXP.URL = @"bg_music_mediaplayer.mp3";
            MXP.settings.playCount = 9999;
            MXP.Ctlcontrols.stop();
            MXP.Visible = false;

        }

        private void btnLaserSound_Click(object sender, EventArgs e)
        {
            laserSound = new SoundPlayer(@"laserSound.wav");
            laserSound.Play();
        }

        private void btnBackgroundSound_Click(object sender, EventArgs e)
        {
            backgroundMusic = new SoundPlayer(@"bg_music.wav");
            backgroundMusic.PlayLooping();
            MXP.Ctlcontrols.stop();
            bgPlaying = true;
        }

        private void btnMediaPlayer_Click(object sender, EventArgs e)
        {
            if (bgPlaying == true)
            {
                backgroundMusic.Stop();
                bgPlaying = false;
            }
            MXP.Ctlcontrols.play();
        }
    }
}
