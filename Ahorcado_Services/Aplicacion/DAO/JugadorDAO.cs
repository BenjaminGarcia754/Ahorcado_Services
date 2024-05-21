using Ahorcado_Services.Infraestructura.Utilidades;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Aplicacion.DAO
{
    public class JugadorDAO
    {
        public static readonly AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public static bool ActualizarInformacionJugador(Jugador jugador)
        {
            try
            {
                ahorcadoDbContext.Jugadores.Update(jugador);
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

        public static Jugador IniciarSesion(string correo, string contrasena)
        {
            try
            {
                var jugador = ahorcadoDbContext.Jugadores.Where(j => j.Correo == correo && j.Contrasena == contrasena).FirstOrDefault();
                if (jugador != null)
                {
                    return jugador;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al iniciar sesión");
            }
            return null;
        }

        public static bool RegistrarJugador(Jugador jugador)
        {
            //TODO: Agregar una entidad que indique el tipo de respuesta 
            try
            {
                ahorcadoDbContext.Jugadores.Add(jugador);
                ahorcadoDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (EntityException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool ExisteJugador(string correo)
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