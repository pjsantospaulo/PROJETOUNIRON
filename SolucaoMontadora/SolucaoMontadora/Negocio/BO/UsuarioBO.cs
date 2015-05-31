using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;


namespace Negocio.BO
{
    public class UsuarioBO
    {
        public void Gravar(Usuario objUsuario)
        {
            UsuarioDAO uDAO = new UsuarioDAO();
            if (String.IsNullOrEmpty(objUsuario.Nome))
                throw new Exception("O Campo Nome é Ogrigatório");
            if (String.IsNullOrEmpty(objUsuario.Login))
                throw new Exception("O Campo Login é Ogrigatório!");
            if (String.IsNullOrEmpty(objUsuario.Senha))
                throw new Exception("O Campo Senha é Obrigatorio!");
            if(objUsuario.Id !=0)
            {
                uDAO.Alterar(objUsuario);
            }
            else
            {
                uDAO.Inserir(objUsuario);
            }
        }
        public void Apagar(Usuario objUsuario)
        {
            UsuarioDAO uDAO = new UsuarioDAO();
            VeiculoBO vBO = new VeiculoBO();
            if (vBO.VerificaUsuarioVeiculo(objUsuario))
            {
                uDAO.Excluir(objUsuario.Id);
            }
            else
            {
                throw new Exception("O usuário Possui Veiculo!");
            }
        }
        public Usuario BuscarPorId(Usuario objUsuario)
        {
          UsuarioDAO uDAO = new UsuarioDAO();
          return uDAO.BuscarPorId(objUsuario.Id);
        }
        public IList<Usuario> BuscarPorUsuario(Usuario objUsuario)
        {
            UsuarioDAO uDAO =new UsuarioDAO();
            IList<Usuario> listaDeUsuario = new List<Usuario>();
            listaDeUsuario = uDAO.BuscarPorUsuario(objUsuario.Nome);
            return listaDeUsuario;
        }
    }
}
