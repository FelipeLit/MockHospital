using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Medicos
{
    public interface IMedicoRepository
    {
        IEnumerable<Medico> GetAllMedicos();
        Medico GetMedicoById(int id);
        void AddMedico(MedicoDto medicoDto);
        void RemoveMedico(int id);
        void UpdateMedico(int id, MedicoDto medicoDto);
        IEnumerable<dynamic>PacientesDeUnMedico(int id);

    }
}