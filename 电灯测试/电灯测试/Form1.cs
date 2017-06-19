using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 电灯测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "您现在的分数为:100";
        }
        int 计数 = 0;
        string 状态 = "0000000000000000";
        
        /// <summary>
        /// 变色
        /// </summary>
        /// <param name="b">按钮</param>
        private void bianse(Button b,int ddh)
        {
            if (b.BackColor == Color.Black)
            {
                b.BackColor = Color.Yellow;
            }
            else
            {
                b.BackColor = Color.Black;
            }
            计数++;
            label1.Text = "您现在的分数为;"+(100-计数).ToString();


            ztxg(ddh);
            if (状态.IndexOf("0") == -1)
            {
                MessageBox.Show((100 - 计数).ToString() + "分");
                this.Close();
            }
            if (计数>100)
            {
                MessageBox.Show("游戏结束");
                this.Close();
            }
           
            
        }
        private void ztxg(int ddh)
        {
            string s = "";
            for (int i = 0; i < 16; i++)
            {
                if (i == ddh-1)
                {
                    if (状态[ddh - 1] == '0')
                    {
                        s += "1";//s = s + "1";
                    }
                    else
                    {
                        s += "0";
                    }
                }
                else
                {
                    s += 状态[i];
                }
                
            }
            状态 = s;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bianse(button1,1);
            bianse(button2,2);
            bianse(button5,5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bianse(button2,2);
            bianse(button1,1);
            bianse(button3,3);
            bianse(button6,6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bianse(button3,3);
            bianse(button2,2);
            bianse(button4,4);
            bianse(button7,7);
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            bianse(button4,4);
            bianse(button3,3);
            bianse(button8,8);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bianse(button5,5);
            bianse(button1,1);
            bianse(button6,6);
            bianse(button9,9);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bianse(button6,6);
            bianse(button2,2);
            bianse(button5,5);
            bianse(button7,7);
            bianse(button10,10);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bianse(button7,7);
            bianse(button3,3);
            bianse(button6,6);
            bianse(button8,8);
            bianse(button11,11);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bianse(button8,8);
            bianse(button4,4);
            bianse(button7,7);
            bianse(button12,12);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            bianse(button9,9);
            bianse(button5,5);
            bianse(button10,10);
            bianse(button13,13);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bianse(button10,10);
            bianse(button6,6);
            bianse(button9,9);
            bianse(button11,11);
            bianse(button14,14);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bianse(button11,11);
            bianse(button7,7);
            bianse(button10,10);
            bianse(button12,12);
            bianse(button15,15);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bianse(button12,12);
            bianse(button8,8);
            bianse(button11,11);
            bianse(button16,16);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bianse(button13,13);
            bianse(button9,9);
            bianse(button14,14);
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bianse(button14,14);
            bianse(button10,10);
            bianse(button13,13);
            bianse(button15,15);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bianse(button15,15);
            bianse(button11,11);
            bianse(button14,14);
            bianse(button16,16);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bianse(button16,16);
            bianse(button12,12);
            bianse(button15,15);
        }
    }
}
