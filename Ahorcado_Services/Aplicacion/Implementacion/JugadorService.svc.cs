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

        public bool ActualizarInformacionJugador(JugadorDTO jugador)
        {
            var jugadorEntity = mapper.Map<Jugador>(jugador);
            try
            {
                ahorcadoDbContext.Jugadores.Update(jugadorEntity);
                ahorcadoDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ex.Source = "Error al actualizar la información del jugador";
                return false;
            }
            catch (EntityException ex)
            {
                ex.Source = "Error al actualizar la información del jugador";
                return false;
            }
            return true;
        }

        public JugadorDTO IniciarSesion(string nombre, string contrasena)
        {
            var jugador = ahorcadoDbContext.Jugadores.Where(j => j.Nombre == nombre && j.Contrasena == contrasena).FirstOrDefault();
            if (jugador != null)
            {
                return mapper.Map<JugadorDTO>(jugador);
            }
            return null;
        }

        public bool RegistrarJugador(JugadorDTO jugador)
        {
            var jugadorEntity = mapper.Map<Jugador>(jugador);
            try
            {
                ahorcadoDbContext.Jugadores.Add(jugadorEntity);
            }
            catch (DbUpdateException ex)
            {
                ex.Source = "Error al registrar el jugador";
                return false;
            }
            catch(EntityException ex)
            {
                ex.Source = "Error al registrar el jugador";
                return false;
            }
            return true;
        }

        public bool ExisteJugador(string correo)
        {
            var jugador = ahorcadoDbContext.Jugadores.Where(j => j.Correo == correo).FirstOrDefault();
            if (jugador != null)
            {
                return true;
            }
            return false;
        }
    }

}
