
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mylibrary
{
    public class Class1
    {
        public static DataSet Excecute (string cmd)
        {
            SqlConnection Cn;
           
            string con = "Data Source=DESKTOP-6LB2A6A\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Cn = new SqlConnection(con);
            Cn.Open();
            DataSet Ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(cmd, Cn);
            Cn.Close();

            return Ds; 

        }
    }
}
