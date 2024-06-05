using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Pacientes;

namespace practica1.Controllers.Pacientes
{
    public class PacienteRemoveController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteRemoveController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpPut]
        [Route("remove/paciente/{id}")]
        public IActionResult RemovePaciente(int id)
        {
            try
            {
                var paciente = _pacienteRepository.GetPaciente(id);
                if (paciente != null)
                {
                    _pacienteRepository.RemovePaciente(id);
                    return Ok("Paciente ha sido removido");
                }
                else 
                {
                    return NotFound("Paciente no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}