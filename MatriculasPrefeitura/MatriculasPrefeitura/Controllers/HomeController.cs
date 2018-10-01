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

        public ActionResult CursoDetalhe(int id)
        {
            return View(CursoDAO.BuscarCursoPorId(id));
        }

        public ActionResult MostrarTurma(int id)
        {
            return View(CursoDAO.ListarAlunoPorCurso(id));
        }

        
    }
}