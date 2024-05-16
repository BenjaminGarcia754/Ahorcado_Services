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
    /// Interaction logic for HistorialPuntaje.xaml
    /// </summary>
    public partial class HistorialPuntaje : UserControl
    {
        private int partidas = 14;
        public HistorialPuntaje()
        {
            InitializeComponent();
            AgregarComponenteHistorial();
            lPuntaje.Content = partidas * 10;
        }

        private void AgregarComponenteHistorial()
        {

            for (int i = 0; i < partidas; i++)
            {
                string fecha = DateTime.Now.ToShortDateString();
                string usuarioContrincante = "Usuario" + i;
                string palabra = "Palabra" + i;
                string puntaje = "10";

                HistorialPuntos partidaHistorial = new HistorialPuntos(fecha, usuarioContrincante, palabra, puntaje);
                WPPanelPuntos.Children.Add(partidaHistorial);
            }
        }
    }
}
