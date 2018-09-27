using MatriculasPrefeitura.DAL;
using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult MatricularAluno(Matricula matricula)
        {
            if (AlunoDAO.BuscarAlunoPorCPF(matricula.AlunoMatriculado) == null)
            {
                ModelState.AddModelError("", "Aluno não cadastrado no sistema!");
            }
            else
            {
                Aluno alu = AlunoDAO.BuscarAlunoPorCPF(matricula.AlunoMatriculado);
                matricula.AlunoMatriculado = alu;
                AlunoDAO.MatricularAluno(matricula);
                ModelState.AddModelError("", "Matrícula realizada com sucesso!");
            }

            return View("Index", "Home");
        }

        

        
    }
}