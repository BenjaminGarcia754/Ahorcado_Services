using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.EntityFramework
{
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdJugadorAnfitrion { get; set; }
        public int IdJugadorInvitado { get; set; }
        [Required]
        public int IntentosRestantes { get; set; }
        [Required]
        public int IdPalabraSelecionada { get; set; }
        [Required]
        public String PalabraParcial { get; set; }
        [Required]
        public int IdEstadoPartida { get; set; }
        public string IdiomaPartida { get; set; }

        public bool PartidaGanadaJugadorInvitado { get; set; }
        public bool PartidaGanadaJugadorAnfitrion { get; set; }
        public string palabraSeleccionada { get; set; }

        public EstadoPartida EstadoPartida { get; set; }

        public Palabra Palabra { get; set; }

        public DateTime FechaCreacionPartida { get; set; }
    }
}