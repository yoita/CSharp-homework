using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_program1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int h, m, s;
            string hh, mm, ss;
            h = DateTime.Now.Hour;
            m = DateTime.Now.Minute;
            s = DateTime.Now.Second;
            if (h < 10)
                hh = "0" + h.ToString();//当h小于10时，在前面补0
            else
                hh = h.ToString();
            if (m < 10)
                mm = "0" + m.ToString();
            else
                mm = m.ToString();
            if (s < 10)
                ss = "0" + s.ToString();
            else
                ss = s.ToString();
            textBox1.Text=hh+":"+mm+":"+ss;
        }



    }
}
