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
    public partial class NewItemSubGroup : Form
    {
        public NewItemSubGroup()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        private void NewItemSubGroup_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            Con.Open();
            SqlCommand cmd2 = Con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select item_group from item_subgroup_master";
            cmd2.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["item_group"].ToString());
            }

            Con.Close();

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemSubGroupMaster Dash = new ItemSubGroupMaster();
            Dash.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            Con.Open();

            if (textBox1.Text == "" || comboBox1.Text=="")
            {
                MessageBox.Show("Fill the Empty Fields !");

            }
            else
            {
                String que2 = "insert into item_subgroup_master values('" + comboBox1.Text + "','" + textBox1.Text + "')";
                SqlCommand cmd = new SqlCommand(que2, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added Successfully");
            }

            Con.Close();
            comboBox1.Text = "";
            textBox1.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
