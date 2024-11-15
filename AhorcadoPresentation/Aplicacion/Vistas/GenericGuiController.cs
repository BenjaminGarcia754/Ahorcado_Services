﻿using AhorcadoPresentation.Modelo.Singleton;
using AhorcadoPresentation.RecursosLocalizables;
using PartidaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace AhorcadoPresentation.Aplicacion.Vistas
{
    internal static class GenericGuiController
    {
        public static void MostrarMensajeBox(string mensaje)
        {
            //MessageBox.Show(mensaje);
            Alertas.Alerta alerta = new Alertas.Alerta(mensaje);
            alerta.ShowDialog();
        }

        public static string EnmascararFrase(string frase)
        {
            char[] arregloEnmascarado = new char[frase.Length];

            for (int i = 0; i < frase.Length; i++)
            {
                if (char.IsWhiteSpace(frase[i]))
                {
                    arregloEnmascarado[i] = ' ';
                }
                else
                {
                    arregloEnmascarado[i] = '_';
                }
            }

            return new string(arregloEnmascarado);
        }


        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static void MapearPartida(PartidaRespuesta partidaRespuesta)
        {
            PartidaSingleton.Instance.Id = partidaRespuesta.partida.Id;
            PartidaSingleton.Instance.IdJugadorAnfitrion = partidaRespuesta.partida.IdJugadorAnfitrion;
            PartidaSingleton.Instance.IdJugadorInvitado = JugadorSingleton.Instance.Id;
            PartidaSingleton.Instance.IdEstadoPartida = partidaRespuesta.partida.IdEstadoPartida;
            PartidaSingleton.Instance.IntentosRestantes = partidaRespuesta.partida.IntentosRestantes;
            PartidaSingleton.Instance.PalabraParcial = partidaRespuesta.partida.PalabraParcial;
            PartidaSingleton.Instance.palabraSeleccionada = partidaRespuesta.partida.palabraSeleccionada;
            PartidaSingleton.Instance.IdPalabraSelecionada = partidaRespuesta.partida.IdPalabraSelecionada;
        }

        public static bool ValidarTextBlockVacios(List<TextBox> textBoxes)
        {
            bool respuesta = true;
            foreach (var textBox in textBoxes)
            {
                
                if (string.IsNullOrEmpty(textBox.Text) && !string.Equals(textBox.Name, "TbApellidoMaterno"))
                {
                    textBox.Background = Brushes.OrangeRed;
                    respuesta = false;
                }
                else
                {
                    textBox.Background = null;
                }
            }
            return respuesta;
        }

        public static bool ValidarPasswordBox(PasswordBox passwordBox)
        {
            bool respuesta = true;
            if (string.IsNullOrEmpty(passwordBox.Password) )
            {
                passwordBox.Background = Brushes.OrangeRed;
                respuesta = false;

            }
            else
            {
                if (!ContraseñaSegura(passwordBox.Password))
                {
                    respuesta = false;
                    passwordBox.Background = Brushes.OrangeRed;
                }
                else
                {
                    passwordBox.Background = null;
                }
            }
            return respuesta;
        }

        public static bool ContraseñaSegura(string contraseña)
        {
            bool respuesta;
            bool mayuscula = false, minuscula = false, numero = false, carespecial = false;
            for (int i = 0; i < contraseña.Length; i++)
            {
                if (Char.IsUpper(contraseña, i))
                {
                    mayuscula = true;
                }
                else if (Char.IsLower(contraseña, i))
                {
                    minuscula = true;
                }
                else if (Char.IsDigit(contraseña, i))
                {
                    numero = true;
                }
                else
                {
                    carespecial = true;
                }
            }

            if (carespecial)
            {
                respuesta = false;
            }
            else 
            {
                if (mayuscula && minuscula && numero && contraseña.Length >= 8)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public static bool ValidarDatePicker(DatePicker datePicker)
        {
            DateTime fechaMinima = new DateTime(1950, 1, 1);
            DateTime fechaMaxima = DateTime.Now.AddYears(-10);
            bool respuesta = true;
            if (datePicker.SelectedDate != null)
            {
                DateTime fechaActual = datePicker.SelectedDate.Value;
                if (fechaActual < fechaMinima || fechaActual > fechaMaxima)
                {
                    respuesta = false;
                    datePicker.Background = Brushes.OrangeRed;
                }
                else
                {
                    datePicker.Background = null;
                }
            }else
            {
                datePicker.Background = Brushes.OrangeRed;
                respuesta = false;
            }
            return respuesta;
        }
        public static void imprimirPalabraParcial(WrapPanel WPPPalabraContenedor, string palabraParcial){
            WPPPalabraContenedor.Children.Clear();
            foreach (char letra in palabraParcial)
            {
                Label labelLetra = generarLabel();
                if (letra == ' ')
                {
                    labelLetra.BorderThickness = new Thickness(0, 0, 0, 0);
                }
                else if(letra != '_')
                {
                    labelLetra.Content = letra;
                }
                WPPPalabraContenedor.Children.Add(labelLetra);
            }
        }
        private static System.Windows.Controls.Label generarLabel()
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
            labelLetra.BorderThickness = new Thickness(0, 0, 0, 1);
            labelLetra.BorderBrush = Brushes.White;
            return labelLetra;
        }
        public static string FormatearFecha(DateTime fecha)
        {
           if(ResourceAccesor.GetIdiomaHilo() == Constantes.IDIOMA_INGLES)
           {
               return fecha.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
           }
           else
           {
                return fecha.ToString("dd 'de' MMMM 'de' yyyy", new CultureInfo("es-MX"));
           }
           
        }
    }
}
