﻿using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.DAO
{
    public class ClienteDAO
    {

        public void Inserir(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Clientes(nome, cpf, endereco, dtNascimento, sexo, rg, orgaoExpedidor numero, cidadeId) values(@nome, @cpf, @endereco, @dtNascimento, @sexo, @rg, @orgaoExpedidor,  @numero, @cidadeId)"; 
            
            
                ;
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@dtNascimento", cliente.DataNascimento);
            cmd.Parameters.AddWithValue("@sexo", cliente._Sexo);
            cmd.Parameters.AddWithValue("@rg", cliente.Rg);
            cmd.Parameters.AddWithValue("@cidadeId", cliente.Cidade.CidadeId);
            cmd.Parameters.AddWithValue("@numero", cliente.Numero);
           
            Conexao.CRUD(cmd);
        }
        public void Alterar(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Clientes set nome=@nome, cpf=@cpf, endereco=@endereco, dtNascimento=@dtNascimento, sexo=@sexo, rg=@rg, cidadeId=@cidadeId, numero=@numero, uf=@uf WHERE clienteID  = @clienteID";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@dtNascimento", cliente.DataNascimento);
            cmd.Parameters.AddWithValue("@sexo", cliente._Sexo);
            cmd.Parameters.AddWithValue("@rg", cliente.Rg);
            cmd.Parameters.AddWithValue("@cidadeId", cliente.Cidade.CidadeId);
            //cmd.Parameters.AddWithValue("@uf", cliente.Uf);
            Conexao.CRUD(cmd);
        }
        public void Excluir(int clienteID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Clientes WHERE clienteID = @clienteID";
            cmd.Parameters.AddWithValue("@clienteID", clienteID);
            Conexao.CRUD(cmd);
        }
        public Cliente BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Clientes WHERE clienteID = @id";

            SqlDataReader dr = Conexao.Buscar(cmd);
            Cliente c = new Cliente();
            if (dr.HasRows)
            {
                c.Id = (int)dr["clienteID"];
                c.Nome = (string)dr["nome"];
                c.Cpf = (string)dr["cpf"];
                c.Endereco = (string)dr["endereco"];
                c.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                c._Sexo = (Sexo)dr["sexo"];
                c.Rg = (string)dr["rg"];
                c.Cidade = (Cidade)dr["cidade"];
                c.OrgaoExpedidor = (string)dr["orgaoExpedidor"];
                c.Numero = (string)dr["numero"];
               // c.Uf = (Estado)dr["uf"];
            }
            else
            {
                c = null;
            }
            dr.Close();
            return c;

        }
        public Cliente BuscarPorCpf(string cpf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Clientes WHERE cpf = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);

            SqlDataReader dr = Conexao.Buscar(cmd);
            Cliente c = new Cliente();
            if (dr.HasRows)
            {
                c.Id = (int)dr["clienteID"];
                c.Nome = (string)dr["nome"];
                c.Cpf = (string)dr["cpf"];
                c.Endereco = (string)dr["endereco"];
                c.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                c._Sexo = (Sexo)dr["sexo"];
                c.Rg = (string)dr["rg"];
                c.Cidade = (Cidade)dr["cidade"];
                c.OrgaoExpedidor = (string)dr["orgaoExpedidor"];
                c.Numero = (string)dr["numero"];
               // c.Uf = (Estado)dr["estado"];
            }
            else
            {
                c = null;
            }
            dr.Close();
            return c;
        }
    
        public IList<Cliente> BuscarPorNome(string nome)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Clientes WHERE nome like @nome";
            cmd.Parameters.AddWithValue("@nome","%"+nome+"%");

            SqlDataReader dr = Conexao.Buscar(cmd);
            IList<Cliente> listaDeClientes = new List<Cliente>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                     Cliente c = new Cliente();
                     c.Id = (int)dr["clienteID"];
                     c.Nome = (string)dr["nome"];
                     c.Cpf = (string)dr["cpf"];
                     c.Endereco = (string)dr["endereco"];
                     c.DataNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                     c._Sexo = (Sexo)Enum.Parse(typeof(Sexo), dr["sexo"].ToString());
                     c.Rg = (string)dr["rg"];
                     c.Cidade = (Cidade)dr["nome"];
                     c.OrgaoExpedidor = (string)dr["orgaoExpedidor"];
                     c.Numero = (string)dr["numero"];
                    // c.Uf = (Estado)Enum.Parse(typeof(Estado), dr["estado"].ToString());
                     listaDeClientes.Add(c);
                }
            }
            else
            {
                listaDeClientes = null;
            }
            dr.Close();
            return listaDeClientes;
        }

    }

}
