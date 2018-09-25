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


        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(CursoDAO.RetornarCursos());
        }

        public ActionResult CadastrarCurso()
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            ViewBag.Professores = new SelectList(ProfessorDAO.RetornarProfessores(), "NumProfessor", "NomeProfessor");
            return View((Curso)TempData["Curso"]);
        }

        [HttpPost]
        public ActionResult CadastrarCurso([Bind(Include = "CursoId, NomeCurso, DuracaoCurso, QtdeVagas, DescricaoCurso, Logradouro, Localidade, UF, Cep, Bairro, Numero")] Curso curso, int? Professores, int? Categorias, HttpPostedFileBase fupImagem)
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            ViewBag.Professores = new SelectList(ProfessorDAO.RetornarProfessores(), "NumProfessor", "NomeProfessor");
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

        public ActionResult EditarCurso(int id)
        {
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            ViewBag.Professores = new SelectList(ProfessorDAO.RetornarProfessores(), "NumProfessor", "NomeProfessor");
            return View(CursoDAO.BuscarCursoPorId(id));
        }

        [HttpPost]
        public ActionResult EditarCurso([Bind(Include = "CursoId, NomeCurso, DuracaoCurso, QtdeVagas, DescricaoCurso, Logradouro, Localidade, UF, Cep, Bairro, Numero")] Curso cursoAlterado, int? Professores, int? Categorias, HttpPostedFileBase fupImagem)
        {
            {
                ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
                ViewBag.Professores = new SelectList(ProfessorDAO.RetornarProfessores(), "NumProfessor", "NomeProfessor");
                Curso cursoOriginal = CursoDAO.BuscarCursoPorId(cursoAlterado.CursoId);
                if (ModelState.IsValid)
                {
                    if (Categorias != null)
                    {
                        if (fupImagem != null)
                        {
                            string nomeImagem = Path.GetFileName(fupImagem.FileName);
                            string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);

                            fupImagem.SaveAs(caminho);

                            cursoAlterado.FotoCurso = nomeImagem;
                        }
                        else
                        {
                            cursoAlterado.FotoCurso = "image (1).jpeg";
                        }

                        cursoAlterado.Categoria = CategoriaDAO.BuscarCategoriaPorId(Categorias);
                        cursoOriginal.NomeCurso = cursoAlterado.NomeCurso;
                        cursoOriginal.DescricaoCurso = cursoAlterado.DescricaoCurso;
                        cursoOriginal.DuracaoCurso = cursoAlterado.DuracaoCurso;
                        cursoOriginal.Categoria = cursoAlterado.Categoria;
                        cursoOriginal.Logradouro = cursoAlterado.Logradouro;
                        cursoOriginal.Localidade = cursoAlterado.Localidade;
                        cursoOriginal.Bairro = cursoAlterado.Bairro;
                        cursoOriginal.CEP = cursoAlterado.CEP;
                        cursoOriginal.Numero = cursoAlterado.Numero;
                        cursoOriginal.UF = cursoAlterado.UF;
                        cursoOriginal.QtdeVagas = cursoAlterado.QtdeVagas;
                        cursoOriginal.FotoCurso = cursoAlterado.FotoCurso;
                        cursoOriginal.Professor = cursoAlterado.Professor;
                        if (CursoDAO.AlterarCurso(cursoAlterado))
                        {
                            return RedirectToAction("Index", "Curso");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Não é possível adicionar um curso com o mesmo nome!");
                            return View(cursoAlterado);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Por favor selecione uma categoria!");
                        return View(cursoAlterado);
                    }
                }
                else
                {
                    return View(cursoAlterado);
                }
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

        [HttpPost]
        public ActionResult PesquisarCEP(Curso endereco)
        {
            try
            {
                string url = "https://viacep.com.br/ws/" + endereco.CEP + "/json/";

                WebClient client = new WebClient();
                string json = client.DownloadString(url);
                // Converter string pra UTF-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);
                // Converter json para objeto
                endereco = JsonConvert.DeserializeObject<Curso>(json);

                // Passar informação para qualquer action do controller
                TempData["Curso"] = endereco;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP Inválido!";
            }

            return RedirectToAction("CadastrarCurso", "Curso");
        }

        [HttpPost]
        public ActionResult PesquisarCEPAlterar(Curso endereco)
        {
            try
            {
                string url = "https://viacep.com.br/ws/" + endereco.CEP + "/json/";

                WebClient client = new WebClient();
                string json = client.DownloadString(url);
                // Converter string pra UTF-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);
                // Converter json para objeto
                endereco = JsonConvert.DeserializeObject<Curso>(json);

                // Passar informação para qualquer action do controller
                TempData["Curso"] = endereco;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP Inválido!";
            }

            return RedirectToAction("EditarCurso", "Curso");
        }
    }
}