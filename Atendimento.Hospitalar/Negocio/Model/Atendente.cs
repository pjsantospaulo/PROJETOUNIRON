using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    class Atendente
    {
        int atendenteId;


        public int AtendenteId
        {
            get { return atendenteId; }
            set { atendenteId = value; }
        }string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

    }
}
