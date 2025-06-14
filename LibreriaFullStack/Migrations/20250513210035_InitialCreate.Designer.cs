﻿// <auto-generated />
using System;
using Libreria.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Libreria.Backend.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20250513210035_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Libreria.Backend.Models.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AutorId"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FhNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AutorId");

                    b.ToTable("Autors");
                });

            modelBuilder.Entity("Libreria.Backend.Models.Libro", b =>
                {
                    b.Property<int>("LibroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LibroID"));

                    b.Property<int>("Anio")
                        .HasColumnType("integer");

                    b.Property<int>("AutorID")
                        .HasColumnType("integer");

                    b.Property<string>("Editorial")
                        .HasColumnType("text");

                    b.Property<string>("Genero")
                        .HasColumnType("text");

                    b.Property<int>("Paginas")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LibroID");

                    b.HasIndex("AutorID");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("Libreria.Backend.Models.Libro", b =>
                {
                    b.HasOne("Libreria.Backend.Models.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("Libreria.Backend.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}
