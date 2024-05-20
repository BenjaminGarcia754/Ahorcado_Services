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
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<JugadorSingleton, Jugador>().ReverseMap();
        }

        public static IMapper ObtenerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Mapper>();
            });

            return config.CreateMapper();
        }

    }
}
