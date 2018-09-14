using MatriculasOsorio.Models;
using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.DAL
{
    public class UsuarioDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Usuario> RetonarUsuarios()
        {
            return context.Usuarios.ToList();
        }

        public static Usuario BuscarUsuarioPorLogin(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Login.Equals(usuario.Login));
        }

        public static bool CadastrarUsuario(Usuario usuario)
        {
            if (BuscarUsuarioPorLogin(usuario) == null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Usuario BuscarUsuarioPorLoginSenha(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Login.Equals(usuario.Login) && x.Senha.Equals(usuario.Senha));
        }
    }
}