using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.RecursosLocalizables;
using CategoriaService;
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
using PalabraService;
using System.Globalization;

namespace AhorcadoPresentation.Aplicacion.Vistas
{
    /// <summary>
    /// Lógica de interacción para GenerarPartida.xaml
    /// </summary>
    public partial class GenerarPartida : UserControl
    {
        string idiomaHilo = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        Dictionary<string, int> dificultadDiccionario = new Dictionary<string, int>();
        Dictionary<string, int> categoriaDiccionario = new Dictionary<string, int>();
        Dictionary<string, PalabraService.Palabra> palabraDiccionario = new Dictionary<string, PalabraService.Palabra>();
        IMapper mapper = Modelo.Mapper.ObtenerMapper();
        
        public GenerarPartida()
        {
            InitializeComponent();
            CbPalabra.IsEnabled = false;

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
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiGenerarPartidaErrorAlCargarDificultades"));
                return null;
            }
        }
        private List<CategoriaService.Categoria> ObtenerCategorias()
        {
            CategoriaServiceClient categoriaServiceClient = new CategoriaServiceClient();
            try
            {
                return categoriaServiceClient.GetCategoriasAsync().Result.ToList();
            }
            catch (Exception)
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiGenerarPartidaErrorCategorias"));
                return null;
            }

        }

        private void InicializarComboBoxDificultades(List<DificultadService.Dificultad> dificultades)
        {
            string idiomaHilo = ResourceAccesor.GetIdiomaHilo();
            if (dificultades != null)
            {
                foreach (var dificultad in dificultades)
                {
                    string nombre = idiomaHilo == Constantes.IDIOMA_ESPANOL ? dificultad.Nombre : dificultad.NombreIngles;
                    CbDificultad.Items.Add(nombre);
                    dificultadDiccionario.Add(nombre, dificultad.Id);
                }
            }
        }

        private void InicializarComboBoxCategorias(List<CategoriaService.Categoria> categorias)
        {
            string idiomaHilo = ResourceAccesor.GetIdiomaHilo();
            foreach (var categoria in categorias)
            {
                string nombre = idiomaHilo == Constantes.IDIOMA_ESPANOL ? categoria.Nombre : categoria.NombreIngles;
                CbCategoria.Items.Add(nombre);
                categoriaDiccionario.Add(nombre, categoria.Id);
            }
        }

        private void InicializarComboBoxPalabras(List<PalabraService.Palabra> palabras)
        {
            palabraDiccionario.Clear();
            foreach (var palabra in palabras)
            {
                if (!palabraDiccionario.ContainsKey(palabra.Nombre))
                {
                    string idiomaAsignado = idiomaHilo == "es" ? palabra.Nombre : palabra.NombreIngles;
                    CbPalabra.Items.Add(idiomaAsignado);
                    palabraDiccionario.Add(idiomaAsignado, palabra);
                }
            }

        }

        private void cargarPalabras()
        {
            CbPalabra.Items.Clear();
            if (CbCategoria.SelectedItem != null && CbDificultad.SelectedItem != null)
            {
                var dificultad = dificultadDiccionario[CbDificultad.SelectedItem.ToString()];
                var categoria = categoriaDiccionario[CbCategoria.SelectedItem.ToString()];
                PalabraServiceClient palabraServiceClient = new PalabraServiceClient();
                try
                {
                    var palabras = palabraServiceClient.ObtenerPalabrasPorFiltroAsync(categoria,dificultad).Result;
                    if (palabras != null)
                    {
                        InicializarComboBoxPalabras(palabras.ToList());
                        CbPalabra.IsEnabled = true;
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiGenerarPartidaNoPalabras"));
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
                partida.palabraSeleccionada = idiomaHilo == "es" ? palabra.Nombre : palabra.NombreIngles; ;//Validar Idioma
                partida.IntentosRestantes = 0;
                partida.PalabraParcial = GenericGuiController.EnmascararFrase(partida.palabraSeleccionada);//Validar Idioma
                partida.IdiomaPartida = idiomaHilo;
                partida.FechaCreacionPartida = DateTime.Now;
                try
                {
                    PartidaServiceClient partidaServiceClient = new PartidaServiceClient();
                    var respuesta = partidaServiceClient.CrearPartidaAsync(partida).Result;
                    if (respuesta != null)
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiGenerarPartidaExito"));
                        PartidaSingleton.Instance.Id = respuesta.Id;
                        PartidaSingleton.Instance.IdJugadorAnfitrion = respuesta.IdJugadorAnfitrion;
                        PartidaSingleton.Instance.IdEstadoPartida = respuesta.IdEstadoPartida;
                        PartidaSingleton.Instance.IntentosRestantes = respuesta.IntentosRestantes;
                        PartidaSingleton.Instance.PalabraParcial = respuesta.PalabraParcial;
                        PartidaSingleton.Instance.palabraSeleccionada = respuesta.palabraSeleccionada;
                        PartidaSingleton.Instance.IdPalabraSelecionada = respuesta.IdPalabraSelecionada;
                        PartidaSingleton.Instance.IdiomaPartida = respuesta.IdiomaPartida;
                        PartidaSingleton.Instance.FechaCreacionPartida = respuesta.FechaCreacionPartida;
                        cambiarVentana();
                    }
                    else
                    {
                        GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiGenerarPartidaError"));
                    }
                }
                catch (Exception)
                {
                    GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiGenerarPartidaErrorExcepcion"));
                    throw;
                }
            }
            else
            {
                GenericGuiController.MostrarMensajeBox(ResourceAccesor.GetString("GuiGenerarPartidaNoSeleccion"));
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
