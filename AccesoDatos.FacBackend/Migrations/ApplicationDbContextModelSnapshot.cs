﻿// <auto-generated />
using System;
using AccesoDatos.FacBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccesoDatos.FacBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entidades.FacBackend.Atleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoAtleta")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool?>("Beca")
                        .HasMaxLength(3)
                        .HasColumnType("bit");

                    b.Property<string>("CelularAtleta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Club")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("DireccionAtleta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DniAtleta")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailAtleta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeNacimientoAtleta")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoDniDorsalAtleta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FotoDniFrontalAtleta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPasaporteDorsalAtleta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPasaporteFrontalAtleta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MadreAtletaId")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NombreAtleta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NumeroCarnetObraSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDePasaporte")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool?>("ObraSocialAtleta")
                        .HasColumnType("bit");

                    b.Property<int?>("PadreAtletaId")
                        .HasColumnType("int");

                    b.Property<bool?>("PermisoDeViaje")
                        .HasMaxLength(3)
                        .HasColumnType("bit");

                    b.Property<int?>("TutorAtletaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MadreAtletaId");

                    b.HasIndex("PadreAtletaId");

                    b.HasIndex("TutorAtletaId");

                    b.ToTable("Atletas");
                });

            modelBuilder.Entity("Entidades.FacBackend.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Entidades.FacBackend.MadreDeAtleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CelularMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DniMadre")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniDorsalMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniFrontalMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAtleta")
                        .HasColumnType("int");

                    b.Property<string>("NombreMadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("MadreDeAtletas");
                });

            modelBuilder.Entity("Entidades.FacBackend.PadreDeAtleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoPadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CelularPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DniPadre")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniDorsalPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniFrontalPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAtleta")
                        .HasColumnType("int");

                    b.Property<string>("NombrePadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("PadreDeAtletas");
                });

            modelBuilder.Entity("Entidades.FacBackend.TutorDeAtleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoTutor")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CelularTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DniTutor")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniDorsalTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniFrontalTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAtleta")
                        .HasColumnType("int");

                    b.Property<string>("NombreTutor")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TutorDeAtletas");
                });

            modelBuilder.Entity("Entidades.FacBackend.Atleta", b =>
                {
                    b.HasOne("Entidades.FacBackend.MadreDeAtleta", "MadreAtleta")
                        .WithMany("AtletaList")
                        .HasForeignKey("MadreAtletaId");

                    b.HasOne("Entidades.FacBackend.PadreDeAtleta", "PadreAtleta")
                        .WithMany("AtletaList")
                        .HasForeignKey("PadreAtletaId");

                    b.HasOne("Entidades.FacBackend.TutorDeAtleta", "TutorAtleta")
                        .WithMany("AtletaList")
                        .HasForeignKey("TutorAtletaId");

                    b.Navigation("MadreAtleta");

                    b.Navigation("PadreAtleta");

                    b.Navigation("TutorAtleta");
                });

            modelBuilder.Entity("Entidades.FacBackend.MadreDeAtleta", b =>
                {
                    b.Navigation("AtletaList");
                });

            modelBuilder.Entity("Entidades.FacBackend.PadreDeAtleta", b =>
                {
                    b.Navigation("AtletaList");
                });

            modelBuilder.Entity("Entidades.FacBackend.TutorDeAtleta", b =>
                {
                    b.Navigation("AtletaList");
                });
#pragma warning restore 612, 618
        }
    }
}
