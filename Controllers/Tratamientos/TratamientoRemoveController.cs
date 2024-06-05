using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.Tratamientos;

namespace practica1.Controllers.Tratamientos
{
    public class TratamientoRemoveController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;
        public TratamientoRemoveController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPut]
        [Route("remove/tratamiento/{id}")]
        public IActionResult RemoveTratamiento(int id)
        {
            try
            {
                var tratamiento = _tratamientoRepository.GetTratamientoById(id);
                if (tratamiento != null)
                {
                    _tratamientoRepository.RemoveTratamiento(id);
                    return Ok("Tratamiento ha sido removido");
                }
                else 
                {
                    return NotFound("Tratamiento no fue encontrado para ser removida");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}