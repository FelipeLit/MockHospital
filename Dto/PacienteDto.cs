using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practica1.Dto
{
    public class PacienteDto
    {   
        [Required (ErrorMessage = "Nombres son obligatorios")]
        public string Nombre { get; set; }
        [Required (ErrorMessage = "Apellidos son obligatorios")]
        public string Apellidos { get; set; }
        [Required (ErrorMessage = "La fecha es obligatorio")]
        public DateTime FechaNacimiento { get; set; }
        [Required (ErrorMessage = "Correo es obligatorio")]
        public string Correo { get; set; }
        [Required (ErrorMessage = "Telefono son obligatorio")]
        public string Telefono { get; set; }
         [Required (ErrorMessage = "Direccion es obligatorio")]
        public string Direccion { get; set; }
        [Required (ErrorMessage = "Esatdo es obligatorio")]
        public string Estado { get; set; }
       
    }
}