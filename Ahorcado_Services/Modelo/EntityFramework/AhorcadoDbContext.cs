using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aqui podemos agregar las palabras iniciales :)
        }
    }
}