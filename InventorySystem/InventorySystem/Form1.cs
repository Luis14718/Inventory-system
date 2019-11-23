using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mylibrary;
using System.Data.SqlClient;
using System.Diagnostics;

namespace InventorySystem
{








    public partial class Form1 : Form
    {  
        String OrderDetails = "{0, -20} {1,-20} {2, -20} {3, -20} {4, -20} {5, -20} {6, -20}";
        public Form1()
        {  /* try
            {
                string id = "781";

                string Product = "Apple ";
                string price = "2.36";
                string company = "colonia ";
                string dateentry = "2018-05-03";

                SqlConnection Cn;
                SqlCommand cmd; 
                string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
                Cn = new SqlConnection(con);
                Cn.Open();
                MessageBox.Show("Conexion completed ");
                cmd= new SqlCommand("Insert into Products(id,Product,Price,Company,Dateentry) values("+id+",'"+Product+"','"+price+"','"+company+"','"+dateentry+"')",Cn);
                cmd.ExecuteNonQuery();

            }
            catch(Exception error)  {
                MessageBox.Show("There was an error "+error);
            }
            */



            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox3.Text="select one object";


            dealer.Text = "hello";
            listBox1.Items.Clear();
            listBox1.Items.Add(String.Format(OrderDetails, "Customer ID", "Firstname", "Surname", "Order Made", "Payment", "Date Ordered", "Price"));
            comboBox1.Text = "Select Order";
            comboBox2.Text = "Select Type";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox3.Text=" Select an option ";
            
           
            dealer.Text=" Select an Item";

            comboBox1.Text = "Select Order";
            comboBox2.Text = "Select Type";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dealer.Text == "" || textBox2.Text == "" || comboBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("fill all the areas");
            }
            else
            {
                int count = Decimal.ToInt32(numericUpDown1.Value);
                int i = 1;

                for (i = 0; i < count; i++)
                {
            
                    
                    try
                    {
                        String ID, Firstname, Surname, SelectOrder, SelectType, SelectDate, Price;
                        ID = textBox2.Text;
                  Firstname = textBox1.Text;
                  Surname = comboBox3.Text;
                  SelectOrder = comboBox2.Text;
                  SelectType = comboBox1.Text;
                  SelectDate = dateTimePicker1.Text;
                  Price = textBox4.Text;
                        string id = textBox2.Text;

                        string Product = comboBox3.Text;
                        string price = textBox4.Text;
                        string company = dealer.Text;
                        string dateentry = dateTimePicker1.Text;

                        SqlConnection Cn;
                        SqlCommand cmd;
                        string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";
                        Cn = new SqlConnection(con);
                        Cn.Open();
                        
                        cmd = new SqlCommand("Insert into Products(id,Product,Price,Company,Dateentry) values(" + id + ",'" + Product + "','" + price + "','" + company + "','" + dateentry + "')", Cn);
                        cmd.ExecuteNonQuery();

                        listBox1.Items.Add(String.Format(OrderDetails, ID, Firstname, Surname, SelectOrder, SelectType, SelectDate, Price));

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("There was an error " + error);
                    }

                }
            }
          
               
                 
            




               
           

                 
                

                   
        
            }
 

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void Loadcombox2()
        {
            SqlConnection Cn;
            string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";


            using (Cn = new SqlConnection(con))
            {
                try
                {
                    string query = "SElECT id, local FROM Dealers ORDER BY local";
                    SqlDataAdapter da = new SqlDataAdapter(query, Cn);
                    Cn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "model");
                   dealer.DisplayMember = "local";
                    dealer.ValueMember = "id";

                    dealer.DataSource = ds.Tables["model"];
                    Cn.Close();
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!" + ex);
                }
            }
        }
        private void Loadcombox1() {
            SqlConnection Cn;
            string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True";


            using (Cn = new SqlConnection(con))
            {
                try
                {
                    string query = "SElECT id, Product FROM Catalogue ORDER BY Product";
                    SqlDataAdapter da = new SqlDataAdapter(query, Cn);
                    Cn.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "model");
                    comboBox3.DisplayMember = "Product";
                    comboBox3.ValueMember = "id";

                    comboBox3.DataSource = ds.Tables["model"];
                    Cn.Close();
                }
                catch (Exception ex)
                {
                    // write exception info to log or anything else
                    MessageBox.Show("Error occured!" + ex);
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'modelDataSet.Catalogue' Puede moverla o quitarla según sea necesario.
         
            listBox1.Items.Add(String.Format(OrderDetails, "Product ID", "Administrator", "Product","Order Made", "Payment", "Date Ordered", "Price"));
            
            comboBox2.Items.Add("Select Order");
            comboBox2.Items.Add("Account");
            comboBox2.Items.Add("Telephone");
            comboBox2.Items.Add("Online Order");
            comboBox2.Items.Add("Instore Order");

            comboBox1.Items.Add("Select Type");
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Master Card");
            comboBox1.Items.Add("Visa Card");
            comboBox1.Items.Add("Debit Card");
            Loadcombox1();
            Loadcombox2();

           







        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void IstBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

           





    }

        private void button1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            String p = "insert into Products(id,Products)values('" + textBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "')";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        { 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
               DataRowView drv = comboBox3.SelectedItem as DataRowView;

                Debug.WriteLine("Item: " + drv.Row["Product"].ToString());
                Debug.WriteLine("Value: " + drv.Row["id"].ToString());
                Debug.WriteLine("Value: " + comboBox3.SelectedValue.ToString());
                textBox2.Text = drv.Row["id"].ToString();
            }
        }
    }
    }

