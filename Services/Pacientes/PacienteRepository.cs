using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using practica1.Data;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Pacientes
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HospitalContext _context;
        public PacienteRepository(HospitalContext context)
        {
            _context = context;
        }
        public void AddPaciente(PacienteDto pacienteDto)
        {
            try 
            {
                var paciente = new Paciente
                {
                    Nombre = pacienteDto.Nombre,
                    Apellidos = pacienteDto.Apellidos,
                    FechaNacimiento = pacienteDto.FechaNacimiento,
                    Correo = pacienteDto.Correo,
                    Telefono = pacienteDto.Telefono,
                    Direccion = pacienteDto.Direccion,
                    Estado = "activo"
                };
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public IEnumerable<Paciente> GetAllPacientes()
        {
            var pacientes = _context.Pacientes.ToList();
            if (pacientes != null)
            {
                return pacientes;
            }
            else{
                return null;
            }
        }

        public Paciente GetPaciente(int id)
        {
            
            var paciente = _context.Pacientes.Find(id);
            if(paciente!=null)
            {
                return paciente;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<dynamic> HistorialMedicoPaciente(int id)
        {
            var paciente = _context.Pacientes
            .Where(p=>p.Id == id)
            .Include(c=>c.Citas)
            .Select(c=> new
            {
                Paciente = new
                {
                    id = c.Id,
                    nombre = c.Nombre,
                    apellido = c.Apellidos
                },
                Citas = c.Citas.Select(cita => new
                {
                    id = cita.Id,
                    medicoId =cita.MedicoId,
                    fecha =cita.Fecha,
                    estado = cita.Estado,
                    Tratamientos = cita.Tratamientos.Select(t => new{
                        id = t.Id,
                        descripcion = t.Descripcion
                    })
                })
            }).ToList();

            if(paciente != null)
            {
                return paciente;
            }
            else
            {
                return null;
            }
        }

        public void RemovePaciente(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente != null)
            {
                paciente.Estado = "inactivo";
                _context.Pacientes.Update(paciente);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro paciente");
            }
        }

        public void UpdatePaciente(int id, PacienteDto pacienteDto)
        {
            var pacienteU = _context.Pacientes.Find(id);
            if (pacienteU != null)
            {
                pacienteU.Nombre = pacienteDto.Nombre;
                pacienteU.Apellidos = pacienteDto.Apellidos;
                pacienteU.FechaNacimiento = pacienteDto.FechaNacimiento;
                pacienteU.Correo = pacienteDto.Correo;
                pacienteU.Telefono = pacienteDto.Telefono;
                pacienteU.Direccion = pacienteDto.Direccion;
                pacienteU.Estado = pacienteDto.Estado;

                _context.Pacientes.Update(pacienteU);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Paciente no encontrado");
            }
        }
    }
}
