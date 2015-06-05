using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;


namespace Negocio.BO
{
    public class ClienteBO
    {
        ClienteDAO cDAO = new ClienteDAO();
  

        public void Gravar(Cliente objCliente)
        {
            if (String.IsNullOrEmpty(objCliente.Cpf))
                 throw new Exception("O campo CPF não pode estar Vazio!");
            if (String.IsNullOrEmpty(objCliente.Nome))
                throw  new Exception("O Campo nome deve ser preenchido!");
            if (String.IsNullOrEmpty(objCliente.Endereco)) 
                throw new Exception("O Campo Endereço deve Ser preenchido!");

            if (objCliente.Id!= 0)
            {
                cDAO.Alterar(objCliente);
            }
            else
            {
                cDAO.Inserir(objCliente);
            }

        }
        public void Excluir(Cliente objCliente)
        {
            cDAO.Excluir(objCliente.Id);
        }
        public Cidade BuscaCidade(int id)
        {
            return new CidadeBO().BuscarPorId(id);
        }
        public Cliente BuscarPorid(int id)
        {
           return cDAO.BuscarPorId(id);
        }
        public Cliente BuscarPorCpf(Cliente objCliente)
        {
            return cDAO.BuscarPorCpf(objCliente.Cpf);
        }
        public IList<Cliente> BuscarPorNome(string nome)
        {
            IList<Cliente> listaDeCliente = new List<Cliente>();

            return cDAO.BuscarPorNome(nome);
        }

       
    }
}
