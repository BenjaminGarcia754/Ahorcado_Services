using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoPresentation.Modelo
{
    public class PalabraDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSubcategoria { get; set; }
        public int IdDificultad { get; set; }
        public string Descripcion { get; set; }
    }
}
