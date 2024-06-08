using AhorcadoPresentation.Modelo.Singleton;
using AutoMapper;
using JugadorServiceReference;
using PartidaService;
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
            //Automappers para jugador
            CreateMap<JugadorSingleton, JugadorServiceReference.Jugador>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username)) // Mapear Username
                .ForMember(dest => dest.fechaDeNacimiento, opt => opt.MapFrom(src => src.fechaDeNacimiento.ToString("yyyy-MM-dd"))); // Convertir fecha de nacimiento a string en formato "yyyy-MM-dd"

            CreateMap<JugadorServiceReference.Jugador, JugadorSingleton>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username)) // Mapear Username
                .ForMember(dest => dest.fechaDeNacimiento, opt => opt.MapFrom(src => DateTime.Parse(src.fechaDeNacimiento.ToString()))); // Convertir fecha de nacimiento a DateTime

            //Automappers para partida
            CreateMap<PartidaSingleton, Partida>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdJugadorInvitado, opt => opt.MapFrom(src => src.IdJugadorInvitado))
                .ForMember(dest => dest.IdPalabraSelecionada, opt => opt.MapFrom(src => src.IdPalabraSelecionada))
                .ForMember(dest => dest.IdEstadoPartida, opt => opt.MapFrom(src => src.IdEstadoPartida))
                .ForMember(dest => dest.IntentosRestantes, opt => opt.MapFrom(src => src.IntentosRestantes))
                .ForMember(dest => dest.PalabraParcial, opt => opt.MapFrom(src => src.PalabraParcial))
                .ForMember(dest => dest.PartidaGanadaJugadorAnfitrion, opt => opt.MapFrom(src => src.PartidaGanadaJugadorAnfitrion))
                .ForMember(dest => dest.PartidaGanadaJugadorInvitado, opt => opt.MapFrom(src => src.PartidaGanadaJugadorInvitado))
                .ForMember(dest => dest.palabraSeleccionada, opt => opt.MapFrom(src => src.palabraSeleccionada))
                .ForMember(dest => dest.FechaCreacionPartida, opt => opt.MapFrom(src => src.FechaCreacionPartida))
                .ReverseMap();
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
