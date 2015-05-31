using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.DAO;
using Negocio.Model;


namespace Negocio.BO
{
    public class VeiculoBO
    {
        VeiculoDAO vDAO = new VeiculoDAO();
        public bool VerificaUsuarioVeiculo(Usuario objUsuario)
        {
            return vDAO.VerificaUsuarioVeiculo(objUsuario);
        }
        public void Gravar(Veiculo objVeiculo)
        {
            if (String.IsNullOrEmpty(objVeiculo.Categoria))
                throw new Exception("O campo Categoria é Obrigatorio");
            if (String.IsNullOrEmpty(objVeiculo.Marca))
                throw new Exception("O Campo Marca é Obrigatorio");
            if (String.IsNullOrEmpty(objVeiculo.Modelo))
                throw new Exception("O Campo Modelo é obrigatorio");
            if (objVeiculo.Id !=0)
            {
                vDAO.Alterar(objVeiculo);
            }
            else
            {
                vDAO.Inserir(objVeiculo);
            }
        }
    }
}
