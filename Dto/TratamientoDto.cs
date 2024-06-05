using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.Dto
{
    public class TratamientoDto
    {   
        [Required (ErrorMessage = "Descripcion es requerido")]
        public string Descripcion { get; set; }
        [Required (ErrorMessage = "Esatdo es requerido")]
        public string Estado { get; set; }
        [Required (ErrorMessage = "El Id de cita requerido")]
        public int CitaId { get; set; }
    }
}