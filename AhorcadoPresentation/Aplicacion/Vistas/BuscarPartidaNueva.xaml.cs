﻿using JugadorServiceReference;
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
    /// Lógica de interacción para BuscarPartidaNueva.xaml
    /// </summary>
    public partial class BuscarPartidaNueva : UserControl
    {
        public Jugador JugadorRetador { get; set; }
        public BuscarPartidaNueva()
        {
            InitializeComponent();
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.JugadorActivo = JugadorRetador;
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.cambiarVista(menuPrincipal);
        }

        private void Click_Jugar(object sender, RoutedEventArgs e)
        {

        }
    }
}
