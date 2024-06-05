using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace AhorcadoPresentation.RecursosLocalizables
{
    [MarkupExtensionReturnType(typeof(string))]
    public class ResxExtension : MarkupExtension
    {
        public string Key { get; set; }

        public ResxExtension() { }

        public ResxExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Key == null)
                return string.Empty;

            return ResourceAccesor.GetString(Key);
        }
    }

}
