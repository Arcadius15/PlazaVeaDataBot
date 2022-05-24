﻿// <auto-generated />
using System;
using BotPlazaVea.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BotPlazaVea.Migrations
{
    [DbContext(typeof(PlazaVeaContext))]
    partial class PlazaVeaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BotPlazaVea.Modelos.Productos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("categoria")
                        .HasColumnType("text");

                    b.Property<int?>("idUrl")
                        .HasColumnType("integer");

                    b.Property<string>("imagenUrl")
                        .HasColumnType("text");

                    b.Property<string>("nombreProducto")
                        .HasColumnType("text");

                    b.Property<decimal>("precioOferta")
                        .HasColumnType("numeric");

                    b.Property<decimal>("precioReg")
                        .HasColumnType("numeric");

                    b.Property<string>("proveedor")
                        .HasColumnType("text");

                    b.Property<string>("subcategoria")
                        .HasColumnType("text");

                    b.Property<string>("subtipo")
                        .HasColumnType("text");

                    b.Property<string>("tipo")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("idUrl")
                        .IsUnique();

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("BotPlazaVea.Modelos.Urls", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("url")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("url")
                        .IsUnique();

                    b.ToTable("Urls");
                });

            modelBuilder.Entity("BotPlazaVea.Modelos.Productos", b =>
                {
                    b.HasOne("BotPlazaVea.Modelos.Urls", "Url")
                        .WithOne("Producto")
                        .HasForeignKey("BotPlazaVea.Modelos.Productos", "idUrl")
                        .HasConstraintName("FK_URL_1");

                    b.Navigation("Url");
                });

            modelBuilder.Entity("BotPlazaVea.Modelos.Urls", b =>
                {
                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}
