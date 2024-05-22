using AhorcadoPresentation.Modelo.Singleton;
using JugadorServiceReference;
using PartidaService;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var PartidaServicioCliente = new PartidaServiceClient();
            var PartidasTerminadas = PartidaServicioCliente.ObtenerTodasLasPartidasAsync(JugadorSingleton.Instance.Id).Result;
            List<Partida> partidas = (List<Partida>)PartidasTerminadas["partidas"];
            List<Jugador> jugadores = (List<Jugador>)PartidasTerminadas["jugadores"]; 

            for (int i = 0; i < partidas.Count; i++)
            {
                Partida partida = partidas[i];
                Jugador jugadorContrincante = jugadores[i];
                string fecha = partida.FechaCreacionPartida.ToString();
                string usuarioContrincante = jugadorContrincante.Nombre;
                string palabra = partida.Palabra.ToString();
                string resultado = partida.PartidaGanada.ToString();
                string puntaje = "No soportado";

                Historial partidaHistorial = new Historial(fecha, usuarioContrincante, palabra, resultado, puntaje);
                WPPanelPartidas.Children.Add(partidaHistorial);
            }
            //{
            //    //string fecha = DateTime.Now.ToShortDateString();
            //    //string usuarioContrincante = "Usuario" + i;
            //    //string palabra = "Palabra" + i;
            //    //string resultado = "Ganada";
            //    //string puntaje = "10";


            //    Historial partidaHistorial = new Historial(partida.FechaCreacionPartida.ToString(), partida.IdJugadorAnfitrion.ToString(), partida.Palabra.ToString(), partida.PartidaGanada.ToString(), "No soportado");
            //    WPPanelPartidas.Children.Add(partidaHistorial);
            //}
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
