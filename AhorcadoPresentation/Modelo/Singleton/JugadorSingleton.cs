using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoPresentation.Modelo.Singleton
{
    internal class JugadorSingleton
    {
        private static JugadorSingleton instance;
        private static readonly object lockObject = new object();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int Rol { get; set; }
        public string Telefono { get; set; }
        public int puntaje { get; set; }
        public DateTime fechaDeNacimiento { get; set; }

        private JugadorSingleton()
        {
            // Private constructor to prevent instantiation
        }

        public static JugadorSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new JugadorSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }



}
