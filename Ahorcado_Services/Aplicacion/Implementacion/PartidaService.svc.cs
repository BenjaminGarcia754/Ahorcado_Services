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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PartidaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PartidaService.svc o PartidaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PartidaService : IPartidaService
    {
        AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;

        public async Task<bool> ActualizarPartida(Partida partida)
        {
            return await PartidaDAO.ActualizarPartidaAsync(partida);
        }

        public Partida CrearPartida(Partida partida)
        {
            return PartidaDAO.CrearPartida(partida);
        }

        public async Task<PartidaRespuesta> ObtenerPartidaPorId(int idPartida)
        {
            return await PartidaDAO.ObtenerPartida(idPartida);
        }

        public List<Partida> ObtenerPartidasListasParaJugar()
        {
            return PartidaDAO.ObtenerPartidasListasParaJugar();
        }

        public PartidaRespuesta ObtenerPartidasPorJugador(int IdJugador)
        {
            return PartidaDAO.ObtenerPartidasJugadasPorJugador(IdJugador);
        }

        public PartidaRespuesta RealizarIntento(Partida partida, char caracterIntento)
        {
            return PartidaDAO.RealizarIntento(partida, caracterIntento);    
        }

        public PartidaRespuesta ObtenerTodasLasPartidasPorJugador(int idJugardor)
        {
            return PartidaDAO.ObtenerTodasLasPartidasPorJugador(idJugardor);
        }
        /*
        public PartidaRespuesta RealizarIntento(Partida partida, string palabraIntento)
        {
            throw new NotImplementedException();
        }
        */
    }
}
