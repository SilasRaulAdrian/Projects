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
    public partial class MainForm : Form
    {
        string words;
        string[] splitUp;
        int totalWords;
        int counting = -1;
        ReadingWindow reader;
        int localCounter;
        char[] charsToTrim = { '*', '.', ',', '-', '+', '!' };
        string cleanText;

        public MainForm()
        {
            InitializeComponent();
            cbSpeed.Text = "1"; 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            reader = new ReadingWindow();

            words = txtText.Text;
            splitUp = words.Split();
            totalWords = splitUp.Length;
            int value = Convert.ToInt32(cbSpeed.Text);
            readingTimer.Interval = 100 * value;
            counting = -1;
            localCounter = 0;
            reader.Show();
            readingTimer.Start();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpWindow showHelp = new HelpWindow();
            showHelp.Show();
        }

        private void readingTimer_Tick(object sender, EventArgs e)
        {
            localCounter = counting;

            if(counting >= totalWords - 1)
            {
                readingTimer.Stop();
                MessageBox.Show("End of Article", "Raul Says: ");
                counting = -1;
            }
            else if(reader.isClosed)
            {
                readingTimer.Stop();
            }
            else
            {
                if(reader.isPaused)
                {
                    counting = localCounter;
                }
                else
                {
                    counting++;
                }

                cleanText = splitUp[counting].Trim(charsToTrim);
                reader.lblWords.Text = cleanText;
            }
        }
    }
}
