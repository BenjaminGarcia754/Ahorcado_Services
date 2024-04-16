using Ahorcado_Services.Modelo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ahorcado_Services.Aplicacion
{
    [ServiceContract]
    public interface ISubcategoriaService
    {
        [OperationContract]
        Subcategoria GetSubcategoria(int id);
        [OperationContract]
        List<Subcategoria> GetSubcategorias();
        [OperationContract]
        bool AddSubcategoria(Subcategoria subcategoria);
    }
}
