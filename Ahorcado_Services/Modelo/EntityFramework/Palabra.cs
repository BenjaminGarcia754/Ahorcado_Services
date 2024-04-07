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
        public int IdSubcategoria { get; set; }
        [Required]
        public Subcategoria subcategoria { get; set; }
        [Required]
        public int IdDificultad { get; set; }
        public Dificultad dificultad { get; set; }
        
        
    }
}