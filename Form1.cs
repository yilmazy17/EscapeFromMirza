using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labyrinth
{
    
   
    public partial class Labyrinth : Form
    {
        
        public class loc
        {
            public int x;
            public int y;
            public int sizes;
        }
        public List<loc> locs = new List<loc>();
        public double time = 0;
        public int counter = 0;
        private Random rand = new Random();
        public Image images;
        public Labyrinth()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            counter++;
            time = time + 0.05;
            label2.Text = time.ToString("0.00");
            if (counter % 10 == 0)
            {

                Graphics g = this.CreateGraphics();
                Image x = new Bitmap("1.jpg");
                int a = rand.Next(50, 200);
                x = resizeImage(x, new Size(a, a));
                int xLoc = rand.Next(0, Width - a);
                int yLoc = rand.Next(80, Height-a);
                g.DrawImage(x, xLoc , yLoc);
                
                loc locat = new loc{x = xLoc, y = yLoc , sizes = a};
                locs.Add(locat);
            }
            foreach (loc pos in locs)
            {
                if (label3.Location.X > pos.x &&  (pos.x + pos.sizes) > label3.Location.X && label3.Location.Y > pos.y && (pos.y + pos.sizes) > label3.Location.Y)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Your point is : " + label2.Text + "s.");
                    time = 0;
                    Refresh();
                    button1.Show();
                    locs.Clear();
                    label3.Hide();
                    break;
                }
                else if (label3.Location.X+15 > pos.x && (pos.x + pos.sizes) > label3.Location.X+15 && label3.Location.Y > pos.y && (pos.y + pos.sizes) > label3.Location.Y)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Your point is : " + label2.Text + "s.");
                    time = 0;
                    Refresh();
                    button1.Show();
                    locs.Clear();
                    label3.Hide();
                    break;
                }
                else if (label3.Location.X + 15 > pos.x && (pos.x + pos.sizes) > label3.Location.X + 15 && label3.Location.Y + 15> pos.y && (pos.y + pos.sizes) > label3.Location.Y + 15)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Your point is : " + label2.Text + "s.");
                    time = 0;
                    Refresh();
                    button1.Show();
                    locs.Clear();
                    label3.Hide();
                    break;
                }
                else if (label3.Location.X  > pos.x && (pos.x + pos.sizes) > label3.Location.X  && label3.Location.Y + 15 > pos.y && (pos.y + pos.sizes) > label3.Location.Y + 15)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Your point is : " + label2.Text + "s.");
                    time = 0;
                    Refresh();
                    button1.Show();
                    locs.Clear();
                    label3.Hide();
                    break;
                }

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button1.Hide();
            label3.Show();
        }


        private void Labyrinth_Load(object sender, EventArgs e)
        {
            label3.Hide();
        }

        private void Labyrinth_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    label3.Location = new Point(label3.Location.X, label3.Location.Y - 10);
                    break;
                case Keys.Down:
                    label3.Location = new Point(label3.Location.X, label3.Location.Y + 10);
                    break;
                case Keys.Right:
                    label3.Location = new Point(label3.Location.X+10, label3.Location.Y);
                    break;
                case Keys.Left:
                    label3.Location = new Point(label3.Location.X - 10, label3.Location.Y);
                    break;
            }

            if (label3.Location.X < 3)
            {
                label3.Location = new Point(Width + label3.Location.X, label3.Location.Y);
            }
            else if (label3.Location.X > Width)
            {
                label3.Location = new Point(0 + (-1 * (Width - label3.Location.X)), label3.Location.Y);
            }

            if (label3.Location.Y < 80)
            {
                label3.Location = new Point(label3.Location.X, Height + ((80-label3.Location.Y)));
            } 
            else if (label3.Location.Y > Height)
            {
                label3.Location = new Point(label3.Location.X, 80 + (( label3.Location.Y - Height)));
            }
            
        }

    }
}
