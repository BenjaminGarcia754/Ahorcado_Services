using AhorcadoPresentation.Modelo;
using AhorcadoPresentation.Modelo.Singleton;
using AutoMapper;
using JugadorServiceReference;
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
        IMapper mapper = Modelo.Mapper.ObtenerMapper();

        public JugarPartida()
        {
            InitializeComponent();

            palabraDTO.Nombre = "Los juegos del hambre en llamas español latino";
            PartidaSingleton partida = PartidaSingleton.Instance;
            partida.PalabraParcial = "--- --e--- -e- -----e e- ------ e----- ------";
            ttAyuda.Content = "Categoria:\nPelicula\nDescripcion:\nEsta pelicula fue nominada al Oscar y fue protagonizada por Jennifer Lawrence";
        }

        public void ComprobarStatusPartida()
        {
            Task.Run(async () =>
            {
                while (!detenerTarea)
                {
                    var partida = await VerificarStatusPartida();
                    if (partida.IdEstadoPartida == 2)//Cancelada
                    {
                        detenerTarea = true;
                        MessageBox.Show("La partida ha sido cancelada por el jugador anfitrion regresaras al menu principal");
                        await CambiarVista();
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
                var partida = mapper.Map<Partida>(PartidaSingleton.Instance);
                var respuesta = partidaServiceClient.RealizarIntentoAsync(partida, letra).Result;
                if (respuesta.respuesta)
                {
                    GenericGuiController.MostrarMensajeBox("La letra se encuentra en la palabra");
                    GenericGuiController.imprimirPalabraParcial(WPPalabraContainer, respuesta.partida.PalabraParcial);
                    if (respuesta.partida.PalabraParcial.Equals(partida.palabraSeleccionada))
                    {
                        GenericGuiController.MostrarMensajeBox("Ganaste");
                        partida.IdEstadoPartida = 3;//Finalizada
                        partida.PartidaGanadaJugadorInvitado = true;
                    }
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox("La letra no se encuentra en la palabra");
                    if (respuesta.partida.IntentosRestantes >= 6)
                    {
                        GenericGuiController.MostrarMensajeBox("Perdiste");
                        partida.IdEstadoPartida = 3;//Finalizada
                        //TODO:Actualizar Partida Estado Finalizada, JUgador Anfitrion Gana
                    }
                    cambiarImagen();
                }
                mapper.Map(respuesta.partida, PartidaSingleton.Instance);
                partidaServiceClient.ActualizarPartidaAsync(partida);

            }
            catch (Exception)
            {
                throw;
            }
            
            buttonLetra.Visibility = Visibility.Hidden;
        }

        private void cambiarImagen()
        {
            numeroIntento++;
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
            MenuPrincipal menu =  new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menu);
            await Task.Delay(1000);
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menu);
        }
    }

}
