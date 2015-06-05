using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Cliente : Pessoa
    {
        
        private Cidade cidade;
        private DateTime dataNascimento;
        private string endereco;
        private string numero;
        private string orgaoExpedidor;
        private string rg;
        private Sexo sexo;

        public Sexo _Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        public string OrgaoExpedidor
        {
            get { return orgaoExpedidor; }
            set { orgaoExpedidor = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
  
        public Cidade Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
    }
}
