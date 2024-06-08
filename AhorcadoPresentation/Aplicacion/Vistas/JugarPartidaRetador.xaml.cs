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
        }

        public void ComprobarStatusPartida()
        {
            Task.Run(async () =>
            {
                while (!detenerTarea)
                {
                    var partida = await VerificarStatusPartida();
                    if (partida.IdEstadoPartida == 1)//Cancelada
                    {
                        detenerTarea = true;
                        MessageBox.Show("La partida ha Cancelada por el jugador invitado regresaras al menu principal");
                        await CambiarVista();
                    }
                    else if (partida.IdEstadoPartida == 2)//Jugando
                    {
                        await actualizarEstadoEnPartida(partida);
                    }else if (partida.IdEstadoPartida == 3)//Finalizada
                    {
                        detenerTarea = true;
                        MessageBox.Show("La partida ha finalizado");
                        await CambiarVista();
                    }

                    await Task.Delay(2000);
                }
            });
        }

        private async Task actualizarEstadoEnPartida(Partida partida)
        {
            try
            {
                mapper.Map(partida, PartidaSingleton.Instance);
                GenericGuiController.imprimirPalabraParcial(WPPalabraContainer, partida.PalabraParcial);
            }
            catch (Exception)
            {

                throw;
            }
            //TODO Generear labels con la palabra parcial

        }

        private void ActualizarImagen(int numeroIntentos)
        {
            switch (numeroIntentos)
            {
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
                    //Pensar en hacer algo
                    break;
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
            MenuPrincipal menu = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menu);
            await Task.Delay(1000);
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            detenerTarea = true;
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menuPrincipal);

        }

    }
}
