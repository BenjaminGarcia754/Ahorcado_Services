using Ahorcado_Services.Aplicacion.DAO;
using Ahorcado_Services.Modelo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PalabraService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PalabraService.svc o PalabraService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PalabraService : IPalabraService
    {
        public Palabra ObtenerPalabra(int IdPalabra)
        {
            return PalabraDAO.ObtenerPalabra(IdPalabra);
        }

        public List<Palabra> ObtenerPalabrasPorFiltro(int idCatergoria, int idDificultad)
        {
            return null;//PalabraDAO.ObtenerPalabrasPorFiltro(idCatergoria, idDificultad);
        }

        public Partida RealizarIntento(Partida partida, char caracterIntento)
        {
            return null;             
        }

        public bool RegistrarPalabra(Palabra palabra)
        {
            palabra = PalabraDAO.AsignarDificultadPalabra(palabra);
            return PalabraDAO.registrarPalabra(palabra);
            //Facil : Una palabrad
            //Intermedio Mas de dos menos o igual a 4
            //Dificil mas de 4 o numeros

        }
    }
}
