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
    public partial class NewItemGroupMaster : Form
    {
        public NewItemGroupMaster()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        private void NewItemGroupMaster_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemGroupMaster Dash = new ItemGroupMaster();
            Dash.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaGradientButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ItemGroupMaster Dash = new ItemGroupMaster();
            Dash.Show();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            Con.Open();

            if(textBox1.Text=="" || textBox2.Text=="") {
                MessageBox.Show("Fill the Empty Fields !");

        }
        else{
                String que1 = "insert into item_group_master values('" + textBox2.Text + "','" + textBox1.Text.ToUpper() + "')";
                SqlCommand cmd = new SqlCommand(que1, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }
            Con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
