﻿using MatriculasPrefeitura.DAL;
using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MatriculasPrefeitura.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult ListarCategoria ()
        {
            CategoriaDAO.RetornarCategoria();
            return View();
        }

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

        public ActionResult AlterarCategoria(int id)
        {
            return View(CategoriaDAO.BuscarCategoriaPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarCategoria(CategoriaCurso categoriaAlterada)
        {
            if (ModelState.IsValid)
            {
                CategoriaCurso categoriaOriginal = CategoriaDAO.BuscarCategoriaPorId(categoriaAlterada.CategoriaId);
                categoriaOriginal.NomeCategoria = categoriaAlterada.NomeCategoria;
                categoriaOriginal.DescricaoCategoria = categoriaAlterada.DescricaoCategoria;

                if (CategoriaDAO.AlterarCategoria(categoriaAlterada))
                {
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar a categoria com o mesmo nome!");
                    return View(categoriaAlterada);
                }
            }
            else
            {
                return View(categoriaAlterada);
            }
        }

        public ActionResult RemoverCategoria (int id)
        {
            CategoriaDAO.ExcluirCategoria(id);
            return RedirectToAction("Index", "Categoria");
        }
    }
}