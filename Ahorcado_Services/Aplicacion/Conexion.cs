using Ahorcado_Services.Modelo.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionLocal"].ConnectionString;
            DbContextOptions<AhorcadoDbContext> opciones = new DbContextOptionsBuilder<AhorcadoDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new AhorcadoDbContext(opciones);
        }
    }
}