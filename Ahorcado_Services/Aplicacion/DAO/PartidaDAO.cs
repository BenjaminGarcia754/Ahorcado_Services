using Ahorcado_Services.Modelo.EntityFramework;
using Ahorcado_Services.Modelo.Respuestas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

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

        public static async Task<bool> ActualizarPartidaAsync(Partida partida)
        {
            using (var context = new AhorcadoDbContext())
            {
                //Desvincular cualquier instancia previa de la entidad
                var local = context.Partidas.Local.FirstOrDefault(p => p.Id == partida.Id);
                if (local != null)
                {
                    context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                }

                // Adjuntar y marcar la nueva instancia como modificada
                context.Partidas.Attach(partida);
                context.Entry(partida).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                // Guardar los cambios
                return await context.SaveChangesAsync() > 0;
            }
        }

        public static Partida CrearPartida(Partida partida)
        {
            try
            {
                ahorcadoDbContext.Partidas.Add(partida);
                ahorcadoDbContext.SaveChanges();
                return partida;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
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
            char[] palabraParcial = partida.PalabraParcial.ToCharArray();
            if (partida.palabraSeleccionada.Contains(caracterIntento))
            {
                for (int i = 0; i < partida.palabraSeleccionada.Length; i++)
                {
                    if (partida.palabraSeleccionada.ToLower().ToCharArray()[i] == caracterIntento)
                    {
                        palabraParcial[i] = caracterIntento;
                    }
                }
                partida.PalabraParcial = new string(palabraParcial);
                respuesta.partida = partida;
                respuesta.respuesta = true;
            }
            else
            {
                respuesta.respuesta = false;
                partida.IntentosRestantes++;
                respuesta.partida = partida;
            }

            return respuesta;
        }

        public static async Task<PartidaRespuesta> ObtenerPartida(int IdPartida)
        {
            using (var ahorcadoDbContext = new AhorcadoDbContext())
            {
                var partida = await ahorcadoDbContext.Partidas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == IdPartida);
                return new PartidaRespuesta { partida = partida, respuesta = true };
            }    
        }
    }

 
}