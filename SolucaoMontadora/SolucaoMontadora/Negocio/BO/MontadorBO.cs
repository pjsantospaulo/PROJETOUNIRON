using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;


namespace Negocio.BO
{
    public class MontadorBO
    {
        MontadorDAO cDAO = new MontadorDAO();
        public void Gravar(Montador objMontador)
        {
            if (String.IsNullOrEmpty(objMontador.Cpf))
                throw new Exception("O Campo CPF deve ser Preenchido!");
            if (String.IsNullOrEmpty(objMontador.Nome))
                throw new Exception("O Campo Nome deve ser preenchido!");
            if (objMontador.Id != 0)
            {
                cDAO.Alterar(objMontador);
            }
            else
            {
                cDAO.Inserir(objMontador);
            }
        }
        public void Excluir(Montador objMontador)
        {
            cDAO.Excluir(objMontador.Id);
        }
        public Montador BuscarPorId(int id)
        {
            return cDAO.BuscarPorId(id);
        }
        public IList<Montador> BuscarPorNome(String montador)
        {
            IList<Montador> listaDeMontador = new List<Montador>();
            return cDAO.BuscarPorNome(montador);
        }
        public Montador BuscarPorCpf(Montador objMontador)
        {
            return cDAO.BuscarPorCpf(objMontador.Cpf);
        }
    }
}
