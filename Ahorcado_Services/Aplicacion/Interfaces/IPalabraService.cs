using Ahorcado_Services.Modelo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPalabraService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPalabraService
    {
        [OperationContract]
        Palabra ObtenerPalabra(int IdPalabra);
        [OperationContract]
        List<Palabra> ObtenerPalabrasPorFiltro(int idCatergoria, int idDificultad);
        [OperationContract]
        Partida RealizarIntento(Partida partida, char caracterIntento);
        [OperationContract]
        bool RegistrarPalabra(Palabra palabra);
    }
}
