using MatriculasOsorio.Models;
using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.DAL
{
    public class CategoriaDAO
    {
        private static Context context = SingletonContext.GetIntance();

        public static List<CategoriaCurso> RetornarCategoria()
        {
            return context.Categorias.ToList();
        }
        public static void CadastrarCategoria()
        {

        }

        public static void AlterarCategoria()
        {

        }

        public static void ExcluirCategoria()
        {

        }
    }
}