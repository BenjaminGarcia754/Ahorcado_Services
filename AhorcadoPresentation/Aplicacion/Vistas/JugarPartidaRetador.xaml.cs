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
    /// Lógica de interacción para JugarPartidaRetador.xaml
    /// </summary>
    public partial class JugarPartidaRetador : UserControl
    {
        private bool detenerTarea = false;
        IMapper mapper = Modelo.Mapper.ObtenerMapper();

        public JugarPartidaRetador()
        {
            InitializeComponent();
            ComprobarStatusPartida();
        }

        public void ComprobarStatusPartida()
        {
            Task.Run(async () =>
            {
                while (!detenerTarea)
                {
                    Partida partida = new Partida();
                    
                    partida = await VerificarStatusPartida();
                        if (PartidaSingleton.Instance.IdEstadoPartida == 3)//Cancelada
                        {
                            detenerTarea = true;
                            await Dispatcher.InvokeAsync(async () =>
                            {
                                GenericGuiController.MostrarMensajeBox("La partida ha Cancelada por el jugador invitado regresaras al menu principal");
                                await CambiarVista();
                            });
                                
                        }
                        else if (PartidaSingleton.Instance.IdEstadoPartida == 2)//Jugando
                        {
                            await Dispatcher.InvokeAsync(async () =>
                            {
                                await actualizarEstadoEnPartida(partida);
                            });
                        }
                        else if (PartidaSingleton.Instance.IdEstadoPartida == 4)//Finalizada
                        {
                                detenerTarea = true;
                                if (PartidaSingleton.Instance.PartidaGanadaJugadorAnfitrion)
                                {
                                    Dispatcher.Invoke( () =>
                                    {
                                        GenericGuiController.MostrarMensajeBox("Ganaste");
                                    });
                                    
                                }
                                else if (PartidaSingleton.Instance.PartidaGanadaJugadorInvitado)
                                {
                                    Dispatcher.Invoke(() =>
                                    {
                                        GenericGuiController.MostrarMensajeBox("Gano el jugador invitado");
                                    });       
                                }

                                await Dispatcher.InvokeAsync(async () =>
                                {
                                    MessageBox.Show("La partida ha finalizado");
                                    await Task.Delay(2000);
                                    await CambiarVista();
                                });
                        }
                    await Task.Delay(2000);
                }
            });
        }

        private async Task actualizarEstadoEnPartida(Partida partida)
        {
            GenericGuiController.imprimirPalabraParcial(WPPalabraContainer, PartidaSingleton.Instance.PalabraParcial);
            ActualizarImagen(PartidaSingleton.Instance.IntentosRestantes);
            await Task.Delay(1000);
        }

        private void ActualizarImagen(int numeroIntentos)
        {
            switch (numeroIntentos)
            {
                case 0:
                    ImgImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/ImagenBaseAhorcado.png", UriKind.Relative));
                    break;
                case 1:
                    ImgImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/PrimerIntento.png", UriKind.Relative));
                    break;
                case 2:
                    ImgImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/SegundoIntento.png", UriKind.Relative));
                    break;
                case 3:
                    ImgImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/TercerIntento.png", UriKind.Relative));
                    break;
                case 4:
                    ImgImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/cuartoIntento.png", UriKind.Relative));
                    break;
                case 5:
                    ImgImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/QuintoIntento.png", UriKind.Relative));
                    break;
                case 6:
                    ImgImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/SextoIntento.png", UriKind.Relative));
                    break;
                default:
                    GenericGuiController.MostrarMensajeBox("Superaste el numero de intentos");
                    break;
            }
        }

        private async Task<Partida> VerificarStatusPartida()
        {
            PartidaServiceClient partidaService = new PartidaService.PartidaServiceClient();
            try
            {
                var partida = await partidaService.ObtenerPartidaPorIdAsync(PartidaSingleton.Instance.Id);
                PartidaSingleton.Instance.IdEstadoPartida = partida.partida.IdEstadoPartida;
                PartidaSingleton.Instance.IdJugadorInvitado = partida.partida.IdJugadorInvitado;
                PartidaSingleton.Instance.IdJugadorAnfitrion = partida.partida.IdJugadorAnfitrion;
                PartidaSingleton.Instance.Id = partida.partida.Id;
                PartidaSingleton.Instance.palabraSeleccionada = partida.partida.palabraSeleccionada;
                PartidaSingleton.Instance.PalabraParcial = partida.partida.PalabraParcial;
                PartidaSingleton.Instance.IdPalabraSelecionada = partida.partida.IdPalabraSelecionada;
                PartidaSingleton.Instance.IntentosRestantes = partida.partida.IntentosRestantes;
                PartidaSingleton.Instance.PartidaGanadaJugadorAnfitrion = partida.partida.PartidaGanadaJugadorAnfitrion;
                PartidaSingleton.Instance.PartidaGanadaJugadorInvitado = partida.partida.PartidaGanadaJugadorInvitado;
                return partida.partida;

            }
            catch (CommunicationException)
            {
                //GenericGuiController.MostrarMensajeBox("Error de comunicación con el servidor");
                return null;
            }
        }

        public async Task CambiarVista()
        {
            await Task.Delay(1000);
            MenuPrincipal menu = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menu);
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

    }
}
