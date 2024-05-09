using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoPresentation.Modelo.Singleton
{
    internal class JugadorSingleton
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int Rol { get; set; }
        public string Teleforno { get; set; }
        public int puntaje { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}
