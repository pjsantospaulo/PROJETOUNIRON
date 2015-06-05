using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Negocio.Model;



namespace Negocio.DAO
{
    public class FornecedorDAO
    {
       

        public void Inserir(Fornecedor fornecedor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Fornecedores(nome, cpf, endereco)Values(@nome, @cpf, @endereco)";
            cmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
            cmd.Parameters.AddWithValue("@cpf", fornecedor.Cpf);
            cmd.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
            Conexao.CRUD(cmd);

        }

        public void Alterar(Fornecedor fornecedor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Fornecedores set nome=@nome, cpf=@cpf, endereco=@endereco where fornecedorID = @fornecedorID ";
            cmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
            cmd.Parameters.AddWithValue("@cpf", fornecedor.Cpf);
            cmd.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
            cmd.Parameters.AddWithValue("@fornecedorID", fornecedor.Id);
            Conexao.CRUD(cmd);

           

        }

        public void Excluir(int fornecedorID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Fornecedores WHERE fornecedorID = @fornecedorID";
            cmd.Parameters.AddWithValue("@fornecedorID", fornecedorID);
            Conexao.CRUD(cmd);

        }
        public Fornecedor BuscarPorId(int id)
        {
            Fornecedor f = new Fornecedor();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Fornecedores where fornecedorID = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Buscar(cmd);

            if (dr.HasRows)
            {
                dr.Read();
                f.Cpf = (string)dr["cpf"];
                f.Nome = (string)dr["nome"];
                f.Endereco = (string)dr["endereco"];
                f.Id = (int)dr["fornecedorID"];
            }
            else
            {
                f = null;
            }
            dr.Close();
            return f;
        }

        public Fornecedor BuscarPorCpf(string cpf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Fonecedores where cpf = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);

            SqlDataReader dr = Conexao.Buscar(cmd);
            Fornecedor f = new Fornecedor();

            if (dr.HasRows)
            {
                dr.Read();
                f.Id = (int)dr["fornecedorID"];
                f.Cpf = (string)dr["cpf"];
                f.Nome = (string)dr["nome"];
                f.Endereco = (string)dr["endereco"];

            }
            else
            {
                f = null;
            }
            dr.Close();
            return f;
        }

        public IList<Fornecedor> BuscarPorNome(string nomeF)
        {
            SqlCommand cmd = new SqlCommand();
            IList<Fornecedor> fornecedores = new List<Fornecedor>();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Fornecedores WHERE nome like  @nomeF";
            cmd.Parameters.AddWithValue("@nomeF", "%" + nomeF + "%");

           
            SqlDataReader dr = Conexao.Buscar(cmd);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Fornecedor f =new Fornecedor();
                    f.Id = (int)dr["fornecedorID"];
                    f.Cpf = (string)dr["cpf"];
                    f.Nome = (string)dr["nome"];
                    f.Endereco = (string)dr["endereco"];
                    fornecedores.Add(f);
                }
            }
            else
            {
                fornecedores = null;
            }
            dr.Close();
            return fornecedores;
        }
      


    }
}
