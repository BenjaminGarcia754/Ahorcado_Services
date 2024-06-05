using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AhorcadoPresentation.Modelo.Singleton
{
    internal class PartidaSingleton
    {
        private static PartidaSingleton instance;
        private static readonly object lockObject = new object();

        public int Id { get; set; }
        public int IdJugadorAnfitrion { get; set; }
        public int IdJugadorInvitado { get; set; }
        public int IntentosRestantes { get; set; }
        public int IdPalabraSelecionada { get; set; }
        public String PalabraParcial { get; set; }
        public int IdEstadoPartida { get; set; }

        public bool PartidaGanadaJugadorInvitado { get; set; }
        public bool PartidaGanadaJugadorAnfitrion { get; set; }
        public string palabraSeleccionada { get; set; }

        public DateTime FechaCreacionPartida { get; set; }

        private PartidaSingleton()
        {
            // Constructor privado para prevenir instanciación externa
        }

        public static PartidaSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new PartidaSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
