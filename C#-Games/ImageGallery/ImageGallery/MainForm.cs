using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGallery
{
    public partial class MainForm : Form
    {
        int pictureNumber = 1;

        public MainForm()
        {
            InitializeComponent();
            ChangePictures(pictureNumber);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pictureNumber--;

            if(pictureNumber < 1)
            {
                pictureNumber = 8;
            }

            ChangePictures(pictureNumber);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pictureNumber++;

            if(pictureNumber > 8)
            {
                pictureNumber = 1;
            }

            ChangePictures(pictureNumber);
        }

        private void ChangePictures(int picNum)
        {
            switch(picNum)
            {
                case 1:
                    pbViewer.Image = Properties.Resources.carl;
                    lblInfo.Text = "He is Carl";
                    break;
                case 2:
                    pbViewer.Image = Properties.Resources.lewandowski;
                    lblInfo.Text = "He is Lewandowski";
                    break;
                case 3:
                    pbViewer.Image = Properties.Resources.messi;
                    lblInfo.Text = "He is Messi";
                    break;
                case 4:
                    pbViewer.Image = Properties.Resources.neymar;
                    lblInfo.Text = "He is Neymar";
                    break;
                case 5:
                    pbViewer.Image = Properties.Resources.ramos;
                    lblInfo.Text = "He is Ramos";
                    break;
                case 6:
                    pbViewer.Image = Properties.Resources.ronaldinho;
                    lblInfo.Text = "He is Ronaldinho";
                    break;
                case 7:
                    pbViewer.Image = Properties.Resources.ronaldo;
                    lblInfo.Text = "He is Ronaldo Siuuu";
                    break;
                case 8:
                    pbViewer.Image = Properties.Resources.salah;
                    lblInfo.Text = "He is Salah";
                    break;
            }
        }
    }
}
