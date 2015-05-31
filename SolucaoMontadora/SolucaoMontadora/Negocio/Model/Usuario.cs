using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.Model
{
    public class Usuario
    {
        private int id;
        private string login;
        private string nome;
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
