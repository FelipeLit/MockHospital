using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.Dto
{
    public class CitaDto
    {
        [Required (ErrorMessage = " fecha requerido")]        
        public DateTime Fecha { get; set; }
        [Required (ErrorMessage = "estado requerido")]        
        public string Estado { get; set; }
        [Required (ErrorMessage = "id de medico requerido")]        
        public int MedicoId { get; set; }
        [Required (ErrorMessage = "id de paciente requerido")]        
        public int PacienteId { get; set; }
    }
}