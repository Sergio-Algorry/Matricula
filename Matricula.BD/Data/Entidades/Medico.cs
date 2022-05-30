using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.BD.Data.Entidades
{
    [Index(nameof(DNI), Name = "MedicoDNI_UQ", IsUnique = true)]
    public class Medico : EntityBase
    {
        [Required]
        [MaxLength(8, ErrorMessage = "El DNI de la persona no debe superar los {1} caracteres")]
        public string DNI { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "El Nombre de la persona no debe superar los {1} caracteres")]
        public string Nombre { get; set; }
    }
}
