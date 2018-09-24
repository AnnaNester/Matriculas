using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatriculasPrefeitura.Models
{
    [Table("Categoria")]
    public class CategoriaCurso
    {
        [Key]
        public int CategoriaId { get; set; }


        [Display(Name = "Nome da Categoria")]
        [Required(ErrorMessage = "Campo obrigatório")]
         public string NomeCategoria { get; set; }

        [Display(Name = "Descrição da Categoria")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DescricaoCategoria { get; set; }
    }
}
