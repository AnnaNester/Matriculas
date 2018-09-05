﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatriculasOsorio.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int NumAluno { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres!")]
        [Display(Name = "Nome do Aluno")]
        public string NomeAluno { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CPF do Aluno")]
        public string CPFAluno { get; set; }

        [Display(Name = "Curso matriculado")]
        public Curso CursoMatriculado { get; set; }

        [Display(Name = "Foto do Aluno")]
        public string FotoAluno { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Endereço do Aluno")]
        public string EnderecoAluno { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Senha do Aluno")]
        public string SenhaAluno { get; set; }

        [Compare("SenhaAluno", ErrorMessage = "Os campos não coincidem!")]
        [Display(Name = "Confirmação da senha")]
        [NotMapped]
        public string ConfirmacaoAluno { get; set; }
    }
}
