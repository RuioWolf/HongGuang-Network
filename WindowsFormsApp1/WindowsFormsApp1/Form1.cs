using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public void timer1_Tick(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(textBox1.Text)>=0&&int.Parse(textBox1.Text)<=100&&!string.IsNullOrEmpty(textBox1.Text))
            {
                Properties.Settings.Default.pl = textBox1.Text;
                Properties.Settings.Default.Save();
#if (DEBUG)
                //MessageBox.Show(Properties.Settings.Default.pl);
                textBox2.Text = Properties.Settings.Default.pl;
#endif
                timer1.Interval = int.Parse(Properties.Settings.Default.pl);
            }
            else
            {
                MessageBox.Show("错误的数值 必须设置在0-100之间");
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.pl;
            //timer1.Interval = 1000 / Convert.ToInt32;
            timer1.Interval = int.Parse(Properties.Settings.Default.pl);
            //timer1.Enabled = true;
            webBrowser1.Navigate("http://1.1.1.2/ajaxlogout?_t=1473332977129");
#if(DEBUG)
            textBox2.Text = "DEBUG";
#endif
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        public void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
    }
}
