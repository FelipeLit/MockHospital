using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Especialidades;

namespace practica1.Controllers.Especialidades
{
    public class EspecialidadCreateController : ControllerBase
    {
         private readonly IEspecialidadRepository _especialidadRepository;
        public EspecialidadCreateController(IEspecialidadRepository especialidadRepository)
        {
            _especialidadRepository = especialidadRepository;
        }

        [HttpPost]
        [Route("crear/especilidad")]
        public IActionResult CrearEspecialidad([FromBody] EspecialidadDto especialidadDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _especialidadRepository.AddEspecialidad(especialidadDto);
                return StatusCode(202, "Especialidad creada con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error"+ex.Message);
            }
        }
    }
}