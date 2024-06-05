using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practica1.Dto;
using practica1.Services.CItas;

namespace practica1.Controllers.Citas
{
    public class CitaController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;
        public CitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet]
        [Route("citas")]
        public IActionResult GetAllCitas()
        {
            try
            {
                var citas = _citaRepository.GetAllCitas();
                if (citas.Count() < 1)
                {
                    return NotFound("No existen citas");
                }
                else
                {
                    return Ok(citas);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("cita/{id}")]
        public IActionResult GetCita(int id)
        {
            try
            {
                var cita = _citaRepository.GetCitaById(id);
                if (cita != null)
                {
                    return Ok(cita);
                }
                else
                {
                    return NotFound("No se encontro cita");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("cantidad/citas/paciente/{id}")]
        public IActionResult GetCitasByPaciente(int id)
        {
            try
            {
                var citas = _citaRepository.CountCitesByPacient(id);
                if (citas == "El paciente no tiene citas")
                {
                    return NotFound("No existen citas");
                }
                else
                {
                    return Ok(citas);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("cantidad/citas/dia")]
        public IActionResult GetCitasByMedico([FromBody] FechaRequest fechaRequest)
        {
            try
            {
                var fecha = new DateTime(fechaRequest.Year, fechaRequest.Month, fechaRequest.Day);
                var cantidad = _citaRepository.CantidadCitasPorDia(fecha);
                return Ok(new { Fecha = fecha, Cantidad = cantidad });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Capturar errores de fecha no válidos y devolver un mensaje amigable
                return BadRequest(new { Message = "Fecha no válida. Verifique los valores de año, mes y día.", Error = ex.Message });
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error y devolver un estado de error 500
                return StatusCode(500, new { Message = "Ocurrió un error inesperado.", Error = ex.Message });
            }

        }

        [HttpGet]
        [Route("citas/medico/pordia/{id}")]
        public IActionResult GetCitasByMedico(int id, [FromQuery] FechaRequest fechaRequest)
        {
            try
            {
                var fecha = new DateTime (fechaRequest.Year, fechaRequest.Month, fechaRequest.Day);
                var citas = _citaRepository.CitasMedicoDia(fecha, id);
                if (citas.Count()<1)
                {
                    return NotFound("No hay citas para esa fecha con el medico");
                }
                return Ok(citas);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("citas/activas")]
        public IActionResult GetCitasActivas()
        {
            try
            {
                var citas = _citaRepository.GetAllCitesActive();
                if (citas.Count()<1)
                {
                    return NotFound("No existen citas activas");
                }
                else
                {
                    return Ok(citas);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}