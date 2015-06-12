using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Paciente
    {
        private int pacienteID;

        public int PacienteID
        {
            get { return pacienteID; }
            set { pacienteID = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        DateTime dtNascimento;

        public DateTime DtNascimento
        {
            get { return dtNascimento; }
            set { dtNascimento = value; }
        }
        private TipoConveniado tipoConveniado;

        public TipoConveniado TipoConveniado
        {
            get { return tipoConveniado; }
            set { tipoConveniado = value; }
        }

       


        PlanoDeSaude objPlanoSaude;

        public PlanoDeSaude ObjPlanoSaude
        {
            get { return objPlanoSaude; }
            set { objPlanoSaude = value; }
        }
        public void PlanoDeSaude(PlanoDeSaude planoDeSaude)
        {
            ObjPlanoSaude = planoDeSaude;
        }
    }
}
