using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Data;


namespace ClassLibrary1
{
    public class Utilidades
    {
        public static DataSet Execute(string cmd){
            
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2KI128P;Initial Catalog=userlogin;Integrated Security=True");
                con.Open();
            
                
         
            DataSet Ds = new DataSet();
            SqlDataAdapter Dp = new  SqlDataAdapter(cmd,con);
            Dp.Fill(Ds);
        
            return Ds;

        }
    }
}
