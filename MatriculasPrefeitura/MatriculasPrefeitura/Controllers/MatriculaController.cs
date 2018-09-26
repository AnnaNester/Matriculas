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
                ModelState.AddModelError("", TempData["Aluno não cadastrado no sistema!"].ToString());
            }
            else
            {
                Aluno alu = AlunoDAO.BuscarAlunoPorCPF(matricula.AlunoMatriculado);
                AlunoDAO.MatricularAluno(alu);
                ModelState.AddModelError("", TempData["Matrícula realizada com sucesso!"].ToString());
            }

            return View("Index", "Home");
        }

        

        
    }
}