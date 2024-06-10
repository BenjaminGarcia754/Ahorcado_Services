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
using System.Windows.Shapes;

namespace AhorcadoPresentation.Aplicacion.Vistas.Alertas
{
    /// <summary>
    /// Lógica de interacción para Alerta.xaml
    /// </summary>
    public partial class Alerta : Window
    {
        public Alerta(string mensaje)
        {
            InitializeComponent();
            tblkMessage.Text = mensaje;
        }

        private void Clic_Aceptar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MoverVentana(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
