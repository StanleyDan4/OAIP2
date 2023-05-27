using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAIP2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        { }
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

            public abstract void Draw(Graphics g); // метод прорисовки
            public abstract void MoveTo(int x, int y, int newX, int newY, Graphics g); // метод перемещения
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
        public class Ellipse : Figure
        {
            protected int width, height;

            public Ellipse(int x, int y, int width, int height) : base(x, y)
            {
                this.width = width;
                this.height = height;
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, x, y, width, height);
            }

            public override void MoveTo(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;
                x = newX + x;
                y = newY + y;

                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawEllipse(myColor, x1, y1, width, height);

                g.DrawEllipse(Pens.Black, x, y, width, height);
            }

            public void Delete(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;

                x = newX + x;
                y = newY + y;


                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawEllipse(myColor, x, y, width, height);
            }
        }

        public class Triangle : Figure
        {
            protected int x2, x3, y2, y3;

            public Triangle(int x, int y, int x2, int x3, int y2, int y3) : base(x, y)
            {
                this.x2 = x2;
                this.x3 = x3;
                this.y2 = y2;
                this.y3 = y3;
            }

            public override void Draw(Graphics g)
            {
                Pen myPen = new Pen(Color.Black);

                Point[] points =
                {
                    new Point(x, y),
                    new Point(x2, y2),
                    new Point(x3, y3),
                    new Point(x, y),
                };
                g.DrawLines(myPen, points);
            }
            public override void MoveTo(int x, int y, int newX, int newY, Graphics g)
            {
                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);


                Point[] points =
                {
                    new Point(x, y),
                    new Point(x2, y2),
                    new Point(x3, y3),
                    new Point(x, y),
                };
                g.DrawLines(myColor, points);

                Point[] points1 =
                {
                    new Point(x+newX, y+newY),
                    new Point(x2+newX, y2+newY),
                    new Point(x3+newX, y3+newY),
                    new Point(x+newX, y+newY),
                };
                g.DrawLines(Pens.Black, points1);
            }


            public void Delete(int x, int y, int newX, int newY, Graphics g)
            {
                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                Point[] points =
                {
                    new Point(x+newX, y+newY),
                    new Point(x2+newX, y2+newY),
                    new Point(x3+newX, y3+newY),
                    new Point(x+newX, y+newY),
                };
                g.DrawLines(myColor, points);
            }
        }
        public class Circle : Ellipse
        {
            protected int diameter;
            public Circle(int x, int y, int diameter) : base(x, y, diameter, diameter)
            {
                this.diameter = diameter;
            }
            public int Diameter
            {
                get { return diameter; }
                set { diameter = value; }
            }
            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Black, x, y, diameter, diameter);
            }

            public override void MoveTo(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;
                x = newX + x;
                y = newY + y;

                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawEllipse(myColor, x1, y1, diameter, diameter);

                g.DrawEllipse(Pens.Black, x, y, diameter, diameter);
            }
            public void Delete(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;

                x = newX + x;
                y = newY + y;


                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawEllipse(myColor, x, y, diameter, diameter);
            }

            public void Change(int x, int y, int diameter, int newD, Graphics g)
            {
                int diameter1 = diameter + newD;

                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawEllipse(myColor, x, y, diameter, diameter);
                g.DrawEllipse(Pens.Black, x, y, diameter1, diameter1);
            }
        }



        public class Rectangle : Figure
        {
            protected int width, height;

            public Rectangle(int x, int y, int width, int height) : base(x, y)
            {
                this.width = width;
                this.height = height;
            }
            public override void Draw(Graphics g)
            {
                g.DrawRectangle(Pens.Black, x, y, width, height);
            }

            public override void MoveTo(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;
                x = newX + x;
                y = newY + y;

                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawRectangle(myColor, x1, y1, width, height);

                g.DrawRectangle(Pens.Black, x, y, width, height);
            }
            public void Delete(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;

                x = newX + x;
                y = newY + y;


                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawRectangle(myColor, x, y, width, height);

            }

            public void Change(int x, int y, int newH, int newW, Graphics g)
            {
                int width1 = width + newH;
                int height1 = height + newW;

                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawRectangle(myColor, x, y, width, height);
                g.DrawRectangle(Pens.Black, x, y, width1, height1);
            }
        }
        public class Square : Rectangle
        {
            int width;

            public Square(int x, int y, int width) : base(x, y, width, width)
            {
                this.width = width;
            }


            public override void Draw(Graphics g)
            {
                g.DrawRectangle(Pens.Black, x, y, width, width);
            }

            public override void MoveTo(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;
                x = newX + x;
                y = newY + y;

                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawRectangle(myColor, x1, y1, width, width);

                g.DrawRectangle(Pens.Black, x, y, width, width);
            }
            public void Delete(int x, int y, int newX, int newY, Graphics g)
            {
                int x1 = x;
                int y1 = y;

                x = newX + x;
                y = newY + y;


                Color pen = Color.FromArgb(240, 240, 240);
                Pen myColor = new Pen(pen);

                g.DrawRectangle(myColor, x, y, width, width);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x, y, width, height;
            int.TryParse(textBox1.Text, out int result1);
            int.TryParse(textBox3.Text, out int result2);
            int.TryParse(textBox2.Text, out int result3);
            int.TryParse(textBox4.Text, out int result4);


            x = result1;
            y = result2;
            width = result3;
            height = result4;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - width);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - height);

            Rectangle rectangle = new Rectangle(x, y, height, width);

            Graphics g = this.CreateGraphics();

            rectangle.Draw(g);
            g.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x, y, width;
            int.TryParse(textBox8.Text, out int result1);
            int.TryParse(textBox6.Text, out int result2);
            int.TryParse(textBox7.Text, out int result3);

            x = result1;
            y = result2;
            width = result3;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - width);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - width);

            Square square = new Square(x, y, width);
            Graphics g = this.CreateGraphics();

            square.Draw(g);
            g.Save();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int x, y, width, height, newW, newH;
            int.TryParse(textBox1.Text, out int result1);
            int.TryParse(textBox3.Text, out int result2);
            int.TryParse(textBox2.Text, out int result3);
            int.TryParse(textBox4.Text, out int result4);
            int.TryParse(textBox21.Text, out int result5);
            int.TryParse(textBox30.Text, out int result6);

            x = result1;
            y = result2;
            width = result3;
            height = result4;
            newW = result5;
            newH = result6;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - width);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - height);

            Rectangle rectangle = new Rectangle(x, y, height, width);

            Graphics g = this.CreateGraphics();

            rectangle.Change(x, y, newW, newH, g);
            g.Save();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int x, y, diameter;
            int.TryParse(textBox12.Text, out int result1);
            int.TryParse(textBox10.Text, out int result2);
            int.TryParse(textBox11.Text, out int result3);

            x = result1;
            y = result2;
            diameter = result3;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - diameter);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - diameter);

            Circle circle = new Circle(x, y, diameter);
            Graphics g = this.CreateGraphics();

            circle.Draw(g);
            g.Save();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            int x, y, diameter, newD;
            int.TryParse(textBox12.Text, out int result1);
            int.TryParse(textBox10.Text, out int result2);
            int.TryParse(textBox11.Text, out int result3);
            int.TryParse(textBox31.Text, out int result4);

            x = result1;
            y = result2;
            diameter = result3;
            newD = result4;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - diameter);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - diameter);

            Circle circle = new Circle(x, y, diameter);
            Graphics g = this.CreateGraphics();

            circle.Change(x, y, diameter, newD, g);
            g.Save();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int x, y, width, height;
            int.TryParse(textBox16.Text, out int result1);
            int.TryParse(textBox14.Text, out int result2);
            int.TryParse(textBox15.Text, out int result3);
            int.TryParse(textBox13.Text, out int result4);

            x = result1;
            y = result2;
            width = result3;
            height = result4;

            x = Math.Max(x, 10);
            x = Math.Min(x, 650 - width);
            y = Math.Max(y, 10);
            y = Math.Min(y, 580 - height);

            Ellipse ellipse = new Ellipse(x, y, width, height);
            Graphics g = this.CreateGraphics();

            ellipse.Draw(g);
            g.Save();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            int x, y, width, height, newX, newY, diameter, x2, x3, y2, y3;
            Graphics g = this.CreateGraphics();


            switch (comboBox1.SelectedIndex)
            {

                case 0:

                    int.TryParse(textBox1.Text, out int result1);
                    int.TryParse(textBox3.Text, out int result2);
                    int.TryParse(textBox2.Text, out int result3);
                    int.TryParse(textBox4.Text, out int result4);
                    int.TryParse(textBox29.Text, out int result5);
                    int.TryParse(textBox28.Text, out int result6);

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

                    Rectangle rect = new Rectangle(x, y, width, height);

                    rect.MoveTo(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 1:

                    int.TryParse(textBox8.Text, out int result7);
                    int.TryParse(textBox6.Text, out int result8);
                    int.TryParse(textBox7.Text, out int result9);
                    int.TryParse(textBox29.Text, out int result10);
                    int.TryParse(textBox28.Text, out int result11);

                    x = result7;
                    y = result8;
                    width = result9;
                    newX = result10;
                    newY = result11;

                    x = Math.Max(x, 10);
                    x = Math.Min(x, 650 - width);
                    y = Math.Max(y, 10);
                    y = Math.Min(y, 580 - width);

                    Square square = new Square(x, y, width);


                    square.MoveTo(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 2:

                    int.TryParse(textBox16.Text, out int result12);
                    int.TryParse(textBox14.Text, out int result13);
                    int.TryParse(textBox15.Text, out int result14);
                    int.TryParse(textBox13.Text, out int result15);
                    int.TryParse(textBox29.Text, out int result16);
                    int.TryParse(textBox28.Text, out int result17);

                    x = result12;
                    y = result13;
                    width = result14;
                    height = result15;
                    newX = result16;
                    newY = result17;

                    x = Math.Max(x, 10);
                    x = Math.Min(x, 650 - width);
                    y = Math.Max(y, 10);
                    y = Math.Min(y, 580 - height);

                    Ellipse ellipse = new Ellipse(x, y, width, height);

                    ellipse.MoveTo(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 3:

                    int.TryParse(textBox12.Text, out int result18);
                    int.TryParse(textBox10.Text, out int result19);
                    int.TryParse(textBox11.Text, out int result20);
                    int.TryParse(textBox29.Text, out int result21);
                    int.TryParse(textBox28.Text, out int result22);

                    x = result18;
                    y = result19;
                    diameter = result20;
                    newX = result21;
                    newY = result22;

                    x = Math.Max(x, 10);
                    x = Math.Min(x, 650 - diameter);
                    y = Math.Max(y, 10);
                    y = Math.Min(y, 580 - diameter);

                    Circle circle = new Circle(x, y, diameter);

                    circle.MoveTo(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 4:

                    int.TryParse(textBox9.Text, out int result23);
                    int.TryParse(textBox20.Text, out int result24);
                    int.TryParse(textBox17.Text, out int result25);
                    int.TryParse(textBox18.Text, out int result26);
                    int.TryParse(textBox19.Text, out int result27);
                    int.TryParse(textBox5.Text, out int result28);
                    int.TryParse(textBox29.Text, out int result29);
                    int.TryParse(textBox28.Text, out int result30);

                    x = result23;
                    y = result24;
                    x2 = result25;
                    x3 = result26;
                    y2 = result27;
                    y3 = result28;
                    newX = result29;
                    newY = result30;

                    Triangle triangle = new Triangle(x, y, x2, x3, y2, y3);

                    triangle.MoveTo(x, y, newX, newY, g);
                    g.Save();
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            int x, y, width, height, newX, newY, diameter, x2, x3, y2, y3;
            Graphics g = this.CreateGraphics();


            switch (comboBox1.SelectedIndex)
            {

                case 0:

                    int.TryParse(textBox1.Text, out int result1);
                    int.TryParse(textBox3.Text, out int result2);
                    int.TryParse(textBox2.Text, out int result3);
                    int.TryParse(textBox4.Text, out int result4);
                    int.TryParse(textBox29.Text, out int result5);
                    int.TryParse(textBox28.Text, out int result6);

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

                    Rectangle rect = new Rectangle(x, y, width, height);

                    rect.Delete(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 1:

                    int.TryParse(textBox8.Text, out int result7);
                    int.TryParse(textBox6.Text, out int result8);
                    int.TryParse(textBox7.Text, out int result9);
                    int.TryParse(textBox29.Text, out int result10);
                    int.TryParse(textBox28.Text, out int result11);

                    x = result7;
                    y = result8;
                    width = result9;
                    newX = result10;
                    newY = result11;

                    x = Math.Max(x, 10);
                    x = Math.Min(x, 650 - width);
                    y = Math.Max(y, 10);
                    y = Math.Min(y, 580 - width);

                    Square square = new Square(x, y, width);


                    square.Delete(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 2:

                    int.TryParse(textBox16.Text, out int result12);
                    int.TryParse(textBox14.Text, out int result13);
                    int.TryParse(textBox15.Text, out int result14);
                    int.TryParse(textBox13.Text, out int result15);
                    int.TryParse(textBox29.Text, out int result16);
                    int.TryParse(textBox28.Text, out int result17);

                    x = result12;
                    y = result13;
                    width = result14;
                    height = result15;
                    newX = result16;
                    newY = result17;

                    x = Math.Max(x, 10);
                    x = Math.Min(x, 650 - width);
                    y = Math.Max(y, 10);
                    y = Math.Min(y, 580 - height);

                    Ellipse ellipse = new Ellipse(x, y, width, height);

                    ellipse.Delete(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 3:

                    int.TryParse(textBox12.Text, out int result18);
                    int.TryParse(textBox10.Text, out int result19);
                    int.TryParse(textBox11.Text, out int result20);
                    int.TryParse(textBox29.Text, out int result21);
                    int.TryParse(textBox28.Text, out int result22);

                    x = result18;
                    y = result19;
                    diameter = result20;
                    newX = result21;
                    newY = result22;

                    x = Math.Max(x, 10);
                    x = Math.Min(x, 650 - diameter);
                    y = Math.Max(y, 10);
                    y = Math.Min(y, 580 - diameter);

                    Circle circle = new Circle(x, y, diameter);

                    circle.Delete(x, y, newX, newY, g);
                    g.Save();
                    break;

                case 4:

                    int.TryParse(textBox9.Text, out int result23);
                    int.TryParse(textBox20.Text, out int result24);
                    int.TryParse(textBox17.Text, out int result25);
                    int.TryParse(textBox18.Text, out int result26);
                    int.TryParse(textBox19.Text, out int result27);
                    int.TryParse(textBox5.Text, out int result28);
                    int.TryParse(textBox29.Text, out int result29);
                    int.TryParse(textBox28.Text, out int result30);

                    x = result23;
                    y = result24;
                    x2 = result25;
                    x3 = result26;
                    y2 = result27;
                    y3 = result28;
                    newX = result29;
                    newY = result30;

                    Triangle triangle = new Triangle(x, y, x2, x3, y2, y3);

                    triangle.Delete(x, y, newX, newY, g);
                    g.Save();
                    break;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int x, y, x2, x3, y2, y3;
            int.TryParse(textBox9.Text, out int result1);
            int.TryParse(textBox20.Text, out int result2);
            int.TryParse(textBox17.Text, out int result3);
            int.TryParse(textBox18.Text, out int result4);
            int.TryParse(textBox19.Text, out int result5);
            int.TryParse(textBox5.Text, out int result6);

            x = result1;
            y = result2;
            x2 = result3;
            x3 = result4;
            y2 = result5;
            y3 = result6;

            Triangle triangle = new Triangle(x, y, x2, x3, y2, y3);
            Graphics g = this.CreateGraphics();

            triangle.Draw(g);
            g.Save();
        }

        private void comboBox1_RightToLeftChanged(object sender, EventArgs e)
        {

        }
    }
}