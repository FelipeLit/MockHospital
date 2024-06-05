using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Especialidades
{
    public interface IEspecialidadRepository
    {
        IEnumerable<Especialidad>GetEspecialidades();
        Especialidad GetEspecialidad(int id);
        void AddEspecialidad(EspecialidadDto especialidadDto);
        void UpdateEspecialidad(int id, EspecialidadDto especialidadDto);
        void DeleteEspecialidad(int id);
    }
}