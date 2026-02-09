using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sliding_Image_Puzzle
{
    public partial class MainForm : Form
    {
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        List<Bitmap> images = new List<Bitmap>();
        List<string> locations = new List<string>();
        List<string> current_locations = new List<string>();
        string win_position;
        string current_position;
        Bitmap mainBitmap;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList != null)
            {
                foreach (PictureBox pics in pictureBoxList.ToList())
                {
                    this.Controls.Remove(pics);
                }

                pictureBoxList.Clear();
                images.Clear();
                locations.Clear();
                current_locations.Clear();
                win_position = string.Empty;
                current_position = string.Empty;
                lblStatus.Text = string.Empty;
            }

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files Only | *.jpg; *.jpeg; *.gif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                mainBitmap = new Bitmap(open.FileName);
                CreatePictureBoxes();
                AddImages();
            }
        }

        private void CreatePictureBoxes()
        {
            for (int i = 0; i < 9; ++i)
            {
                PictureBox tempPic = new PictureBox();
                tempPic.Size = new Size(130, 130);
                tempPic.Tag = i.ToString();
                tempPic.Click += OnPicClick;
                pictureBoxList.Add(tempPic);
                locations.Add(tempPic.Tag.ToString());
            }
        }

        private void OnPicClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            PictureBox emptyBox = pictureBoxList.Find(x => (string)x.Tag == "0");
            Point pic1 = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            Point pic2 = new Point(emptyBox.Location.X, emptyBox.Location.Y);
            var index1 = this.Controls.IndexOf(pictureBox);
            var index2 = this.Controls.IndexOf(emptyBox);

            if (pictureBox.Right == emptyBox.Left && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Left == emptyBox.Right && pictureBox.Location.Y == emptyBox.Location.Y
                || pictureBox.Top == emptyBox.Bottom && pictureBox.Location.X == emptyBox.Location.X
                || pictureBox.Bottom == emptyBox.Top && pictureBox.Location.X == emptyBox.Location.X)
            {
                pictureBox.Location = pic2;
                emptyBox.Location = pic1;

                this.Controls.SetChildIndex(pictureBox, index2);
                this.Controls.SetChildIndex(emptyBox, index1);
            }

            lblStatus.Text = "";
            current_locations.Clear();
            CheckGame();
        }

        private void CropImage(Bitmap main_bitmap, int height, int width)
        {
            int x, y;
            x = 0;
            y = 0;

            for (int blocks = 0; blocks < 9; ++blocks)
            {
                Bitmap croppedImage = new Bitmap(height, width);

                for (int i = 0; i < height; ++i) 
                {
                    for (int j = 0; j < width; ++j)
                    {
                        croppedImage.SetPixel(i, j, main_bitmap.GetPixel((i + x), (j + y)));
                    }
                }
                images.Add(croppedImage);
                x += 130;
                if (x == 390)
                {
                    x = 0;
                    y += 130;
                }
            }
        }

        private void AddImages()
        {
            Bitmap tempBitmap = new Bitmap(mainBitmap, new Size(390, 390));
            CropImage(tempBitmap, 130, 130);

            for (int i = 1; i < pictureBoxList.Count; ++i)
            {
                pictureBoxList[i].BackgroundImage = (Image)images[i];
            }

            PlacePictureBoxesToForm();
        }

        private void PlacePictureBoxesToForm()
        {
            var shuffleImages = pictureBoxList.OrderBy(a => Guid.NewGuid()).ToList();
            pictureBoxList = shuffleImages;

            int x = 200;
            int y = 25;

            for (int i = 0; i < pictureBoxList.Count; ++i)
            {
                pictureBoxList[i].BackColor = Color.Gold;

                if (i == 3 || i == 6)
                {
                    y += 130;
                    x = 200;
                }

                pictureBoxList[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxList[i].Location = new Point(x, y);

                this.Controls.Add(pictureBoxList[i]);
                x += 130;

                win_position += locations[i];
            }
        }

        private void CheckGame()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    current_locations.Add(x.Tag.ToString());
                }
            }

            current_position = string.Join("", current_locations);
            lblListOne.Text = win_position;
            lblStatus.Text = current_position;

            if (win_position == current_position)
            {
                lblStatus.Text = "Matched !!!";
            }
        }
    }
}
