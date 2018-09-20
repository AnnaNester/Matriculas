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

        // [HttpPost]
        public ActionResult CadastrarAluno(Aluno aluno, HttpPostedFileBase fupImagem)
        {
            if (ModelState.IsValid)
            {
                if(fupImagem != null)
                {
                    string nomeImagem = Path.GetFileName(fupImagem.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);
                    fupImagem.SaveAs(caminho);
                    aluno.FotoAluno = nomeImagem;
                }
                else
                {
                    aluno.FotoAluno = "semImagem.jpg"; // ENCONTRAR FOTO SEM NADA PRA COLOCAR AQUI
                }

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
            alunoOriginal.EnderecoAluno = alunoAlterado.EnderecoAluno;
            

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
                string url = "https://viacep.com.br/ws/" + aluno.EnderecoAluno + "/json/";

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