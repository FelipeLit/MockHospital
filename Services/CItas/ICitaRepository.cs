using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.CItas
{
    public interface ICitaRepository
    {
        IEnumerable<Cita>GetAllCitas();
        IEnumerable<Cita>GetAllCitesActive();
        Cita GetCitaById(int id);
        Task AddCita(CitaDto citaDto);
        void RemoveCita(int id);
        void UpdateCita(int id, CitaDto citaDto);
        string CountCitesByPacient(int id);
        int CantidadCitasPorDia (DateTime fecha);
        IEnumerable<dynamic>CitasMedicoDia(DateTime fecha, int id);
    }
}