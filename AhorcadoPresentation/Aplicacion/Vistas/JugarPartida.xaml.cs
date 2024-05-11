using AhorcadoPresentation.Modelo;
using AhorcadoPresentation.Modelo.Singleton;
using JugadorServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Lógica de interacción para JugarPartida.xaml
    /// </summary>
    public partial class JugarPartida : UserControl
    {
        public PalabraDTO palabraDTO = new PalabraDTO();
        private int numeroIntento = 0;
        public Jugador jugadorRetador { get; set; }
        public Jugador jugadorInvitado { get; set; }

        public JugarPartida()
        {
            InitializeComponent();
            //aqui se debe de recibir el id partida
            //despues se manda el id de la partida y el id del jugador al servicio 

            //para obtener la palabra a adivinar y la ayuda.
            palabraDTO.Nombre = "Los juegos del hambre en llamas español latino";
            PartidaSingleton partida= PartidaSingleton.ObtenerInstancia();
            tbAyuda.TextWrapping = TextWrapping.Wrap;
            tbAyuda.Text = "Categoria:\nPelicula\nDescripcion:\nEsta pelicula fue nominada al Oscar y fue protagonizada por Jennifer Lawrence";
            
            generarLabels();
        }

        private void generarLabels()
        {
            foreach (char letra in palabraDTO.Nombre)
            {
                System.Windows.Controls.Label labelLetra = generarLabel();
                if (letra != ' ')
                {
                    labelLetra.BorderThickness = new Thickness(0, 0, 0, 1);
                    labelLetra.BorderBrush = Brushes.White;
                }
                WPPalabraContainer.Children.Add(labelLetra);
            }
        }

        private System.Windows.Controls.Label generarLabel()
        {
            System.Windows.Controls.Label labelLetra = new System.Windows.Controls.Label();
            labelLetra.Width = 30;
            labelLetra.Height = 32;
            labelLetra.FontSize = 17;
            labelLetra.Margin = new Thickness(5);
            labelLetra.HorizontalContentAlignment = HorizontalAlignment.Center;
            labelLetra.VerticalContentAlignment = VerticalAlignment.Top;
            labelLetra.Foreground = Brushes.White;
            labelLetra.FontFamily = (FontFamily)Application.Current.Resources["Inter"];
            return labelLetra;
        }

        private void Click_intentar(object sender, RoutedEventArgs e)
        {
            Button buttonLetra = (Button)sender;
            char letra = buttonLetra.Content.ToString().ToLower().ToCharArray()[0];
            if (palabraDTO.Nombre.ToLower().Contains(letra))
            {
                for (int i = 0; i < palabraDTO.Nombre.Length; i++)
                {
                    if (palabraDTO.Nombre.ToLower().ToCharArray()[i] == letra)
                    {
                        ((System.Windows.Controls.Label)WPPalabraContainer.Children[i]).Content = palabraDTO.Nombre.ToCharArray()[i];
                    }
                }
            }else
            {
                MessageBox.Show("La letra no se encuentra en la palabra");
                cambiarImagen();
            }
            buttonLetra.Visibility = Visibility.Hidden;
        }

        private void cambiarImagen()
        {
            numeroIntento++;
            if (numeroIntento == 1)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/PrimerIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 2)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/SegundoIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 3)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/TercerIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 4)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/cuartoIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 5)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/QuintoIntento.png", UriKind.Relative));
            }
            else if (numeroIntento == 6)
            {
                ImagenIntento.Source = new BitmapImage(new Uri("/Aplicacion/Resources/SextoIntento.png", UriKind.Relative));
            }
        }
    }

}
