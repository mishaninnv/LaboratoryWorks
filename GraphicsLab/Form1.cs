using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsLab
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {           
            if (e.Button == MouseButtons.Left)
            {
                if(ModifierKeys == Keys.Shift) Draw(g, e.X, e.Y, 75, 150);
                else if(ModifierKeys == Keys.Alt) Draw(g, e.X, e.Y, 100, 200);
                else if(ModifierKeys == Keys.Control) Draw(g, e.X, e.Y, 125, 250);
                else Draw(g, e.X, e.Y, 150, 300);
            }
        }

        private void Draw(Graphics g, int x, int y, int w, int h)
        {
            g.FillEllipse(new SolidBrush(Color.Red), x - w/3, y - (int)(h * 0.6), (int)(h * 0.3), (int)(h * 0.3));
            g.FillEllipse(new SolidBrush(Color.Green), x - w/2, y - (int)(h * 0.3), w, (int)(h * 0.6));
            g.FillRectangle(new SolidBrush(Color.Black), x - w/2, y + (int)(h * 0.3), w, (int)(h * 0.1));
        }
    }
}
