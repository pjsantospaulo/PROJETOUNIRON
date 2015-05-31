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
    class PecaDoVeiculoDAO
    {
        public void Inserir(PecaDoVeiculo pVeiculo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO PecasVeiculo(veiculoID, pecaID, desconto)Values (@veiculoID, @pecaID, @desconto)";
            cmd.Parameters.AddWithValue("@veiculoID", pVeiculo.ObjVeiculo.Id);
            cmd.Parameters.AddWithValue("@pecaID", pVeiculo.ObjPeca.Id);
            cmd.Parameters.AddWithValue("@desconto", pVeiculo.Desconto);
            Conexao.CRUD(cmd);
        }
        public void Alterar(PecaDoVeiculo pVeiculo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE PecasVeiculo SET veiculoID=@veiculoID, pecaID=@pecaID, descricao=@descricao ";
            cmd.Parameters.AddWithValue("@veiculoID", pVeiculo.ObjVeiculo.Id);
            cmd.Parameters.AddWithValue("@pecaID",pVeiculo.ObjPeca.Id);
            cmd.Parameters.AddWithValue("@descricao", pVeiculo.Desconto);
            Conexao.CRUD(cmd);

        }
        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE PecasVeiculo WHERE pecaVeiculoID=@id";
            cmd.Parameters.AddWithValue("@id", id);
            Conexao.CRUD(cmd);

        }
        public PecaDoVeiculo BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PecasVeiculo WHERE pecaVeiculoID = @id";
            cmd.Parameters.AddWithValue("@id",id);

            SqlDataReader dr = Conexao.Buscar(cmd);
            PecaDoVeiculo objPecaVeiculo = new PecaDoVeiculo();
            PecaDAO objPecaDAO = new PecaDAO();

           
            
            if (dr.HasRows)
            {
                dr.Read();
                objPecaVeiculo.Id = (int)dr["pecaVeiculoID"];
                objPecaVeiculo.ObjPeca = objPecaDAO.BuscarPorId((int)dr["pecaID"]);

               
                objPecaVeiculo.Desconto = Convert.ToDecimal(dr["desconto"]);
                
            }
            else
            {
                objPecaVeiculo = null;
            }
            dr.Close();
            return objPecaVeiculo;
        }
        public bool VerificaPecaVeiculo(Peca peca)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT pecaID FROM PecasVeiculo WHERE pecaID = @pecaID";
            cmd.Parameters.AddWithValue("@pecaID", peca.Id);

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
