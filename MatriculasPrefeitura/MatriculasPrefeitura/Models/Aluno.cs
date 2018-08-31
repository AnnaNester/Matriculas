using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Cursos matriculado")]
        public Curso CursoMatriculado { get; set; }

        [Display(Name = "Foto do Aluno")]
        public string FotoAluno { get; set; }
    }
}