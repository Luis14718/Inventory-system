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
    public partial class Form2 : Form
    {
        public string val = "";
        public string prod = "";
        
    
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet.Catalogue' Puede moverla o quitarla según sea necesario.
            this.catalogueTableAdapter.Fill(this.modelDataSet.Catalogue);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
           

           


                try
                {
                    
                   
                    

                    string Product = textBox2.Text;
                    

                    SqlConnection Cn;
                    SqlCommand cmd;
                    string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
                    Cn = new SqlConnection(con);
                    Cn.Open();
                int max2=0;

                SqlCommand cmd2 = new SqlCommand("SELECT MAX (id) FROM Catalogue" , Cn);
                cmd2.CommandText = "SELECT MAX (id) FROM Catalogue";
                max2 = Convert.ToInt32(cmd2.ExecuteScalar());
            

                

               
                max2= max2+1;

                cmd = new SqlCommand("Insert into Catalogue(id,Product) values("+max2+",'" + Product + "')", Cn);
                    cmd.ExecuteNonQuery();
                this.catalogueTableAdapter.Fill(this.modelDataSet.Catalogue);


                Cn.Close();
            }
                catch (Exception error)
                {
                    MessageBox.Show(" There was a problem  "+error );
                }

          



        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentCell.Value.ToString());
            //si se pulsa e el header el RowIndex sera menos a menos
            if (!( dataGridView1.CurrentRow.Index > -1))
            {
                return;
            }

            //obtienes la fila seleccionada
           
           val  = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            prod = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = prod;


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
             

                using (cmd = new SqlCommand("DELETE FROM Catalogue WHERE id = " + val, Cn))
                {
                    

                    cmd.ExecuteNonQuery();

                }
                this.catalogueTableAdapter.Fill(this.modelDataSet.Catalogue);
                Cn.Close();
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


                using (cmd = new SqlCommand("UPDATE Catalogue SET Product ='" + textBox2.Text +  "' WHERE id = " + val, Cn))
                {


                    cmd.ExecuteNonQuery();

                }
                this.catalogueTableAdapter.Fill(this.modelDataSet.Catalogue);
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
    }
}
