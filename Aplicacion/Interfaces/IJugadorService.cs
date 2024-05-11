using Ahorcado_Services.Modelo.DTO_s;
using Ahorcado_Services.Modelo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado_Services.Aplicacion
{
    [ServiceContract]
    internal interface IJugadorService
    {
        [OperationContract]
        bool RegistrarJugador(Jugador jugador);
        [OperationContract]
        Jugador IniciarSesion(string correo, string contrasena);
        [OperationContract]
        bool ActualizarInformacionJugador(Jugador jugador);
        [OperationContract]
        bool ExisteJugador(string correo);
    }
}
