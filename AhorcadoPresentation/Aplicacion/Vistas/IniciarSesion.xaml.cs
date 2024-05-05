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
    /// Lógica de interacción para IniciarSesion.xaml
    /// </summary>
    public partial class IniciarSesion : UserControl
    {

        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void ClickIniciarSesion(object sender, RoutedEventArgs e)
        {
            if (camposValidos())
            {
                var JugadorCliente = new JugadorServiceClient();
                var jugador =  JugadorCliente.IniciarSesionAsync(TbCorreo.Text, PfContrasenia.Password).Result;
                if (jugador != null)
                {
                    GenericGuiController.MostrarMensajeBox("Bienvenido " + jugador.Nombre);
                    mostrarMenuPrincipal(jugador);
                }
                else
                {
                    GenericGuiController.MostrarMensajeBox("Correo o contraseña incorrectos");
                }
            }
        }

        private void mostrarMenuPrincipal(Jugador jugador)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            //acceder a la ventana principal
            var mainWindow = (MainWindow)Window.GetWindow(this);
            menuPrincipal.JugadorActivo = jugador;
            mainWindow.cambiarVista(menuPrincipal);

        }

        private void ClickRegistrarse(object sender, RoutedEventArgs e)
        {

        }

        private bool camposValidos()
        {
            if(string.IsNullOrEmpty(TbCorreo.Text) || string.IsNullOrEmpty(PfContrasenia.Password))
            {
                GenericGuiController.MostrarMensajeBox("Debe completar todos los campos");
                return false;
            }else
            {
                return true;
            }
        }
    }
}
