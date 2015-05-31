using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Montador:Pessoa
    {
        //veiculo 0-*
        private decimal salario;
        private int id;

        public int Id1
        {
            get { return id; }
            set { id = value; }
        }

        public decimal Salario
        {
            get { return salario; }
            set { salario = value; }
        }
    }
}
