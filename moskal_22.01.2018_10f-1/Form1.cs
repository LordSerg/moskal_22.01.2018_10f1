using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace moskal_22._01._2018_10f_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //в проекте:
        //1)Масштабирование функции в процентах
        //2)При изменении размеров формы программа рисует функцию ровно по середине формы
        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            //рисуем координатные оси
            Graphics g = CreateGraphics();
            Pen p1 = new Pen(Color.Black, 1);
            g.DrawLine(p1, 0, this.Height / 2, this.Width, this.Height / 2);
            g.DrawLine(p1, this.Width / 2, 0, this.Width / 2, this.Height);
            Pen p2 = new Pen(Color.Red,1);
            //коефициенты масштаба 
            double n;
            n = double.Parse(textBox1.Text);

            double x1, y1, x0 = 0, y0 = this.Height / 2;
            for(double i=0; i<this.Width; i+=0.1)
            {
                //строим функнию, учитывая размеры Form1 и коеф. масштаба
                //в данном случае получится, что чем больший "n" - тем растянутей (в одинаковой пропорции) рисуется функция

                x1 = i;
                y1 = -1*(n * 0.01) * (Math.Cos((x1 - this.Width / 2) * (1 / (n * 0.01)))) + (this.Height / 2);
                if(((x1 > -2000) && (x1 < 2000)) && ((y1 > -2000) && (y1 < 2000)))
                {
                    int X = Convert.ToInt32(x0);
                    int Y = Convert.ToInt32(y0);
                    int x = Convert.ToInt32(x1);
                    int y = Convert.ToInt32(y1);
                    g.DrawLine(p2, X, Y, x, y);
                }
                x0 = x1;
                y0 = y1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
