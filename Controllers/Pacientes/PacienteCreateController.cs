using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Pacientes;

namespace practica1.Controllers.Pacientes
{
    public class PacienteCreateController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteCreateController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpPost]
        [Route("paciente/crear")]
        public IActionResult CreatePaciente([FromBody]PacienteDto pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _pacienteRepository.AddPaciente(pacienteDto);
                return Ok("Paciente creado con exito");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}