using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.Utils
{
    public class Sessao
    {
        private static string NOME_SESSAO = "Login";

        public static string RetornarLogin()
        {
            if (HttpContext.Current.Session[NOME_SESSAO] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[NOME_SESSAO] = guid.ToString();
            }
            return HttpContext.Current.Session[NOME_SESSAO].ToString();
        }
    }
}