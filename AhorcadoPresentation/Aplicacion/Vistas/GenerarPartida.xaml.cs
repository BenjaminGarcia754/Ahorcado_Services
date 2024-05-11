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
    /// Lógica de interacción para GenerarPartida.xaml
    /// </summary>
    public partial class GenerarPartida : UserControl
    {
        public Jugador JugadorRetador { get; set; }
        public GenerarPartida()
        {
            InitializeComponent();

        }

        private void Click_CrearSala(object sender, RoutedEventArgs e)
        {
            //Aqui se debe de llamar a la ventana de espera de jugadores hasta que el jugador invitado se una
            //Instancia de jugadir retador prueba
            JugadorRetador = new Jugador()
            {
                Id = 1,
                Nombre = "Jugador 1",
                Correo = ""
            };
        }
    }
}
