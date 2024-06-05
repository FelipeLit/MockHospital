using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Pacientes;

namespace practica1.Controllers.Pacientes
{
    public class PacienteUpdateController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteUpdateController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpPut]
        [Route("actualizar/paciente/{id}")]
        public IActionResult UpdateMedico (int id, [FromBody]PacienteDto pacienteDto)
        {
            try
            {
                var pacienteU = _pacienteRepository.GetPaciente(id);
                if (pacienteU != null)
                {
                    _pacienteRepository.UpdatePaciente(id, pacienteDto);
                    return Ok ("Paciente ha sido actualizado");
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