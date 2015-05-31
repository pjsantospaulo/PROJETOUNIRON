using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.Model
{
    public class Fornecedor:Pessoa
    {
        
        private string endereco;
        
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
    }
}
