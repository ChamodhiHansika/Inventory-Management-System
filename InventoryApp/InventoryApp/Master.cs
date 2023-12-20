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
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main Dash = new Main();
            Dash.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemMaster imst = new ItemMaster();
            imst.Show();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemGroupMaster item = new ItemGroupMaster();
            item.Show();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemSubGroupMaster isgm = new ItemSubGroupMaster();
            isgm.Show();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WarehouseMaster whm = new WarehouseMaster();
            whm.Show();
            
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DepartmentMaster dm = new DepartmentMaster();
            dm.Show();
           
        }
    }
}
