using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_DDC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void SetBrightness(int brightnessValue)
        {
            var psi = new ProcessStartInfo
            {
                FileName = @"ClickMonitorDDC_7_2.exe",
                Arguments = $"b {brightnessValue}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    MessageBox.Show("錯誤：" + errors);
                }
            }
        }

        private void SetBrightnessPython(int brightnessValue)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "..\\..\\..\\python\\.venv\\Scripts\\python",
                Arguments = $"..\\..\\..\\python\\set_brightness.py {brightnessValue}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    MessageBox.Show("錯誤：" + errors);
                }
            }
            GlobalFunc.Instance.BValue = brightnessValue;
            BValue_now.Text = "目前亮度: " + GlobalFunc.Instance.BValue.ToString();
            
        }

        private void SetContrastPython(int ContrastValue)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "..\\..\\..\\python\\.venv\\Scripts\\python",
                Arguments = $"..\\..\\..\\python\\set_contrastValue.py {ContrastValue}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    MessageBox.Show("錯誤：" + errors);
                }
            }

            GlobalFunc.Instance.CValue = ContrastValue;
            CValue_now.Text = "目前對比度: " + GlobalFunc.Instance.CValue.ToString();
        }

        // 當按下按鈕時，根據 TrackBar 的值設置亮度
        private void B_btn_Click(object sender, EventArgs e)
        {
            int brightnessValue = B_TrackBar.Value; // 取得 TrackBar 目前的值
            SetBrightnessPython(brightnessValue);        // 呼叫 SetBrightness 設置螢幕亮度
            GlobalFunc.Instance.BValue = brightnessValue;
            BValue_now.Text = "目前亮度: " + GlobalFunc.Instance.BValue.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalFunc.Instance.BValue = GetCurrentBrightnessPython();
            BValue_now.Text = "目前亮度: " + GlobalFunc.Instance.BValue.ToString();
            BValue_set.Text = "設定亮度：" + 0 ;

            GlobalFunc.Instance.CValue = GetCurrentContrastPython();
            CValue_now.Text = "目前對比度: " + GlobalFunc.Instance.CValue.ToString();
            CValue_set.Text = "設定對比度：" + 0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            BValue_set.Text = "設定亮度：" + B_TrackBar.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            CValue_set.Text = "設定對比度：" + C_TrackBar.Value.ToString();
        }

        private int GetCurrentBrightness()
        {
            var psi = new ProcessStartInfo
            {
                FileName = @"ClickMonitorDDC_7_2.exe",
                Arguments = "",  // 不帶參數就會列出目前所有設定
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    MessageBox.Show("錯誤：" + errors);
                    return -1;
                }

                // 解析第一台螢幕的 b=XX 亮度值
                var match = Regex.Match(output, @"\bb=(\d+)");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int brightness))
                {
                    return brightness;
                }

                return -1;
            }
        }

        private int GetCurrentBrightnessPython()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "..\\..\\..\\python\\.venv\\Scripts\\python",  // ← 請填入你的 python.exe 路徑
                Arguments = $"..\\..\\..\\python\\get_brightness.py",  // ← 相對或絕對路徑皆可
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    MessageBox.Show("錯誤：" + errors);
                    return -1;
                }

                if (int.TryParse(output.Trim(), out int brightness))
                {
                    return brightness;
                }

                return -1;
            }
        }

        private int GetCurrentContrastPython()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "..\\..\\..\\python\\.venv\\Scripts\\python",  // ← 請填入你的 python.exe 路徑
                Arguments = $"..\\..\\..\\python\\get_contrastValue.py",  // ← 相對或絕對路徑皆可
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(errors))
                {
                    MessageBox.Show("錯誤：" + errors);
                    return -1;
                }

                if (int.TryParse(output.Trim(), out int contrast))
                {
                    return contrast;
                }

                return -1;
            }
        }

        private void C_btn_Click(object sender, EventArgs e)
        {
            int ConstactValue = C_TrackBar.Value; // 取得 TrackBar 目前的值
            SetContrastPython(ConstactValue);        // 呼叫 SetBrightness 設置螢幕亮度
            GlobalFunc.Instance.CValue = ConstactValue;
            CValue_now.Text = "目前對比度: " + GlobalFunc.Instance.CValue.ToString();

        }

        private void modeA_Click(object sender, EventArgs e)
        {
            SetBrightnessPython(0);
            SetContrastPython(0);
        }

        private void modeB_Click(object sender, EventArgs e)
        {
            SetBrightnessPython(0);
            SetContrastPython(50);
        }

        private void modeC_Click(object sender, EventArgs e)
        {
            SetBrightnessPython(100);
            SetContrastPython(100);
        }
    }
}
