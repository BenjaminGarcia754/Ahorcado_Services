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

        public PartidaNueva(string jugadorRetador, string dificultad, string categoria, string idioma, int idPartida)
        {
            InitializeComponent();
            lJugadorRetador.Content = jugadorRetador;
            lDificultad.Content = dificultad;
            lCategoria.Content = categoria;
            lIdioma.Content = idioma;
            lIdPartida.Content = idPartida;
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
                                //LogicaEntrarAPartida(idPartida);
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
                var partida = partidaServiceClient.ObtenerPartidaPorIdAsync(idPartida).Result;
                if (partida != null)
                {
                    if (partida.partida.IdEstadoPartida != 1)//Disponible para jugar
                    {
                        GenericGuiController.MostrarMensajeBox("La partida ya no esta disponible");
                    }
                    else
                    {
                        mapper.Map(partida.partida, JugadorSingleton.Instance);
                        JugarPartida jugarPartida = new JugarPartida();
                        var mainWindow = (MainWindow)Window.GetWindow(this);
                        mainWindow.CambiarVista(jugarPartida);
                    }
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox("No se encontraron partidas");
                }
            }
            catch (Exception)
            {
                GenericGuiController.MostrarMensajeBox("Error al cargar las partidas");
            }
        }
    }
}
