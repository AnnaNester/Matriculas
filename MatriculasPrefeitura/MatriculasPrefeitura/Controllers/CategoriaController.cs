using MatriculasPrefeitura.DAL;
using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasPrefeitura.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(CategoriaCurso categoria)
        {
            if(ModelState.IsValid)
            {
                if(CategoriaDAO.CadastrarCategoria(categoria))
                {
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Erro! Não pode ser cadastrado categoria de curso com o mesmo nome!");
                    return View(categoria);
                }
            }
            else
            {
                return View(categoria);
            }
        }
    }
}