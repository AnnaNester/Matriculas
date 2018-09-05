using MatriculasOsorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key]
        public int MatriculaId { get; set; }

        public Aluno Aluno { get; set; }

        public Curso Curso { get; set; }
    }
}
