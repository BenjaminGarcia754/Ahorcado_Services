using Ahorcado_Services.Modelo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Aplicacion.DAO
{
    public class PalabraDAO
    {
        public static readonly AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public static Palabra AsignarDificultadPalabra(Palabra palabraFiltrada)
        {
            Palabra palabra = new Palabra();
            //dividir la palabra por espacios y que devuelva un array de palabras
            string[] palabras = palabraFiltrada.Nombre.Split(' ');
            if (ContieneNumeros(palabraFiltrada.Nombre))
            {
                palabra.IdDificultad = 3;//dificil
            }
            else
            {
                if(palabras.Length == 1)
                {
                    palabra.IdDificultad = 1;//facil
                }
                else if(palabras.Length > 1 && palabras.Length <= 4)
                {
                    palabra.IdDificultad = 2;//intermedio
                }
                else if(palabras.Length > 4)
                {
                    palabra.IdDificultad = 3;//dificil
                }
            }
            return palabra;
        }

        public static List<string> dividirPalabra(string palabra)
        {
            return palabra.Split(' ').ToList();
        }

        public static bool ContieneNumeros(string palabra)
        {
            return palabra.Any(char.IsDigit);
        }

        public static bool registrarPalabra(Palabra palabra)
        {
            bool partidaCreada = true;
            try
            {
                ahorcadoDbContext.Palabras.Add(palabra);
                ahorcadoDbContext.SaveChanges();
            }
            catch (UpdateException ex)
            {
                partidaCreada = false;
                Console.WriteLine(ex.Message);
            }
            catch (EntityException ex)
            {
                partidaCreada = false;
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                partidaCreada = false;
                Console.WriteLine(ex.Message);
            }
            return partidaCreada;
        }

        public static Palabra ObtenerPalabra(int IdPalabra)
        {
            return ahorcadoDbContext.Palabras.Find(IdPalabra);
        }

        public static List<Palabra> ObtenerPalabrasPorFiltro(int idCatergoria, int idDificultad)
        {
            List<Palabra> palabras = new List<Palabra>();
            try
            {
                palabras = ahorcadoDbContext.Palabras.Where(p => p.IdCategoria == idCatergoria && p.IdDificultad == idDificultad).ToList();
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                palabras = null;
            }
            return palabras;
        }
        public static Partida RealizarIntento(Partida partida, char caracterIntento)
        {
            return null;
        }
    }
}