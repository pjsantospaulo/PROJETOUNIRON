using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
   public class PlanoDeSaude
    {
        int planoID;

        public int PlanoID
        {
            get { return planoID; }
            set { planoID = value; }
        }
        string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
