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
    public partial class Form5 : Form
    {
        public string val = "";
        public string prod = "";
        public string loc = "";
        public string rate = "";
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        { 
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet1.Dealers' Puede moverla o quitarla según sea necesario.
            this.dealersTableAdapter.Fill(this.modelDataSet1.Dealers);

        }

        private void button1_Click(object sender, EventArgs e)
        {




            try
            {




                string local = textBox2.Text;


                SqlConnection Cn;
                SqlCommand cmd;
                string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
                Cn = new SqlConnection(con);
                Cn.Open();
                int max2 = 0;

                SqlCommand cmd2 = new SqlCommand("SELECT MAX (id) FROM Dealers", Cn);
                cmd2.CommandText = "SELECT MAX (id) FROM Dealers";
                max2 = Convert.ToInt32(cmd2.ExecuteScalar());





                max2 = max2 + 1;

                cmd = new SqlCommand("Insert into Dealers(id,local,location,rating) values(" + max2 + ",'" + local + "','" + textBox1.Text + "','" + textBox3.Text + "')", Cn);
                cmd.ExecuteNonQuery();
                this.dealersTableAdapter.Fill(this.modelDataSet1.Dealers);


                Cn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(" There was a problem  " + error);
            }




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


                using (cmd = new SqlCommand("UPDATE Dealers SET local ='" + textBox2.Text + "', location ='"+textBox1.Text+ "', Rating ='"+textBox3.Text+"' WHERE id = " + val, Cn))
                {


                    cmd.ExecuteNonQuery();

                }
                this.dealersTableAdapter.Fill(this.modelDataSet1.Dealers);
                Cn.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());

            if (!(dataGridView1.CurrentRow.Index > -1))
            {
                return;
            }

            //obtienes la fila seleccionada

            val = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            prod = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            loc = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            rate = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = prod;
            textBox1.Text = loc;
            textBox3.Text = rate;

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


                using (cmd = new SqlCommand("DELETE FROM Dealers WHERE id = " + val, Cn))
                {


                    cmd.ExecuteNonQuery();

                }
                this.dealersTableAdapter.Fill(this.modelDataSet1.Dealers);
                Cn.Close();
            }
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

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
