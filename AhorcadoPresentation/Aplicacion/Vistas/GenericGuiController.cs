using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AhorcadoPresentation.Aplicacion.Vistas
{
    internal static class GenericGuiController
    {
        public static void MostrarMensajeBox(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
