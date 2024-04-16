using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Ahorcado_Services.Modelo.EntityFramework
{
    public class AhorcadoDbContext : DbContext
    {

        public AhorcadoDbContext(DbContextOptions<AhorcadoDbContext> options) : base(options)
        {
        }

        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Dificultad> Dificultades { get; set; }
        public DbSet<Palabra> Palabras { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<EstadoPartida> EstadosPartida { get; set; }

        public AhorcadoDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionLocal"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aqui podemos agregar las palabras iniciales :)
        }
    }
}