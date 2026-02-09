using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedReading
{
    public partial class ReadingWindow : Form
    {
        public bool isPaused = false;
        public bool isClosed = false;

        public ReadingWindow()
        {
            InitializeComponent();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;

            if(isPaused)
            {
                btnPause.Text = "Resume";
            }

            if(!isPaused)
            {
                btnPause.Text = "Pause";
            }
        }

        private void ReadingWindow_Load(object sender, EventArgs e)
        {
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;

            lblWords.Height = height;
            lblWords.Width = width;

            isClosed = false;
            isPaused = false;
        }

        private void ReadingWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClosed = true;
        }
    }
}
