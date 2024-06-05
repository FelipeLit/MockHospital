using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Especialidades;

namespace practica1.Controllers.Especialidades
{
    public class EspecilidadUpdateController : ControllerBase
    {
         private readonly IEspecialidadRepository _especialidadRepository;
        public EspecilidadUpdateController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPut]
        [Route("actualizar/especialidad/{id}")]

        public IActionResult ActualizarEspecialidad ([FromBody] EspecialidadDto especialidadDto, int id)
        {
            try
            {
                var especilidadU = _especialidadRepository.GetEspecialidad(id);
                if (especilidadU != null)
                {
                    _especialidadRepository.UpdateEspecialidad(id, especialidadDto);
                    return Ok("Especialidad actualizada");
                }
                else
                {
                    return NotFound("Especialidad no encontrada");
                }

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}