using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Negocio.Model;



namespace Negocio.DAO
{
    public class PacienteDAO
    {
        public void Inserir(Paciente objPaciente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Paciente(nome, dtNascimento, tipoConveniado, planoDeSaudeId)Values(@nome, @dtNascimento, @tipo, @planoDeSaudeId)";
            cmd.Parameters.AddWithValue("@nome", objPaciente.Nome);
            cmd.Parameters.AddWithValue("@dtNascimento", objPaciente.DtNascimento);
            cmd.Parameters.AddWithValue("@tipo", objPaciente. TipoConveniado);
            cmd.Parameters.AddWithValue("@planoDeSaudeId", objPaciente.ObjPlanoSaude.PlanoDeSaudeId);
            Conexao.CRUD(cmd);
        }
        public void Alterar(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Paciente SET nome=@nome, dtNascimento=@dtNascimento, tipoConveniado=@tipoConveniado, planoDeSaudeId=@planoDeSaudeId where pacienteId=@pacienteId";
            cmd.Parameters.AddWithValue("@pacienteId", paciente.PacienteID);
            cmd.Parameters.AddWithValue("@nome", paciente.Nome);
            cmd.Parameters.AddWithValue("@dtNascimento", paciente.DtNascimento);
            cmd.Parameters.AddWithValue("@tipoConveniado", paciente.TipoConveniado);
            cmd.Parameters.AddWithValue("@planoDeSaudeId", paciente.ObjPlanoSaude.PlanoDeSaudeId);
            Conexao.CRUD(cmd);
        }
        public void Excluir(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE Paciente where pacienteId = @pacienteId";
            cmd.Parameters.AddWithValue("@pacienteId", paciente.PacienteID);
            Conexao.CRUD(cmd);
        }
        public Paciente BuscarPorId(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " SELECT * FROM Paciente where pacienteId = @pacienteId";
            cmd.Parameters.AddWithValue("@pacienteId", id);
            
            SqlDataReader dr = Conexao.Buscar(cmd);
            Paciente objPaciente = new Paciente();
            if (dr.HasRows)
            {
                dr.Read();
                objPaciente.PacienteID = (int)dr["pacienteId"];
                objPaciente.Nome = dr["nome"].ToString();
                objPaciente.DtNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                objPaciente.TipoConveniado = (TipoConveniado)Enum.Parse(typeof(TipoConveniado), dr["tipoConveniado"].ToString());
                objPaciente.ObjPlanoSaude.PlanoDeSaudeId = (int)dr["planoDeSaudeId"];
            }
            else
            {
                objPaciente = null;
            }
            dr.Close();
            return objPaciente;
        }
        public IList<Paciente> BuscarPorNome(string nome)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Paciente nome like @nome";
            cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");



            SqlDataReader dr = Conexao.Buscar(cmd);
            IList<Paciente> listaDePaciente = new List<Paciente>();

            if (dr.HasRows)
            {
                Paciente p = new Paciente();
                dr.Read();

                p.PacienteID = (int)dr["pacienteId"];
                p.Nome = dr["nome"].ToString();
                p.DtNascimento = Convert.ToDateTime(dr["dtNascimento"]);
                p.TipoConveniado = (TipoConveniado)Enum.Parse(typeof(TipoConveniado),dr["tipoConveniado"].ToString());
                p.ObjPlanoSaude.PlanoDeSaudeId = (int)dr["planoDeSaudeId"];

                listaDePaciente.Add(p);
            }
            else
            {
                listaDePaciente = null;
            }
            dr.Close();
            return listaDePaciente;

        }
    }
}