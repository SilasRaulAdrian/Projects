using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpawnAndClickPictureBox
{
    public partial class MainForm : Form
    {
        Random rand = new Random();
        List<PictureBox> items = new List<PictureBox>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MakePictureBox();

            lblItems.Text = "Items: " + items.Count();
        }

        private void MakePictureBox()
        {
            PictureBox newPic = new PictureBox();
            newPic.Height = 50;
            newPic.Width = 50;
            newPic.BackColor = Color.Maroon;

            int x = rand.Next(10, this.ClientSize.Width - newPic.Width);
            int y = rand.Next(10, this.ClientSize.Height - newPic.Height);
            newPic.Location = new Point(x, y);

            newPic.Click += NewPic_Click;

            items.Add(newPic);
            this.Controls.Add(newPic);
        }

        private void NewPic_Click(object sender, EventArgs e)
        {
            PictureBox tempPic = sender as PictureBox;
            items.Remove(tempPic);
            this.Controls.Remove(tempPic);

            lblItems.Text = "Items: " + items.Count();
        }
    }
}
