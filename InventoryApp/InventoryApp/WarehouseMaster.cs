using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryApp
{
    public partial class WarehouseMaster : Form
    {
        public WarehouseMaster()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        private void btnback_Click(object sender, EventArgs e)
        {
            
        }

        private void WarehouseMaster_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            Con.Open();
            String que1 = "select Storename as 'STORE NAME',Storecode as 'STORE CODE', Address as 'ADDRESS' from Warehouse_Master";
            SqlDataAdapter sda = new SqlDataAdapter(que1, Con);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewWareHouse Dash = new NewWareHouse();
            Dash.Show();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Master Dash = new Master();
            Dash.Show();
        }
    }
}
