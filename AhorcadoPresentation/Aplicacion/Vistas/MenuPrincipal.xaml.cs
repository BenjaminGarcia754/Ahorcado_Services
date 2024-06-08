using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.RecursosLocalizables;
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
using System.Windows.Media.Animation;
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
        TextBlock TBCerrarSesion = new TextBlock();
        public MenuPrincipal()
        {
            InitializeComponent();
            ConfigurarBotonCerrarSesion();
        }

        private void ConfigurarBotonCerrarSesion()
        {
            BTNCerrarSesion.MouseEnter += BTNCerrarSesion_MouseEnter;
            BTNCerrarSesion.MouseLeave += BTNCerrarSesion_MouseLeave;
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
            mainWindow.CambiarVista(generarPartida);
        }

        private void mostrarBuscarPartidaNueva()
        {
            BuscarPartidaNueva buscarPartidaNueva = new BuscarPartidaNueva();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(buscarPartidaNueva);
        }

        private void Click_BuscarPartida_HistorialPartidas(object sender, RoutedEventArgs e)
        {
            HistorialPartidas historialPartidas = new HistorialPartidas();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(historialPartidas);
        }

        private void Click_ModificarUsuario(object sender, RoutedEventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.esActualizacion = true;
            registrarUsuario.ConfigurarVentana();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(registrarUsuario);

        }

        private void Click_CerrarSesion(object sender, RoutedEventArgs e)
        {
            JugadorSingleton.CerrarSesion();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            IniciarSesion iniciarSesion = new IniciarSesion();
            mainWindow.CambiarVista(iniciarSesion);
        }
        private void BTNCerrarSesion_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.To = 200;
            widthAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            PCerrarSesion.Fill = Brushes.Black;
            WPCerrarSesion.Width = 200;
            BTNCerrarSesion.BeginAnimation(Button.WidthProperty, widthAnimation);
            TBCerrarSesion.FontSize = 19;
            TBCerrarSesion.Text = ResourceAccesor.GetString("GuiMenuCerrarSesion");
            TBCerrarSesion.Margin = new Thickness(10, 0, 14, 0);
            TBCerrarSesion.FontFamily = (FontFamily)Application.Current.Resources["Inter"];
            WPCerrarSesion.Children.Add(TBCerrarSesion);
        }
        private void BTNCerrarSesion_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                To = 49, 
                Duration = new Duration(TimeSpan.FromSeconds(0.5)) 
            };

            BTNCerrarSesion.BeginAnimation(Button.WidthProperty, widthAnimation);
            WPCerrarSesion.Children.Remove(TBCerrarSesion);
            PCerrarSesion.Margin = new Thickness(10, 0, 0, 0);
            PCerrarSesion.Fill = Brushes.White;
        }
    }
}
