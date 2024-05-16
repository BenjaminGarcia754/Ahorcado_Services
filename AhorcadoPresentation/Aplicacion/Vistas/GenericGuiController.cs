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

namespace AhorcadoPresentation.Aplicacion.Vistas
{
    internal static class GenericGuiController
    {
        public static void MostrarMensajeBox(string mensaje)
        {
            MessageBox.Show(mensaje);
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

        public static bool ValidarTextBlockVacios(List<TextBox> textBoxes)
        {
            bool respuesta = true;
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
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
            if (mayuscula && minuscula && numero && carespecial && contraseña.Length >= 8)
            {
                return true;
            }
            return false;
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
            }else
            {
                datePicker.Background = Brushes.OrangeRed;
                respuesta = false;
            }
            return respuesta;
        }

    }
}
