using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.EntityFramework
{
    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public int Rol { get; set;}
        [Required]
        public string Telefono { get; set; }
        public int Puntaje { get; set; }
        [Required]
        public string Username { get; set; }
    }
}