using Ahorcado_Services.Modelo.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Aplicacion.DAO
{
    public class PartidaDAO
    {
        public static readonly AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public static List<Partida> ObtenerTodasLasPartidas(int IdJugador)
        {
            try
            {
                var Partidas = ahorcadoDbContext.Partidas.Where(p => p.IdJugadorAnfitrion == IdJugador || p.IdJugadorInvitado ==IdJugador);
                if (Partidas != null)
                {
                    return Partidas.ToList();
                }
            }
            catch (DbUpdateException ex)
            {
                ex.Source = "Error al obtener las partidas terminadas";
            }
            catch (EntityException ex)
            {
                ex.Source = "Error al obtener las partidas terminadas EntityExcepction";
            }
            return null;
        }

        public static bool CrearPartida(Partida partida)
        {
            bool respuesta = true;
            try
            {
                ahorcadoDbContext.Partidas.Add(partida);
                ahorcadoDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {

                respuesta = false;
            }
            catch (EntityException ex)
            {
                respuesta = false;
            }
            catch (Exception ex)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public static List<Partida> ObtenerPartidasListasParaJugar()
        {
            List<Partida> partidas = new List<Partida>();
            try
            {
                partidas = ahorcadoDbContext.Partidas.Where(p => p.IdEstadoPartida == 1).ToList(); //Cambiar por el escojido para partida pendiente
              
            }
            catch (EntityException ex)
            {
                partidas = null;
            }
            return partidas;
        }    
    }

 
}