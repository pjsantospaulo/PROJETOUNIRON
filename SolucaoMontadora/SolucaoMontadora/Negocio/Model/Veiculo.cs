using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Veiculo
    {
        private string categoria;
        private string marca;
        private string modelo;
        private int id;
        private Cliente objCliente; //1
        private Montador objMontador;//1
        private Usuario objUsuario;//1
        private IList<PecaDoVeiculo> listaPecas = new List<PecaDoVeiculo>();//1-*

        public IList<PecaDoVeiculo> ListaPecas
        {
            get { return listaPecas; }
            set { listaPecas = value; }
        }

        public Usuario ObjUsuario
        {
            get { return objUsuario; }
            set { objUsuario = value; }
        }

        public Montador ObjMontador
        {
            get { return objMontador; }
            set { objMontador = value; }
        }

        public Cliente ObjCliente
        {
            get { return objCliente; }
            set { objCliente = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
    }
}
