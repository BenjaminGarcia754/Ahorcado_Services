using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoPresentation.Modelo.Singleton
{
    internal class PartidaSingleton
    {
        public int IdPartida { get; set; }
        public int IdJugadorAnfitrion { get; set; }
        public int IdJugadorInvitado { get; set; }
        public int IdPalabraSeleccionada { get; set; }
        public string PalabraParcial { get; set; }
        public int IntentosRestantes{ get; set; }
        public int idEstadoPartida { get; set; }
        public DateTime FechaCreacionPartida { get; set; }
    }
}
