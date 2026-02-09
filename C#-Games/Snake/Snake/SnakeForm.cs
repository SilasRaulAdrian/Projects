using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class SnakeForm : Form
    {
        public SnakeForm()
        {
            InitializeComponent();
        }

        PictureBox tabla = new PictureBox();
        PictureBox Snake = new PictureBox();
        PictureBox Mar = new PictureBox();
        PictureBox[] Coada = new PictureBox[1001];
        int dx = 1, dy = 0, cl = 0, score = 0;
        Label Score = new Label();
        Font font = new Font("Arial", 12, FontStyle.Regular);
        private void SnakeForm_Load(object sender, EventArgs e)
        {
            tabla.Width = tabla.Height = 500;
            tabla.BackColor = Color.Black;
            tabla.Location = new Point(30, 30);
            Score.Location = new Point(3, 3);
            Score.Text = "Score:" + score;
            Score.Font = font;
            this.Controls.Add(Score);
            this.Location = new Point(50, 50);
            this.Width = this.Height = 600;
            this.Controls.Add(tabla);
            Snake.Width = Snake.Height = 18;
            Snake.Location = new Point(100, 100);
            Snake.BackColor = Color.White;
            tabla.Controls.Add(Snake);
            Mar.Width = Mar.Height = 18;
            Mar.Location = new Point(300, 400);
            Mar.BackColor = Color.Red;
            tabla.Controls.Add(Mar);
            timer1.Start();
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                dx = -1;
                dy = 0;
            }

            if(e.KeyCode == Keys.Right)
            {
                dx = 1;
                dy = 0;
            }

            if(e.KeyCode == Keys.Up)
            {
                dx = 0;
                dy = -1;
            }

            if(e.KeyCode == Keys.Down)
            {
                dx = 0;
                dy = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = cl; i >= 2; --i)
                Coada[i].Location = Coada[i - 1].Location;
            if(cl > 0)
                Coada[1].Location = Snake.Location;
            Snake.Location = new Point(Snake.Location.X + dx * 20, Snake.Location.Y + dy * 20);
            for (int i = 1; i <= cl; ++i)
                if (Snake.Location == Coada[i].Location)
                {
                    timer1.Stop();
                    MessageBox.Show("Score: " + score);
                }
            if (Snake.Location == Mar.Location)
            {
                Random r = new Random();
                int x1 = r.Next(24) * 20;
                int y1 = r.Next(24) * 20;
                Mar.Location = new Point(x1, y1);
                Coada[++cl] = new PictureBox();
                Coada[cl].BackColor = Color.White;
                Coada[cl].Location = Snake.Location;
                Coada[cl].Width = Coada[cl].Height = 18;
                tabla.Controls.Add(Coada[cl]);
                score++;
                Score.Text = "Score: " + score;
            }
            
            int x = Snake.Location.X;
            int y = Snake.Location.Y;
            if (x >= 500)
                x = 0;
            if (x < 0)
                x = 480;
            if (y >= 500)
                y = 0;
            if (y < 0)
                y = 480;
            Snake.Location = new Point(x, y);
        }
    }
}
