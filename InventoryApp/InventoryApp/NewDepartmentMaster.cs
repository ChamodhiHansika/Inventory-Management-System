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
    public partial class NewDepartmentMaster : Form
    {
        public NewDepartmentMaster()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        private void NewDepartmentMaster_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DepartmentMaster Dash = new DepartmentMaster();
            Dash.Show();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            Con.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text=="")
            {
                MessageBox.Show("Fill the Empty Fields !");

            }
            else
            {
                String que1 = "insert into Department_master values('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','"+ textBox4.Text +"')";
                SqlCommand cmd = new SqlCommand(que1, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }

            Con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


            Con.Close();
        }
    }
}
