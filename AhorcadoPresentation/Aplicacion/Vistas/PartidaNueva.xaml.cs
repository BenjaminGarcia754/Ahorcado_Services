using AhorcadoPresentation.Modelo.Singleton;
using AutoMapper;
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
    /// Lógica de interacción para PartidaNueva.xaml
    /// </summary>
    public partial class PartidaNueva : UserControl
    {
        IMapper mapper = Modelo.Mapper.ObtenerMapper();
        MainWindow mainWindow;
        public PartidaNueva(MainWindow _mainWindow)
        {
            InitializeComponent();
            this.mainWindow = _mainWindow;
        }

        public PartidaNueva ObternerPartidaNueva(string jugadorRetador, string dificultad, string categoria, string idioma, int idPartida)
        {

            PartidaNueva partidaNueva = new PartidaNueva(mainWindow);
            partidaNueva.lCategoria.Content = categoria;
            partidaNueva.lDificultad.Content = dificultad;
            partidaNueva.lIdioma.Content = idioma;
            partidaNueva.lJugadorRetador.Content = jugadorRetador;
            partidaNueva.lIdPartida.Content = idPartida;
            return partidaNueva;
        }

        private void ClickJugarPartida(object sender, RoutedEventArgs e)
        {
            Button botonSeleccionado = sender as Button;
            if (botonSeleccionado != null)
            {
                var parent = botonSeleccionado.Parent as Grid;
                if ( parent != null)
                {
                    foreach(var child in parent.Children)
                    {
                        if (child is Label)
                        {
                            Label label = child as Label;
                            if (label.Name == "lIdPartida")
                            {

                                int idPartida = int.Parse(label.Content.ToString());
                                EntrarAPartida(idPartida);

                            }
                        }
                    }
                }
            }
        }



        private void EntrarAPartida(int idPartida)
        {
            PartidaServiceClient partidaServiceClient = new PartidaServiceClient();
            try
            {
                var partidaRespuesta = partidaServiceClient.ObtenerPartidaPorIdAsync(idPartida).Result;
                if (partidaRespuesta != null)
                {
                    if (partidaRespuesta.partida.IdEstadoPartida != 1)//Disponible para jugar
                    {
                        GenericGuiController.MostrarMensajeBox("La partida ya no esta disponible");
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox(partidaRespuesta.partida.PalabraParcial);
                        PartidaSingleton.Instance.Id = partidaRespuesta.partida.Id;
                        PartidaSingleton.Instance.IdJugadorAnfitrion = partidaRespuesta.partida.IdJugadorAnfitrion;
                        PartidaSingleton.Instance.IdJugadorInvitado = JugadorSingleton.Instance.Id;
                        PartidaSingleton.Instance.IdEstadoPartida = partidaRespuesta.partida.IdEstadoPartida;
                        PartidaSingleton.Instance.IntentosRestantes = partidaRespuesta.partida.IntentosRestantes;
                        PartidaSingleton.Instance.PalabraParcial = partidaRespuesta.partida.PalabraParcial;
                        PartidaSingleton.Instance.palabraSeleccionada = partidaRespuesta.partida.palabraSeleccionada;
                        PartidaSingleton.Instance.IdPalabraSelecionada = partidaRespuesta.partida.IdPalabraSelecionada;

                        partidaRespuesta.partida.IdJugadorInvitado = JugadorSingleton.Instance.Id;
                        partidaRespuesta.partida.IdEstadoPartida = 2;//En juego
                        PartidaSingleton.Instance.IdEstadoPartida = 2;
                        partidaServiceClient.ActualizarPartidaAsync(partidaRespuesta.partida);
                        JugarPartida jugarPartida = new JugarPartida();
                        mainWindow.CambiarVista(jugarPartida);
                    }
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox("No se encontraron partidas");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                GenericGuiController.MostrarMensajeBox("Error al cargar las partidas");
            }
        }
    }
}
