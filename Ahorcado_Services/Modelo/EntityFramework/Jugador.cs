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
        //TODO: Modificar el mapeo en la bd de modo que solo se guarden los ID mas no la relacion entre las tablas como llaves foraneas

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public int Rol { get; set;}
        [Required]
        public string Telefono { get; set; }
        [Required]
        public int Puntaje { get; set; }

    }
}