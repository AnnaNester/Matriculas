using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.Models
{
    [Table ("Endereco")]
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        public string Logradouro { get; set; }
    
        public string CEP { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string UF { get; set; }



    }
}