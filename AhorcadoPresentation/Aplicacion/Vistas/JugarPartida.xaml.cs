using AhorcadoPresentation.Modelo;
using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.RecursosLocalizables;
using AutoMapper;
using JugadorServiceReference;
using PalabraService;
using PartidaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Lógica de interacción para JugarPartida.xaml
    /// </summary>
    public partial class JugarPartida : UserControl
    {
        public PalabraDTO palabraDTO = new PalabraDTO();
        private int numeroIntento = 0;
        private bool detenerTarea = false;
        private PalabraService.Palabra palabraEnJuego;
        IMapper mapper = Modelo.Mapper.ObtenerMapper();

        public JugarPartida()
        {
            InitializeComponent();
            ComprobarStatusPartida();
            var palabra = ObtenerPalabra();
            if (palabra != null)
            {
                palabraEnJuego = palabra;
                //ttAyuda.Content = palabra.Descripcion;
            }
            GenericGuiController.imprimirPalabraParcial(WPPalabraContainer, PartidaSingleton.Instance.PalabraParcial);
        }

        public PalabraService.Palabra ObtenerPalabra()
        {
            PalabraServiceClient palabraServiceClient = new PalabraServiceClient();
            try
            {
                var palabra = palabraServiceClient.ObtenerPalabraAsync(PartidaSingleton.Instance.IdPalabraSelecionada).Result;
                return palabra;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ComprobarStatusPartida()
        {
            Task.Run(async () =>
            {
                while (!detenerTarea)
                {
                    var partida = await VerificarStatusPartida();
                    if (PartidaSingleton.Instance.IdEstadoPartida == 3)//Cancelada
                    {
                        detenerTarea = true;
                        await Dispatcher.InvokeAsync(async () =>
                        {
                            GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiJugarPartidaCancelada"));
                            await CambiarVista();
                        });

                    }
                    await Task.Delay(2000);
                }
            });
        }



        private void Click_intentar(object sender, RoutedEventArgs e)
        {
            Button buttonLetra = sender as Button;
            char letra = buttonLetra.Content.ToString().ToLower().ToCharArray()[0];

            PartidaServiceClient partidaServiceClient = new PartidaServiceClient();
            try
            {
                //var partida = mapper.Map<Partida>(PartidaSingleton.Instance);
                Partida partida = new Partida();
                partida.Id = PartidaSingleton.Instance.Id;
                partida.IntentosRestantes = PartidaSingleton.Instance.IntentosRestantes;
                partida.PalabraParcial = PartidaSingleton.Instance.PalabraParcial;
                partida.palabraSeleccionada = PartidaSingleton.Instance.palabraSeleccionada;
                partida.IdEstadoPartida = PartidaSingleton.Instance.IdEstadoPartida;
                partida.IdJugadorAnfitrion = PartidaSingleton.Instance.IdJugadorAnfitrion;
                partida.IdJugadorInvitado = PartidaSingleton.Instance.IdJugadorInvitado;
                partida.IdPalabraSelecionada = PartidaSingleton.Instance.IdPalabraSelecionada;

                var respuesta = partidaServiceClient.RealizarIntentoAsync(partida, letra).Result;
                partida.PalabraParcial = respuesta.partida.PalabraParcial;
                partida.IntentosRestantes = respuesta.partida.IntentosRestantes;
                var respuestaActualizacion = partidaServiceClient.ActualizarPartidaAsync(respuesta.partida).Result;

                if (respuestaActualizacion)
                {
                    if (respuesta.respuesta)
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiJugarPartidaLetraEnPalabra"));
                        GenericGuiController.imprimirPalabraParcial(WPPalabraContainer, respuesta.partida.PalabraParcial);
                        if (respuesta.partida.PalabraParcial.Equals(partida.palabraSeleccionada))
                        {
                            GenericGuiController.MostrarMensajeBox("Ganaste");
                            partida.IdEstadoPartida = 4;//Finalizada
                            partida.PartidaGanadaJugadorInvitado = true;
                            partidaServiceClient.ActualizarPartidaAsync(partida);
                            MenuPrincipal menuPrincipal = new MenuPrincipal();
                            var mainWindow = (MainWindow)Window.GetWindow(this);
                            mainWindow.CambiarVista(menuPrincipal);
                        }
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiJugarPartidaNoLetraEnPalabra"));
                        if (respuesta.partida.IntentosRestantes >= 6)
                        {
                            GenericGuiController.MostrarMensajeBox("Perdiste");
                            partida.IdEstadoPartida = 4;//Finalizada
                            partida.PartidaGanadaJugadorAnfitrion = true;
                            partidaServiceClient.ActualizarPartidaAsync(partida);
                            MenuPrincipal menuPrincipal = new MenuPrincipal();
                            var mainWindow = (MainWindow)Window.GetWindow(this);
                            mainWindow.CambiarVista(menuPrincipal);
                        }
                        cambiarImagen(partida);
                    }

                    buttonLetra.Visibility = Visibility.Hidden;
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiJugarPartidaErrorIntento"));
                }

                PartidaSingleton.Instance.IntentosRestantes = respuesta.partida.IntentosRestantes;
                PartidaSingleton.Instance.PalabraParcial = respuesta.partida.PalabraParcial;
                PartidaSingleton.Instance.IdEstadoPartida = respuesta.partida.IdEstadoPartida;
                PartidaSingleton.Instance.IdJugadorAnfitrion = respuesta.partida.IdJugadorAnfitrion;
                PartidaSingleton.Instance.IdJugadorInvitado = respuesta.partida.IdJugadorInvitado;
                PartidaSingleton.Instance.IdPalabraSelecionada = respuesta.partida.IdPalabraSelecionada;
                PartidaSingleton.Instance.palabraSeleccionada = respuesta.partida.palabraSeleccionada;
                PartidaSingleton.Instance.IntentosRestantes = respuesta.partida.IntentosRestantes;
                PartidaSingleton.Instance.PalabraParcial = respuesta.partida.PalabraParcial;

                //mapper.Map(respuesta.partida, PartidaSingleton.Instance);
                partidaServiceClient.ActualizarPartidaAsync(partida);
            }
            catch (Exception)
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiJugarPartidaErrorIntento"));
                throw;
            }


        }

        private void cambiarImagen(Partida partida)
        {
            int numeroIntento = partida.IntentosRestantes;
            if (numeroIntento == 1)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/PrimerIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 2)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/SegundoIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 3)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/TercerIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 4)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/cuartoIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 5)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/QuintoIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 6)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/SextoIntento.png", UriKind.Relative));
            }
        }

        private async Task<Partida> VerificarStatusPartida()
        {
            PartidaServiceClient partidaService = new PartidaService.PartidaServiceClient();
            try
            {
                var partida = await partidaService.ObtenerPartidaPorIdAsync(PartidaSingleton.Instance.Id);

                PartidaSingleton.Instance.IdEstadoPartida = partida.partida.IdEstadoPartida;
                return partida.partida;
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiErrorComunicacion"));
                return null;
            }
        }
        public async Task CambiarVista()
        {
            MenuPrincipal menu = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menu);
            await Task.Delay(1000);
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
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiEsperandoErrorTerminar") +": "+ ex.Message);
            }
        }

        private void Click_Ayuda(object sender, RoutedEventArgs e)
        {
            if (palabraEnJuego != null)
            {
                if (ResourceAccesor.GetIdiomaHilo() == Constantes.IDIOMA_ESPANOL)
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiJugarPartidaDescipcion") +":\n"+palabraEnJuego.Descripcion);
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiJugarPartidaDescipcion") + ":\n" + palabraEnJuego.DescripcionIngles);
                }
            }
        }
    }

}
