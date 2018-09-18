using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.Models
{
    [Table("Matricula")]
    public class Matricula
    {
        [Key]
        public int numMatricula { get; set; }

        public Curso CursoMatriculado { get; set; }

        public Aluno AlunoMatriculado { get; set; }

        public DateTime DataMatricula { get; set; }
    }
}