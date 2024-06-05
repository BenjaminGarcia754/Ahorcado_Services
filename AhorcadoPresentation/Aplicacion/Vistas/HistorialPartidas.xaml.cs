using AhorcadoPresentation.Modelo.Singleton;
using JugadorServiceReference;
using PartidaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AhorcadoPresentation.Aplicacion.Vistas
{
    /// <summary>
    /// Interaction logic for HistorialPartidas.xaml
    /// </summary>
    public partial class HistorialPartidas : UserControl
    {
        public HistorialPartidas()
        {
            InitializeComponent();
            AgregarComponenteHistorial();
        }

        private void AgregarComponenteHistorial()
        {

            var respuesta = ObtenerPartidasPorJugador(JugadorSingleton.Instance.Id);
            if (respuesta != null)
            {
                if (respuesta.respuesta)
                {
                    List<Partida> partidas = respuesta.Partidas.ToList();
                    List<PartidaService.Jugador> jugadores = respuesta.Jugadores.ToList();

                    for (int i = 0; i < partidas.Count; i++)
                    {
                        Partida partida = partidas[i];
                        PartidaService.Jugador jugadorContrincante = jugadores[i];
                        string fecha = partida.FechaCreacionPartida.ToString();
                        string usuarioContrincante = jugadorContrincante.Nombre;
                        string palabra = "";
                        string resultado = partida.PartidaGanadaJugadorInvitado ? "Ganada" : "Perdida";
                        string puntaje = "No soportado";

                        Historial partidaHistorial = new Historial(fecha, usuarioContrincante, palabra, resultado, puntaje);
                        WPPanelPartidas.Children.Add(partidaHistorial);
                    }
                }else
                {
                    GenericGuiController.MostrarMensajeBox("No se encontraron partidas");
                }
                
            }
            
        }

        private PartidaRespuesta ObtenerPartidasPorJugador(int idJugador)
        {
            try
            {
                var partidaServicioCliente = new PartidaServiceClient();
                var partidasTerminadas = partidaServicioCliente.ObtenerTodasLasPartidasPorJugadorAsync(JugadorSingleton.Instance.Id).Result;
                return partidasTerminadas;
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox("Error de comunicación con el servidor");
                return null;
            }
        }

        private void ClickConsultarPuntaje(object sender, RoutedEventArgs e)
        {
            HistorialPuntaje historialPuntaje = new HistorialPuntaje();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(historialPuntaje);
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menuPrincipal);
        }
    }
}
