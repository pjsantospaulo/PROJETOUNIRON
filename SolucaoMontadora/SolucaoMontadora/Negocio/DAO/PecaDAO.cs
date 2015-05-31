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
    class PecaDAO
    {
        public void Inserir(Peca peca)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Pecas(dtFabricao, numSerie, descricao)Values(@dtFabricao, @numSerie, @descricao)";
            cmd.Parameters.AddWithValue("@dtFabricao", peca.DataFabricacao);
            cmd.Parameters.AddWithValue("@numSerie", peca.NumeroSerie);
            cmd.Parameters.AddWithValue("@descricao", peca.Descricao);
            Conexao.CRUD(cmd);
        }
        public void Alterar(Peca peca)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Pecas set dtFabricacao=@dtFabricacao, numSerie=@numSerie, descricao=@descricao WHERE pecaID=@pecaID";
            cmd.Parameters.AddWithValue("@dtFabricacao", peca.DataFabricacao);
            cmd.Parameters.AddWithValue("@numSerie", peca.NumeroSerie);
            cmd.Parameters.AddWithValue("@descricao", peca.Descricao);
            cmd.Parameters.AddWithValue("@pecID", peca.Id);
            Conexao.CRUD(cmd);
        }
        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE Pecas WHERE pecaID = @";
        }
        public Peca BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Pecas WHERE pecaID=@ID";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Buscar(cmd);
            Peca objPeca = new Peca();
            FornecedorDAO fDAO = new FornecedorDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objPeca.Id = (int)dr["pecaID"];
                objPeca.DataFabricacao = Convert.ToDateTime(dr["dtFabricacao"]);
                objPeca.NumeroSerie = (string)dr["numSerie"];
                objPeca.Descricao = (string)dr["decricao"];
                objPeca.ObjFornecedor = fDAO.BuscarPorId((int)dr["fornecedorID"]);
            }
            else
            {
                objPeca = null;
            }
            dr.Close();
            return objPeca;


        }
        public bool VerificaFornecedorPeca(Fornecedor fornecedor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT fornecedorID FROM Pecas WHERE fornecedorID = @fornecedorID";
            cmd.Parameters.AddWithValue("@fornecedorID", fornecedor.Id);

            SqlDataReader dr = Conexao.Buscar(cmd);

            if (dr.HasRows)
            {
                return true;
            }
            dr.Close();
            return false;
        }
       

    }
}
