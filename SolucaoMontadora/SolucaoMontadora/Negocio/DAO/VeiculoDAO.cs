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
    class VeiculoDAO
    {
        public void Inserir(Veiculo veiculo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Veiculos(clienteID, montadorID, categoria, marca modelo, usuarioID)Values(@clienteID, @montadorID, @categoria, @marca, @modelo, @usuarioID)";
            cmd.Parameters.AddWithValue("@clienteID", veiculo.ObjCliente.Id);
            cmd.Parameters.AddWithValue("@montadorID", veiculo.ObjMontador.Id);
            cmd.Parameters.AddWithValue("@categoria", veiculo.Categoria);
            cmd.Parameters.AddWithValue("@marca", veiculo.Marca);
            cmd.Parameters.AddWithValue("@modelo", veiculo.Modelo);
            cmd.Parameters.AddWithValue("@usuarioID", veiculo.ObjUsuario.Id);
            Conexao.CRUD(cmd);
        }
        public void Alterar(Veiculo veiculo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Veiculos SET clienteID=@clienteID, montadorID=@montadorID, categoria=@categoria, marca=@marca, modelo=@modelo, usuarioID=@usuarioID";
            cmd.Parameters.AddWithValue("@clienteID", veiculo.ObjCliente.Id);
            cmd.Parameters.AddWithValue("@montadorID", veiculo.ObjMontador.Id);
            cmd.Parameters.AddWithValue("@categoria", veiculo.Categoria);
            cmd.Parameters.AddWithValue("@marca", veiculo.Marca);
            cmd.Parameters.AddWithValue("@modelo", veiculo.Modelo);
            cmd.Parameters.AddWithValue("@usuarioID", veiculo.ObjUsuario);
            Conexao.CRUD(cmd);

        }
        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE Veiculos WHERE veiculoID=@id";
            cmd.Parameters.AddWithValue("@id", id);
            Conexao.CRUD(cmd);
        }
        public Veiculo BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Veiculos WHERE veiculoID= @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Buscar(cmd);
            Veiculo objVeiculo = new Veiculo();
            ClienteDAO objClienteDAO = new ClienteDAO();
            MontadorDAO objMontadorDAO = new MontadorDAO();
            UsuarioDAO objUsuarioDAO = new UsuarioDAO();
            if (dr.HasRows)
            {
                dr.Read();
                objVeiculo.Id = (int)dr["veiculoID"];
                objVeiculo.Marca = (string)dr["marca"];
                objVeiculo.Modelo = (string)dr["modelo"];
                objVeiculo.Categoria = (string)dr["categoria"];
                objVeiculo.ObjCliente = objClienteDAO.BuscarPorId((int)dr["clienteID"]);
                objVeiculo.ObjMontador = objMontadorDAO.BuscarPorId((int)dr["montadorID"]);
                objVeiculo.ObjUsuario = objUsuarioDAO.BuscarPorId((int)dr["usuarioID"]);

            }
            else
            {
                objVeiculo = null;
            }
            dr.Close();
            return objVeiculo;
        }
        public bool VerificaUsuarioVeiculo(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT fornecedorID FROM Veiculos WHERE usuarioID = @usuarioID";
            cmd.Parameters.AddWithValue("@usuarioID", usuario.Id);

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
