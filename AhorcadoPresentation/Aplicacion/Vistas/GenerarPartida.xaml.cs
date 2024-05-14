using AhorcadoService;
using JugadorServiceReference;
using ServiceReference1;
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
            InicializarComboBoxDificultades();
            InicializarComboBoxCategorias();

            // Suscribir al evento SelectionChanged del ComboBox de dificultades
            CbDificultad.SelectionChanged += (sender, e) =>
            {
                // Habilitar el ComboBox de categorías cuando se seleccione una dificultad
                CbCategoria.IsEnabled = CbDificultad.SelectedItem != null;
            };

            // Suscribir al evento SelectionChanged del ComboBox de categorías
            CbCategoria.SelectionChanged += (sender, e) =>
            {
                // Habilitar el ComboBox de palabras cuando se seleccione una categoría
                CbPalabra.IsEnabled = CbCategoria.SelectedItem != null;
            };
        }

        private void InicializarComboBoxDificultades()
        {
            var dificultadServiceClient = new DificultadServiceClient();
            var dificultades = dificultadServiceClient.GetDificultadesAsync().Result;

            CbDificultad.ItemsSource = dificultades;
            CbDificultad.DisplayMemberPath = "Nombre";
            CbDificultad.SelectedValuePath = "Id";
        }

        private void InicializarComboBoxCategorias()
        {
            var categoriaServiceClient = new CategoriaServiceClient();
            var categorias = categoriaServiceClient.GetCategoriasAsync().Result;

            CbCategoria.ItemsSource = categorias;
            CbCategoria.DisplayMemberPath = "Nombre";
            CbCategoria.SelectedValuePath = "Id";

            // Inicialmente bloquear el ComboBox de categorías
            CbCategoria.IsEnabled = false;

            // Inicialmente bloquear el ComboBox de palabras
            CbPalabra.IsEnabled = false;
        }

        private void Click_CrearSala(object sender, RoutedEventArgs e)
        {

        }
    }
}
