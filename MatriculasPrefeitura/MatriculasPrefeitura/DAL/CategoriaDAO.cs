using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.DAL
{
    public class CategoriaDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<CategoriaCurso> RetornarCategoria()
        {
            return context.Categorias.ToList();
        }
        public static bool CadastrarCategoria(CategoriaCurso categoria)
        {
            if(BuscarCategoriaPorNome(categoria) == null)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static CategoriaCurso BuscarCategoriaPorNome(CategoriaCurso categoria)
        {
            return context.Categorias.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria));
        }

        public static bool AlterarCategoria(CategoriaCurso categoria)
        {
            if (context.Categorias.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria) && x.CategoriaId != categoria.CategoriaId) == null)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static void ExcluirCategoria(int id)
        {
            context.Categorias.Remove(BuscarCategoriaPorId(id));
            context.SaveChanges();
        }

        public static CategoriaCurso BuscarCategoriaPorId(int? id)
        {
            return context.Categorias.Find(id);
        }
    }
}