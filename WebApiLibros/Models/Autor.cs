using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiLibros.Validations; //agregar

namespace WebApiLibros.Models
{
    [Table("Autor")]

    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "El Nombre es campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        //[Range(18,120, ErrorMessage = "Edad inválidad")]
        public int? Edad { get; set; }

        [FechaDeNacimiento]
        public DateTime FechaNacimiento { get; set; }
        public List<Libro> Libros{ get; set; }
        

    }
}
