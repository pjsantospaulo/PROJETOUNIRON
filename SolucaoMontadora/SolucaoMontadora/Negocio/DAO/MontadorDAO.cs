using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Negocio.Model;


namespace Negocio.DAO
{
    public class MontadorDAO
    {
        public void Inserir(Montador montador)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Montadores(nome, cpf, salario) Values(@nome, @cpf, @salario)";
            cmd.Parameters.AddWithValue("@nome", montador.Nome);
            cmd.Parameters.AddWithValue("@cpf", montador.Cpf);
            cmd.Parameters.AddWithValue("@salario", montador.Salario);
            Conexao.CRUD(cmd);

        }

        public void Alterar(Montador montador)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Montadores set nome=@nome, cpf=@cpf, salario=@salario WHERE montadorID=@montadorID";
            cmd.Parameters.AddWithValue("@montadorID", montador.Id);
            cmd.Parameters.AddWithValue("@nome", montador.Nome);
            cmd.Parameters.AddWithValue("@cpf", montador.Cpf);
            cmd.Parameters.AddWithValue("@salario", montador.Salario);
            Conexao.CRUD(cmd);

        }

        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE Montadores WHERE montadorID=@id";
            cmd.Parameters.AddWithValue("@id", id);
            Conexao.CRUD(cmd);
        }

        public Montador BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Montadores WHERE montadorID = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Buscar(cmd);
            Montador m = new Montador();
            if (dr.HasRows)
            {
                dr.Read();
                m.Id= (int)dr["montadorID"];
                m.Nome = (string)dr["nome"];
                m.Cpf = (string)dr["cpf"];
                m.Salario = Convert.ToDecimal(dr["salario"]);
            }
            else
            {
                m = null;
            }
            dr.Close();
            return m;
        }
        public Montador BuscarPorCpf(string cpf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Montadores WHERE montadorID = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);

            SqlDataReader dr = Conexao.Buscar(cmd);
            Montador m = new Montador();
            if (dr.HasRows)
            {
                m.Id = (int)dr["montadorID"];
                m.Nome = (string)dr["nome"];
                m.Cpf = (string)dr["cpf"];
                m.Salario = Convert.ToDecimal(dr["salario"]);
            }
            else
            {
                m = null;
            }
            dr.Close();
            return m;
        }
        public IList<Montador> BuscarPorNome(string nome)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Montadores WHERE nome like   @nome";
            cmd.Parameters.AddWithValue("@nome", "%"+nome+"%");

            SqlDataReader dr = Conexao.Buscar(cmd);
            IList<Montador> listaDeMontadores = new List<Montador>();
           
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                     Montador m = new Montador();
                     m.Id = (int)dr["montadorID"];
                     m.Nome = (string)dr["nome"];
                     m.Cpf = (string)dr["cpf"];
                     m.Salario = Convert.ToDecimal(dr["salario"]);
                     listaDeMontadores.Add(m);
                }
               
            }
            else
            {
                listaDeMontadores = null;
            }
            dr.Close();
            return listaDeMontadores;
        }
    }
}
