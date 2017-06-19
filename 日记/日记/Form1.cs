using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 日记
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("请输入标题和内容!");
                    return;
                }
                string time = DateTime.Now.ToString("yyyy-MM-dd HH：mm");
                string path = textBox3.Text + "\\" + time + "_" + textBox2.Text + ".txt";
                if (string.IsNullOrEmpty(textBox2.Tag as string))
                {
                   path = textBox3.Text + "\\" + time + "_" + textBox2.Text + ".txt";
                }
                else
                {
                    path = textBox2.Tag as string;
                    textBox2.Tag = null;
                }
                FileStream cj = new FileStream(path, FileMode.Create, FileAccess.Write);
                cj.Flush();
                cj.Close();
                StreamWriter xr = new StreamWriter(path);
                xr.WriteLine(textBox1.Text);
                xr.Flush();
                xr.Close();
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("无效的路径");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog lj = new FolderBrowserDialog();
            lj.Description = "选择路径";
            lj.ShowDialog();
            textBox3.Text = lj.SelectedPath;
        }
        private void 刷新()
        {
            DirectoryInfo sywj = new DirectoryInfo(textBox3.Text+"\\");
            FileInfo[] wj = sywj.GetFiles();
            string wjmc = "";
            foreach (var item in wj)
            {
                wjmc += item.Name;
            }
            if (Properties.Settings.Default.wjmc != wjmc)
            {
                try
                {
                    treeView1.Nodes.Clear();
                    Properties.Settings.Default.wjmc = wjmc;
                    int wjsl = wj.Count();
                    List<string> 年, 月, 日;
                    年 = new List<string>();
                    月 = new List<string>();
                    日 = new List<string>();
                    for (int i = 0; i < wjsl; i++)
                    {
                        年.Add(get年月日(wj[i].Name, 0));
                        月.Add(get年月日(wj[i].Name, 1));
                        日.Add(get年月日(wj[i].Name, 2));
                    }
                    年 = 年.Distinct().ToList();
                    月 = 月.Distinct().ToList();
                    日 = 日.Distinct().ToList();
                    foreach (string _年 in 年)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = _年 + "年";
                        foreach (string _月 in 月)
                        {
                            string[] 年月 = _月.Split('-');
                            if (年月[0] == _年)
                            {
                                TreeNode ty = new TreeNode();
                                ty.Text = 年月[1] + "月";
                                tn.Nodes.Add(ty);
                                foreach (string _日 in 日)
                                {
                                    string[] 年月日 = _日.Split('-');
                                    if (年月日[0] == _年 && 年月日[0] + "-" + 年月日[1] == _月)
                                    {
                                        TreeNode tr = new TreeNode();
                                        tr.Text = 年月日[2] + "日";
                                        ty.Nodes.Add(tr);
                                        foreach (var item in wj)
                                        {
                                            if (item.Name.Split(' ')[0] == _日)
                                            {
                                                TreeNode tname = new TreeNode();
                                                tname.Text = item.Name;
                                                tr.Nodes.Add(tname);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        treeView1.Nodes.Add(tn);
                        treeView1.ExpandAll();
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private string get年月日(string name, int type )
        {
            try
            {
                string 日 = name.Split(new char[] { ' ' })[0];
                string[] 日期 = 日.Split(new char[] { '-' });
                string 年 = 日期[0];
                string 月 = 日期[0] + "-" + 日期[1];
                switch (type)
                {
                    case 0:
                        return 年;
                    case 1:
                        return 月;
                    case 2:
                        return 日;
                    default:
                        return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (File.Exists(textBox3.Text + "\\" + treeView1.SelectedNode.Text) || treeView1.SelectedNode.Text == "")
                {
                    StreamReader sr = new StreamReader(textBox3.Text + "\\" + treeView1.SelectedNode.Text, Encoding.UTF8);
                    string strs = "";
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        strs += line.ToString() + "\r\n";
                    }
                    sr.Dispose();
                    textBox1.Text = strs;
                    textBox2.Text = treeView1.SelectedNode.Text.Split('_')[1].Split('.')[0];
                    textBox2.Tag = textBox3.Text + "\\" + treeView1.SelectedNode.Text;
                }
            }
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (File.Exists(textBox3.Text + "\\" + treeView1.SelectedNode.Text) || treeView1.SelectedNode.Text == "")
                {
                    File.Delete(textBox3.Text + "\\" + treeView1.SelectedNode.Text);
                    刷新();
                }
                else
                {
                    //  MessageBox.Show("文件不存在!");
                    return;
                }
            }
            else
            {
                //  MessageBox.Show("文件不存在!");
                return;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            刷新();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //if (!File.Exists(textBox3 .Text))
            //{
            //    Directory.CreateDirectory(textBox3.Text );
            //    FileStream cj = new FileStream(textBox3.Text+ "\\" + "1900-01-01 00：00_示例文档.txt", FileMode.Create, FileAccess.Write);
            //    //StreamWriter xru=new StreamWriter();
            //    cj.Flush();
            //    cj.Close();
            //}
        }
    }
}
