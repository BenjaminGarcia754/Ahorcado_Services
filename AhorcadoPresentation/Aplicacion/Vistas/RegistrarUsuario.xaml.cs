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
                string Apellidos = TbApellidoPaterno.Text + " " + TbApellidoMaterno.Text;
                Jugador jugador = new Jugador();
                jugador.Nombre = TbNombre.Text;
                //jugador.Apellidos = Apellidos;
                jugador.Correo = TbCorreo.Text;
                jugador.fechaDeNacimiento = (DateTime)DpFechaNacimiento.SelectedDate.Value;
                jugador.Contrasena = PfContraseña.Password;
                jugador.Telefono = TbTelefono.Text;

                if (esActualizacion)
                {
                    bool respuesta = jugadorCliente.ActualizarInformacionJugadorAsync(jugador).Result;
                    if (respuesta)
                    {
                        GenericGuiController.MostrarMensajeBox("Informacion actualizada");
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox("Error al actualizar la informacion");
                    }
                }else
                {
                    bool respuesta = jugadorCliente.RegistrarJugadorAsync(jugador).Result;
                    if (respuesta)
                    {
                        GenericGuiController.MostrarMensajeBox("Jugador registrado");
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox("Error al registrar el jugador");
                    }
                }
            }else
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
                GenericGuiController.MostrarMensajeBox("Hay campos vacios");
                respuesta = false;
            }
            
            if (!GenericGuiController.ValidarDatePicker(DpFechaNacimiento))
            {
                GenericGuiController.MostrarMensajeBox("Fecha de nacimiento invalida");
                respuesta = false;
            }
            if (!GenericGuiController.ValidarPasswordBox(PfContraseña))
            {
                GenericGuiController.MostrarMensajeBox("Contraseña invalida");
                respuesta = false;
            }

            return respuesta;

        }

        public void CargarInformacionJugador()
        {
            TbNombre.Text = JugadorSingleton.Instance.Nombre;
            //string[] apellidos = JugadorSingleton.Instance.Apellidos.Split(' ');
            //TbApellidoPaterno.Text = apellidos[0];
            //TbApellidoMaterno.Text = apellidos[1];
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
                tbTextoInicial.Text= "Actualizar Informacion";
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
