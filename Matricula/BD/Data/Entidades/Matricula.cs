//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Matricula.BD.Data.Entidades
//{
//    [Index(nameof(MedicoId),nameof(EspecialidadId), Name = "MatriculaMedicoIdEspecialidadId_UQ", IsUnique = true)]
//    public class Matricula : EntityBase
//    {
//        [Required(ErrorMessage = "El Número de Matricula es obligatotio")]
//        [MaxLength(10, ErrorMessage = "El Número de Matricula no debe superar los {1} caracteres")]
//        public string NumMatricula { get; set; }

//        [Required(ErrorMessage = "El médico es obligatotio")]
//        public int MedicoId { get; set; }
//        public Medico Medico { get; set; }

//        [Required(ErrorMessage = "La especialidad es obligatotio")]
//        public int EspecialidadId { get; set; }
//        public Especialidad Especialidad { get; set; }
//    }
//}
