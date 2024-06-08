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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EstadoPartidaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EstadoPartidaService.svc o EstadoPartidaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EstadoPartidaService : IEstadoPartidaService
    {

        public bool AgregarEstadoPartida(EstadoPartida estadoPartida)
        {
            return EstadoPartidaDAO.AgregarEstadoPartida(estadoPartida);    
        }

        public EstadoPartida ObtenerEstadoPartidaPorId(int idEstadoPartida)
        {
            return EstadoPartidaDAO.ObtenerEstadoPartidaPorId(idEstadoPartida);
        }

        public List<EstadoPartida> ObtenerEstadosPartida()
        {
            return EstadoPartidaDAO.ObtenerEstadosPartida();
        }
    }
}
