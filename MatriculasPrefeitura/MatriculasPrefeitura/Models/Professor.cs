﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatriculasOsorio.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Key]
        public int NumProfessor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres!")]
        [Display(Name = "Nome do Professor")]
        public string NomeProfessor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CPF do Professor")]
        public string CPFProfessor { get; set; }

        [Display(Name = "Formação do Professor")]
        public string FormacaoProfessor { get; set; }

        [Display(Name = "Cursos lecionados pelo Professor")]
        public List<Curso> CursoLeciona { get; set; }

        [Display(Name = "Foto do Professor")]
        public string FotoProfessor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Endereço do Professor")]
        public string EnderecoProfessor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Senha do Professor")]
        public string SenhaProfessor { get; set; }

        [Compare("SenhaProfessor", ErrorMessage = "Os campos não coincidem!" )]
        [Display(Name = "Confirmação da senha")]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }
    }
}