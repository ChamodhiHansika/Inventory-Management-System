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
    public partial class InventoryReport : Form
    {
      
        public InventoryReport()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            Con.Open();
            String que1 = "select grn_num as 'GRN No.',item_code as 'ITEM CODE',item_group as 'ITEM GROUP',description as 'DESCRIPTION',item_sub_group as 'ITEM SUB GROUP',uom as 'UOM',quantity as 'Quantity',reorder_level as 'RE-ORDER LEVEL',item_ctrl_srl as 'ITEM CONTROL SERIAL',unitprice as 'Unit Price',defaultwarehouse as 'DEFAULT WAREHOUSE',status as 'STATUS'  from stock_table";
            SqlDataAdapter sda = new SqlDataAdapter(que1, Con);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Con.Close();

           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Print p = new Print();
            p.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryAdd iva = new InventoryAdd();
            iva.Show();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Print p = new Print();
            p.Show();
        }
    }
}
