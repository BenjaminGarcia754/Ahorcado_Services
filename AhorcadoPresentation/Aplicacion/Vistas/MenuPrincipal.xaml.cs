using JugadorServiceReference;
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
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : UserControl
    {   
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void click_CrearParitida(object sender, RoutedEventArgs e)
        {
            mostrarMenuGenerarPartida();
        }

        private void Click_BuscarPartida(object sender, RoutedEventArgs e)
        {
            mostrarBuscarPartidaNueva();
        }


        private void mostrarMenuGenerarPartida()
        {
            GenerarPartida generarPartida = new GenerarPartida();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.cambiarVista(generarPartida);
        }

        private void mostrarBuscarPartidaNueva()
        {
            BuscarPartidaNueva buscarPartidaNueva = new BuscarPartidaNueva();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.cambiarVista(buscarPartidaNueva);
        }

    }
}
