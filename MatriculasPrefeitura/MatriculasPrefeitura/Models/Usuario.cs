using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Login do Usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Senha do Usuário")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Os campos não coincidem!")]
        [Display(Name = "Confirmação da senha")]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }

    }
}