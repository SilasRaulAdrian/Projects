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

namespace Guess_The_Word
{
    public partial class MainForm : Form
    {
        List<string> words = new List<string>();
        string newText;
        int i = 0;
        int guessed = 0;

        public MainForm()
        {
            InitializeComponent();
            Setup();
        }

        private void txtWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (words[i].ToLower() == txtWord.Text.ToLower())
                {
                    if (i < words.Count - 1)
                    {
                        MessageBox.Show("Correct!", "Raul Says: ");
                        txtWord.Text = "";
                        i++;
                        newText = Scramble(words[i]);
                        lblWord.Text = newText;
                        lblInfo.Text = $"Words: {i + 1} of {words.Count}";
                        guessed = 0;
                        lblGuessed.Text = $"Guessed: {guessed} times.";
                    }
                    else
                    {
                        lblWord.Text = "You Win, Well done";
                        return;
                    }
                }
                else
                {
                    guessed++;
                    lblGuessed.Text = $"Guessed: {guessed} times.";
                }
                e.Handled = true;
            }
        }

        private void Setup()
        {
            words = File.ReadLines("words.txt").ToList();
            newText = Scramble(words[i]);
            lblWord.Text = newText;
            lblInfo.Text = $"Words: {i + 1} of {words.Count}";
        }

        private string Scramble(string text)
        {
            return new string(text.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }
    }
}
