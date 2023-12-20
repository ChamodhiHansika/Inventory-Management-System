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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtusername.Text=="Username")
            {
                txtusername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtPassword.Text=="Password")
            {
                txtPassword.Clear();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main Dash = new Main();
            Dash.Show();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register Reg = new Register();
            Reg.Show();
        }
    }
}
