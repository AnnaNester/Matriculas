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

namespace MatriculasPrefeitura.Controllers
{
    public class CursoAPIController : ApiController
    {
        private Context db = new Context();

        // GET: api/CursoAPI
        public IQueryable<Curso> GetCursos()
        {
            return db.Cursos;
        }

        // GET: api/CursoAPI/5
        [ResponseType(typeof(Curso))]
        public IHttpActionResult GetCurso(int id)
        {
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // PUT: api/CursoAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurso(int id, Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curso.CursoId)
            {
                return BadRequest();
            }

            db.Entry(curso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CursoAPI
        [ResponseType(typeof(Curso))]
        public IHttpActionResult PostCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cursos.Add(curso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = curso.CursoId }, curso);
        }

        // DELETE: api/CursoAPI/5
        [ResponseType(typeof(Curso))]
        public IHttpActionResult DeleteCurso(int id)
        {
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            db.Cursos.Remove(curso);
            db.SaveChanges();

            return Ok(curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CursoExists(int id)
        {
            return db.Cursos.Count(e => e.CursoId == id) > 0;
        }
    }
}