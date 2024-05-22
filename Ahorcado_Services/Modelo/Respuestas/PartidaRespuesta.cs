using Ahorcado_Services.Modelo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.Respuestas
{
    public class PartidaRespuesta
    {
        public List<Partida> Partidas { get; set; }
        public List<Jugador> Jugadores { get; set; }
    }
}