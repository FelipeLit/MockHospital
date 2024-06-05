using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.CItas;

namespace practica1.Controllers.Citas
{
    public class CitaUpdateController : ControllerBase
    {
         private readonly ICitaRepository _citaRepository;
        public CitaUpdateController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPut]
        [Route("actualizar/cita/{id}")]
        public IActionResult UpdateCita (int id, [FromBody]CitaDto citaDto)
        {
            try
            {
                var citaU = _citaRepository.GetCitaById(id);
                if (citaU != null)
                {
                    _citaRepository.UpdateCita(id, citaDto);
                    return Ok ("Cita ha sido actualizada");
                }
                else
                {
                    return NotFound("Cita no encontrada para ser actualizada");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}