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
    /// Interaction logic for HistorialPuntos.xaml
    /// </summary>
    public partial class HistorialPuntos : UserControl
    {
        public HistorialPuntos(string fecha, string jugadorVencido, string palabra, string puntaje)
        {
            InitializeComponent();
            lFechaPartida.Content = fecha;
            lUsuarioContrincante.Content = jugadorVencido;
            lPalabraPartida.Content = palabra;
            lPuntaje.Content = puntaje;
        }
    }
}
