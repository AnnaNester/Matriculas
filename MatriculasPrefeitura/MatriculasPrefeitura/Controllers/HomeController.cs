using MatriculasPrefeitura.DAL;
using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasPrefeitura.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Categorias = CategoriaDAO.RetornarCategoria();
            if (id == null)
            {
                return View(CursoDAO.RetornarCursos());
            }
            return View(CursoDAO.BuscarCursoPorCategoria(id));
        }

        // CRIAR MÉTODO BUSCAR ALUNO POR CPF
        public ActionResult MatricularAluno(int id)
        {
            Aluno alu = AlunoDAO.BuscarAlunoPorId(id);
            


            AlunoDAO.MatricularAluno(alu);
            return View();
        }
    }
}