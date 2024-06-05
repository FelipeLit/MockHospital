using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.Dto
{
    public class EspecialidadDto
    {
        [Required(ErrorMessage ="Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripcion es requeridad")]
        public string Descripcion { get; set; }
        [Required (ErrorMessage = "Estado es requerido")]
        public string Estado { get; set; } 
    }
}