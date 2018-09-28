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
                    curso.Professor = ProfessorDAO.BuscarProfessorPorId(Professores);
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
            Curso curso = CursoDAO.BuscarCursoPorId(id);
            ViewBag.Categorias = new SelectList(CategoriaDAO.RetornarCategoria(), "CategoriaId", "NomeCategoria");
            ViewBag.Professores = new SelectList(ProfessorDAO.RetornarProfessores(), "NumProfessor", "NomeProfessor");
            return View(curso);
        }

        [HttpPost]
        public ActionResult AlterarCurso([Bind(Include = "NumProfessor, CategoriaId, CursoId, NomeCurso, DescricaoCurso, DuracaoCurso, QtdeVagas, CEP, Logradouro, Localidade, Bairro, UF, Numero")]
        Curso cursoAlterado, int? Professores, int? Categorias)
        {
            if (ModelState.IsValid)
            {
                Curso cursoOriginal = CursoDAO.BuscarCursoPorId(cursoAlterado.CursoId);
                cursoOriginal.NomeCurso = cursoAlterado.NomeCurso;
                cursoAlterado.DescricaoCurso = cursoAlterado.DescricaoCurso;
                cursoOriginal.DuracaoCurso = cursoAlterado.DuracaoCurso;
                cursoOriginal.QtdeVagas = cursoAlterado.QtdeVagas;
                cursoAlterado.FotoCurso = cursoOriginal.FotoCurso;
                cursoAlterado.CEP = cursoOriginal.CEP;
                cursoAlterado.Logradouro = cursoOriginal.Logradouro;
                cursoAlterado.Localidade = cursoOriginal.Localidade;
                cursoAlterado.Bairro = cursoOriginal.Bairro;
                cursoAlterado.UF = cursoOriginal.UF;
                cursoAlterado.Numero = cursoOriginal.Numero;
                cursoAlterado.Categoria = cursoOriginal.Categoria;
                cursoAlterado.Professor = cursoOriginal.Professor;


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

        public ActionResult Matriculas(Curso curso)
        {
            return ViewBag.Alunos = CursoDAO.ListarAlunos(curso.CursoId);
        }
    }
}