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

        [Display(Name = "Quantidade de vagas do Curso")]
        public int QtdeVagas { get; set; }

        [Display(Name = "Descrição do Curso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DescricaoCurso { get; set; }

        [Display(Name = "Início do Curso")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Categoria do Curso")]
        public CategoriaCurso Categoria { get; set; }

        [Display(Name = "Imagem do curso")]
        public string FotoCurso { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}