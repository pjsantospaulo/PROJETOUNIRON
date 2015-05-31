using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Negocio.DAO
{
    class Conexao
    {
        //private static Conexao conexao = null;
        //private Conexao()
        //{

        //}
        //public static Conexao Cria
        //{
        //    get
        //    {
        //        if (conexao == null)
        //        {
        //            conexao = new Conexao();

        //        }
        //        return conexao;
        //    }
        //}

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
