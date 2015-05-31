using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Paciente
    {
        int pacienteID;

        public int PacienteID
        {
            get { return pacienteID; }
            set { pacienteID = value; }
        }
        string nome;

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
        int tipoConvenio;

        public int TipoConvenio
        {
            get { return tipoConvenio; }
            set { tipoConvenio = value; }
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
