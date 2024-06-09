using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoPresentation.RecursosLocalizables
{
    public static class ResourceAccesor
    {
        private static readonly ResourceManager resourceManager = new ResourceManager("AhorcadoPresentation.RecursosLocalizables.StringResources",
                    Assembly.GetExecutingAssembly());
        public static string GetString(string key)
        {
            return resourceManager.GetString(key);
        }
        public static string GetIdiomaHilo()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
        }
    }
}
