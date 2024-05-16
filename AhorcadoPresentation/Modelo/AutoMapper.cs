using AhorcadoPresentation.Modelo.Singleton;
using AutoMapper;
using JugadorServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoPresentation.Modelo
{
    internal class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<JugadorSingleton, Jugador>().ReverseMap();
        }

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
