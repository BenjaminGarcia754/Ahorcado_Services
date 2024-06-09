using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.EntityFramework
{
    public class Palabra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NombreIngles { get; set; }

        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string DescripcionIngles { get; set; }
     
        [Required]
        public int IdCategoria { get; set; }
        [Required]
        public Categoria Categoria { get; set; }
        [Required]
        public int IdDificultad { get; set; }
        public Dificultad dificultad { get; set; }

    }
}