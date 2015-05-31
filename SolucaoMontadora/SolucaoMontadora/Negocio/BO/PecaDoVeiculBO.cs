using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;

namespace Negocio.BO
{
    class PecaDoVeiculBO
    {
        /// <summary>
        /// Metodo que verifica se a peca que vai ser apagada não está em uma montagem
        /// </summary>
        PecaDoVeiculoDAO pdvDAO = new PecaDoVeiculoDAO();
        public bool VerificaPecaVeiculo(Peca objPeca)
        {
            return pdvDAO.VerificaPecaVeiculo(objPeca);
        }
        public void Gravar(PecaDoVeiculo objPecaDoVeiculo)
        {
            if (String.IsNullOrEmpty(objPecaDoVeiculo.ObjPeca.Descricao))
                throw new Exception("O Campo da descrição da peça deve ser Preenchido!!");
            if (String.IsNullOrEmpty(objPecaDoVeiculo.ObjVeiculo.Modelo))
                throw new Exception("O Campo Modelo deve ser Preenchido");
            if (objPecaDoVeiculo.Id != 0)
            {
                pdvDAO.Alterar(objPecaDoVeiculo);
            }
            else
            {
                pdvDAO.Inserir(objPecaDoVeiculo);

            }

            
        }
        public void Excluir(PecaDoVeiculo objPecado)
        {
            pdvDAO.Excluir(objPecado.Id);
        }
         
    }
}
