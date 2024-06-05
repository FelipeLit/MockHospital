using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Pacientes
{
    public interface IPacienteRepository
    {
        IEnumerable<Paciente>GetAllPacientes();
        Paciente GetPaciente(int id);
        void AddPaciente(PacienteDto pacienteDto);
        void RemovePaciente(int id);
        void UpdatePaciente(int id, PacienteDto pacienteDto);
        IEnumerable<dynamic> HistorialMedicoPaciente (int id);
    }
}