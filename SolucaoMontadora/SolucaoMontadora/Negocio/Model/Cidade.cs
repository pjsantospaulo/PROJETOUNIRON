using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;

namespace Negocio.Model
{
    public class Cidade
    {
        private int cidadeId;
        private string nome;
        private Estado estado;

        internal Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

       

        public int CidadeId
        {
            get { return cidadeId; }
            set { cidadeId = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }



    }
}
