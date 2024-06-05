using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Especialidades;

namespace practica1.Controllers.Especialidades
{
    public class EspecialidadRemoveController : ControllerBase
    {
         private readonly IEspecialidadRepository _especialidadRepository;
        public EspecialidadRemoveController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPut]
        [Route("remove/especialidad/{id}")]

        public IActionResult removeEspecialidad(int id)
        {
            try
            {
                var especialidad = _especialidadRepository.GetEspecialidad(id);
                if (especialidad != null)
                {
                    _especialidadRepository.DeleteEspecialidad(id);
                    return Ok("Especialidad removida");
                }
                else
                {
                    return NotFound("Especialidad no encontrada");
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}