using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.RecursosLocalizables;
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
                    Partida partida = new Partida();
                    partida = await VerificarStatusPartida();
                    PartidaSingleton.Instance.IdEstadoPartida = partida.IdEstadoPartida;
                    PartidaSingleton.Instance.IdJugadorInvitado = partida.IdJugadorInvitado;
                    PartidaSingleton.Instance.IdJugadorAnfitrion= partida.IdJugadorAnfitrion;
                    PartidaSingleton.Instance.Id = partida.Id;
                    PartidaSingleton.Instance.palabraSeleccionada = partida.palabraSeleccionada;
                    PartidaSingleton.Instance.PalabraParcial = partida.PalabraParcial;
                    PartidaSingleton.Instance.IdPalabraSelecionada = partida.IdPalabraSelecionada;
                    PartidaSingleton.Instance.IntentosRestantes = partida.IntentosRestantes;

                    if (PartidaSingleton.Instance.IdEstadoPartida == 2)//Jugando
                    {   
                        PartidaSingleton.Instance.IdJugadorInvitado = partida.IdJugadorInvitado;

                        detenerTarea = true;
                        await Dispatcher.InvokeAsync(() =>
                        {
                            CambiarVista();
                        });
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
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiEsperandoErrorCancelar"));
                    }
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiEsperandoErrorTerminar"));
                }
            }
            catch (Exception ex)
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiEsperandoErrorTerminar") + ex.Message); 
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
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiErrorComunicacion")); 
                return null;
            }
        }

        public void CambiarVista()
        {
            
            //TODO: Cambiar a la pantalla de juego para el anfitrión
            JugarPartidaRetador jugarPartida = new JugarPartidaRetador();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(jugarPartida);

        }
    }
}
