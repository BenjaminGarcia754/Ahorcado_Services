﻿using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.RecursosLocalizables;
using AutoMapper;
using JugadorServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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
        IMapper mapper = Modelo.Mapper.ObtenerMapper();
        ResourceManager rm;

        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void ClickIniciarSesion(object sender, RoutedEventArgs e)
        {
            if ( camposValidos())//camposValidos
            {
                var JugadorCliente = new JugadorServiceClient();
                var jugador =  JugadorCliente.IniciarSesionAsync(TbCorreo.Text,PfContrasenia.Password ).Result;
                if (jugador != null)
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiLoginBienvenido") +" " +jugador.Nombre);
                    mapper.Map(jugador, JugadorSingleton.Instance);
                    mostrarMenuPrincipal();
                }
                else
                {

                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiLoginCamposInvalidos"));
                }
            }
        }

        private void mostrarMenuPrincipal()
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            //acceder a la ventana principal
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menuPrincipal);


        }

        private void ClickRegistrarse(object sender, RoutedEventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.esActualizacion = false;
            //acceder a la ventana principal
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(registrarUsuario);
        }

        private bool camposValidos()
        {
            if(string.IsNullOrEmpty(TbCorreo.Text) || string.IsNullOrEmpty(PfContrasenia.Password))
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiLoginCamposVacios"));
                return false;
            }else
            {
                return true;
            }
        }
    }
}
