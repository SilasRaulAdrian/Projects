using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class XOForm : Form
    {
        public XOForm()
        {
            InitializeComponent();
        }

        Button[,] b = new Button[4, 4];
        int pas = 0;

        private bool Verif()
        {
            bool ok = false;
            for (int i = 1; i <= 3; ++i) 
            {
                bool okk = true;
                for (int j = 2; j <= 3; ++j)
                    if (b[i, j].Text != b[i, j - 1].Text || b[i, j].Text == "")
                        okk = false;
                if (okk)
                    ok = true;
            }

            for (int j = 1; j <= 3; ++j)
            {
                bool okk = true;
                for (int i = 2; i <= 3; ++i)
                    if (b[i, j].Text != b[i - 1, j].Text || b[i, j].Text == "")
                        okk = false;
                if (okk)
                    ok = true;
            }

            if (b[1, 1].Text == b[2, 2].Text && b[2, 2].Text == b[3, 3].Text && b[1, 1].Text != "")
                ok = true;

            if (b[1, 3].Text == b[2, 2].Text && b[2, 2].Text == b[3, 1].Text && b[2, 2].Text != "")
                ok = true;

            return ok;
        }
        private void Click_Btn(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Text == "")
            {
                if (pas % 2 == 0)
                    btn.Text = "X";
                else
                    btn.Text = "O";
                if (Verif())
                {
                    if (pas % 2 == 0)
                        MessageBox.Show("X Castiga!");
                    else
                        MessageBox.Show("O Castiga!");
                    for (int i = 1; i <= 3; ++i)
                        for (int j = 1; j <= 3; ++j)
                            b[i, j].Text = "";
                    pas = -1;
                }

                pas++;
                if (pas == 9)
                {
                    MessageBox.Show("Remiza");
                    for (int i = 1; i <= 3; ++i)
                        for (int j = 1; j <= 3; ++j)
                            b[i, j].Text = "";
                    pas = 0;
                }
            }
            
        }
        private void XOForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 3; ++i) 
                for(int j = 1; j <= 3; ++j)
                {
                    b[i, j] = new Button();
                    b[i, j].Text = "";
                    b[i, j].Width = b[i, j].Height = 40;
                    b[i, j].Location = new Point(i * 50, j * 50);
                    b[i, j].Click += new EventHandler(Click_Btn);
                    this.Controls.Add(b[i, j]);
                }
        }
    }
}
