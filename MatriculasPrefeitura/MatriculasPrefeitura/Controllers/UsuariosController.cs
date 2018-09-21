using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MatriculasPrefeitura.Models;
using MatriculasPrefeitura.DAL;
using System.Web.Security;

namespace MatriculasPrefeitura.Controllers
{
    public class UsuariosController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

       
        public ActionResult CadastrarUsuario()
        {
            if (TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View((Usuario)TempData["Usuario"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioDAO.CadastrarUsuario(usuario))
                {
                    return RedirectToAction("Index", "Usuarios");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);
            }

            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            usuario = UsuarioDAO.BuscarUsuarioPorLoginSenha(usuario);
            if (usuario != null)
            {
                // Autenticar
                FormsAuthentication.SetAuthCookie(usuario.Login, true); // false usa sessão, true usa cookie 
                return RedirectToAction("Index", "Curso");
            }
            ModelState.AddModelError("", "O login ou senha não coincidem!");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        
    }
}
