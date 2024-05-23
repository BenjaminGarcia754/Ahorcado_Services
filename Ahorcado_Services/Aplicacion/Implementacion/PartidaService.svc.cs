using Ahorcado_Services.Aplicacion.DAO;
using Ahorcado_Services.Modelo.EntityFramework;
using Ahorcado_Services.Modelo.Respuestas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PartidaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PartidaService.svc o PartidaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PartidaService : IPartidaService
    {
        AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public List<Partida> ObtenerPartidasDisponibles()
        {
            return PartidaDAO.ObtenerPartidasListasParaJugar();
        }

        public PartidaRespuesta ObtenerPartidasPorJugador(int IdJugador)
        {
            return PartidaDAO.ObtenerPartidasPorJugador(IdJugador);
        }

        public PartidaRespuesta RealizarIntento(Partida partida, char caracterIntento)
        {
            return PartidaDAO.RealizarIntento(partida, caracterIntento);    
        }
    }
}
