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
    class UsuarioDAO
    {
        public void Inserir(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Usuarios(nome, login, senha)Values(@nome, @lgin, @senha)";
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            Conexao.CRUD(cmd);
        }
        public void Alterar(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Usuarios SET nome=@nome, login=@login, senha=@senha ";
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            Conexao.CRUD(cmd);
        }
        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE Usuarios WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            Conexao.CRUD(cmd);
        }
        public Usuario BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Usuarios WHERE Id =@id";
            SqlDataReader dr = Conexao.Buscar(cmd);
            Usuario objUsuario = new Usuario();
            if (dr.HasRows)
            {
                dr.Read();
                objUsuario.Id = (int)dr["Id"];
                objUsuario.Nome = (string)dr["nome"];
                objUsuario.Login = (string)dr["login"];
                objUsuario.Senha = (string)dr["senha"];
            }
            else
            {
                objUsuario = null;
            }
            dr.Close();
            return objUsuario;
        }
        public IList<Usuario> BuscarPorUsuario(string usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Usuarios WHERE like nome = @usuario";
            cmd.Parameters.AddWithValue("@usuario","%"+usuario+"%");
            SqlDataReader dr = Conexao.Buscar(cmd);
            IList<Usuario> listaDeUsuario = new List<Usuario>();
            if (dr.HasRows)
            {
                Usuario objUsuario = new Usuario();
                objUsuario.Id = (int)dr["Id"];
                objUsuario.Nome = (string)dr["nome"];
                objUsuario.Login = (string)dr["login"];
                objUsuario.Senha = (string)dr["senha"];
                listaDeUsuario.Add(objUsuario);
            }
            else
            {
                listaDeUsuario = null;
            }
            dr.Close();
            return listaDeUsuario;
        }

    }
}
