using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Examen
{
    class db
    {
        SqlConnection con = new SqlConnection("Server = HOME-PC;Initial Catalog = Hotel;Integrated Security = True");


        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnection()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}




