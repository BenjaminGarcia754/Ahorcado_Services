using Ahorcado_Services.Infraestructura.Utilidades;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ahorcado_Services.Aplicacion.DAO
{
    public class CategoriaService
    {
        private static readonly AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        public IMapper mapper = AutoMapperHelper.ObtenerMapper();

        public static Categoria GetCategoria(int id)
        {
            return ahorcadoDbContext.Categorias.Find(id);
        }

        public static List<Categoria> GetCategorias()
        {
            return ahorcadoDbContext.Categorias.ToList();
        }

        public static bool AddCategoria(Categoria categoria)
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