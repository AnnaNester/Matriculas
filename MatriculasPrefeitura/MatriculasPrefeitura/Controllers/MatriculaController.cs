using MatriculasPrefeitura.DAL;
using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasPrefeitura.Controllers
{
    public class MatriculaController : Controller
    {
        // GET: Matricula
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MatricularAluno(Aluno aluno)
        {
            if (AlunoDAO.BuscarAlunoPorCPF(aluno) == null)
            {
                AlunoDAO.CadastrarAluno(aluno);
            }
            else
            {
                AlunoDAO.MatricularAluno(aluno);
            }

            return View();
        }
    }
}