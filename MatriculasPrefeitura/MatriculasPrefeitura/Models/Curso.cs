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

        [Display(Name = "Quantidade de vagas do Curso")]
        public int QtdeVagas { get; set; }

        [Display(Name = "Descrição do Curso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DescricaoCurso { get; set; }

        [Display(Name = "Categoria do Curso")]
        public CategoriaCurso Categoria { get; set; }

        [Display(Name = "Imagem do curso")]
        public string FotoCurso { get; set; }

        [Display(Name = "Professor do curso")]
        public Professor Professor { get; set; }

        [Display(Name = "Endereço do curso")]
        public string Logradouro { get; set; }

        [Display(Name = "CEP do curso")]
        public string CEP { get; set; }

        [Display(Name = "Bairro do curso")]
        public string Bairro { get; set; }

        [Display(Name = "Localidade do curso")]
        public string Localidade { get; set; }

        [Display(Name = "UF do curso")]
        public string UF { get; set; }

        [Display(Name = "Número do curso")]
        public int Numero { get; set; }

        public virtual List<Matricula> matriculas { get; set; }

    }
}