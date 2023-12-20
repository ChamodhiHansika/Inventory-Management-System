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
    public partial class grn : Form
    {
        DataTable table = new DataTable("table");
        int index;

        public grn()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        private void grn_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            

            table.Columns.Add("Item No");
            table.Columns.Add("Description");
            table.Columns.Add("Item Sub Group", Type.GetType("System.String"));
            table.Columns.Add("UOM", Type.GetType("System.String"));
            table.Columns.Add("Quantity", Type.GetType("System.Int32"));
            table.Columns.Add("Rate");
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
               comboItem.Items.Add(dr["item_code"].ToString());
            }

            SqlCommand cmd3 = new SqlCommand("select description from stock_table", Con);
            SqlDataReader rdr = cmd3.ExecuteReader();
            AutoCompleteStringCollection txtbx = new AutoCompleteStringCollection();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    txtbx.Add(rdr.GetString(0));
                }
            }
            rdr.Close();
            Con.Close();
            txtDes.AutoCompleteCustomSource = txtbx;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboItem.Text = String.Empty;
            txtDes.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            txtSubgrp.Text = String.Empty;
            txtUom.Text = String.Empty;
            txtRate.Text = String.Empty;
            txtAmount.Text = String.Empty;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            DataGridViewRow newdata = dgv1.Rows[index];
            newdata.Cells[0].Value = comboItem.Text;
            newdata.Cells[1].Value = txtDes.Text;
            newdata.Cells[2].Value = txtSubgrp.Text;
            newdata.Cells[3].Value = txtUom.Text;
            newdata.Cells[4].Value = txtQuantity.Text;
            newdata.Cells[5].Value = txtRate.Text;
            newdata.Cells[6].Value = txtAmount.Text;

       
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            table.Rows.Add(comboItem.Text, txtDes.Text, txtSubgrp.Text, txtUom.Text, txtQuantity.Text, txtRate.Text, txtAmount.Text);
            comboItem.Text = "Select One";
            txtDes.Text = String.Empty;
            txtSubgrp.Text = String.Empty;
            txtUom.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            txtRate.Text = String.Empty;
            txtAmount.Text = String.Empty;


        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dgv1.Rows[index];
            comboItem.Text = row.Cells[0].Value.ToString();
            txtDes.Text = row.Cells[1].Value.ToString();
            txtSubgrp.Text = row.Cells[2].Value.ToString();
            txtUom.Text = row.Cells[3].Value.ToString();
            txtQuantity.Text = row.Cells[4].Value.ToString();
            txtRate.Text = row.Cells[5].Value.ToString();
            txtAmount.Text = row.Cells[6].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            index = dgv1.CurrentCell.RowIndex;
            dgv1.Rows.RemoveAt(index);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaction g = new Transaction();
            g.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void txtRate_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            double amt;

            if (txtRate.Text == String.Empty)
            {
                amt = 0;

            }
            else if (txtQuantity.Text == String.Empty)
            {
                amt = 0;
            }

            else
            {

                amt = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQuantity.Text);

            }
            txtAmount.Text = amt.ToString();
           
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
      
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged_1(object sender, EventArgs e)
        {
            double amt;

            if (txtQuantity.Text == String.Empty)
            {
                amt = 0;

            }
            else if (txtRate.Text == String.Empty)
            {
                amt = 0;
            }
            else {

                amt = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQuantity.Text);

            }
            txtAmount.Text = amt.ToString();
        }

        private void txtUom_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           
            Con.Open();
            for (int i=0;i<dgv1.Rows.Count-1;i++) {
            String que1 = "insert into grn_table values('" + txtGrnsrl.Text + "','" +dgv1.Rows[i].Cells[0].Value.ToString() + "','" + dgv1.Rows[i].Cells[1].Value.ToString() + "','" + dgv1.Rows[i].Cells[2].Value.ToString() + "','" + dgv1.Rows[i].Cells[3].Value.ToString() + "','" + dgv1.Rows[i].Cells[4].Value.ToString() + "','" + dgv1.Rows[i].Cells[5].Value.ToString() + "','" + dgv1.Rows[i].Cells[6].Value.ToString() + "')";
            SqlCommand cmd = new SqlCommand(que1, Con);
            cmd.ExecuteNonQuery();
               }
            String que2 = "insert into grn_supplier_table values('" + txtGrnsrl.Text+ "','" + textBox2.Text+ "','" +textBox3.Text+ "','" +dateTimePicker1.Text+ "')";
            SqlCommand cmd2 = new SqlCommand(que2, Con);
            cmd2.ExecuteNonQuery();

            for (int i = 0; i < dgv1.Rows.Count - 1; i++)
            {
                String a, b, c, d,f;
                String a1 = "select reorder_level from stock_table where item_code='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                String b1 = "select item_ctrl_srl from stock_table where item_code='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                String c1 = "select defaultwarehouse from stock_table where item_code='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                String d1 = "select status from stock_table where item_code='" + dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                String f1 = "select item_group from stock_table where item_code='"+ dgv1.Rows[i].Cells[0].Value.ToString() + "'";
                SqlCommand cmda1 = new SqlCommand(a1, Con);
                

                a = cmda1.ExecuteScalar().ToString();

                SqlCommand cmdb1 = new SqlCommand(b1, Con);


                b = cmdb1.ExecuteScalar().ToString();

                SqlCommand cmdc1 = new SqlCommand(c1, Con);


                c = cmdc1.ExecuteScalar().ToString();

                SqlCommand cmdd1 = new SqlCommand(d1, Con);


                d = cmdd1.ExecuteScalar().ToString();

                SqlCommand cmdf1 = new SqlCommand(f1, Con);

                f = cmdf1.ExecuteScalar().ToString();

                String que3 = "insert into stock_table values('" + txtGrnsrl.Text + "','" + dgv1.Rows[i].Cells[0].Value.ToString() + "','"+f+"','" + dgv1.Rows[i].Cells[1].Value.ToString() + "','" + dgv1.Rows[i].Cells[2].Value.ToString() + "','" + dgv1.Rows[i].Cells[3].Value.ToString() + "','" + dgv1.Rows[i].Cells[4].Value.ToString() + "','"+a+"','"+b+"','" + dgv1.Rows[i].Cells[5].Value.ToString() + "','" + c + "','" + d + "')";
                SqlCommand cmd3 = new SqlCommand(que3, Con);
                cmd3.ExecuteNonQuery();
            }

            MessageBox.Show("Record Added Successfully");


            Con.Close();
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Con.Open();
            String sql1="select description,item_sub_group,uom from stock_table where item_code='"+comboItem.Text+"'";
            SqlCommand cmd1 = new SqlCommand(sql1, Con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da1.Fill(dt);

            
            foreach (DataRow dr in dt.Rows)
            {
                txtDes.Text=(dr["description"].ToString());
                txtSubgrp.Text = (dr["item_sub_group"].ToString());
                txtUom.Text = (dr["uom"].ToString());
            }

            Con.Close();
            
        }

        private void txtGrnsrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void txtDes_TextChanged(object sender, EventArgs e)
        {
           /*
               Con.Open();
                String sql1 = "select item_code,item_sub_group,uom from stock_table where description='" + txtDes.Text + "'";
                SqlCommand cmd1 = new SqlCommand(sql1, Con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                da1.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    comboItem.Text = (dr["item_code"].ToString());
                    txtSubgrp.Text = (dr["item_sub_group"].ToString());
                    txtUom.Text = (dr["uom"].ToString());
                }
            
              Con.Close();
                 
            */
        }

        private void comboItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDes_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

  
    }
}
