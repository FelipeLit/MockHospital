using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace practica1.Models
{
    public class Cita
    {
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public int MedicoId { get; set; }
        [Required]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        [JsonIgnore]
        public List<Tratamiento> Tratamientos { get; set; }
    }
}