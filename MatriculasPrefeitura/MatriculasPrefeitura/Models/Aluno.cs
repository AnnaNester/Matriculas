using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatriculasPrefeitura.Models
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
        [Display(Name = "Rua do Aluno")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CEP do Aluno")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Bairro do Aluno")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Cidade do Aluno")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Estado do Aluno")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Número da Casa do Aluno")]
        public int Numero { get; set; }

    }
}
