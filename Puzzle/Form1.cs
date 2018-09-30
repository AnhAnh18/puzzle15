using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        Point EmptyPoint;
        int n;
        int totalSize = 600;
        int itemSize;
        ArrayList images = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MoveButton((Button)sender);
        }
        private void MoveButton(Button btn)
        {
            if (((btn.Location.X == EmptyPoint.X - itemSize || btn.Location.X == EmptyPoint.X + itemSize)
                && btn.Location.Y == EmptyPoint.Y)
                || (btn.Location.Y == EmptyPoint.Y - itemSize || btn.Location.Y == EmptyPoint.Y + itemSize)
                && btn.Location.X == EmptyPoint.X)
            {
                Point swap = btn.Location;
                btn.Location = EmptyPoint;
                EmptyPoint = swap;
                Console.WriteLine("X:" + EmptyPoint.X + "Y:" + EmptyPoint.Y);
            }

            //if (EmptyPoint.X == totalSize - itemSize && EmptyPoint.Y == totalSize - itemSize)
                //CheckValid();
        }

        private void CheckValid()
        {
            throw new NotImplementedException();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Button b in panel1.Controls)
            {
                b.Visible = true;
                b.Enabled = true;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            foreach (Button b in panel1.Controls)
                b.Enabled = true;
            Image orginal = Image.FromFile(@"E:/a.jpg");
            cropImageTomages(orginal, totalSize, totalSize);
            AddImagesToButtons(images);
        }
        private int[] Suffle(int[] arr)
        {
            Random rand = new Random();
            arr = arr.OrderBy(x => rand.Next()).ToArray();
            return arr;
        }
        private void AddImagesToButtons(ArrayList images)
        {
            int i = 0;
            int[] arr = new int[(n*n)-1];
            if (n == 3 )
            {
                for (int runs = 0; runs < (n*n) -1; runs++)
                {
                    arr[runs] = runs;
                    
                }
            }
            else if (n == 4)
            {
                for (int runs = 0; runs < (n * n) -1; runs++)
                {
                    arr[runs] = runs;
                    Console.WriteLine(runs);
                }
            }
            //arr = Suffle(arr);
            foreach (Button b in panel1.Controls)
            {
                if (i < arr.Length)
                {
                    b.Image = (Image)images[arr[i]];
                    i++;
                }
            }
        }
        private void cropImageTomages(Image orginal, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);

            Graphics graphic = Graphics.FromImage(bmp);

            graphic.DrawImage(orginal, 0, 0, w, h);

            graphic.Dispose();

            int movr = 0, movd = 0;

            for (int x = 0; x < n*n; x++)
            {
                Bitmap piece = new Bitmap(itemSize, itemSize);
                for (int i = 0; i < itemSize; i++)
                    for (int j = 0; j < itemSize; j++)
                        piece.SetPixel(i, j,
                            bmp.GetPixel(i + movr, j + movd));

                images.Add(piece);

                movr += itemSize;

                if (movr == totalSize)
                {
                    movr = 0;
                    movd += itemSize;
                }
            }

        }
        public void set3(int n)
        {
            n = 3;
            itemSize = totalSize / n;
            foreach (Button b in panel1.Controls)
            {
                b.Height = totalSize/n;
                b.Width = totalSize/n;
            }
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;

            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button1.Location = new Point(0, 0);
            button2.Location = new Point(200, 0);
            button3.Location = new Point(400, 0);

            button4.Location = new Point(0, 200);
            button5.Location = new Point(200, 200);
            button6.Location = new Point(400, 200);

            button7.Location = new Point(0, 400);
            button8.Location = new Point(200, 400);

            panel1.Controls.Remove(button9);
            panel1.Controls.Remove(button10);
            panel1.Controls.Remove(button11);
            panel1.Controls.Remove(button12);
            panel1.Controls.Remove(button13);
            panel1.Controls.Remove(button14);
            panel1.Controls.Remove(button15);

        }
        private void button16_Click(object sender, EventArgs e)
        {
            n = 3;
            set3(n);
            EmptyPoint.X = totalSize - itemSize;
            EmptyPoint.Y = totalSize - itemSize;
        }
        public void set4(int n)
        {
            n = 4;
            itemSize = totalSize / n;
            foreach (Button b in panel1.Controls)
            {
                b.Height = totalSize/n;
                b.Width = totalSize/n;
            }
            foreach (Button b in panel1.Controls)
            {
                b.Visible = true;
            }
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button13);
            panel1.Controls.Add(button14);
            panel1.Controls.Add(button15);


            button1.Location = new Point(0, 0);
            button2.Location = new Point(150, 0);
            button3.Location = new Point(300, 0);
            button4.Location = new Point(450, 0);

            button5.Location = new Point(0, 150);
            button6.Location = new Point(150, 150);
            button7.Location = new Point(300, 150);
            button8.Location = new Point(450, 150);

            button9.Location = new Point(0, 300);
            button10.Location = new Point(150, 300);
            button11.Location = new Point(300, 300);
            button12.Location = new Point(450, 300);

            button13.Location = new Point(0, 450);
            button14.Location = new Point(150, 450);
            button15.Location = new Point(300, 450);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            n = 4;
            set4(n);
            EmptyPoint.X = totalSize - itemSize;
            EmptyPoint.Y = totalSize - itemSize;
        }
    }
}
