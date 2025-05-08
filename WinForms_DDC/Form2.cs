using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net.Http;
using System.IO;
using System.Net;
using System.Text.Json;

namespace WinForms_DDC
{
    public partial class Form2 : Form
    {

        private Timer timer;


        public Form2()
        {
            InitializeComponent();
            StartPythonServer();
            PictureBoxLoading();
            this.Load += Form2_Load;
            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }



        void StartPythonServer()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "..\\..\\..\\python\\.venv\\Scripts\\python",  // ← 請填入你的 python.exe 路徑
                Arguments = $"..\\..\\..\\python\\yoloDetect.py",  // ← 相對或絕對路徑皆可
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process.Start(psi);
        }

        void PictureBoxLoading()
        {
            HttpClient httpClient = new HttpClient();
            timer = new Timer();
            timer.Interval = 100; // 每 100ms 抓一次
            timer.Tick += async (s, e) =>
            {
                try
                {
                    var bytes = await httpClient.GetByteArrayAsync("http://localhost:5000/detect");
                    Console.WriteLine($"Received {bytes.Length} bytes from Flask"); // 顯示接收到的位元組數
                    using (var ms = new MemoryStream(bytes))
                    {
                        if (pictureBox1.Image != null)
                            pictureBox1.Image.Dispose();
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message); // 捕獲錯誤
                }
            };
            timer.Start();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }






    }
}
