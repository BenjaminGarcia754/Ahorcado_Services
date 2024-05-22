using Ahorcado_Services.Modelo.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.DTO_s
{
    public class PartidaDTO
    {
        public int Id { get; set; }

        public int IdJugadorAnfitrion { get; set; }
        public int IdJugadorInvitado { get; set; }

        public int IntentosRestantes { get; set; }

        public int IdPalabraSelecionada { get; set; }

        public String PalabraParcial { get; set; }

        public int IdEstadoPartida { get; set; }

        public bool PartidaGanada { get; set; }

        public EstadoPartida EstadoPartida { get; set; }

        public Palabra Palabra { get; set; }

        public DateTime FechaCreacionPartida { get; set; }
        public string NombreJugadorInvitado { get; set; }
    }
}