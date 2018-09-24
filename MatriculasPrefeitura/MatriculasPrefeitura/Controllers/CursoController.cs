using MatriculasPrefeitura.Models;
using MatriculasPrefeitura.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace MatriculasPrefeitura.Controllers
{
    public class CursoController : Controller
    {
        public ActionResult ListarProduto()
        {
            CursoDAO.RetornarCursos();
            return View();
        }


        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(CursoDAO.RetornarCursos());
        }

        public ActionResult CadastrarCurso()
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCurso(Curso curso, int? Categorias, HttpPostedFileBase fupImagem)
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            if (ModelState.IsValid)
            {
                if (Categorias != null)
                {
                    if (fupImagem != null)
                    {
                        string nomeImagem = Path.GetFileName(fupImagem.FileName);
                        string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);

                        fupImagem.SaveAs(caminho);

                        curso.FotoCurso = nomeImagem;
                    }
                    else
                    {
                        curso.FotoCurso = "image (1).jpeg";
                    }

                    curso.Categoria = CategoriaDAO.BuscarCategoriaPorId(Categorias);
                    if (CursoDAO.CadastrarCurso(curso))
                    {
                        return RedirectToAction("Index", "Curso");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Não é possível adicionar um curso com o mesmo nome!");
                        return View(curso);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Por favor selecione uma categoria!");
                    return View(curso);
                }
            }
            else
            {
                return View(curso);
            }
        }

        public ActionResult AlterarCurso(int id)
        {
            return View(CursoDAO.BuscarCursoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarCurso(Curso cursoAlterado)
        {
            if (ModelState.IsValid)
            {
                Curso cursoOriginal = CursoDAO.BuscarCursoPorId(cursoAlterado.CursoId);
                cursoOriginal.NomeCurso = cursoAlterado.NomeCurso;
                cursoOriginal.DescricaoCurso = cursoAlterado.DescricaoCurso;
                cursoOriginal.DuracaoCurso = cursoAlterado.DuracaoCurso;
                cursoOriginal.Categoria = cursoAlterado.Categoria;
                cursoOriginal.LocalCurso = cursoAlterado.LocalCurso;
                cursoOriginal.QtdeVagas = cursoAlterado.QtdeVagas;


                if (CursoDAO.AlterarCurso(cursoAlterado))
                {
                    return RedirectToAction("Index", "Curso");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar o curso com o mesmo nome!");
                    return View(cursoAlterado);
                }
            }
            else
            {
                return View(cursoAlterado);
            }
        }

        public ActionResult RemoverCurso(int id)
        {
            CursoDAO.RemoverCurso(id);
            return RedirectToAction("Index", "Curso");
        }

        public ActionResult ListarPorCategoria(int categoria)
        {
            return ViewBag.Cursos = CategoriaDAO.BuscarCategoriaPorId(categoria);
        }
    }
}