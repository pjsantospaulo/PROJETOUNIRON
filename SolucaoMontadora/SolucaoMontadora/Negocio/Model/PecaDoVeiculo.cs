using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class PecaDoVeiculo
    {
        private decimal desconto;
        private int id;
        private Peca objPeca;
        private Veiculo objVeiculo;

        public Veiculo ObjVeiculo
        {
            get { return objVeiculo; }
            set { objVeiculo = value; }
        }

        public void PecaDeVeiculo(Veiculo veiculo)
        {
            objVeiculo = veiculo;
        }

        public Peca ObjPeca
        {
            get { return objPeca; }
            set { objPeca = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public decimal Desconto
        {
            get { return desconto; }
            set { desconto = value; }
        }
    }
}
