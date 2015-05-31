using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Negocio.DAO;
using Negocio.Model;

namespace Negocio.DAO
{
    class CidadeDAO
    {
        public IList<Cidade> BuscaCidadeUf(int id)
        {
           
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Cidades WHERE estado=@id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = Conexao.Buscar(cmd);
            IList<Cidade> listaDeCidade = new List<Cidade>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade c = new Cidade();
                    c.CidadeId = (int)dr["cidadeId"];
                    c.Nome = (string)dr["nome"];
                    c.Estado = (Estado)Enum.Parse(typeof(Estado), dr["estado"].ToString());
                    listaDeCidade.Add(c);

                }
            }
            else
            {
                listaDeCidade = null;
            }
            dr.Close();
            return listaDeCidade;

        }
        public Cidade BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Cidades WHERE estado=@id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = Conexao.Buscar(cmd);
            Cidade objCidade = new Cidade();
          
            if (dr.HasRows)
            {
                dr.Read();
                objCidade.CidadeId = (int)dr["cidadeId"];
                objCidade.Nome = (string)dr["nome"];
            }
            else
            {
                objCidade = null;
            }
            dr.Close();
            return objCidade;
        }
        public  IList<Cidade> BuscarPorCidade(string cidade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM WHERE nome=@nome";
            cmd.Parameters.AddWithValue("@nome", cidade);
            SqlDataReader dr = Conexao.Buscar(cmd);
            IList<Cidade> listaDeCidade = new List<Cidade>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade c = new Cidade();
                    c.CidadeId = (int)dr["cidadeId"];
                    c.Nome = (string)dr["nome"];
                    c.Estado = (Estado)Enum.Parse(typeof(Estado), dr["estado"].ToString());
                    listaDeCidade.Add(c);

                }
            }
            else
            {
                listaDeCidade = null;
            }
            dr.Close();
            return listaDeCidade;



        }
    }
}
