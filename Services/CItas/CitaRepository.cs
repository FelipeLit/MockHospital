using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using practica1.Data;
using practica1.Dto;
using practica1.Models;
using practica1.Services.Emails;

namespace practica1.Services.CItas
{
    public class CitaRepository : ICitaRepository
    {
        private readonly HospitalContext _context;
        private readonly IMailService _mailService;
        public CitaRepository(HospitalContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        public async Task AddCita(CitaDto citaDto)
        {
            try 
            {
                var cita = new Cita
                {
                    Fecha = citaDto.Fecha,
                    Estado = "activo",
                    MedicoId = citaDto.MedicoId,
                    PacienteId = citaDto.PacienteId
                };
                _context.Citas.Add(cita);
               await  _context.SaveChangesAsync();

               var paciente = await _context.Pacientes.FindAsync(citaDto.PacienteId);
               if (paciente != null)
               {
                string subject = "Recordatorio de su cita medica";
                string body = $"{paciente.Nombre} su cita ha cita ha sido programada para {citaDto.Fecha}";
                await _mailService.SendEmailAsync(paciente.Correo, subject, body);
               }
               else
               {
                throw new Exception("No se encontro paciente para enviar correo");
               }
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public int CantidadCitasPorDia(DateTime fecha)
        {
            return _context.Citas.Count(c=>c.Fecha.Date == fecha.Date);
        }

        public IEnumerable<dynamic> CitasMedicoDia(DateTime fecha, int id)
        {
           var citasMedico = _context.Citas
        .Where(c => c.Medico.Id == id && c.Fecha.Date == fecha.Date)
        .Select(c => new
        {
            Medico = new
            {
                id = c.Medico.Id,
                Nombre = c.Medico.NombreCompleto
            },
            Citas = new[]
            {
                new
                {
                    id = c.Id,
                    fecha = c.Fecha,
                    estado = c.Estado,
                    pacienteId = c.PacienteId,
                    medicoId = c.MedicoId
                }
            }
        }).ToList();
            if (citasMedico != null)
            {
                return citasMedico;
            }	
            else
            {
                return null;
            }	
        }

        public string CountCitesByPacient(int id)
        {
            var paciente = _context.Pacientes.Include(p => p.Citas).FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                return "El paciente ha tenido:"+paciente.Citas.Count+" citas";
            }
            else
            {
                return "El paciente no tiene citas"; 
            }
        }

        public IEnumerable<Cita> GetAllCitas()
        {
            var citas = _context.Citas.ToList();
            if (citas != null)
            {
                return citas;
            }
            else{
                return null;
            }
        }

        public IEnumerable<Cita> GetAllCitesActive()
        {
            var citas = _context.Citas.Where(c=>c.Estado =="activo");
            if (citas!= null)
            {
                return citas;
            }
            else
            {
                return null;
            }
        }

        public Cita GetCitaById(int id)
        {
           var cita = _context.Citas.Find(id);
            if(cita!=null)
            {
                return cita;
            }
            else
            {
                return null;
            }
        }

        public void RemoveCita(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita != null)
            {
                cita.Estado = "inactivo";
                _context.Citas.Update(cita);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro cita programada");
            }
        }

        public void UpdateCita(int id, CitaDto citaDto)
        {
            var citaU = _context.Citas.Find(id);
            if (citaU != null)
            {
                citaU.Fecha = citaDto.Fecha;
                citaU.Estado = citaDto.Estado;
                citaU.MedicoId = citaDto.MedicoId;
                citaU.PacienteId = citaDto.PacienteId;
                _context.Citas.Update(citaU);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro cita para actualizar");
            }
        }
    }
}