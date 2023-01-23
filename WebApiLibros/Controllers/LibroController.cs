
using WebApiLibros.Models;
using WebApiLibros.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;
using System;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        //Agregar un nuevo api controller: “LibroController”

        //Programar las siguientes acciones:
        //GET—> traer todos los libros
        //GET—>traer todos los libros por autorId
        //GET→ Traer uno por Id
        //POST→Insertar libros, retornar un Ok()
        //PUT→modificar libro, pasado id y modelo.retornar un NoContent()
        //DELETE —>Eliminar libro.Retornar el libro eliminado

        //Tarea 2
        //Realizar las pruebas en Postman.
        //Preparar una colección de request.
        //Compartir un imagen por cada acción en la prueba

        private readonly DBLibrosBootcampContext context;

        //constructor
        public LibroController(DBLibrosBootcampContext contex)
        {
            this.context = contex;
        }

        //GET: api/libros
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }

        //GET AUTOR ID 
        [HttpGet("autores/{autorId}")]
        public ActionResult<Libro> GetbyAutorId(int autorId)
        {
            Libro libro = (from a in context.Libros
                           where a.AutorId == autorId
                           select a).SingleOrDefault();
            return libro;
        }

        //GET ID 
        [HttpGet("{id}")]
        public ActionResult<Libro> GetbyId(int id)
        {
            Libro libro = (from a in context.Libros
                           where a.Id == id
                           select a).SingleOrDefault();
            return libro;
        }

        //Insert
        //POST 
        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }

        //UPDATE
        //PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }
            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //DELETE api/autor/3 --> /id
        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id)
        {
            var libro = (from a in context.Libros
                         where a.Id == id
                         select a).SingleOrDefault();

            if (libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(libro);
            context.SaveChanges();
            return libro;
        }

    }
}
