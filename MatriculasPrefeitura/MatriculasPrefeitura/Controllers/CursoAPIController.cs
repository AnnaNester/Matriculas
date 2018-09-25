using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MatriculasPrefeitura.Models;
using MatriculasPrefeitura.DAL;

namespace MatriculasPrefeitura.Controllers
{
    [RoutePrefix("api/Curso")]
    public class CursoAPIController : ApiController
    {
        private Context db = new Context();

        [Route("Produtos")]
        public List<Curso> GetCursos() 
        {
            return CursoDAO.RetornarCursos();
        }

        [Route("ProdutosPorCategoria/{categoriaId}")]
        public List<Curso> GetCursosPorCategoria(int categoriaId) // mesmo nome que foi definido acima
        {
            return CursoDAO.BuscarCursoPorCategoria(categoriaId);
        }

        // GET: api/Produto/ProdutoPorId/5 exemplo
        [Route("ProdutoPorId/{produtoId}")]
        public dynamic GetCursoPorId(int cursoId) // dynamic: qualquer coisa de qualquer jeito
        {
            Curso curso = CursoDAO.BuscarCursoPorId(cursoId);
            if (curso != null)
            {
                // Entregar dados
                dynamic cursoDinamico = new
                {
                    Nome = curso.NomeCurso,
                    Duração = curso.DuracaoCurso,
                    Categoria = curso.Categoria.NomeCategoria,
                };

                return new { Curso = cursoDinamico }; // dar nome ao objeto dinâmico
            }
            return NotFound(); // retornar código http ao usuário
        }


        // POST: api/Produto/CadastrarProduto
        [Route("CadastrarProduto")]
        public IHttpActionResult PostCadastrarCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (CursoDAO.CadastrarCurso(curso))
            {
                return Created("", curso);
            }
            else
            {
                return Conflict();
            }
        }
    }


}