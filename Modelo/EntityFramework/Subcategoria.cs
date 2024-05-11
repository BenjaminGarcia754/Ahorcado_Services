using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.EntityFramework
{
    public class Subcategoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public Categoria categoria { get; set; }
        public List<Palabra> Palabras { get; set; }
    }
}