using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Especialidades;

namespace practica1.Controllers.Especialidades
{
    public class EspecialidadController : ControllerBase
    {
        private readonly IEspecialidadRepository _especialidadRepository;
        public EspecialidadController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpGet]
        [Route("especialidades")]

        public IActionResult GetAllEspecialidades ()
        {
            var especialidades = _especialidadRepository.GetEspecialidades();

            if(especialidades.Count() < 1)
            {
                return NotFound("No se encontraron especialidades");
            }
            return Ok(especialidades);
        }

        [HttpGet]
        [Route("especialidad/{id}")]
        public IActionResult GetEspecialidad (int id)
        {
            var especialidad = _especialidadRepository.GetEspecialidad(id);

            if(especialidad != null)
            {
                return Ok(especialidad);
            }
                return NotFound("No se encontro especialidad");
        }
    }
}