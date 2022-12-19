using MrSmarty.CodeProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace samHydeVirus
{
    public partial class SamHax : Form
    {
        public SamHax()
        {
            InitializeComponent();
        }

        private void SamHax_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SamHax funkymonkeychunk = new SamHax();
            funkymonkeychunk.Show();
            SamHax funkymonkeychunk2 = new SamHax();
            funkymonkeychunk2.Show();
        }
    }
}
