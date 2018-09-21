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

                    curso.CategoriaCurso = CategoriaDAO.BuscarCategoriaPorId(Categorias);
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
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            if (ModelState.IsValid)
            {
                Curso cursoOriginal = CursoDAO.BuscarCursoPorId(cursoAlterado.CursoId);
                cursoOriginal.NomeCurso = cursoAlterado.NomeCurso;
                cursoOriginal.DuracaoCurso = cursoAlterado.DuracaoCurso;
                cursoOriginal.LocalCurso = cursoAlterado.LocalCurso;
                cursoOriginal.QtdeVagas = cursoAlterado.QtdeVagas;
                cursoOriginal.DescricaoCurso = cursoAlterado.DescricaoCurso;
                cursoOriginal.CategoriaCurso = cursoAlterado.CategoriaCurso;

                if (CursoDAO.AlterarCurso(cursoAlterado))
                {
                    return RedirectToAction("Index", "Produto");
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

        public ActionResult ExcluirCurso(int id)
        {
            CursoDAO.ExcluirCurso(id);
            return RedirectToAction("Index", "Curso");
        }

        [HttpPost]
        public ActionResult LocalizacaoCurso(Curso curso)
        {
            try
            {
                string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + curso.LocalCurso + "&key=AIzaSyCpbsdLaCvNpC0jObCLKvRSH8eFXwuZ5Yk";
                WebClient client = new WebClient();
                string json = client.DownloadString(url);
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);
                curso = JsonConvert.DeserializeObject<Curso>(json);

                TempData["Curso"] = curso;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "Localização Inválida!";
            }

            return RedirectToAction("DetalhesCurso", "Curso");
        }
    }
}