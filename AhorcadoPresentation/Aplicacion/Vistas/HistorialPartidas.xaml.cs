using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.RecursosLocalizables;
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
        private JugadorServiceClient jugadorServiceCliente = new JugadorServiceClient();
        private PalabraService.PalabraServiceClient palabraServiceCliente = new PalabraService.PalabraServiceClient();
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
                if (respuesta.respuesta && respuesta.Partidas.Any())
                {
                    List<Partida> partidas = respuesta.Partidas.ToList();

                    for (int i = 0; i < partidas.Count; i++)
                    {
                        Partida partida = partidas[i];
                        if (!(partida.IdEstadoPartida == 1 || partida.IdEstadoPartida == 2))
                        {
                            if(partida.IdEstadoPartida == 1)
                                GenericGuiController.MostrarMensajeBox("id estado partida tengo" + partida.IdEstadoPartida);
                            if(partida.IdEstadoPartida == 2)
                                GenericGuiController.MostrarMensajeBox("id estado partida tengo" + partida.IdEstadoPartida);
                            string fecha = GenericGuiController.FormatearFecha(partida.FechaCreacionPartida);
                            string palabra = partida.palabraSeleccionada;
                            string jugadorVencido = "---";
                            string resultado = ResourceAccesor.GetString("GuiHistorialCancelada");//Cancelada
                            string puntaje = "---";
                            if (partida.PartidaGanadaJugadorInvitado)
                            {
                                jugadorVencido = obtenerNombreJugadorVencido(partida.IdJugadorInvitado);
                                resultado = ResourceAccesor.GetString("GuiHistorialGanada"); //Ganada
                                puntaje = ResourceAccesor.GetString("GuiPuntosGanados");
                            }
                            else if (partida.PartidaGanadaJugadorAnfitrion)
                            {
                                jugadorVencido = obtenerNombreJugadorVencido(partida.IdJugadorAnfitrion);
                                resultado = ResourceAccesor.GetString("GuiHistorialPerdido");//perdida
                                puntaje = ResourceAccesor.GetString("GuiPuntosPerdido");
                            }
                            Historial partidaHistorial = new Historial(fecha, jugadorVencido, palabra, resultado, puntaje);
                            WPPanelPartidas.Children.Add(partidaHistorial);
                        }
                    }
                }else
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("MsgNoPartidas"));
                }
                
            }
            
        }

        private string obtenerNombreJugadorVencido(int idJugador)
        {
            try
            {
                var jugador = jugadorServiceCliente.ObtenerJugadorPorIdAsync(idJugador).Result;
                return jugador.Nombre;
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiErrorComunicacion"));
                return null;
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
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiErrorComunicacion"));
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
