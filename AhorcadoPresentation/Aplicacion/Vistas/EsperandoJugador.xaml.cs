using AhorcadoPresentation.Modelo.Singleton;
using AutoMapper;
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
        IMapper mapper = Modelo.Mapper.ObtenerMapper();
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
                    if (PartidaSingleton.Instance.IdJugadorInvitado != partida.IdJugadorInvitado && partida.IdEstadoPartida == 2)//Jugando
                    {
                        PartidaSingleton.Instance.IdJugadorInvitado = partida.IdJugadorInvitado;
                        await CambiarVista();
                    }
                    await Task.Delay(2000);
                }
            });
        }

        private async void Click_Regresar(object sender, RoutedEventArgs e)
        {
            detenerTarea = true;
            try
            {
                PartidaServiceClient partidaService = new PartidaServiceClient();

                // Obtener la partida actual
                var partidaResponse = await partidaService.ObtenerPartidaPorIdAsync(PartidaSingleton.Instance.Id);
                var partida = partidaResponse.partida;

                if (partidaResponse.respuesta)
                {
                    // Modificar el estado de la partida
                    partida.IdEstadoPartida = 3; // Cancelada

                    // Actualizar la partida a través del servicio WCF
                    var respuesta = await partidaService.ActualizarPartidaAsync(partida);
                    if (respuesta)
                    {
                        detenerTarea = true;
                        MenuPrincipal menuPrincipal = new MenuPrincipal();
                        var mainWindow = (MainWindow)Window.GetWindow(this);
                        mainWindow.CambiarVista(menuPrincipal);
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox("Error al cancelar la partida");
                    }
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox("Error al terminar la partida");
                }
            }
            catch (Exception ex)
            {
                GenericGuiController.MostrarMensajeBox("Error al terminar la partida: " + ex.Message);
            }
        }

        private async Task<Partida> VerificarStatusPartida()
        {
            try
            {
                using (var partidaService = new PartidaServiceClient())
                {
                    var partida = await partidaService.ObtenerPartidaPorIdAsync(PartidaSingleton.Instance.Id);
                    return partida.partida;
                }
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
