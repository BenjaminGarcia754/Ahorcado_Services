using AhorcadoPresentation.RecursosLocalizables;
using CategoriaService;
using DificultadService;
using JugadorServiceReference;
using PalabraService;
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
                    var mainWindow = (MainWindow)Window.GetWindow(this);
                    PartidaNueva partidaNueva = new PartidaNueva(mainWindow);
                    foreach (var partida in partidas)
                    {
                        PalabraServiceClient palabraServiceClient = new PalabraServiceClient();
                        DificultadServiceClient dificultadServiceClient = new DificultadServiceClient();
                        CategoriaServiceClient categoriaServiceClient = new CategoriaServiceClient();
                        var palabra = palabraServiceClient.ObtenerPalabraAsync(partida.IdPalabraSelecionada).Result;
                        var categoria = categoriaServiceClient.GetCategoriaAsync(palabra.IdCategoria).Result;
                        var dificultad = dificultadServiceClient.GetDificultadAsync(palabra.IdDificultad).Result;
                        var jugadorService = new JugadorServiceClient();
                        var jugadorAnfitrion = jugadorService.ObtenerJugadorPorIdAsync(partida.IdJugadorAnfitrion).Result;
                        PartidaNueva partidaHistorial = new PartidaNueva(mainWindow);
                        string idioma = partida.IdiomaPartida == "es"? ResourceAccesor.GetString("IdiomaEsp"): ResourceAccesor.GetString("IdiomaIng");
                        if (ResourceAccesor.GetIdiomaHilo() == Constantes.IDIOMA_ESPANOL)
                            partidaHistorial = partidaNueva.ObternerPartidaNueva(jugadorAnfitrion.Nombre, dificultad.Nombre, categoria.Nombre, idioma, partida.Id);
                        else
                        {
                            partidaHistorial = partidaNueva.ObternerPartidaNueva(jugadorAnfitrion.Nombre, dificultad.NombreIngles, categoria.NombreIngles, idioma, partida.Id);
                        }
                        WPPanelPartidasNuevas.Children.Add(partidaHistorial);
                    }
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox("No hay partidas disponibles");
                }
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox("Error al cargar las partidas");
            }
            
        }

    }
}
