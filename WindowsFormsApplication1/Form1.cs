using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Spiral_of_Ulam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
  
        }

        private bool[] InitSpiral(long N)
        {
            bool[] B = new bool[N];
            for (int i = 0; i < N; i++)
            {
                B[i] = true;
            }

            B[0] = false;
            for (int i = 2; i*i < N; i++)
            {
                if (B[i])
                    for (int j = i*i; j < N; j += i)
                        B[j] = false;
            }
            return B;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Brush br = new SolidBrush(Color.Black);
            long N = pictureBox1.Width * pictureBox1.Height;
            bool[] prime = InitSpiral(N);
            int x, y;
            x = pictureBox1.Width / 2;
            y = pictureBox1.Height / 2;
            int mode = 0;
            long counter = 1;
            long next = 0;
            long position = 1;
            prime[1] = false;
            while (counter < N)
            {
                for (; position < counter; )
                {
                    if (prime[position])
                    {
                        g.FillRectangle(br, x - 1, y - 1, 2, 2);
                    }
                    switch (mode)
                    {
                        case 0: { x++; break; }
                        case 1: { y--; break; }
                        case 2: { x--; break; }
                        case 3: { y++; break; }
                    }
                    position++;
                }
                mode = (mode + 1) % 4;
                counter += next++;
            }
            pictureBox1.Refresh();
        }
    }
}
