using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using practica1.Data;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Medicos
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HospitalContext _context;
        public MedicoRepository(HospitalContext context)
        {
            _context = context;
        }
        public void AddMedico(MedicoDto medicoDto)
        {
            try
            {
                var medico = new Medico
                {
                    NombreCompleto = medicoDto.NombreCompleto,
                    Correo = medicoDto.Correo,
                    Telefono = medicoDto.Telefono,
                    Estado = "activo",
                    EspecialidadId = medicoDto.EspecialidadId
                };
                _context.Medicos.Add(medico);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Medico> GetAllMedicos()
        {
            var medicos = _context.Medicos.ToList();
            if (medicos != null)
            {
                return medicos;
            }
            else{
                return null;
            }
        }

        public Medico GetMedicoById(int id)
        {
            var medico = _context.Medicos.Find(id);
            if (medico!= null)
            {
                return medico;
            }
            else{
                return null;
            }
        }

       public IEnumerable<dynamic> PacientesDeUnMedico(int id)
        {
            var pacientesDeUnMedico = _context.Citas
                .Where(m=>m.MedicoId == id)
                .Include(c=>c.Paciente)
                .GroupBy(m=>m.Medico)
                .Select(c => new
                {
                    Medico = new
                    {
                        id = c.Key.Id,
                        nombre = c.Key.NombreCompleto
                    },
                    Paciente = c.Select(p=> new
                    {
                        id = p.Paciente.Id,
                        nombre = p.Paciente.Nombre,
                        apellidos = p.Paciente.Apellidos,
                        fechaNacimiento = p.Paciente.FechaNacimiento,
                        correo = p.Paciente.Correo,
                        telefono = p.Paciente.Telefono,
                        direccion = p.Paciente.Direccion,
                    })
                    
                }).ToList();
                  if (pacientesDeUnMedico != null) 
                  {
                    return pacientesDeUnMedico;
                  }     
                else
                {
                    return null;
                }
            
        }
        public void RemoveMedico(int id)
        {
            var medico = _context.Medicos.Find(id);
            if (medico != null)
            {
                medico.Estado = "inactivo";
                _context.Medicos.Update(medico);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro medico");
            }
        }

        public void UpdateMedico(int id, MedicoDto medicoDto)
        {
            var medicoU = _context.Medicos.Find(id);
            if (medicoU!= null)
            {
                medicoU.NombreCompleto = medicoDto.NombreCompleto;
                medicoU.Correo = medicoDto.Correo;
                medicoU.Telefono = medicoDto.Telefono;
                medicoU.Estado = medicoDto.Estado;
                medicoU.EspecialidadId = medicoDto.EspecialidadId;
                _context.Medicos.Update(medicoU);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro medico");
            }

        }
    }
}