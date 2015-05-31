using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Peca
    {
       
        private DateTime dataFabricacao;
        private string numeroSerie;
        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        private int id;
        private Fornecedor objFornecedor;//1

        public Fornecedor ObjFornecedor
        {
            get { return objFornecedor; }
            set { objFornecedor = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string NumeroSerie
        {
            get { return numeroSerie; }
            set { numeroSerie = value; }
        }

        public DateTime DataFabricacao
        {
            get { return dataFabricacao; }
            set { dataFabricacao = value; }
        }
    }
}
