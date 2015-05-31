using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Negocio.Model;


namespace Negocio.DAO
{
    public class AtendenteDAO
    {
        public void Inserir(Atendente objAtendente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Atendente(nome, login, senha)Values(@nome, @login, @senha)";
            cmd.Parameters.AddWithValue("@nome", objAtendente.Nome);
            cmd.Parameters.AddWithValue("@login", objAtendente.Login);
            cmd.Parameters.AddWithValue("@senha", objAtendente.Senha);
            Conexao.CRUD(cmd);
        }
       

        internal Atendente Logar(string login, string senha)
        {
            Atendente objAtendente = new Atendente();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Atendente where login=@login and senha=@senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            SqlDataReader dr = Conexao.Buscar(cmd);

            if (dr.HasRows)
            {
                dr.Read();
                objAtendente.AtendenteId = (int)dr["atendenteId"];
                objAtendente.Nome = dr["nome"].ToString();
                objAtendente.Login = dr["login"].ToString();
            }
            else
            {
                objAtendente = null;
            }
            return objAtendente;
        }
        internal void alterar(Atendente objAtendente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Atendente SET nome=@nome Where atendenteId=@id";
            cmd.Parameters.AddWithValue("@id", objAtendente.AtendenteId);
            cmd.Parameters.AddWithValue("@nome", objAtendente.Nome);
            Conexao.CRUD(cmd);
        }
    }
}
