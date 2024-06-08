using Ahorcado_Services.Modelo.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Aplicacion.DAO
{
    public class EstadoPartidaDAO
    {
        public static readonly AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public static EstadoPartida ObtenerEstadoPartidaPorId(int idEstadoPartida)
        {
            try
            {
                return ahorcadoDbContext.EstadosPartida.Find(idEstadoPartida);
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

        }

        public static List<EstadoPartida> ObtenerEstadosPartida()
        {
            try
            {
                return ahorcadoDbContext.EstadosPartida.ToList();
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static bool AgregarEstadoPartida(EstadoPartida estadoPartida)
        {
            try
            {
                ahorcadoDbContext.EstadosPartida.Add(estadoPartida);
                ahorcadoDbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}