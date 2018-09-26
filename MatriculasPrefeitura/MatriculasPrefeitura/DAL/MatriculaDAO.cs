using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.DAL
{
    public class MatriculaDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Matricula> RetornarMatriculas()
        {
            return context.Matriculas.ToList();
        }
        public static void MatricularAluno(Matricula matricula)
        {
            Matricula cadastro = context.Matriculas.Include("Aluno").FirstOrDefault(x => x.AlunoMatriculado.CPFAluno == matricula.AlunoMatriculado.CPFAluno);
            if (cadastro == null)
            {
                context.Matriculas.Add(cadastro);
                context.SaveChanges();
            }
        }

        public void ExcluirMatricula(int id)
        {
            Matricula matricula = context.Matriculas.Find(id);
            if (matricula != null)
            {
                context.Matriculas.Remove(matricula);
                context.SaveChanges();
            }
        }
    }
}