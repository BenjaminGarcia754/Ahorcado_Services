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
            CreateMap<JugadorSingleton, Jugador>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username)) // Mapear Username
                .ForMember(dest => dest.fechaDeNacimiento, opt => opt.MapFrom(src => src.fechaDeNacimiento.ToString("yyyy-MM-dd"))); // Convertir fecha de nacimiento a string en formato "yyyy-MM-dd"

            CreateMap<Jugador, JugadorSingleton>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username)) // Mapear Username
                .ForMember(dest => dest.fechaDeNacimiento, opt => opt.MapFrom(src => DateTime.Parse(src.fechaDeNacimiento.ToString()))); // Convertir fecha de nacimiento a DateTime
                
            
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
