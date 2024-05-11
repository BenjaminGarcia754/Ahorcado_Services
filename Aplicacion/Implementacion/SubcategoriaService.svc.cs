using Ahorcado_Services.Infraestructura.Utilidades;
using Ahorcado_Services.Modelo.EntityFramework;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion
{
    public class SubcategoriaService : ISubcategoriaService
    {
        private AhorcadoDbContext ahorcadoDbContext = Conexion.ObtenerConexion;
        IMapper mapper = AutoMapperHelper.ObtenerMapper();
        public bool AddSubcategoria(Subcategoria subcategoria)
        {
            try
            {
                ahorcadoDbContext.Subcategorias.Add(subcategoria);
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error: " + ex.Source);
                return false;
            }
        }

        public Subcategoria GetSubcategoria(int id)
        {
            return ahorcadoDbContext.Subcategorias.Find(id);
        }

        public List<Subcategoria> GetSubcategorias()
        {
            return ahorcadoDbContext.Subcategorias.ToList(); 
        }
    }
}
