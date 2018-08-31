using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.Models
{
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
