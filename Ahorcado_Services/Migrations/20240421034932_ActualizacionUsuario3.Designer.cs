﻿// <auto-generated />
using System;
using Ahorcado_Services.Modelo.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ahorcado_Services.Migrations
{
    [DbContext(typeof(AhorcadoDbContext))]
    [Migration("20240421034932_ActualizacionUsuario3")]
    partial class ActualizacionUsuario3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Dificultad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dificultades");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.EstadoPartida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstadosPartida");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Palabra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDificultad")
                        .HasColumnType("int");

                    b.Property<int>("IdSubcategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubcategoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("dificultadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoriaId");

                    b.HasIndex("dificultadId");

                    b.ToTable("Palabras");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Partida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoPalabra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstadoPartidaId")
                        .HasColumnType("int");

                    b.Property<int>("IdEstadoPartida")
                        .HasColumnType("int");

                    b.Property<int>("IdJugadorAnfitrion")
                        .HasColumnType("int");

                    b.Property<int>("IdJugadorInvitado")
                        .HasColumnType("int");

                    b.Property<int>("IdPalabraSelecionada")
                        .HasColumnType("int");

                    b.Property<int>("IntentosRestantes")
                        .HasColumnType("int");

                    b.Property<int?>("PalabraId")
                        .HasColumnType("int");

                    b.Property<bool>("PartidaGanada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EstadoPartidaId");

                    b.HasIndex("PalabraId");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Subcategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("categoriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categoriaId");

                    b.ToTable("Subcategorias");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Palabra", b =>
                {
                    b.HasOne("Ahorcado_Services.Modelo.EntityFramework.Subcategoria", "Subcategoria")
                        .WithMany("Palabras")
                        .HasForeignKey("SubcategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ahorcado_Services.Modelo.EntityFramework.Dificultad", "dificultad")
                        .WithMany("Palabras")
                        .HasForeignKey("dificultadId");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Partida", b =>
                {
                    b.HasOne("Ahorcado_Services.Modelo.EntityFramework.EstadoPartida", "EstadoPartida")
                        .WithMany("Partidas")
                        .HasForeignKey("EstadoPartidaId");

                    b.HasOne("Ahorcado_Services.Modelo.EntityFramework.Palabra", "Palabra")
                        .WithMany()
                        .HasForeignKey("PalabraId");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Subcategoria", b =>
                {
                    b.HasOne("Ahorcado_Services.Modelo.EntityFramework.Categoria", "categoria")
                        .WithMany("Subcategorias")
                        .HasForeignKey("categoriaId");
                });
#pragma warning restore 612, 618
        }
    }
}
