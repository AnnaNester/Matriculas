using System;
using MatriculasPrefeitura.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MatriculasPrefeitura.DAL
{
    public class AlunoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Aluno> RetornarAlunos()
        {
            return context.Alunos.ToList();
        }

        public static bool CadastrarAluno(Aluno aluno)
        {
            if (BuscarAlunoPorCPF(aluno) == null)
            {
                context.Alunos.Add(aluno);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ExcluirAluno(int id)
        {
            context.Alunos.Remove(BuscarAlunoPorId(id));
            context.SaveChanges();
        }

        public static Aluno BuscarAlunoPorId(int id)
        {
            return context.Alunos.Find(id);
        }

        public static bool AlterarAluno(Aluno aluno)
        {
            if (context.Alunos.FirstOrDefault(x => x.NomeAluno.Equals(aluno.NomeAluno) && x.NumAluno != aluno.NumAluno) == null)
            {
                context.Entry(aluno).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static void MatricularAluno(Aluno aluno)
        {
            Matricula matricula = new Matricula();

            matricula.AlunoMatriculado = aluno;
            matricula.CursoMatriculado = aluno.CursoMatriculado;
            matricula.DataMatricula = DateTime.Now;

            context.Matriculas.Add(matricula);
            context.SaveChanges();
        }

        public static Aluno BuscarAlunoPorCPF(Aluno aluno)
        {
            return context.Alunos.FirstOrDefault(x => x.CPFAluno.Equals(aluno.CPFAluno));
        }


    }
}