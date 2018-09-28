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
        ArrayList images = new ArrayList();
        public Form1()
        {
            EmptyPoint.X = 384;
            EmptyPoint.Y = 384;
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            MoveButton((Button)sender);
        }
        private void MoveButton(Button btn)
        {
            if (((btn.Location.X == EmptyPoint.X - 128 || btn.Location.X == EmptyPoint.X + 128)
                && btn.Location.Y == EmptyPoint.Y)
                || (btn.Location.Y == EmptyPoint.Y - 128 || btn.Location.Y == EmptyPoint.Y + 128)
                && btn.Location.X == EmptyPoint.X)
            {
                Point swap = btn.Location;
                btn.Location = EmptyPoint;
                EmptyPoint = swap;
                Console.WriteLine("X:" + EmptyPoint.X + "Y:" + EmptyPoint.Y);
            }

            if (EmptyPoint.X == 180 && EmptyPoint.Y == 180)
                CheckValid();
        }

        private void CheckValid()
        {
            throw new NotImplementedException();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            foreach (Button b in panel1.Controls)
                b.Enabled = true;
            Image orginal = Image.FromFile(@"E:/a.jpg");

            cropImageTomages(orginal, 512, 512);
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
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};

            arr = Suffle(arr);

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

            for (int x = 0; x < 16; x++)
            {
                Bitmap piece = new Bitmap(128, 128);

                for (int i = 0; i < 128; i++)
                    for (int j = 0; j < 128; j++)
                        piece.SetPixel(i, j,
                            bmp.GetPixel(i + movr, j + movd));

                images.Add(piece);

                movr += 128;

                if (movr == 512)
                {
                    movr = 0;
                    movd += 128;
                }
            }

        }
    }
}
