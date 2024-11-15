﻿using Ahorcado_Services.Modelo.EntityFramework;
using Ahorcado_Services.Modelo.Respuestas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPartidaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPartidaService
    {
        [OperationContract]
        PartidaRespuesta ObtenerPartidasPorJugador(int IdJugador);
        [OperationContract]
        Task<bool> ActualizarPartida(Partida partida);
        [OperationContract]
        Partida CrearPartida(Partida partida);
        [OperationContract]
        PartidaRespuesta RealizarIntento(Partida partida, char caracterIntento);
        [OperationContract]
        List<Partida> ObtenerPartidasListasParaJugar();
        //[OperationContract]
        //PartidaRespuesta RealizarIntento(Partida partida, string palabraIntento);
        [OperationContract]
        Task<PartidaRespuesta> ObtenerPartidaPorId(int idPartida);
        [OperationContract]
        PartidaRespuesta ObtenerTodasLasPartidasPorJugador(int idJugardor);
    }

}
