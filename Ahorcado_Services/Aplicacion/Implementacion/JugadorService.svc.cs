using Ahorcado_Services.Aplicacion.DAO;
using Ahorcado_Services.Infraestructura.Utilidades;
using Ahorcado_Services.Modelo.DTO_s;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion.Implementacion
{
    public class JugadorService : IJugadorService
    {
        public IMapper mapper = AutoMapperHelper.ObtenerMapper();
        AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;

        public bool ActualizarInformacionJugador(Jugador jugador)
        {
            return JugadorDAO.ActualizarInformacionJugador(jugador);
        }

        public Jugador IniciarSesion(string correo, string contrasena)
        {
            return JugadorDAO.IniciarSesion(correo, contrasena);
        }

        public bool RegistrarJugador(Jugador jugador)
        {
            //TODO: Agregar una entidad que indique el tipo de respuesta 
            return JugadorDAO.RegistrarJugador(jugador);
        }

        public bool ExisteJugador(string correo)
        {
            return JugadorDAO.ExisteJugador(correo);
        }
    }

}
