using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    // api/autor
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //propiedad
        private readonly DBLibrosBootcampContext context;

        //constructor
        public AutorController(DBLibrosBootcampContext contex)
        {
            this.context = contex;
        }

        //GET: api/autor
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            //return context.Autores.ToList();
            var result = context.Autores.Include(x => x.Libros).ToList();
            return result;
        }

        //GET api/autor/5 --> /id
        [HttpGet("{id}")]
        public ActionResult<Autor> GetbyId(int id)
        {
            Autor autor = (from a in context.Autores
                           where a.IdAutor == id
                           select a).SingleOrDefault();
            return autor;
        }

        //GET por edad api/autor/50 --> /edad
        [HttpGet("listado/{edad}")]
        public ActionResult<IEnumerable<Autor>> GetEdad(int edad)
        {
            List <Autor> autorList = (from a in context.Autores
                           where a.Edad == edad
                           select a).ToList();
            return autorList;
        }

        //Insert
        //POST api/autor
        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Autores.Add(autor);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE
        //PUT api/autor/2 ---> /id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return BadRequest();
            }
            context.Entry(autor).State = EntityState.Modified;//ver esto
            context.SaveChanges();
            return Ok();
        }

        //DELETE api/autor/3 --> /id
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = (from a in context.Autores
                         where a.IdAutor == id
                         select a).SingleOrDefault();
            
            if (autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }
        
    }
}
