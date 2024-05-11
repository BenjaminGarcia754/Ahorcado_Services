using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.DTO_s
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