using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatriculasOsorio.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }

        [Display(Name = "Nome do Curso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeCurso { get; set; }

        [Display(Name = "Duração do Curso")]
        public int DuracaoCurso { get; set; }

        [Display(Name = "Local do Curso")]
        public string LocalCurso { get; set; }

        [Display(Name = "Professor do Curso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Professor ProfessorCurso { get; set; }

        public List<Aluno> AlunosCurso { get; set; }

        [Display(Name = "Quantidade de vagas do Curso")]
        public int QtdeVagas { get; set; }
    }
}