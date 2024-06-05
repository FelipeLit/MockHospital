using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practica1.Data;
using practica1.Dto;
using practica1.Models;

namespace practica1.Services.Tratamientos
{
    public class TratamientoRepository : ITratamientoRepository
    {
        private readonly HospitalContext _context;
        public TratamientoRepository(HospitalContext context)
        {
            _context = context;
        }
        public void AddTratamiento(TratamientoDto tratamientoDto)
        {
            try 
            {
                var tratamiento = new Tratamiento
                {
                    Descripcion = tratamientoDto.Descripcion,
                    Estado = "activo",
                    CitaId = tratamientoDto.CitaId
                };
                _context.Tratamientos.Add(tratamiento);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public IEnumerable<Tratamiento> GetAllTratamientos()
        {
            var tratamientos = _context.Tratamientos.ToList();
            if (tratamientos != null)
            {
                return tratamientos;
            }
            else{
                return null;
            }
        }

        public Tratamiento GetTratamientoById(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if(tratamiento!=null)
            {
                return tratamiento;
            }
            else
            {
                return null;
            }
        }

        public void RemoveTratamiento(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento != null)
            {
                tratamiento.Estado = "inactivo";
                _context.Tratamientos.Update(tratamiento);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro tratamiento");
            }
        }

        public void UpdateTratamiento(int id, TratamientoDto tratamientoDto)
        {
            var tratamientoU = _context.Tratamientos.Find(id);
            if (tratamientoU != null)
            {
               tratamientoU.Descripcion = tratamientoDto.Descripcion;
               tratamientoU.Estado = tratamientoDto.Estado;
               tratamientoU.CitaId = tratamientoDto.CitaId;
               _context.Tratamientos.Update(tratamientoU);
               _context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro tratamiento para actualizar");
            }
        }
    }
}