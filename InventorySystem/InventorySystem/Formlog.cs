using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem
{
    public partial class Formlog : Form8
    {
        public Formlog()
        {
            InitializeComponent();

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection Cn = new SqlConnection("Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True");
                Cn.Open();
                string CMD = string.Format("SELECT * FROM Users WHERE account='{0}' AND Password='{1}'", txtNameAcc.Text.Trim(), txtPass.Text.Trim());
                DataSet Ds = new DataSet();
                SqlDataAdapter Da = new SqlDataAdapter(CMD, Cn);
                Da.Fill(Ds);


                string account = Ds.Tables[0].Rows[0]["account"].ToString().Trim();
                string passw = Ds.Tables[0].Rows[0]["Password"].ToString().Trim();

                if (account == txtNameAcc.Text.Trim() && passw == txtPass.Text.Trim())
                {
                    MessageBox.Show("Your loggin was successful");
                    Cn.Close();

                    Form4 fr = new Form4();
                    fr.Show();
                    this.Hide();

                }
            }

            catch(Exception  )
            {

                MessageBox.Show("id or password incorrect");
            }
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNameAcc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
