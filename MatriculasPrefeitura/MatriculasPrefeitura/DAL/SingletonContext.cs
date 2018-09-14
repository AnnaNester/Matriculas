using MatriculasPrefeitura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatriculasPrefeitura.DAL
{
    public class SingletonContext
    {
        private static Context context;

        private SingletonContext() { }

        public static Context GetInstance()
        {
            if (context == null)
            {
                context = new Context();
            }
            return context;
        }
    }
}