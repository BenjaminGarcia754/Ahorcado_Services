using AhorcadoService;
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
            InicializarComboBox();
        }
        private void InicializarComboBox()
        {

            var categoriaServiceClient = new CategoriaServiceClient();
            var categorias = categoriaServiceClient.GetCategoriasAsync().Result;

            CbCategoria.ItemsSource = categorias;
            CbCategoria.DisplayMemberPath = "Nombre";
            CbCategoria.SelectedValuePath = "Id";
        }

        private void Click_CrearSala(object sender, RoutedEventArgs e)
        {

        }
    }
}
