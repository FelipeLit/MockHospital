using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Medicos;

namespace practica1.Controllers.Medicos
{
    public class MedicoCreateController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoCreateController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        [HttpPost]
        [Route("medico/crear")]
        public IActionResult CreateMedico([FromBody]MedicoDto medicoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _medicoRepository.AddMedico(medicoDto);
                return Ok("Medico creado con exito");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}