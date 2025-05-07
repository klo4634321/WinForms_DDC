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

namespace WinForms_DDC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            StartPythonServer();
            PictureBoxLoading();
        }

        

    void StartPythonServer()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "..\\..\\..\\python\\.venv\\Scripts\\python",  // ← 請填入你的 python.exe 路徑
                Arguments = $"..\\..\\..\\python\\screen_stream.py",  // ← 相對或絕對路徑皆可
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
            Timer timer = new Timer();
            timer.Interval = 100; // 每 100ms 抓一次
            timer.Tick += async (s, e) =>
            {
                try
                {
                    var bytes = await httpClient.GetByteArrayAsync("http://localhost:5003/current");
                    using (var ms = new MemoryStream(bytes))
                    {
                        if (pictureBox1.Image != null)
                            pictureBox1.Image.Dispose();
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            };
            timer.Start();
        }



    }
}
