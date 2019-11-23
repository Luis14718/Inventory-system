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

namespace InventorySystem
{
    public partial class Form6 : Form
    {
        public string val = "";
        public string loc = "";
        public string rate = "";
        public string prod = "";
       
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet1.Products' Puede moverla o quitarla según sea necesario.
            this.productsTableAdapter.Fill(this.modelDataSet1.Products);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                DateTime now = DateTime.Today;

                string local = textBox2.Text;
                string time =now.ToString();

                SqlConnection Cn;
                SqlCommand cmd;
                string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
                Cn = new SqlConnection(con);
                Cn.Open();
                int max2 = 0;

                SqlCommand cmd2 = new SqlCommand("SELECT MAX (id) FROM Products", Cn);
                cmd2.CommandText = "SELECT MAX (id) FROM Products";
                max2 = Convert.ToInt32(cmd2.ExecuteScalar());





                max2 = max2 + 1;

                cmd = new SqlCommand("Insert into Products(id,Product,Price,Company,Dateentry) values(" + max2 + ",'" + local + "','" + textBox1.Text + "','" + textBox3.Text + "','" + time + "')", Cn);
                cmd.ExecuteNonQuery();
                this.productsTableAdapter.Fill(this.modelDataSet1.Products);


                Cn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(" There was a problem  " + error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Product = textBox2.Text;


            SqlConnection Cn;
            SqlCommand cmd;

            string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
            using (Cn = new SqlConnection(con))
            {
                Cn.Open();


                using (cmd = new SqlCommand("DELETE FROM Products WHERE id = " + val, Cn))
                {


                    cmd.ExecuteNonQuery();

                }
                this.productsTableAdapter.Fill(this.modelDataSet1.Products);

                Cn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (!(dataGridView1.CurrentRow.Index > -1))
            {
                return;
            }

            //get the row selected 

            val = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            prod = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            loc = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            rate = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = prod;
            textBox1.Text = loc;
            textBox3.Text = rate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Product = textBox2.Text;


            SqlConnection Cn;
            SqlCommand cmd;

            string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
            using (Cn = new SqlConnection(con))
            {
                Cn.Open();


                using (cmd = new SqlCommand("UPDATE Products SET Product ='" + textBox2.Text + "', Price ='" + textBox1.Text + "', Company ='" + textBox3.Text + "' WHERE id = " + val, Cn))
                {


                    cmd.ExecuteNonQuery();

                }
                this.productsTableAdapter.Fill(this.modelDataSet1.Products);
                Cn.Close();
            }
        }
    }
}
