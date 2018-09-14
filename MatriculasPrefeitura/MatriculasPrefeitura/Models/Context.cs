using MatriculasPrefeitura.Models;
using System.Data.Entity;

namespace MatriculasOsorio.Models
{
    public class Context : DbContext
    {
        public Context() : base("Matriculas") { }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<CategoriaCurso> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}