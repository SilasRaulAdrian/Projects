using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging; // this one is for saving JPG images

namespace MemeMaker
{
    public partial class MainForm : Form
    {
        OpenFileDialog openImageFile;

        public MainForm()
        {
            InitializeComponent();
            SetUpApp();
        }

        private void txtTopText_TextChanged(object sender, EventArgs e)
        {
            lblTopText.Text = txtTopText.Text;
        }

        private void txtBottomText_TextChanged(object sender, EventArgs e)
        {
            lblBottomText.Text = txtBottomText.Text;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openImageFile = new OpenFileDialog();
            openImageFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openImageFile.Filter = "Image Files Only (*.jpg, *.gif, *.png, *.bmp) | *.jpg; *.gif; *.png; *.bmp";

            if(openImageFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbImgPreview.Image = Image.FromFile(openImageFile.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! Couldn't load the file " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.FileName = "Meme with Raul";
            saveDialog.DefaultExt = "jpg";
            saveDialog.Filter = "JPG Image | *.jpg";
            saveDialog.ValidateNames = true;

            if(saveDialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pbImgPreview.Width);
                int height = Convert.ToInt32(pbImgPreview.Height);
                Bitmap bmp = new Bitmap(width, height);
                pbImgPreview.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(saveDialog.FileName, ImageFormat.Jpeg);
            }
        }

        private void ChangeTextColour(object sender, EventArgs e)
        {
            Button tempButton = (Button)sender;

            lblTopText.ForeColor = tempButton.BackColor;
            lblBottomText.ForeColor = tempButton.BackColor;
        }

        private void SetUpApp()
        {
            pbImgPreview.Controls.Add(lblTopText);
            pbImgPreview.Controls.Add(lblBottomText);

            lblTopText.Location = new Point(0, 0);
            lblBottomText.Location = new Point(0, 320);

            pbImgPreview.SendToBack();
        }
    }
}
