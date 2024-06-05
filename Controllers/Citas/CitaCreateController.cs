using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.CItas;

namespace practica1.Controllers.Citas
{
    public class CitaCreateController : ControllerBase
    {
         private readonly ICitaRepository _citaRepository;
        public CitaCreateController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPost]
        [Route("cita/crear")]
        public async Task<IActionResult> CreateCita([FromBody]CitaDto citaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _citaRepository.AddCita(citaDto);
                return Ok("Cita creada con exito");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}