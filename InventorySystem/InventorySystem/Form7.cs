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
    public partial class Form7 : Form
    {
       public  string val ;

    
        public string loc = "";
        public string rate = "";
        public string prod = "";

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet1.Users' Puede moverla o quitarla según sea necesario.
            this.usersTableAdapter.Fill(this.modelDataSet1.Users);

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




                string local = textBox2.Text;


                SqlConnection Cn;
                SqlCommand cmd;
                string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
                Cn = new SqlConnection(con);
                Cn.Open();
                int max2 = 0;

                SqlCommand cmd2 = new SqlCommand("SELECT MAX (id) FROM Users", Cn);
                cmd2.CommandText = "SELECT MAX (id) FROM Users";
                max2 = Convert.ToInt32(cmd2.ExecuteScalar());





                max2 = max2 + 1;

                cmd = new SqlCommand("Insert into Users(id,account,name,Password) values(" + max2 + ",'" + local + "','" + textBox1.Text + "','" + textBox3.Text + "')", Cn);
                cmd.ExecuteNonQuery();
                this.usersTableAdapter.Fill(this.modelDataSet1.Users);


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


                using (cmd = new SqlCommand("DELETE FROM Users WHERE id = " + val, Cn))
                {


                    cmd.ExecuteNonQuery();

                }
                this.usersTableAdapter.Fill(this.modelDataSet1.Users);

                Cn.Close();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

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


                using (cmd = new SqlCommand("UPDATE Users SET account ='" + textBox2.Text + "', name ='" + textBox1.Text + "', Password ='" + textBox3.Text + "' WHERE id = " + val, Cn))
                {


                    cmd.ExecuteNonQuery();

                }
                this.usersTableAdapter.Fill(this.modelDataSet1.Users);
                Cn.Close();
            }
        }
    }   
}
