using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using Negocio.DAO;

namespace Negocio.BO
{
    public class FornecedorBO
    {
        FornecedorDAO fDAO = new FornecedorDAO();

        public void Gravar(Fornecedor objFornecedor)
        {
            if (String.IsNullOrEmpty(objFornecedor.Cpf))
               new Exception("O Campo CPF é obrigatorio!");
            if (String.IsNullOrEmpty(objFornecedor.Nome))
                throw new Exception("O Campo Nome é Obrigatório!");
            if (String.IsNullOrEmpty(objFornecedor.Endereco))
                throw new Exception("O Campo Endereço é Obrigatório");

            if (objFornecedor.Id!=0)
            {
                fDAO.Alterar(objFornecedor);
            }
            else
            {
                fDAO.Inserir(objFornecedor);
            }
        }
        public void Apagar(Fornecedor objFornecedor)
        {
            PecaBO pBO = new PecaBO();
            if (!pBO.VerificaFornecedorPeca(objFornecedor))
            {
                fDAO.Excluir(objFornecedor.Id);
            }
            else
            {
                throw new Exception("O Fornecedor Possui Peças!");
            }
        }
        public Fornecedor BuscarPorId(int id)
        {
           return fDAO.BuscarPorId(id);
        }
        public IList<Fornecedor> BuscarPorFornecedor(string nome)
        {
            IList<Fornecedor> listaDeFornecedor = new List<Fornecedor>();

            listaDeFornecedor = fDAO.BuscarPorNome(nome);
            return listaDeFornecedor;
        }
        public Fornecedor buscarPorCpf(Fornecedor objFornecedor)
        {
            return fDAO.BuscarPorCpf(objFornecedor.Cpf);
        }
    }
}
