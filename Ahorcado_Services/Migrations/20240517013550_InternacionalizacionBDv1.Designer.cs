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
    [Migration("20240517013550_InternacionalizacionBDv1")]
    partial class InternacionalizacionBDv1
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

                    b.Property<string>("NombreIngles")
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

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreIngles")
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

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaDeNacimiento")
                        .HasColumnType("datetime2");

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

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripcionIngles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdDificultad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreIngles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("dificultadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("dificultadId");

                    b.ToTable("Palabras");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Partida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstadoPartidaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacionPartida")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("PalabraParcial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PartidaGanada")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EstadoPartidaId");

                    b.HasIndex("PalabraId");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("Ahorcado_Services.Modelo.EntityFramework.Palabra", b =>
                {
                    b.HasOne("Ahorcado_Services.Modelo.EntityFramework.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
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
#pragma warning restore 612, 618
        }
    }
}
