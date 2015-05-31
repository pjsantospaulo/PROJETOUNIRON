using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using Negocio.DAO;

namespace Negocio.BO
{
    public class AtendendeBO
    {
        
        public void Gravar(Atendente objAtendente)
        {
            AtendenteDAO cDAO = new AtendenteDAO();
            if (objAtendente.AtendenteId !=0 )
            {
                cDAO.alterar(objAtendente);
            }
            else
            {
                cDAO.Inserir(objAtendente);
            }
           
            cDAO.Inserir(objAtendente);
        }
        public Atendente Logar(string login, string senha)
        {
            AtendenteDAO cDAO = new AtendenteDAO();
           return cDAO.Logar(login, senha);
        }
    }
}
