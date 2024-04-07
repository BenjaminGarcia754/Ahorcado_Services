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
        public String PalabraSelecionada { get; set; }
        [Required]
        public String EstadoPalabra { get; set; }
        [Required]
        public String EstadoPartida { get; set; }/*Creada, Aceptada ,En curso, Ganada, Perdida*/

        [ForeignKey("IdJugadorAnfitrion")]
        public Jugador JugadorAnfitrion { get; set; }
        [ForeignKey("IdJugadorInvitado")]
        public Jugador JugadorInvitado { get; set; }
        public Palabra Palabra { get; set; }

    }
}