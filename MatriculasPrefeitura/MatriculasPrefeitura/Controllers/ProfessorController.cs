using MatriculasPrefeitura.Models;
using MatriculasPrefeitura.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MatriculasPrefeitura.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        public ActionResult Index()
        {
            return View();
        }
        // [HttpPost]
        public ActionResult CadastrarProfessor(Professor professor, HttpPostedFileBase fupImagem)
        {
            if (ModelState.IsValid)
            {
                if (fupImagem != null)
                {
                    string nomeImagem = Path.GetFileName(fupImagem.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);
                    fupImagem.SaveAs(caminho);
                    professor.FotoProfessor = nomeImagem;
                }
                else
                {
                    professor.FotoProfessor = "semImagem.jpg"; // ENCONTRAR FOTO SEM NADA PRA COLOCAR AQUI
                }

                return View(professor);
            }
            else
            {
                return View(professor);
            }

        }

        public ActionResult AlterarProfessor(int id)
        {
            return View(ProfessorDAO.BuscarProfessorPorId(id));
        }

        public ActionResult AlterarProfessor(Professor professorAlterado)
        {
            Professor professorOriginal = ProfessorDAO.BuscarProfessorPorId(professorAlterado.NumProfessor);

            professorOriginal.NomeProfessor = professorAlterado.NomeProfessor;
            professorOriginal.CPFProfessor = professorAlterado.CPFProfessor;
            professorOriginal.FormacaoProfessor = professorAlterado.FormacaoProfessor;
            professorOriginal.CursoLeciona = professorAlterado.CursoLeciona;
            professorOriginal.FotoProfessor = professorAlterado.FotoProfessor;
            professorOriginal.EnderecoProfessor = professorAlterado.EnderecoProfessor;


            if (ModelState.IsValid)
            {
                if (ProfessorDAO.AlterarProfessor(professorOriginal))
                {
                    return RedirectToAction("Index", "Professor");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar um professor com o mesmo nome!");
                    return View(professorOriginal);
                }
            }
            else
            {
                return View(professorOriginal);
            }
        }


        public ActionResult ExcluirProfesssor(int id)
        {
            ProfessorDAO.ExcluirProfessor(id);
            return RedirectToAction("Index", "Professor");
        }

        [HttpPost]
        public ActionResult PesquisarCEP(Professor professor)
        {
            try
            {
                string url = "https://viacep.com.br/ws/" + professor.EnderecoProfessor + "/json/";

                WebClient client = new WebClient();
                string json = client.DownloadString(url);
                // Converter string pra UTF-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);
                // Converter json para objeto
                professor = JsonConvert.DeserializeObject<Professor>(json);

                // Passar informação para qualquer action do controller
                TempData["Professor"] = professor;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP Inválido!";
            }

            return RedirectToAction("CadastrarProfessor", "Professor");
        }
    }
}