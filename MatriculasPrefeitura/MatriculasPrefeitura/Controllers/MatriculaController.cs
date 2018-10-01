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
            ViewBag.Data = DateTime.Now;
            return View(MatriculaDAO.RetornarMatriculas());
        }

        public ActionResult MatricularAluno()
        {
            if (TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View((Matricula)TempData["Matricula"]);
        }

        [HttpPost]
        public ActionResult MatricularAluno(Matricula matricula)
        {
            if (AlunoDAO.BuscarAlunoPorCPF(matricula.AlunoMatriculado) == null)
            {
                ModelState.AddModelError("", "Aluno não cadastrado no sistema!");
            }
            else
            {
                Aluno alu = AlunoDAO.BuscarAlunoPorCPF(matricula.AlunoMatriculado);
                Curso cur = CursoDAO.BuscarCursoPorId(matricula.CursoMatriculado);
                matricula.AlunoMatriculado = alu;
                matricula.CursoMatriculado = cur;
                AlunoDAO.MatricularAluno(matricula);
                ModelState.AddModelError("", "Matrícula realizada com sucesso!");
                return View(matricula);
            }

            return View("Index", "Home");
        }

        

        
    }
}