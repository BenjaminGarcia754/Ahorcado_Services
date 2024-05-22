using Ahorcado_Services.Modelo.EntityFramework;
using Ahorcado_Services.Modelo.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPartidaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPartidaService
    {
        [OperationContract]
         List<Partida> ObtenerPartidasDisponibles();
        [OperationContract]
        PartidaRespuesta ObtenerPartidasPorJugador(int IdJugador);
    }
   
}
