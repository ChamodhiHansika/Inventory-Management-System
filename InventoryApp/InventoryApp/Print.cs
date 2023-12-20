using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main Dash = new Main();
            Dash.Show();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryReport inv = new InventoryReport();
            inv.Show();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GRNreportprint grn = new GRNreportprint();
            grn.Show();

        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SRNreportprint grn = new SRNreportprint();
            grn.Show();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
