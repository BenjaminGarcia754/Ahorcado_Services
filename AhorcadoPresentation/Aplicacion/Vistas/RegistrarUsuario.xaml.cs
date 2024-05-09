using JugadorServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Lógica de interacción para RegistrarUsuario.xaml
    /// </summary>
    public partial class RegistrarUsuario : UserControl
    {
        public bool esActualizacion = false;

        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void ClickRegistrarse(object sender, RoutedEventArgs e)
        {
            JugadorServiceClient jugador = new JugadorServiceClient();

            if (ValidarCampos())
            {
                if (esActualizacion)
                {

                }
            }
        }

        private void ClickRegresar(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);

            if (esActualizacion)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                mainWindow.cambiarVista(menuPrincipal);
            }
            else
            {
                IniciarSesion iniciarSesion = new IniciarSesion();
                mainWindow.cambiarVista(iniciarSesion);
            }
        }

        private bool ValidarCampos()
        {
            bool respuesta = true;
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            List<TextBlock> textBlocks = new List<TextBlock>();
            foreach (TextBlock block in GenericGuiController.FindVisualChildren<TextBlock>(registrarUsuario))
            {
                textBlocks.Add(block);
            }

            if (!GenericGuiController.ValidarTextBlockVacios(textBlocks))
            {
                respuesta = false;
            }else if (!GenericGuiController.ValidarDatePicker(DpFechaNacimiento))
            {
                respuesta = false;
            }else if (!GenericGuiController.ValidarPasswordBox(PfContraseña))
            {
                respuesta = false;
            }

            return respuesta;

        }

    }
}
