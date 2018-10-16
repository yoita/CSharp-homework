using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Tree(Point O, double angle, double length, float width, Graphics g)
        {
            if (width < 1)
                width = 1;
            if (length < 10)//差不多树枝尽头的时候停止绘制 
            {
                return;
            }
            Point p = new Point(O.X + (int)(length * Math.Cos(angle)), O.Y - (int)(length * Math.Sin(angle)));
            Pen pen = new Pen(Brushes.Red, width);
            g.DrawLine(pen, O, p);
            Tree(p, angle + Math.PI / 18, length * 0.8, width * 0.8f, g);//递归画左半个，这里可以修改参数，画出不同形状的树 
            Tree(p, angle - Math.PI / 18, length * 0.8, width * 0.8f, g);//递归画右半个 
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            Point O = new Point(this.Width / 2, this.Height - 100);//取窗体最下边靠上面点的中间位置作树根点 
            Graphics g = this.CreateGraphics();//获取Graphics的对象 
            Tree(O, Math.PI / 2, 100, 10, g);//画分形树 
        }  
    }
}
