using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Negocio.Model
{
    class Conexao
    {
       public static SqlConnection Conectar()
        {
            string srtConecta = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            SqlConnection con = new SqlConnection(srtConecta);
            con.Open();
            return con;
        }

        public static void CRUD(SqlCommand cmd)
        {
            SqlConnection con = Conectar();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static SqlDataReader Buscar(SqlCommand cmd)
        {
            SqlConnection con = Conectar();
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

    
    }

}
