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
       public void Inserir(Paciente obPaciente)
       {
           SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
           cmd.CommandText = "INSERT INTO Paciente(nome, dtNascimento, tipoConveniado, planoDeSaudeId)Values(@nome, @dtNascimento, @tipo)";
       }
    }
}
