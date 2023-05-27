using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OAIP2
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public abstract class Figure
        {
            protected int x, y;

            public Figure(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X
            {
                get { return x; }
                set { x = value; }
            }

            public int Y
            {
                get { return y; }
                set { y = value; }
            }

            public abstract void Draw(Graphics g);
            public abstract void MoveTo(int x, int y, int newX, int newY, Graphics g);
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Black);

            Point[] points =
            {
                new Point(10, 10),
                new Point(10, 580),
                new Point(650, 580),
                new Point(650, 10),
                new Point(10, 10)
            };

            Graphics g = this.CreateGraphics();

            g.DrawLines(myPen, points);
        }
    

        public class Own_figure : Figure
        {
            private int height, width;

            public Own_figure(int x, int y, int width, int height) : base(x, y)
            {
                this.width = width;
                this.height = height;
            }


            public override void Draw(Graphics g)
            {
                SolidBrush PinkBrush = new SolidBrush(Color.LightPink);
                SolidBrush GreenBrush = new SolidBrush(Color.LimeGreen);


                int palkax1 = x + width * 9 / 20;
                int palkax2 = x + width * 11 / 20;
                int palkay1 = y + height * 4 / 10;
                int palkay2 = y + height * 9 / 10;
                Point[] points =
               {
                    new Point(palkax1, palkay1),
                    new Point(palkax1, palkay2),
                    new Point(palkax2, palkay2),
                    new Point(palkax2, palkay1),
                    new Point(palkax1, palkay1),
                };
                g.DrawLines(Pens.Black, points);


                int circleX1 = x + width / 5;
                int circleY1 = y + height / 10;
                int circleSizeX = width * 3 / 5;
                int circleSizeY = height * 3 / 10;
                g.DrawEllipse(Pens.Black, circleX1, circleY1, circleSizeX, circleSizeY);
                g.FillEllipse(GreenBrush, circleX1, circleY1, circleSizeX, circleSizeY);


                int circleX3 = x + width * 4 / 10;
                int circleY3 = y + height * 4 / 20;
                int circleSizeX3 = width * 2 / 10;
                int circleSizeY3 = height * 2 / 20;
                g.DrawEllipse(Pens.Black, circleX3, circleY3, circleSizeX3, circleSizeY3);
                g.DrawRectangle(Pens.Black, x, y, width, height);
                g.FillEllipse(PinkBrush, circleX3, circleY3, circleSizeX3, circleSizeY3);
            }

            public override void MoveTo(int x, int y, int newX, int newY, Graphics g)
            {
                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);
                SolidBrush WhiteBrush = new SolidBrush(Color.FromArgb(240, 240, 240));

                int palkax1 = x + width * 9 / 20;
                int palkax2 = x + width * 11 / 20;
                int palkay1 = y + height * 4 / 10;
                int palkay2 = y + height * 9 / 10;
                Point[] points =
               {
                    new Point(palkax1, palkay1),
                    new Point(palkax1, palkay2),
                    new Point(palkax2, palkay2),
                    new Point(palkax2, palkay1),
                    new Point(palkax1, palkay1),
                };
                g.DrawLines(myColor, points);


                int circleX1 = x + width / 5;
                int circleY1 = y + height / 10;
                int circleSizeX = width * 3 / 5;
                int circleSizeY = height * 3 / 10;
                g.DrawEllipse(myColor, circleX1, circleY1, circleSizeX, circleSizeY);
                g.FillEllipse(WhiteBrush, circleX1, circleY1, circleSizeX, circleSizeY);


                int circleX3 = x + width * 4 / 10;
                int circleY3 = y + height * 4 / 20;
                int circleSizeX3 = width * 2 / 10;
                int circleSizeY3 = height * 2 / 20;
                g.DrawEllipse(myColor, circleX3, circleY3, circleSizeX3, circleSizeY3);
                g.DrawRectangle(myColor, x, y, width, height);
                g.FillEllipse(WhiteBrush, circleX3, circleY3, circleSizeX3, circleSizeY3);


                SolidBrush PinkBrush = new SolidBrush(Color.LightPink);
                SolidBrush GreenBrush = new SolidBrush(Color.LimeGreen);

                ////

                int palkaxN1 = newX + width * 9 / 20;
                int palkaxN2 = newX + width * 11 / 20;
                int palkayN1 = newY + height * 4 / 10;
                int palkayN2 = newY + height * 9 / 10;
                Point[] pointsN =
               {
                    new Point(palkaxN1, palkayN1),
                    new Point(palkaxN1, palkayN2),
                    new Point(palkaxN2, palkayN2),
                    new Point(palkaxN2, palkayN1),
                    new Point(palkaxN1, palkayN1),
                };
                g.DrawLines(Pens.Black, pointsN);


                int circleXN1 = newX + width / 5;
                int circleYN1 = newY + height / 10;
                int circleSizeNX = width * 3 / 5;
                int circleSizeNY = height * 3 / 10;
                g.DrawEllipse(Pens.Black, circleXN1, circleYN1, circleSizeNX, circleSizeNY);
                g.FillEllipse(GreenBrush, circleXN1, circleYN1, circleSizeNX, circleSizeNY);


                int circleXN3 = newX + width * 4 / 10;
                int circleYN3 = newY + height * 4 / 20;
                int circleSizeXN3 = width * 2 / 10;
                int circleSizeYN3 = height * 2 / 20;
                g.DrawEllipse(Pens.Black, circleXN3, circleYN3, circleSizeXN3, circleSizeYN3);
                g.DrawRectangle(Pens.Black, newX, newY, width, height);
                g.FillEllipse(PinkBrush, circleXN3, circleYN3, circleSizeXN3, circleSizeYN3);
               
            }
            public void Delete(int x, int y, int newX, int newY, Graphics g)
            {
                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);
                SolidBrush WhiteBrush = new SolidBrush(Color.FromArgb(240, 240, 240));

                int palkax1 = x + width * 9 / 20;
                int palkax2 = x + width * 11 / 20;
                int palkay1 = y + height * 4 / 10;
                int palkay2 = y + height * 9 / 10;
                Point[] points =
               {
                    new Point(palkax1, palkay1),
                    new Point(palkax1, palkay2),
                    new Point(palkax2, palkay2),
                    new Point(palkax2, palkay1),
                    new Point(palkax1, palkay1),
                };
                g.DrawLines(myColor, points);


                int circleX1 = x + width / 5;
                int circleY1 = y + height / 10;
                int circleSizeX = width * 3 / 5;
                int circleSizeY = height * 3 / 10;
                g.DrawEllipse(myColor, circleX1, circleY1, circleSizeX, circleSizeY);
                g.FillEllipse(WhiteBrush, circleX1, circleY1, circleSizeX, circleSizeY);


                int circleX3 = x + width * 4 / 10;
                int circleY3 = y + height * 4 / 20;
                int circleSizeX3 = width * 2 / 10;
                int circleSizeY3 = height * 2 / 20;
                g.DrawEllipse(myColor, circleX3, circleY3, circleSizeX3, circleSizeY3);
                g.DrawRectangle(myColor, x, y, width, height);
                g.FillEllipse(WhiteBrush, circleX3, circleY3, circleSizeX3, circleSizeY3);


                SolidBrush PinkBrush = new SolidBrush(Color.LightPink);
                SolidBrush GreenBrush = new SolidBrush(Color.LimeGreen);

                ////

                int palkaxN1 = newX + width * 9 / 20;
                int palkaxN2 = newX + width * 11 / 20;
                int palkayN1 = newY + height * 4 / 10;
                int palkayN2 = newY + height * 9 / 10;
                Point[] pointsN =
               {
                    new Point(palkaxN1, palkayN1),
                    new Point(palkaxN1, palkayN2),
                    new Point(palkaxN2, palkayN2),
                    new Point(palkaxN2, palkayN1),
                    new Point(palkaxN1, palkayN1),
                };
                g.DrawLines(myColor, pointsN);


                int circleXN1 = newX + width / 5;
                int circleYN1 = newY + height / 10;
                int circleSizeNX = width * 3 / 5;
                int circleSizeNY = height * 3 / 10;
                g.DrawEllipse(myColor, circleXN1, circleYN1, circleSizeNX, circleSizeNY);
                g.FillEllipse(WhiteBrush, circleXN1, circleYN1, circleSizeNX, circleSizeNY);


                int circleXN3 = newX + width * 4 / 10;
                int circleYN3 = newY + height * 4 / 20;
                int circleSizeXN3 = width * 2 / 10;
                int circleSizeYN3 = height * 2 / 20;
                g.DrawEllipse(myColor, circleXN3, circleYN3, circleSizeXN3, circleSizeYN3);
                g.DrawRectangle(myColor, newX, newY, width, height);
                g.FillEllipse(WhiteBrush, circleXN3, circleYN3, circleSizeXN3, circleSizeYN3);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x, y, width, height;
            int.TryParse(textBox25.Text, out int result1);
            int.TryParse(textBox23.Text, out int result2);
            int.TryParse(textBox24.Text, out int result3);
            int.TryParse(textBox22.Text, out int result4);

            x = result1;
            y = result2;
            width = result4;
            height = result3;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - width);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - height);

            Graphics g = this.CreateGraphics();
            Own_figure own_Figure = new Own_figure(x, y, width, height);
            own_Figure.Draw(g);
            g.Save();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            int x, y, width, height, newX, newY;
            int.TryParse(textBox25.Text, out int result1);
            int.TryParse(textBox23.Text, out int result2);
            int.TryParse(textBox24.Text, out int result3);
            int.TryParse(textBox22.Text, out int result4);
            int.TryParse(textBox27.Text, out int result5);
            int.TryParse(textBox26.Text, out int result6);

            x = result1;
            y = result2;
            width = result4;
            height = result3;
            newX = result5;
            newY = result6;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - width - x);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - height - y);

            Graphics g = this.CreateGraphics();

            Own_figure own_Figure1 = new Own_figure(x, y, width, height);

            own_Figure1.MoveTo(x, y, newX, newY, g);
            g.Save();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x, y, width, height, newX, newY;
            int.TryParse(textBox25.Text, out int result1);
            int.TryParse(textBox23.Text, out int result2);
            int.TryParse(textBox24.Text, out int result3);
            int.TryParse(textBox22.Text, out int result4);
            int.TryParse(textBox27.Text, out int result5);
            int.TryParse(textBox26.Text, out int result6);

            x = result1;
            y = result2;
            width = result4;
            height = result3;
            newX = result5;
            newY = result6;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - width);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - height);

            Graphics g = this.CreateGraphics();

            Own_figure own_Figure2 = new Own_figure(x, y, width, height);

            own_Figure2.Delete(x, y, newX, newY, g);
            g.Save();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }
    }

