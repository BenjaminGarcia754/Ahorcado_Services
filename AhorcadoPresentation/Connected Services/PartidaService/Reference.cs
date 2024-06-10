﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PartidaService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PartidaRespuesta", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.Respuestas")]
    public partial class PartidaRespuesta : object
    {
        
        private PartidaService.Jugador[] JugadoresField;
        
        private PartidaService.Partida[] PartidasField;
        
        private PartidaService.Partida partidaField;
        
        private bool respuestaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.Jugador[] Jugadores
        {
            get
            {
                return this.JugadoresField;
            }
            set
            {
                this.JugadoresField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.Partida[] Partidas
        {
            get
            {
                return this.PartidasField;
            }
            set
            {
                this.PartidasField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.Partida partida
        {
            get
            {
                return this.partidaField;
            }
            set
            {
                this.partidaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool respuesta
        {
            get
            {
                return this.respuestaField;
            }
            set
            {
                this.respuestaField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Partida", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Partida : object
    {
        
        private PartidaService.EstadoPartida EstadoPartidaField;
        
        private System.DateTime FechaCreacionPartidaField;
        
        private int IdField;
        
        private int IdEstadoPartidaField;
        
        private int IdJugadorAnfitrionField;
        
        private int IdJugadorInvitadoField;
        
        private int IdPalabraSelecionadaField;
        
        private string IdiomaPartidaField;
        
        private int IntentosRestantesField;
        
        private PartidaService.Palabra PalabraField;
        
        private string PalabraParcialField;
        
        private bool PartidaGanadaJugadorAnfitrionField;
        
        private bool PartidaGanadaJugadorInvitadoField;
        
        private string palabraSeleccionadaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.EstadoPartida EstadoPartida
        {
            get
            {
                return this.EstadoPartidaField;
            }
            set
            {
                this.EstadoPartidaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaCreacionPartida
        {
            get
            {
                return this.FechaCreacionPartidaField;
            }
            set
            {
                this.FechaCreacionPartidaField = value;
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
        public int IdEstadoPartida
        {
            get
            {
                return this.IdEstadoPartidaField;
            }
            set
            {
                this.IdEstadoPartidaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdJugadorAnfitrion
        {
            get
            {
                return this.IdJugadorAnfitrionField;
            }
            set
            {
                this.IdJugadorAnfitrionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdJugadorInvitado
        {
            get
            {
                return this.IdJugadorInvitadoField;
            }
            set
            {
                this.IdJugadorInvitadoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdPalabraSelecionada
        {
            get
            {
                return this.IdPalabraSelecionadaField;
            }
            set
            {
                this.IdPalabraSelecionadaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IdiomaPartida
        {
            get
            {
                return this.IdiomaPartidaField;
            }
            set
            {
                this.IdiomaPartidaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IntentosRestantes
        {
            get
            {
                return this.IntentosRestantesField;
            }
            set
            {
                this.IntentosRestantesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.Palabra Palabra
        {
            get
            {
                return this.PalabraField;
            }
            set
            {
                this.PalabraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PalabraParcial
        {
            get
            {
                return this.PalabraParcialField;
            }
            set
            {
                this.PalabraParcialField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PartidaGanadaJugadorAnfitrion
        {
            get
            {
                return this.PartidaGanadaJugadorAnfitrionField;
            }
            set
            {
                this.PartidaGanadaJugadorAnfitrionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PartidaGanadaJugadorInvitado
        {
            get
            {
                return this.PartidaGanadaJugadorInvitadoField;
            }
            set
            {
                this.PartidaGanadaJugadorInvitadoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string palabraSeleccionada
        {
            get
            {
                return this.palabraSeleccionadaField;
            }
            set
            {
                this.palabraSeleccionadaField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Jugador", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Jugador : object
    {
        
        private string ApellidoMaternoField;
        
        private string ApellidoPaternoField;
        
        private string ContrasenaField;
        
        private string CorreoField;
        
        private int IdField;
        
        private string NombreField;
        
        private int PuntajeField;
        
        private string TelefonoField;
        
        private string UsernameField;
        
        private System.DateTime fechaDeNacimientoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoMaterno
        {
            get
            {
                return this.ApellidoMaternoField;
            }
            set
            {
                this.ApellidoMaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoPaterno
        {
            get
            {
                return this.ApellidoPaternoField;
            }
            set
            {
                this.ApellidoPaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contrasena
        {
            get
            {
                return this.ContrasenaField;
            }
            set
            {
                this.ContrasenaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Correo
        {
            get
            {
                return this.CorreoField;
            }
            set
            {
                this.CorreoField = value;
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
        public int Puntaje
        {
            get
            {
                return this.PuntajeField;
            }
            set
            {
                this.PuntajeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono
        {
            get
            {
                return this.TelefonoField;
            }
            set
            {
                this.TelefonoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime fechaDeNacimiento
        {
            get
            {
                return this.fechaDeNacimientoField;
            }
            set
            {
                this.fechaDeNacimientoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EstadoPartida", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class EstadoPartida : object
    {
        
        private int IdField;
        
        private string NombreField;
        
        private PartidaService.Partida[] PartidasField;
        
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
        public PartidaService.Partida[] Partidas
        {
            get
            {
                return this.PartidasField;
            }
            set
            {
                this.PartidasField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Palabra", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Palabra : object
    {
        
        private PartidaService.Categoria CategoriaField;
        
        private string DescripcionField;
        
        private string DescripcionInglesField;
        
        private int IdField;
        
        private int IdCategoriaField;
        
        private int IdDificultadField;
        
        private string NombreField;
        
        private string NombreInglesField;
        
        private PartidaService.Dificultad dificultadField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.Categoria Categoria
        {
            get
            {
                return this.CategoriaField;
            }
            set
            {
                this.CategoriaField = value;
            }
        }
        
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
        public string DescripcionIngles
        {
            get
            {
                return this.DescripcionInglesField;
            }
            set
            {
                this.DescripcionInglesField = value;
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
        public string NombreIngles
        {
            get
            {
                return this.NombreInglesField;
            }
            set
            {
                this.NombreInglesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.Dificultad dificultad
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Categoria", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Categoria : object
    {
        
        private int IdField;
        
        private string NombreField;
        
        private string NombreInglesField;
        
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
        public string NombreIngles
        {
            get
            {
                return this.NombreInglesField;
            }
            set
            {
                this.NombreInglesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Dificultad", Namespace="http://schemas.datacontract.org/2004/07/Ahorcado_Services.Modelo.EntityFramework")]
    public partial class Dificultad : object
    {
        
        private int IdField;
        
        private string NombreField;
        
        private string NombreInglesField;
        
        private PartidaService.Palabra[] PalabrasField;
        
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
        public string NombreIngles
        {
            get
            {
                return this.NombreInglesField;
            }
            set
            {
                this.NombreInglesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartidaService.Palabra[] Palabras
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PartidaService.IPartidaService")]
    public interface IPartidaService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPartidaService/ObtenerPartidasPorJugador", ReplyAction="http://tempuri.org/IPartidaService/ObtenerPartidasPorJugadorResponse")]
        System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> ObtenerPartidasPorJugadorAsync(int IdJugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPartidaService/ActualizarPartida", ReplyAction="http://tempuri.org/IPartidaService/ActualizarPartidaResponse")]
        System.Threading.Tasks.Task<bool> ActualizarPartidaAsync(PartidaService.Partida partida);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPartidaService/CrearPartida", ReplyAction="http://tempuri.org/IPartidaService/CrearPartidaResponse")]
        System.Threading.Tasks.Task<PartidaService.Partida> CrearPartidaAsync(PartidaService.Partida partida);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPartidaService/RealizarIntento", ReplyAction="http://tempuri.org/IPartidaService/RealizarIntentoResponse")]
        System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> RealizarIntentoAsync(PartidaService.Partida partida, char caracterIntento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPartidaService/ObtenerPartidasListasParaJugar", ReplyAction="http://tempuri.org/IPartidaService/ObtenerPartidasListasParaJugarResponse")]
        System.Threading.Tasks.Task<PartidaService.Partida[]> ObtenerPartidasListasParaJugarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPartidaService/ObtenerPartidaPorId", ReplyAction="http://tempuri.org/IPartidaService/ObtenerPartidaPorIdResponse")]
        System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> ObtenerPartidaPorIdAsync(int idPartida);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPartidaService/ObtenerTodasLasPartidasPorJugador", ReplyAction="http://tempuri.org/IPartidaService/ObtenerTodasLasPartidasPorJugadorResponse")]
        System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> ObtenerTodasLasPartidasPorJugadorAsync(int idJugardor);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IPartidaServiceChannel : PartidaService.IPartidaService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class PartidaServiceClient : System.ServiceModel.ClientBase<PartidaService.IPartidaService>, PartidaService.IPartidaService
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public PartidaServiceClient() : 
                base(PartidaServiceClient.GetDefaultBinding(), PartidaServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IPartidaService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PartidaServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(PartidaServiceClient.GetBindingForEndpoint(endpointConfiguration), PartidaServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PartidaServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(PartidaServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PartidaServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(PartidaServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PartidaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> ObtenerPartidasPorJugadorAsync(int IdJugador)
        {
            return base.Channel.ObtenerPartidasPorJugadorAsync(IdJugador);
        }
        
        public System.Threading.Tasks.Task<bool> ActualizarPartidaAsync(PartidaService.Partida partida)
        {
            return base.Channel.ActualizarPartidaAsync(partida);
        }
        
        public System.Threading.Tasks.Task<PartidaService.Partida> CrearPartidaAsync(PartidaService.Partida partida)
        {
            return base.Channel.CrearPartidaAsync(partida);
        }
        
        public System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> RealizarIntentoAsync(PartidaService.Partida partida, char caracterIntento)
        {
            return base.Channel.RealizarIntentoAsync(partida, caracterIntento);
        }
        
        public System.Threading.Tasks.Task<PartidaService.Partida[]> ObtenerPartidasListasParaJugarAsync()
        {
            return base.Channel.ObtenerPartidasListasParaJugarAsync();
        }
        
        public System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> ObtenerPartidaPorIdAsync(int idPartida)
        {
            return base.Channel.ObtenerPartidaPorIdAsync(idPartida);
        }
        
        public System.Threading.Tasks.Task<PartidaService.PartidaRespuesta> ObtenerTodasLasPartidasPorJugadorAsync(int idJugardor)
        {
            return base.Channel.ObtenerTodasLasPartidasPorJugadorAsync(idJugardor);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPartidaService))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPartidaService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:55459/Aplicacion/Implementacion/PartidaService.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return PartidaServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IPartidaService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return PartidaServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IPartidaService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IPartidaService,
        }
    }
}
