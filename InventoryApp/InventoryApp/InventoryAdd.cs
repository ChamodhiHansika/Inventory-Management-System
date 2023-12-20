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
    public partial class InventoryAdd : Form
    {
        public InventoryAdd()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryReport ivr = new InventoryReport();
            ivr.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Con.Open();
            if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty || textBox4.Text == String.Empty || textBox5.Text == String.Empty || textBox6.Text == String.Empty || textBox7.Text == String.Empty || textBox8.Text == String.Empty || textBox9.Text == String.Empty || textBox10.Text == String.Empty || textBox11.Text == String.Empty) 
            {
                MessageBox.Show("Fill the Empty Fields !");

            }
            else
            {
                String que1 = "insert into stock_table values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
                SqlCommand cmd = new SqlCommand(que1, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }
            Con.Close();

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;

            Con.Close();
        }

        private void InventoryAdd_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
    }
}
