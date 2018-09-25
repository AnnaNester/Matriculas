using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatriculasPrefeitura.Models
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

        [Display(Name = "Foto do Professor")]
        public string FotoProfessor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Rua do Professor")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CEP do Professor")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Bairro do Professor")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Cidade do Professor")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Estado do Professor")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Número da Casa do Professor")]
        public int Numero { get; set; }



    }
}