using MatriculasPrefeitura.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasPrefeitura.Controllers
{
    [Authorize]
    public class CursoController : Controller
    {
        public ActionResult ListarCursos()
        {
            CursoDAO.RetornarCursos();
            return View();
        }

        // GET: Curso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarCurso()
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            return View();
        }

        public ActionResult AlterarCurso(int id)
        {
            return View(CursoDAO.BuscarCursoPorId(id));
        }

        public void ExcluirCurso()
        {

        }
    }
}