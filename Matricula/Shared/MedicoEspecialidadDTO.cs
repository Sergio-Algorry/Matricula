using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Shared
{
    public class MedicoEspecialidadDTO
    {
        [Required]
        [MaxLength(8, ErrorMessage = "El DNI de la persona no debe superar los {1} caracteres")]
        public string DNI { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "El Nombre de la persona no debe superar los {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El código es obligatorio")]
        [MaxLength(2, ErrorMessage = "El Código de la especialidad no debe superar los {1} caracteres")]
        public string Codigo { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "El Nombre de la especialidad no debe superar los {1} caracteres")]
        public string NomEspecialidad { get; set; }
    }
}
