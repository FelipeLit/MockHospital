using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Tratamientos;

namespace practica1.Controllers.Tratamientos
{
    public class TratamientoCreateController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;
        public TratamientoCreateController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPost]
        [Route("tratamiento/crear")]
        public IActionResult CreateTratamiento([FromBody]TratamientoDto tratamientoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _tratamientoRepository.AddTratamiento(tratamientoDto);
                return Ok("Tratamiento creado con exito");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}