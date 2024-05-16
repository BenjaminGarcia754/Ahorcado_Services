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
    /// Interaction logic for Historial.xaml
    /// </summary>
    public partial class Historial : UserControl
    {
        public Historial(string fecha, string usuarioContrincante, string palabra, string resultado, string puntaje)
        {
            InitializeComponent();
            lFechaPartida.Content = fecha;
            lUsuarioContrincante.Content = usuarioContrincante;
            lPalabraPartida.Content = palabra;
            lResultado.Content = resultado;
            lPuntaje.Content = puntaje;
        }
    }
}
