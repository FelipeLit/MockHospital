using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.Tratamientos;

namespace practica1.Controllers.Tratamientos
{
    public class TratamientoUpdateController : ControllerBase
    {
        private readonly ITratamientoRepository _tratamientoRepository;
        public TratamientoUpdateController(ITratamientoRepository tratamientoRepository)
        {
            _tratamientoRepository = tratamientoRepository;
        }

        [HttpPut]
        [Route("actualizar/tratamiento/{id}")]
        public IActionResult UpdateTratamiento (int id, [FromBody]TratamientoDto tratamientoDto)
        {
            try
            {
                var tratamientoU = _tratamientoRepository.GetTratamientoById(id);
                if (tratamientoU != null)
                {
                    _tratamientoRepository.UpdateTratamiento(id, tratamientoDto);
                    return Ok ("Tratamiento ha sido actualizado");
                }
                else
                {
                    return NotFound("Tratamiento no fue encontrado para ser actualizado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}