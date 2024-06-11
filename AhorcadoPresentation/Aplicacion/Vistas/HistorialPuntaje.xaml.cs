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
    /// Interaction logic for HistorialPuntaje.xaml
    /// </summary>
    public partial class HistorialPuntaje : UserControl
    {
        //private int partidas = 14;
        private JugadorServiceClient jugadorServiceCliente = new JugadorServiceClient();
        public HistorialPuntaje()
        {
            InitializeComponent();
            AgregarComponenteHistorial();
        }

        private void AgregarComponenteHistorial()
        {
            var respuesta = ObtenerPartidasPorJugador(JugadorSingleton.Instance.Id);
            var partidas = respuesta.Partidas;
            
            if (respuesta != null)
            {
                if (respuesta.respuesta)
                {
                    foreach (var partida in partidas)
                    {
                        string fecha = GenericGuiController.FormatearFecha(partida.FechaCreacionPartida);
                        string palabra = partida.palabraSeleccionada;
                        string puntaje = ResourceAccesor.GetString("GuiPuntosGanados");
                        string jugadorVencido = obtenerNombreJugadorVencido(partida.IdJugadorAnfitrion);
                        HistorialPuntos partidaHistorial = new HistorialPuntos(fecha, jugadorVencido, palabra, puntaje);
                        WPPanelPuntos.Children.Add(partidaHistorial);
                    }
                    lPuntaje.Content = partidas.Length * 10;
                }else
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiHistorialNoHayPartidas"));
                    lPuntaje.Content = "0";
                }
            }
            
        }
        private string obtenerNombreJugadorVencido(int idJugador)
        {
            try
            {
                if(idJugador == JugadorSingleton.Instance.Id)
                {
                    return JugadorSingleton.Instance.Nombre;
                }
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
                var partidasTerminadas = partidaServicioCliente.ObtenerPartidasPorJugadorAsync(JugadorSingleton.Instance.Id).Result;
                return partidasTerminadas;
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiErrorComunicacion"));
                return null;
            }
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {  
            HistorialPartidas historialPartidas = new HistorialPartidas();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(historialPartidas);
        }
    }
}
