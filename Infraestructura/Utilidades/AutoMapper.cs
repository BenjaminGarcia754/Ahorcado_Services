using Ahorcado_Services.Modelo.DTO_s;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Infraestructura.Utilidades
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<JugadorDTO, Jugador>().ReverseMap();
            CreateMap<DificultadDTO, Dificultad>().ReverseMap();
            //CreateMap<PalabraDTO, Palabra>().ReverseMap();
            //CreateMap<SubcategoriaDTO, Subcategoria>().ReverseMap();
            //CreateMap<CategoriaDTO, Categoria>().ReverseMap();


        }
    }
}