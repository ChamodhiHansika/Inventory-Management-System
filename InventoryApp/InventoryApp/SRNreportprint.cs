﻿using System;
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
    public partial class SRNreportprint : Form
    {
        public SRNreportprint()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Database\Inventory.mdf;Integrated Security=True;Connect Timeout=30");


        private void btnback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Print pri = new Print();
            pri.Show();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Print p = new Print();
            p.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SRNreportprint_Load(object sender, EventArgs e)
        {
            Con.Open();
            String que1 = "select SRN_NO as 'SRN No.',Department_Name as 'Department Name',Invoice_num as 'Invoice No.',Date as 'SRN Date' from srn_table";
            SqlDataAdapter sda = new SqlDataAdapter(que1, Con);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


            Con.Close();
        }
    }
}
