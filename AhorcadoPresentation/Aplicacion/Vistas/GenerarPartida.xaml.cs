using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoService;
using AutoMapper;
using DificultadService;
using JugadorServiceReference;
using PartidaService;
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
        Dictionary<string, DificultadService.Dificultad> dificultadDiccionario = new Dictionary<string, DificultadService.Dificultad>();
        Dictionary<string, AhorcadoService.Categoria> categoriaDiccionario = new Dictionary<string, AhorcadoService.Categoria>();
        Dictionary<string, PalabraService.Palabra> palabraDiccionario = new Dictionary<string, PalabraService.Palabra>();
        IMapper mapper = Modelo.Mapper.ObtenerMapper();
        
        public GenerarPartida()
        {
            CbPalabra.IsEnabled = false;
            InitializeComponent();
            
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

            CargarComboBox();
        }
        private void CargarComboBox()
        {
            var categorias = ObtenerCategorias();
            var dificultades = ObtenerDidicultades();
            InicializarComboBoxCategorias(categorias);
            InicializarComboBoxDificultades(dificultades);
        }

        private List<DificultadService.Dificultad> ObtenerDidicultades()
        {
            DificultadServiceClient dificultadServiceClient = new DificultadServiceClient();
            try
            {
                return dificultadServiceClient.GetDificultadesAsync().Result.ToList();

            }
            catch (Exception)
            {
                GenericGuiController.MostrarMensajeBox("No se pudo obtener las dificultades");
                return null;
            }
        }
        private List<AhorcadoService.Categoria> ObtenerCategorias()
        {
            CategoriaServiceClient categoriaServiceClient = new CategoriaServiceClient();
            try
            {
                return categoriaServiceClient.GetCategoriasAsync().Result.ToList();
            }
            catch (Exception)
            {
                GenericGuiController.MostrarMensajeBox("No se pudo obtener las categorías");
                return null;
            }

        }

        private void InicializarComboBoxDificultades(List<DificultadService.Dificultad> dificultades)
        {
            foreach (var dificultad in dificultades)
            {
                CbDificultad.Items.Add(dificultad.Nombre);
                dificultadDiccionario.Add(dificultad.Nombre, dificultad);
            }
        }

        private void InicializarComboBoxCategorias(List<AhorcadoService.Categoria> categorias)
        {
            foreach (var categoria in categorias)
            {
                categoriaDiccionario.Add(categoria.Nombre, categoria);
                CbCategoria.Items.Add(categoria.Nombre);
            }
        }

        private void InicializarComboBoxPalabras(List<PalabraService.Palabra> palabras)
        {
            foreach (var palabra in palabras)
            {
                CbPalabra.Items.Add(palabra.Nombre);
                palabraDiccionario.Add(palabra.Nombre, palabra);
            }
        }

        private void cargarPalabras()
        {
            if (CbCategoria.SelectedItem != null && CbDificultad.SelectedItem != null)
            {
                var dificultad = dificultadDiccionario[CbDificultad.SelectedItem.ToString()];
                var categoria = categoriaDiccionario[CbCategoria.SelectedItem.ToString()];
                try
                {
                    PalabraService.PalabraServiceClient palabraServiceClient = new PalabraService.PalabraServiceClient();
                    var palabras = palabraServiceClient.ObtenerPalabrasPorFiltroAsync(categoria.Id, dificultad.Id).Result;
                    if (palabras != null)
                    {
                        InicializarComboBoxPalabras(palabras.ToList());
                        CbPalabra.IsEnabled = true;
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox("No se encontraron palabras para la categoría y dificultad seleccionadas");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error en la conexion");
                    throw;
                }                
            }
        }

        private void Click_CrearSala(object sender, RoutedEventArgs e)
        {
            if (ValidarComboBox())
            {
                var palabra = palabraDiccionario[CbPalabra.SelectedItem.ToString()];
                Partida partida = new Partida();
                partida.IdPalabraSelecionada = palabra.Id;
                partida.IdJugadorAnfitrion = JugadorSingleton.Instance.Id;
                partida.IdEstadoPartida = 1;//Creada
                partida.palabraSeleccionada = palabra.Descripcion;//Validar Idioma
                partida.IntentosRestantes = 0;
                partida.PalabraParcial = GenericGuiController.EnmascararFrase(palabra.Nombre);//Validar Idioma
                mapper.Map(partida, PartidaSingleton.Instance);
                try
                {
                    PartidaServiceClient partidaServiceClient = new PartidaServiceClient();
                    partidaServiceClient.CrearPartidaAsync(partida);
                    GenericGuiController.MostrarMensajeBox("Partida creada con éxito");
                    cambiarVentana();
                }
                catch (Exception)
                {
                    GenericGuiController.MostrarMensajeBox("Error al crear la partida");
                    throw;
                }
            }
            else
            {
                GenericGuiController.MostrarMensajeBox("Debe seleccionar una dificultad, categoría y palabra");
            }
        }

        private void cambiarVentana()
        {
            EsperandoJugador esperandoJugador = new EsperandoJugador();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(esperandoJugador);
        }

        private void Click_Regresar(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.CambiarVista(menuPrincipal);
        }

        private void CbDificultad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargarPalabras();
        }

        private void CbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargarPalabras();
        }


        public bool ValidarComboBox()
        {
            return CbDificultad.SelectedItem != null && CbCategoria.SelectedItem != null && CbPalabra.SelectedItem != null;
        }
        private void CbPalabra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
