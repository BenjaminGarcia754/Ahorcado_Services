using Ahorcado_Services.Modelo.DTO_s;
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
        bool RegistrarJugador(JugadorDTO jugador);
        [OperationContract]
        JugadorDTO IniciarSesion(string nombre, string contrasena);
        [OperationContract]
        bool ActualizarInformacionJugador(JugadorDTO jugador);
        [OperationContract]
        bool ExisteJugador(string correo);
    }
}
