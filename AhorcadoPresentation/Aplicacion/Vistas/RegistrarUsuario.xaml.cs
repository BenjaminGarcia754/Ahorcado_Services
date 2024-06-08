using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.Modelo;
using AutoMapper;
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
using AhorcadoPresentation.RecursosLocalizables;

namespace AhorcadoPresentation.Aplicacion.Vistas
{
    /// <summary>
    /// Lógica de interacción para RegistrarUsuario.xaml
    /// </summary>
    public partial class RegistrarUsuario : UserControl
    {
        public bool esActualizacion = false;
        IMapper mapper = Modelo.Mapper.ObtenerMapper();


        public RegistrarUsuario()
        {
            InitializeComponent();
            ConfigurarVentana();
        }

        private void ClickRegistrarse(object sender, RoutedEventArgs e)
        {
            JugadorServiceClient jugadorCliente = new JugadorServiceClient();

            if (ValidarCampos())
            {
                Jugador jugador = new Jugador();
                jugador.Nombre = TbNombre.Text;
                jugador.ApellidoPaterno = TbApellidoPaterno.Text;
                jugador.ApellidoMaterno = TbApellidoMaterno.Text;
                jugador.Correo = TbCorreo.Text;
                jugador.Username = TbUsuario.Text;
                jugador.fechaDeNacimiento = (DateTime)DpFechaNacimiento.SelectedDate.Value;
                jugador.Contrasena = PfContraseña.Password;
                jugador.Telefono = TbTelefono.Text;
                jugador.Username = TbUsuario.Text;
                if (esActualizacion)
                {
                    jugador.Id = JugadorSingleton.Instance.Id;
                    bool respuesta = jugadorCliente.ActualizarInformacionJugadorAsync(jugador).Result;
                    if (respuesta)
                    {
                        mapper.Map(jugador, JugadorSingleton.Instance);
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiRegistrarMsgActualizado"));
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiRegistrarMsgErrorActualizar"));
                    }
                }
                else
                {
                    bool respuesta = jugadorCliente.RegistrarJugadorAsync(jugador).Result;
                    if (respuesta)
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiRegistrarMsgRegistrado"));
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiRegistrarMsgErrorRegistrar"));
                    }
                }
                ClickRegresar(sender, e);
            }
            else
            {

            }
        }

        private void ClickRegresar(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);

            if (esActualizacion)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                mainWindow.CambiarVista(menuPrincipal);
            }
            else
            {
                IniciarSesion iniciarSesion = new IniciarSesion();
                mainWindow.CambiarVista(iniciarSesion);
            }
        }

        private bool ValidarCampos()
        {
            bool respuesta = true;
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            List<TextBox> textBlocks = new List<TextBox>();
            
            foreach (TextBox block in GenericGuiController.FindVisualChildren<TextBox>(GdContenedor))
            {
                textBlocks.Add(block);
            }

            if (!GenericGuiController.ValidarTextBlockVacios(textBlocks))
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiRegistrarMsgCamposVacios"));
                respuesta = false;
            }
            
            if (!GenericGuiController.ValidarDatePicker(DpFechaNacimiento))
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiRegistrarMsgFechaInvalida"));
                respuesta = false;
            }
            if (!GenericGuiController.ValidarPasswordBox(PfContraseña))
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiRegistrarMsgContraseniaInvalida"));
                respuesta = false;
            }

            return respuesta;

        }

        public void CargarInformacionJugador()
        {
            TbNombre.Text = JugadorSingleton.Instance.Nombre;
            TbApellidoMaterno.Text = JugadorSingleton.Instance.ApellidoMaterno;
            TbApellidoPaterno.Text = JugadorSingleton.Instance.ApellidoPaterno ;
            TbCorreo.Text = JugadorSingleton.Instance.Correo;
            DpFechaNacimiento.SelectedDate = JugadorSingleton.Instance.fechaDeNacimiento;
            PfContraseña.Password = JugadorSingleton.Instance.Contrasena;
            TbTelefono.Text = JugadorSingleton.Instance.Telefono;
            TbUsuario.Text = JugadorSingleton.Instance.Username;
        }

        public void ConfigurarVentana()
        {
            if(esActualizacion)
            {
                tbTextoInicial.Text= ResourceAccesor.GetString("GuiRegistrarActualizarInfo");
                BTNRegistrar .Content = ResourceAccesor.GetString("GuiRegistrarBtnActualizar");
                CargarInformacionJugador();
                TbCorreo.IsEnabled = false;
            }
        }

        private void ValidarNumeros(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length -1))
            {
                e.Handled = true;
            }
            if (TbTelefono.Text.Length > 9)
            {
                e.Handled = true;
            }
        }
    }
}
