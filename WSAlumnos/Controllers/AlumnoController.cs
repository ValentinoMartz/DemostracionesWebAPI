using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WSAlumnos.Models;
using System.Linq;

namespace WSAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private List<Alumno> Listado()
        {
            List<Alumno> alumnos = new List<Alumno>() {
                new Alumno() { Id =1, Apellido="Martinez", Nombre="Valentino"},
                new Alumno() { Id =2, Apellido="Riquelme", Nombre="Juan Roman"},
                new Alumno() { Id =3, Apellido="Lanogni", Nombre="Luca"}
            };
            return alumnos;
        }

        //GET api/Alumno
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return Listado(); 
        }

        //GET BY ID api/Alumno
        [HttpGet("{id}")]
        public ActionResult<Alumno> GetById(int id)
        {
            Alumno alumno = (from a in Listado()
                          where a.Id == id
                          select a).SingleOrDefault();
            return alumno;
        }
    }
}
