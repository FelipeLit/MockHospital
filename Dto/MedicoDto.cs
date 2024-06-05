using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.Dto
{
    public class MedicoDto
    {
        [Required(ErrorMessage ="Nombre es requerido")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage ="Correo es requerido")]
        public string Correo { get; set; }
        [Required(ErrorMessage ="Telefono es requerido")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="Estado es requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage ="Id de especialidad requerido es requerido")]
        public int EspecialidadId { get; set; }
    }
}