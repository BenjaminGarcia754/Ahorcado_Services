using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Infraestructura.Utilidades
{
    public static class AutoMapperHelper
    {
        public static IMapper ObtenerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapper>();
            });

            return config.CreateMapper();
        }
    }
}