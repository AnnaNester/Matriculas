using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.DAL
{
    public class CursoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Curso> RetornarCursos()
        {
            return context.Cursos.Include("CategoriaCurso").ToList();
        }

        public static bool CadastrarCurso(Curso curso)
        {
            if(BuscarCursoPorNome(curso) == null)
            {
                context.Cursos.Add(curso);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Curso BuscarCursoPorId(int id)
        {
            return context.Cursos.Find(id);
        }

        public static bool AlterarCurso(Curso curso)
        {
            if (context.Cursos.Include("CategoriaCurso").FirstOrDefault(x => x.NomeCurso.Equals(curso.NomeCurso) && x.CursoId != curso.CursoId) == null)
            {
                context.Entry(curso).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static void ExcluirCurso(int id)
        {
            context.Cursos.Remove(BuscarCursoPorId(id));
            context.SaveChanges();
        }

        public static List<Curso> BuscarCursoPorCategoria(int? id)
        {
            return context.Cursos.Include("CategoriaCurso").Where(x => x.CategoriaCurso.CategoriaId == id).ToList();
        }

        public static Curso BuscarCursoPorNome(Curso curso)
        {
            return context.Cursos.Include("CategoriaCurso").FirstOrDefault(x => x.NomeCurso.Equals(curso.NomeCurso) && x.LocalCurso.Equals(curso.LocalCurso));
        }
    }
}