using Ahorcado_Services.Modelo.EntityFramework;
using Ahorcado_Services.Modelo.Respuestas;
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

        public static PartidaRespuesta ObtenerPartidasJugadasPorJugador(int IdJugador)
        {
            
            try
            {
                PartidaRespuesta partidasTerminadas = new PartidaRespuesta();
                List<Partida> partidas = ahorcadoDbContext.Partidas.Where(p => p.IdJugadorInvitado == IdJugador && p.PartidaGanadaJugadorInvitado == true).ToList();
                partidasTerminadas.Partidas = partidas;
                if (partidas.Count > 0)
                {
                    partidasTerminadas.respuesta = true;
                    return partidasTerminadas;
                }
                else
                {
                    partidasTerminadas.respuesta = false;
                    return partidasTerminadas;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static PartidaRespuesta ObtenerTodasLasPartidasPorJugador(int IdJugador)
        {
            PartidaRespuesta partidasTerminadas = new PartidaRespuesta();
            try
            {
                var Partidas = ahorcadoDbContext.Partidas.Where(p => p.IdJugadorAnfitrion == IdJugador || p.IdJugadorInvitado ==IdJugador);
                if (Partidas != null)
                {
                    partidasTerminadas.respuesta = true;
                    partidasTerminadas.Partidas = Partidas.ToList();
                    return partidasTerminadas;
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

        public static bool ActualizarPartida(Partida partida)
        {
            bool respuesta = true;
            try
            {
                ahorcadoDbContext.Partidas.Update(partida);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }
            return respuesta;
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
                Console.WriteLine(ex.Message);
                respuesta = false;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                respuesta = false;
            }
            return respuesta;
        }

        //Partidas disponibles para jugar
        public static List<Partida> ObtenerPartidasListasParaJugar()
        {
            List<Partida> partidas = new List<Partida>();
            try
            {
                partidas = ahorcadoDbContext.Partidas.Where(p => p.IdEstadoPartida == 1).ToList();               
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                partidas = null;
            }
            return partidas;
        }

        public static PartidaRespuesta RealizarIntento(Partida partida, char caracterIntento)
        {
            PartidaRespuesta respuesta = new PartidaRespuesta();
            if (partida.palabraSeleccionada.Contains(caracterIntento))
            {
                for (int i = 0; i < partida.palabraSeleccionada.Length; i++)
                {
                    if (partida.palabraSeleccionada.ToLower().ToCharArray()[i] == caracterIntento)
                    {
                        partida.PalabraParcial.ToCharArray()[i] = caracterIntento;
                    }
                }
                respuesta.partida = partida;
                respuesta.respuesta = true;
            }
            else
            {
                respuesta.respuesta = false;
                partida.IntentosRestantes--;
                respuesta.partida = partida;

            }

            return respuesta;
        }

        public static PartidaRespuesta ObtenerPartida(int IdPartida)
        {
            PartidaRespuesta respuesta = new PartidaRespuesta();
            try
            {
                Partida partida = ahorcadoDbContext.Partidas.Find(IdPartida);
                if (partida != null)
                {
                    respuesta.partida = partida;
                    respuesta.respuesta = true;
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                respuesta.respuesta = false;
            }
            return respuesta;
        }
    }

 
}