using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Tratamientos
{
    public interface ITratamientoRepository
    {
        IEnumerable<Tratamiento> GetAllTratamientos();
        Tratamiento GetTratamientoById(int id);
        void AddTratamiento(TratamientoDto tratamientoDto);
        void RemoveTratamiento(int id);
        void UpdateTratamiento(int id, TratamientoDto tratamientoDto);
    }
}