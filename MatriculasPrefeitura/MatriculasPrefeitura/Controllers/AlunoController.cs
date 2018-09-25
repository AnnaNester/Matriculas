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
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarAluno()
        {
            if (TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View((Aluno)TempData["Aluno"]);
        }

        [HttpPost]
        public ActionResult CadastrarAluno(Aluno aluno, HttpPostedFileBase fupImagem)
        {
            if (ModelState.IsValid)
            {
                if (fupImagem != null)
                {
                    string nomeImagem = Path.GetFileName(fupImagem.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);
                    fupImagem.SaveAs(caminho);
                    aluno.FotoAluno = nomeImagem;
                }
                else
                {
                    aluno.FotoAluno = "semImagem.jpeg";
                }
                if (AlunoDAO.CadastrarAluno(aluno) == true)
                {
                    ModelState.AddModelError("", "Aluno cadastrado com sucesso!");
                    return View(aluno);
                }
                ModelState.AddModelError("", "Não é possível alterar um aluno com o mesmo CPF!");
                return View(aluno);
            }
            else
            {
                return View(aluno);
            }

        }

        public ActionResult AlterarAluno(int id)
        {
            return View(AlunoDAO.BuscarAlunoPorId(id));
        }

        public ActionResult AlterarAluno(Aluno alunoAlterado)
        {
            Aluno alunoOriginal = AlunoDAO.BuscarAlunoPorId(alunoAlterado.NumAluno);

            alunoOriginal.NomeAluno = alunoAlterado.NomeAluno;
            alunoOriginal.CPFAluno = alunoAlterado.CPFAluno;
            alunoOriginal.CursoMatriculado = alunoAlterado.CursoMatriculado;
            alunoOriginal.FotoAluno = alunoAlterado.FotoAluno;
            alunoOriginal.Localidade = alunoAlterado.Localidade;
            alunoOriginal.Logradouro = alunoAlterado.Logradouro;
            alunoOriginal.Numero = alunoAlterado.Numero;
            alunoOriginal.Bairro = alunoAlterado.Bairro;
            alunoOriginal.CEP = alunoAlterado.CEP;
            alunoOriginal.UF = alunoAlterado.UF;


            if (ModelState.IsValid)
            {
                if (AlunoDAO.AlterarAluno(alunoOriginal))
                {
                    return RedirectToAction("Index", "Aluno");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar um aluno com o mesmo nome!");
                    return View(alunoOriginal);
                }
            }
            else
            {
                return View(alunoOriginal);
            }
        }


        public ActionResult ExcluirAluno(int id)
        {
            AlunoDAO.ExcluirAluno(id);
            return RedirectToAction("Index", "Aluno");
        }

        [HttpPost]
        public ActionResult PesquisarCEP(Aluno aluno)
        {
            try
            {
                string url = "https://viacep.com.br/ws/" + aluno.CEP + "/json/";

                WebClient client = new WebClient();
                string json = client.DownloadString(url);
                // Converter string pra UTF-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);
                // Converter json para objeto
                aluno = JsonConvert.DeserializeObject<Aluno>(json);

                // Passar informação para qualquer action do controller
                TempData["Aluno"] = aluno;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP Inválido!";
            }

            return RedirectToAction("CadastrarAluno", "Aluno");

        }

    }
}