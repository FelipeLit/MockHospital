using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Medicos;

namespace practica1.Controllers.Medicos
{
    public class MedicoUpdateController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoUpdateController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPut]
        [Route("actualizar/medico/{id}")]
        public IActionResult UpdateMedico (int id, [FromBody]MedicoDto medicoDto)
        {
            try
            {
                var medicoU = _medicoRepository.GetMedicoById(id);
                if (medicoU != null)
                {
                    _medicoRepository.UpdateMedico(id, medicoDto);
                    return Ok ("Medico ha sido actualizado");
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