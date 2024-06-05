using Ahorcado_Services.Aplicacion.DAO;
using Ahorcado_Services.Infraestructura.Utilidades;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "DificultadService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione DificultadService.svc o DificultadService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class DificultadService : IDificultadService
    {
        private AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public IMapper mapper = AutoMapperHelper.ObtenerMapper();


        public List<Dificultad> GetDificultades()
        {
            return ahorcadoDbContext.Dificultades.ToList();
        }

        public Dificultad GetDificultad(int id)
        {
            return DificultadDAO.GetDificultad(id);
        }

        public bool AddDificultad(Dificultad dificultad)
        {
            return DificultadDAO.AddDificultad(dificultad);
        }
    }
}
