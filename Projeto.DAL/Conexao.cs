using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL
{
    public class Conexao
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["aula"].ConnectionString);
            con.Open();
        }

        protected void CloseConnection()
        {
            con.Close();
        }
    }
}
