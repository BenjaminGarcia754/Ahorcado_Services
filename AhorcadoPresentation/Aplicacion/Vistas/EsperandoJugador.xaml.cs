using AhorcadoPresentation.Modelo.Singleton;
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
    /// Interaction logic for EsperandoJugador.xaml
    /// </summary>
    public partial class EsperandoJugador : UserControl
    {
        public bool detenerTarea = false;

        public EsperandoJugador()
        {
            InitializeComponent();
            EsperarJugador();
        }

        

        public void EsperarJugador()
        {
            Task.Run(async () =>
            {
                while (!detenerTarea)
                {
                    var partida = await VerificarStatusPartida();
                    if (PartidaSingleton.Instance.IdJugadorInvitado != partida.IdJugadorInvitado)
                    {
                        PartidaSingleton.Instance.IdJugadorInvitado = partida.IdJugadorInvitado;
                        await CambiarVista();
                    }
                    await Task.Delay(2000);
                }
            });
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            Partida partida = new Partida();
            partida.Id = PartidaSingleton.Instance.Id;
            partida.IdEstadoPartida = 1;//Cancelada
            partida.IdPalabraSelecionada = PartidaSingleton.Instance.IdPalabraSelecionada;
            partida.IdJugadorAnfitrion = PartidaSingleton.Instance.IdJugadorAnfitrion;
            partida.IdJugadorInvitado = PartidaSingleton.Instance.IdJugadorInvitado;

            try
            {
                PartidaServiceClient partidaService = new PartidaServiceClient();
                partidaService.ActualizarPartidaAsync(partida);
                detenerTarea = true;
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                var mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.CambiarVista(menuPrincipal);
            }
            catch (Exception)
            {
                GenericGuiController.MostrarMensajeBox("Error al terminar la partida");
                throw;
            }
            
        }

        private async Task<Partida> VerificarStatusPartida()
        {
            PartidaServiceClient partidaService = new PartidaService.PartidaServiceClient();
            try
            {
                var partida = await partidaService.ObtenerPartidaPorIdAsync(PartidaSingleton.Instance.Id);
                return partida.partida;
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox("Error de comunicación con el servidor");
                return null;
            }
        }

        public async Task CambiarVista()
        {
            detenerTarea = true;
            //TODO: Cambiar a la pantalla de juego para el anfitrión
            JugarPartidaRetador jugarPartida = new JugarPartidaRetador();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(jugarPartida);
            await Task.Delay(1000);
        }
    }
}
