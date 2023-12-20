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
    public partial class MIN : Form
    {
        DataTable table = new DataTable("table");
        int index;
        public MIN()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        private void MIN_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            

            table.Columns.Add("Item No");
            table.Columns.Add("Description");
            table.Columns.Add("UOM", Type.GetType("System.String"));
            table.Columns.Add("Unit Cost");
            table.Columns.Add("Request Quantity", Type.GetType("System.Int32"));
            table.Columns.Add("Issue Quantity", Type.GetType("System.Int32"));
            table.Columns.Add("Warehouse Code");
            table.Columns.Add("Expenditure Code");
            table.Columns.Add("Department Code");
            table.Columns.Add("Amount", Type.GetType("System.Int32"));
            dgv1.DataSource = table;

            Con.Open();
            SqlCommand cmd2 = Con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select item_code from stock_table";
            cmd2.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cboItemNo.Items.Add(dr["item_code"].ToString());
            }

            Con.Close();

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaction g = new Transaction();
            g.Show();
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Con.Open();
            String sql1 = "select description,uom,unitprice from stock_table where item_code='" +cboItemNo.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, Con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da1.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                txtDes.Text = (dr["description"].ToString());
                txtUOM.Text = (dr["uom"].ToString());
                txtCost.Text = (dr["unitprice"].ToString());
            }



            Con.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaction g = new Transaction();
            g.Show();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int amt;

            amt = Convert.ToInt32(txtCost.Text) * Convert.ToInt32(txtIssue.Text);

            txtAmount.Text = amt.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtUOM.Text, txtDes.Text, txtUOM.Text, txtCost.Text, txtRequest.Text,txtIssue.Text, textWarehouse.Text, txtExpenditure.Text, txtDepartment.Text, txtAmount.Text);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboItemNo.Text = String.Empty;
            txtDes.Text = String.Empty;
            txtUOM.Text = String.Empty;
            txtCost.Text = String.Empty;
            txtRequest.Text = String.Empty;
            txtIssue.Text = String.Empty;
            textWarehouse.Text = String.Empty;
            txtExpenditure.Text = String.Empty;
            txtDepartment.Text = String.Empty;
            txtAmount.Text = String.Empty;

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dgv1.Rows[index];
            cboItemNo.Text = row.Cells[0].Value.ToString();
            txtDes.Text = row.Cells[1].Value.ToString();
            txtUOM.Text = row.Cells[2].Value.ToString();
            txtCost.Text = row.Cells[3].Value.ToString();
            txtRequest.Text = row.Cells[4].Value.ToString();
            txtIssue.Text = row.Cells[5].Value.ToString();
            textWarehouse.Text = row.Cells[6].Value.ToString();
            txtExpenditure.Text = row.Cells[7].Value.ToString();
            txtDepartment.Text = row.Cells[8].Value.ToString();
            txtAmount.Text = row.Cells[9].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            index = dgv1.CurrentCell.RowIndex;
            dgv1.Rows.RemoveAt(index);
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            double amt;

            if (txtCost.Text == String.Empty)
            {
                amt = 0;

            }
            else if (txtIssue.Text ==String.Empty)
            {
                amt = 0;
            }
            else
            {

                amt = Convert.ToDouble(txtIssue.Text) * Convert.ToDouble(txtCost.Text);

            }
            txtAmount.Text = amt.ToString();
        }

        private void txtIssue_TextChanged(object sender, EventArgs e)
        {
            double amt;

            if (txtCost.Text == String.Empty)
            {
                amt = 0;

            }
            else if (txtIssue.Text == String.Empty)
            {
                amt = 0;
            }
            else
            {

                amt = Convert.ToDouble(txtIssue.Text) * Convert.ToDouble(txtCost.Text);

            }
            txtAmount.Text = amt.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();
            for (int i = 0; i < dgv1.Rows.Count - 1; i++)
            {
                String que1 = "insert into SRN_Rep_table values('" + textBox1.Text + "','" + dgv1.Rows[i].Cells[0].Value.ToString() + "','" + dgv1.Rows[i].Cells[1].Value.ToString() + "','" + dgv1.Rows[i].Cells[2].Value.ToString() + "','" + dgv1.Rows[i].Cells[3].Value.ToString() + "','" + dgv1.Rows[i].Cells[4].Value.ToString() + "','" + dgv1.Rows[i].Cells[5].Value.ToString() + "','" + dgv1.Rows[i].Cells[6].Value.ToString() + "','" + dgv1.Rows[i].Cells[7].Value.ToString() + "','" + dgv1.Rows[i].Cells[8].Value.ToString() + "','" + dgv1.Rows[i].Cells[9].Value.ToString() + "')";
                SqlCommand cmd = new SqlCommand(que1, Con);
                cmd.ExecuteNonQuery();
            }

            String que2 = "insert into srn_table values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker4.Text + "')";
            SqlCommand cmd2 = new SqlCommand(que2, Con);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Record Added Successfully");

            Con.Close();

            cboItemNo.Text = String.Empty;
            txtDes.Text = String.Empty;
            txtUOM.Text = String.Empty;
            txtCost.Text = String.Empty;
            txtRequest.Text = String.Empty;
            txtIssue.Text = String.Empty;
            textWarehouse.Text = String.Empty;
            txtExpenditure.Text = String.Empty;
            txtDepartment.Text = String.Empty;
            txtAmount.Text = String.Empty;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
           


        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
