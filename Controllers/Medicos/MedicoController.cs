using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Medicos;

namespace practica1.Controllers.Medicos
{
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpGet]
        [Route("medicos")]
        public IActionResult GetAllMedicos ()
        {
            try
            {
                 var medicos = _medicoRepository.GetAllMedicos();
                if (medicos.Count()<1)
                {
                    return NotFound("No existen medicos");
                }
                else
                {
                    return Ok(medicos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("medico/{id}")]
        public IActionResult GetMedico (int id)
        {
            try 
            {
                 var medico = _medicoRepository.GetMedicoById(id);
                if (medico != null)
                {
                    return Ok(medico);
                }
                else
                {
                    return NotFound("Medico no encontrado o no existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("pacientes/medico/{id}")]
        public IActionResult GetPacientesDeUnMedico (int id)
        {
            var medicoPacientes = _medicoRepository.PacientesDeUnMedico(id);
                if (medicoPacientes != null)
                {
                    return Ok(medicoPacientes);
                }
                else
                {
                    return NotFound("No hay pacientes asociados a ese medico");
                }
        }

    }
}