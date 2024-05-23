using Ahorcado_Services.Infraestructura.Utilidades;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Aplicacion.DAO
{
    public class DificultadDAO
    {
        private static readonly AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public IMapper mapper = AutoMapperHelper.ObtenerMapper();


        public static List<Dificultad> GetDificultades()
        {
            return ahorcadoDbContext.Dificultades.ToList();
        }

        public static Dificultad GetDificultad(int id)
        {
            return ahorcadoDbContext.Dificultades.Find(id);
        }

        public static bool AddDificultad(Dificultad dificultad)
        {
            bool respuesta = true;
            try
            {
                ahorcadoDbContext.Dificultades.Add(dificultad);
                ahorcadoDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }
            return respuesta;
        }
    }
}