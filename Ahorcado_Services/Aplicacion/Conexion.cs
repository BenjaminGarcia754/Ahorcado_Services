using Ahorcado_Services.Modelo.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Aplicacion
{
    public class Conexion
    {
        private static readonly AhorcadoDbContext ahorcadoDbContext = CrearInstancia();

        public static AhorcadoDbContext ObtenerConexion => ahorcadoDbContext;

        private static AhorcadoDbContext CrearInstancia()
        {
            DbContextOptions<AhorcadoDbContext> opciones = new DbContextOptionsBuilder<AhorcadoDbContext>()
                .UseSqlServer("Cadena de conexion")
                .Options;

            return new AhorcadoDbContext(opciones);
        }
    }
}