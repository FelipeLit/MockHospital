using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Tratamientos;

namespace practica1.Controllers.Tratamientos
{
    public class TratamientoController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;
        public TratamientoController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpGet]
        [Route("tratamientos")]
        public IActionResult GetAllTratamientos ()
        {
            try
            {
                var tratamientos = _tratamientoRepository.GetAllTratamientos();
                if (tratamientos.Count()<1)
                {
                    return NotFound("No existen tratamientos");
                }
                else
                {
                    return Ok(tratamientos);
                }    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("tratamientos/{id}")]
        public IActionResult GetTratamiento (int id)
        {
            try
            {
                var tratamiento = _tratamientoRepository.GetTratamientoById(id);
                if (tratamiento != null)
                {
                    return Ok(tratamiento);
                }
                else
                {
                    return NotFound("No se encontro tratamiento");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}