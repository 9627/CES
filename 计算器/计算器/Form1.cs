using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double jg;
        private void but_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }
        private void button16_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] cf = textBox1.Text.Split(new char[] { '+','-','x','/','%'});
                if (textBox1.Text.IndexOf("+") >= 0)
                {
                    jg = (Convert.ToDouble(cf[0]) + Convert.ToDouble(cf[1]));
                }
                if (textBox1.Text.IndexOf("－") >= 0)
                {
                    jg = (Convert.ToDouble(cf[0]) - Convert.ToDouble(cf[1]));
                }
                if (textBox1.Text.IndexOf("x") >= 0)
                {
                    jg = (Convert.ToDouble(cf[0]) * Convert.ToDouble(cf[1]));
                }
                if (textBox1.Text.IndexOf("/") >= 0)
                {
                    jg = (Convert.ToDouble(cf[0]) / Convert.ToDouble(cf[1]));
                }
                if (textBox1.Text.IndexOf("%") >= 0)
                {
                    jg = (Convert.ToDouble(cf[0]) % Convert.ToDouble(cf[1]));
                }
                textBox1.Text = Convert.ToString(jg);
            }
            catch (Exception)
            {
            }
        }
        private void button17_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            jg = 0;
            textBox1.Text = "";
        }
    }
}
