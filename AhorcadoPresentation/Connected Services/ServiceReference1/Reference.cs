﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Dificultad", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Dificultad : object
    {
        
        private int IdField;
        
        private int NivelField;
        
        private string NombreField;
        
        private ServiceReference1.Palabra[] PalabrasField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Nivel
        {
            get
            {
                return this.NivelField;
            }
            set
            {
                this.NivelField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre
        {
            get
            {
                return this.NombreField;
            }
            set
            {
                this.NombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Palabra[] Palabras
        {
            get
            {
                return this.PalabrasField;
            }
            set
            {
                this.PalabrasField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Palabra", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Palabra : object
    {
        
        private string DescripcionField;
        
        private int IdField;
        
        private int IdDificultadField;
        
        private int IdSubcategoriaField;
        
        private string NombreField;
        
        private ServiceReference1.Subcategoria SubcategoriaField;
        
        private ServiceReference1.Dificultad dificultadField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdDificultad
        {
            get
            {
                return this.IdDificultadField;
            }
            set
            {
                this.IdDificultadField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdSubcategoria
        {
            get
            {
                return this.IdSubcategoriaField;
            }
            set
            {
                this.IdSubcategoriaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre
        {
            get
            {
                return this.NombreField;
            }
            set
            {
                this.NombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Subcategoria Subcategoria
        {
            get
            {
                return this.SubcategoriaField;
            }
            set
            {
                this.SubcategoriaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Dificultad dificultad
        {
            get
            {
                return this.dificultadField;
            }
            set
            {
                this.dificultadField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Subcategoria", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Subcategoria : object
    {
        
        private int IdField;
        
        private int IdCategoriaField;
        
        private string NombreField;
        
        private ServiceReference1.Palabra[] PalabrasField;
        
        private ServiceReference1.Categoria categoriaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdCategoria
        {
            get
            {
                return this.IdCategoriaField;
            }
            set
            {
                this.IdCategoriaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre
        {
            get
            {
                return this.NombreField;
            }
            set
            {
                this.NombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Palabra[] Palabras
        {
            get
            {
                return this.PalabrasField;
            }
            set
            {
                this.PalabrasField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Categoria categoria
        {
            get
            {
                return this.categoriaField;
            }
            set
            {
                this.categoriaField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Categoria", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Categoria : object
    {
        
        private int IdField;
        
        private string NombreField;
        
        private ServiceReference1.Subcategoria[] SubcategoriasField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre
        {
            get
            {
                return this.NombreField;
            }
            set
            {
                this.NombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.Subcategoria[] Subcategorias
        {
            get
            {
                return this.SubcategoriasField;
            }
            set
            {
                this.SubcategoriasField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDificultadService")]
    public interface IDificultadService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDificultadService/GetDificultades", ReplyAction="http://tempuri.org/IDificultadService/GetDificultadesResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Dificultad[]> GetDificultadesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDificultadService/GetDificultad", ReplyAction="http://tempuri.org/IDificultadService/GetDificultadResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Dificultad> GetDificultadAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IDificultadServiceChannel : ServiceReference1.IDificultadService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class DificultadServiceClient : System.ServiceModel.ClientBase<ServiceReference1.IDificultadService>, ServiceReference1.IDificultadService
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DificultadServiceClient() : 
                base(DificultadServiceClient.GetDefaultBinding(), DificultadServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDificultadService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DificultadServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(DificultadServiceClient.GetBindingForEndpoint(endpointConfiguration), DificultadServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DificultadServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DificultadServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DificultadServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DificultadServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DificultadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Dificultad[]> GetDificultadesAsync()
        {
            return base.Channel.GetDificultadesAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Dificultad> GetDificultadAsync(int id)
        {
            return base.Channel.GetDificultadAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDificultadService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDificultadService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:55459/Aplicacion/Implementacion/DificultadService.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return DificultadServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDificultadService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return DificultadServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDificultadService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IDificultadService,
        }
    }
}