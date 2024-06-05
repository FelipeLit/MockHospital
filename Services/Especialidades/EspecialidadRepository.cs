using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.Data;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Especialidades
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly HospitalContext _context;
        public EspecialidadRepository(HospitalContext context)
        {
            _context = context;
        }
        public void AddEspecialidad(EspecialidadDto especialidadDto)
        {
            try 
            {
                var especialidad = new Especialidad
                {
                    Nombre = especialidadDto.Nombre,
                    Descripcion = especialidadDto.Descripcion,
                    Estado = "activo"
                };
                _context.Especialidades.Add(especialidad);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public void DeleteEspecialidad(int id)
        {
           var especialidad = _context.Especialidades.Find(id);
           if(especialidad!=null)
           {
            especialidad.Estado = "inactivo";
            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
           }
           else
           {
            throw new Exception("Especialidad no encontrada");
           }
        }

        public Especialidad GetEspecialidad(int id)
        {
            var especialidad = _context.Especialidades.Find(id);
            if(especialidad!=null)
            {
                return especialidad;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Especialidad> GetEspecialidades()
        {
            var especialidad = _context.Especialidades.ToList();
            if(especialidad!=null)
            {
                return especialidad;
            }
            else
            {
                return null;
            }
        }

        public void UpdateEspecialidad(int id, EspecialidadDto especialidadDto)
        {
            var especialidadU = _context.Especialidades.Find(id);
            if(especialidadU!=null)
            {
                especialidadU.Nombre = especialidadDto.Nombre;
                especialidadU.Descripcion = especialidadDto.Descripcion;
                especialidadU.Estado = especialidadDto.Estado;

                _context.Especialidades.Update(especialidadU);
                _context.SaveChanges();
            }

            else
            {
                throw new Exception("Especialidad no encontrada");
            }
        }
    }
}