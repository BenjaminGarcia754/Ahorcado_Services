using AhorcadoService;
using JugadorServiceReference;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            CbCategoria.SelectionChanged += (sender, e) =>
            {
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

            // Inicialmente bloquear CbCategoria
            CbCategoria.IsEnabled = false;

            CbPalabra.IsEnabled = false;
        }

        private void ValidarComboBox(object sender, MouseButtonEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Validar si es el ComboBox de dificultad
            if (comboBox == CbDificultad)
            {
                // Si no hay una selección en el ComboBox de dificultad, mostrar mensaje
                if (CbDificultad.SelectedIndex == -1)
                {
                    e.Handled = true; // Detener el evento para que el ComboBox no reciba el clic
                    MessageBox.Show("Debe seleccionar una dificultad antes de continuar.");
                    return;
                }
            }
            // Validar si es el ComboBox de categoría
            else if (comboBox == CbCategoria)
            {
                // Si no hay una selección en el ComboBox de categoría, mostrar mensaje
                if (CbCategoria.SelectedIndex == -1)
                {
                    e.Handled = true; // Detener el evento para que el ComboBox no reciba el clic
                    MessageBox.Show("Debe seleccionar una categoría antes de continuar.");
                    return;
                }
            }
            // Validar si es el ComboBox de palabra
            else if (comboBox == CbPalabra)
            {
                // Si no hay una selección en el ComboBox de palabra, mostrar mensaje
                if (CbPalabra.SelectedIndex == -1)
                {
                    e.Handled = true; // Detener el evento para que el ComboBox no reciba el clic
                    MessageBox.Show("Debe seleccionar una palabra antes de continuar.");
                    return;
                }
            }
        }

        private void Click_CrearSala(object sender, RoutedEventArgs e)
        {
            if(CbDificultad.SelectedItem == null || CbCategoria.SelectedItem == null || CbPalabra.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una dificultad, categoría y palabra para poder crear la partida.");
                return;
            }
            /*else
            {
                var dificultad = (Dificultad)CbDificultad.SelectedItem;
                var categoria = (Categoria)CbCategoria.SelectedItem;
                var palabra = (Palabra)CbPalabra.SelectedItem;

                var partidaServiceClient = new PartidaServiceClient();
                var partida = partidaServiceClient.CrearPartidaAsync(JugadorRetador.Id, palabra.Id, categoria.Id, dificultad.Id).Result;

                if (partida != null)
                {
                    MessageBox.Show("Partida creada con éxito.");
                    MenuPrincipal menuPrincipal = new MenuPrincipal();
                    menuPrincipal.JugadorActivo = JugadorRetador;
                    var mainWindow = (MainWindow)Window.GetWindow(this);
                    mainWindow.cambiarVista(menuPrincipal);
                }
                else
                {
                    MessageBox.Show("No se pudo crear la partida.");
                }
            }*/   
        }


        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.JugadorActivo = JugadorRetador;
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.cambiarVista(menuPrincipal);
        }
    }
}
