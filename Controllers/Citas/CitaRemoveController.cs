using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Services.CItas;

namespace practica1.Controllers.Citas
{
    public class CitaRemoveController : ControllerBase
    {
         private readonly ICitaRepository _citaRepository;
        public CitaRemoveController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpPut]
        [Route("remove/cita/{id}")]
        public IActionResult RemoveCita(int id)
        {
            try
            {
                var cita = _citaRepository.GetCitaById(id);
                if (cita != null)
                {
                    _citaRepository.RemoveCita(id);
                    return Ok("Cita ha sido removida");
                }
                else 
                {
                    return NotFound("Cita no encontrada para ser removida");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}