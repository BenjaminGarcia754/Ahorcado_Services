using Ahorcado_Services.Aplicacion.DAO;
using Ahorcado_Services.Modelo.EntityFramework;
using Ahorcado_Services.Modelo.Respuestas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PartidaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PartidaService.svc o PartidaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PartidaService : IPartidaService
    {
        AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public List<Partida> ObtenerPartidasDisponibles()
        {
            return null;
        }

        public PartidaRespuesta ObtenerPartidasPorJugador(int IdJugador)
        {
            PartidaRespuesta partidasTerminadas = new PartidaRespuesta();
            List<Partida> partidas = PartidaDAO.ObtenerTodasLasPartidas(IdJugador);
            List<Jugador> jugadores = new List<Jugador>();
            foreach (Partida partida in partidas)
            {
                if (partida.IdJugadorAnfitrion == IdJugador)
                {
                    jugadores.Add(JugadorDAO.ObtenerJugador(partida.IdJugadorInvitado));
                }
                else
                {
                    jugadores.Add(JugadorDAO.ObtenerJugador(partida.IdJugadorAnfitrion));
                }
            }
            //Mostrar en un mensaje box las partidas
            partidasTerminadas.Partidas = partidas;
            partidasTerminadas.Jugadores = jugadores;
            if (partidas.Count > 0)
            {
                return partidasTerminadas;
            }
                return null;
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
                respuesta.
            }
            else
            {
                partida.IntentosRestantes--;
            }

            return partida;
        }
    }
}
