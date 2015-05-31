using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;

namespace Negocio.BO
{
    public class CidadeBO
    {
        public IList<Cidade> BuscarCidades(int id)
        {
            IList<Cidade> listaDeCidade = new List<Cidade>();
            CidadeDAO cDAO = new CidadeDAO();
            listaDeCidade = cDAO.BuscaCidadeUf(id);
            return listaDeCidade;
        }
        public Cidade BuscarPorId(int id)
        {
            return new CidadeDAO().BuscarPorId(id);
        }
        

    }
}
