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
    /// Lógica de interacción para BuscarPartidaNueva.xaml
    /// </summary>
    public partial class BuscarPartidaNueva : UserControl
    {
        public bool detenerTarea = false;
        //public Jugador JugadorRetador { get; set; }
        public BuscarPartidaNueva()
        {
            InitializeComponent();
            IniciarActualizacionPartidasPeriodica();        
        }

        private void IniciarActualizacionPartidasPeriodica()
        {
            Task.Run(async () =>
            {
                while (!detenerTarea)
                {
                    var partidas = await ObtenerPartidasListasParaJugar();

                    await Dispatcher.InvokeAsync(() =>
                    {
                        AgregarComponenteHistorial(partidas);
                    });
                    //Duerme la tarea por 10 segundos
                    await Task.Delay(10000);
                }
            });
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            detenerTarea = true;
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menuPrincipal);
        }

        private void LogicaEntrarAPartida()
        {

        }
        
        private async Task<List<Partida>> ObtenerPartidasListasParaJugar() 
        {
            PartidaServiceClient partidaService = new PartidaService.PartidaServiceClient();
            try
            {
                var partidas = await partidaService.ObtenerPartidasListasParaJugarAsync();
                return partidas.ToList();
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox("Error de comunicación con el servidor");
                return null;
            }
            
        }


        private void AgregarComponenteHistorial(List<Partida> partidas)
        {
            WPPanelPartidasNuevas.Children.Clear();
            try
            {
                if (partidas != null)
                {
                    foreach (var partida in partidas)
                    {
                        var jugadorService = new JugadorServiceClient();
                        var jugadorAnfitrion = jugadorService.ObtenerJugadorPorIdAsync(partida.IdJugadorAnfitrion).Result;
                        PartidaNueva partidaHistorial = new PartidaNueva(jugadorAnfitrion.Nombre, partida.Palabra.dificultad.Nombre, partida.Palabra.Categoria.Nombre);
                        WPPanelPartidasNuevas.Children.Add(partidaHistorial);
                    }
                }
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox("Error al cargar las partidas");
            }
            
        }


        private void Click_Jugar(object sender, RoutedEventArgs e)
        {
            detenerTarea = true;
            JugarPartida jugarPartida = new JugarPartida();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(jugarPartida);
        }
    }
}
