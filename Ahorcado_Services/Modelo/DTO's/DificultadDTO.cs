using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Modelo.DTO_s
{
    public class DificultadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }

    }
}