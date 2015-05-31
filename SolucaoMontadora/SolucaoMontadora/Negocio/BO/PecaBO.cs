using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;

namespace Negocio.BO
{
    class PecaBO
    {
        PecaDAO pDAO = new PecaDAO();
        public bool VerificaFornecedorPeca(Fornecedor fornecedor)
        {
            return pDAO.VerificaFornecedorPeca(fornecedor);
        }
        public void Gravar(Peca objPeca)
        {
            if(!String.IsNullOrEmpty(objPeca.NumeroSerie))
            {
                if (objPeca.Id!=0)
                {
                    pDAO.Alterar(objPeca);
                }
                else
                {
                    pDAO.Inserir(objPeca);
                }
            }
        }
        public void Excluir(Peca objPeca)
        {
            PecaDoVeiculBO pdvBO = new PecaDoVeiculBO();
            if (pdvBO.VerificaPecaVeiculo(objPeca))
            {
                pDAO.Excluir(objPeca.Id);
            }
            else
            {
                throw new Exception("A peça está em uma montagem");
            }
        }
        public Peca BuscarPorId(Peca objPeca)
        {
            return pDAO.BuscarPorId(objPeca.Id);
        }
    }
}
