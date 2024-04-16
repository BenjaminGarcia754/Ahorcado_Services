﻿using Ahorcado_Services.Infraestructura.Utilidades;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion
{
    public class DificultadService : IDificultadService
    {
        private AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public IMapper mapper = AutoMapperHelper.ObtenerMapper();
        public Dificultad GetDificultad(int id)
        {
            return ahorcadoDbContext.Dificultades.Find(id);
        }

        public List<Dificultad> GetDificultades()
        {
            List<Dificultad> dificultades = ahorcadoDbContext.Dificultades.ToList();
            return dificultades;
        }
    }
}