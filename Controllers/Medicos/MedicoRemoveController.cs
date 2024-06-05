using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Medicos;

namespace practica1.Controllers.Medicos
{
    public class MedicoRemoveController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoRemoveController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPut]
        [Route("remove/medico/{id}")]
        public IActionResult RemoveMedico(int id)
        {
            try
            {
                var medico = _medicoRepository.GetMedicoById(id);
                if (medico != null)
                {
                    _medicoRepository.RemoveMedico(id);
                    return Ok("Medico ha sido removido");
                }
                else 
                {
                    return NotFound("Medico no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}