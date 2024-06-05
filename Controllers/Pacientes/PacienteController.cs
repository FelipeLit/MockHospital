using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Pacientes;

namespace practica1.Controllers.Pacientes
{
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        [Route("pacientes")]
        public IActionResult GetAllPacientes ()
        {
            try
            {
                var pacientes = _pacienteRepository.GetAllPacientes();
                if (pacientes.Count()<1)
                {
                    return NotFound("No existen pacientes");
                }
                else
                {
                    return Ok(pacientes);
                }    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("paciente/{id}")]
        public IActionResult GetPaciente (int id)
        {
            try
            {
                var paciente = _pacienteRepository.GetPaciente(id);
                if (paciente != null)
                {
                    return Ok(paciente);
                }
                else
                {
                    return NotFound("No se encontro paciente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet]
        [Route("historial/medico/{id}")]
        public IActionResult HistorialMedicoPaciente(int id)
        {
            try
            {
                
                var historial = _pacienteRepository.HistorialMedicoPaciente(id);
                if (historial.Count()<1)
                {
                    return NotFound("No hay historial para este paciente");
                }
                return Ok(historial);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}