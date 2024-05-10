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
    public class CategoriaService : ICategoriaService
    {
        private AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public IMapper mapper = AutoMapperHelper.ObtenerMapper();

        public Categoria GetCategoria(int id)
        {
            return ahorcadoDbContext.Categorias.Find(id);
        }

        public List<Categoria> GetCategorias()
        {
            return ahorcadoDbContext.Categorias.ToList();
        }

        public bool AddCategoria(Categoria categoria)
        {
            try
            {
                ahorcadoDbContext.Categorias.Add(categoria);
                ahorcadoDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
