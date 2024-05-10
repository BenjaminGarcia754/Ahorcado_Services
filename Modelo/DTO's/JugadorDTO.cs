using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.DTO_s
{
    public class JugadorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int Rol { get; set; }
        public string Teleforno { get; set; }
        public int puntaje { get; set; }
    }
}