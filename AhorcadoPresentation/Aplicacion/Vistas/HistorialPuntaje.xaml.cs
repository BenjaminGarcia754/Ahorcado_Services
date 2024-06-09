﻿using AhorcadoPresentation.Modelo.Singleton;
using PartidaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    /// Interaction logic for HistorialPuntaje.xaml
    /// </summary>
    public partial class HistorialPuntaje : UserControl
    {
        //private int partidas = 14;
        public HistorialPuntaje()
        {
            InitializeComponent();
            AgregarComponenteHistorial();
        }

        private void AgregarComponenteHistorial()
        {
            var respuesta = ObtenerPartidasPorJugador(JugadorSingleton.Instance.Id);
            var partidas = respuesta.Partidas;
            
            if (respuesta != null)
            {
                if (respuesta.respuesta)
                {
                    foreach (var partida in partidas)
                    {
                        string fecha = partida.FechaCreacionPartida.ToString();
                        string palabra = partida.palabraSeleccionada;
                        string puntaje = "10";
                        HistorialPuntos partidaHistorial = new HistorialPuntos(fecha, "No soportado", palabra, puntaje);
                        WPPanelPuntos.Children.Add(partidaHistorial);
                    }
                    lPuntaje.Content = partidas.Length * 10;
                }else
                {
                    GenericGuiController.MostrarMensajeBox("No se encontraron partidas");
                    lPuntaje.Content = "0";
                }
            }
            
        }

        private PartidaRespuesta ObtenerPartidasPorJugador(int idJugador)
        {
            try
            {
                var partidaServicioCliente = new PartidaServiceClient();
                var partidasTerminadas = partidaServicioCliente.ObtenerPartidasPorJugadorAsync(JugadorSingleton.Instance.Id).Result;
                return partidasTerminadas;
            }
            catch (CommunicationException)
            {
                GenericGuiController.MostrarMensajeBox("Error de comunicación con el servidor");
                return null;
            }
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {  
            HistorialPartidas historialPartidas = new HistorialPartidas();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(historialPartidas);
        }
    }
}
