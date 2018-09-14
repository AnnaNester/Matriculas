using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatriculasPrefeitura.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Display(Name = "Nome do Curso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeCurso { get; set; }

        [Display(Name = "Duração do Curso")]
        public int DuracaoCurso { get; set; }

        [Display(Name = "Local do Curso")]
        public string LocalCurso { get; set; }

        [Display(Name = "Professor do Curso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Professor ProfessorCurso { get; set; }

        [Display(Name = "Quantidade de vagas do Curso")]
        public int QtdeVagas { get; set; }

        [Display(Name = "Descrição do Curso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DescricaoCurso { get; set; }

        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public CategoriaCurso CategoriaCurso { get; set; }

        [Display(Name = "Imagem do curso")]
        public string FotoCurso { get; set; }
    }
}