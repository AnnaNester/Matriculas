using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.DAL
{
    public class ProfessorDAO
    {
        private static Context context = SingletonContext.GetInstance();


        public static List<Professor> RetornarProfessores()
        {
            return context.Professores.ToList();
        }

        public static void CadastrarProfessor(Professor professor)
        {
            context.Professores.Add(professor);
            context.SaveChanges();
        }

        public static Professor BuscarProfessorPorId(int id)
        {
            return context.Professores.Find(id);
        }

        public static bool AlterarProfessor(Professor professor)
        {

            if (context.Professores.FirstOrDefault
                (x => x.NomeProfessor.Equals(professor.NomeProfessor) && x.NumProfessor != professor.NumProfessor) == null)
            {
                context.Entry(professor).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static void ExcluirProfessor(int id)
        {
            context.Professores.Remove(BuscarProfessorPorId(id));
            context.SaveChanges();
        }


    }
}