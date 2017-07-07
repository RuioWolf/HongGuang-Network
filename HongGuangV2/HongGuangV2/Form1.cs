using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace HongGuangV2
{
    public partial class Form1 : Form
    {
        static bool automode;
        bool running;
        int t = 0;

        int sj = 0;

        //MainLoop ml=new MainLoop();
        Thread autoThread = new Thread(loop);

        public Form1()
        {
            InitializeComponent();
#if (DEBUG)
            webBrowser1.Visible = true;
#endif
            webBrowser1.Navigate("http://1.1.1.2/ajaxlogout?_t=1473332977129");
            textBox2.Text = Convert.ToString(sj);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    if (int.Parse(textBox2.Text) >= 1 && int.Parse(textBox2.Text) <= 1000)
                    {
                        textBox2.ReadOnly = true;
                        sj = int.Parse(textBox2.Text);
                        timer1.Interval = sj;
                        running = true;
                        timer1.Enabled = true;
                    }
                    else
                    {
                        textBox2.ReadOnly = true;
                        automode = true;
                        running = true;
                        if (t == 0)
                        {
                            t++;
                            autoThread.Start();
                        }
                        else if (!autoThread.IsAlive)
                        {
                            autoThread.Resume();
                        }
                    }
                }
            }
            else
            {
                stoploop();
//                textBox2.ReadOnly = false;
//                timer1.Enabled = false;
//                automode = false;
//                running = false;
//#if (DEBUG)
//                MessageBox.Show("");
//#endif
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            Application.DoEvents();
        }

        public static void loop()
        {
#if (DEBUG)
            while (automode)
            {
                //webBrowser1.DocumentText = HttpGet("http://1.1.1.2/ajaxlogout?_t=1473332977129");
                HttpGet("http://1.1.1.2/ajaxlogout?_t=1473332977129");
            }
#endif
#if (!DEBUG)
            while (automode)
            {
                //webBrowser1.DocumentText = HttpGet("http://1.1.1.2/ajaxlogout?_t=1473332977129");
                HttpGet("http://1.1.1.2/ajaxlogout?_t=1473332977129");
            }
#endif
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Powerfully Powered By Ruio.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stoploop();
            if (t != 0)
            {
                autoThread.Resume();
                autoThread.Abort();
            }
//            textBox2.ReadOnly = false;
//            timer1.Enabled = false;
//            running = false;
//            automode = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void stoploop()
        {
            textBox2.ReadOnly = false;
            timer1.Enabled = false;
            automode = false;
            running = false;
            if (t != 0)
                autoThread.Suspend();
#if (DEBUG)
            //MessageBox.Show("");
#endif
        }

        //public string HttpGet(string url, string data)
        public static string HttpGet(string url)
        {
            try
            {
                //创建Get请求
                //url = url + (data == "" ? "" : "?") + data;
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string retString = streamReader.ReadToEnd();

                streamReader.Close();
                stream.Close();
                response.Close();

                //Application.DoEvents();

                return retString;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

//
//    public class MainLoop
//    {
//        public string HttpGet(string url)
//        {
//            try
//            {
//                //创建Get请求
//                //url = url + (data == "" ? "" : "?") + data;
//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//                request.Method = "GET";
//                request.ContentType = "text/html;charset=UTF-8";
//
//                //接受返回来的数据
//                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//                Stream stream = response.GetResponseStream();
//                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
//                string retString = streamReader.ReadToEnd();
//
//                streamReader.Close();
//                stream.Close();
//                response.Close();
//
//                Application.DoEvents();
//
//                return retString;
//            }
//            catch (Exception)
//            {
//                return "";
//            }
//        }
//
//        public static void LoopGet()
//        {
//            MainLoop.LoopGet("http://1.1.1.2/ajaxlogout?_t=1473332977129");
//        }
//    }
}