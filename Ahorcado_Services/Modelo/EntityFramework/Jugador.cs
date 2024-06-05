using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ahorcado_Services.Modelo.EntityFramework
{
    public class Jugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required] 
        public string ApellidoMaterno { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public string Telefono { get; set; }
        public int Puntaje { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime fechaDeNacimiento { get; set; }
    }
}