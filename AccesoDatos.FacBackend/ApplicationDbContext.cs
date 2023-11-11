using Entidades.FacBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.FacBackend
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Atleta> Atletas { get; set; }
        public DbSet<MadreDeAtleta> MadreDeAtletas { get; set; }
        public DbSet<PadreDeAtleta> PadreDeAtletas { get; set; }
        public DbSet<TutorDeAtleta> TutorDeAtletas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //-------Login-------

            modelBuilder.Entity<Login>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Login>()
                        .Property(x => x.Nombre)
                        .HasMaxLength(20);

            modelBuilder.Entity<Login>()
                       .Property(x => x.Apellido)
                       .HasMaxLength(20);

            modelBuilder.Entity<Login>()
                       .Property(x => x.Email)
                       .HasMaxLength(40);

            modelBuilder.Entity<Login>()
                       .Property(x => x.Password);

            modelBuilder.Entity<Login>()
                       .Property(x => x.Rol)
                       .HasMaxLength(15);

            //------Atleta------

            modelBuilder.Entity<Atleta>()
                       .HasKey(x => x.Id);

            modelBuilder.Entity<Atleta>()
                       .Property(x => x.NombreAtleta)
                       .HasMaxLength(20);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.ApellidoAtleta)
                      .HasMaxLength(40);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.Nacionalidad)
                      .HasMaxLength(20);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.DniAtleta)
                      .HasMaxLength(99_999_999);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.NumeroDePasaporte)
                      .HasMaxLength(25);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.DireccionAtleta);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.EmailAtleta);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.FechaDeNacimientoAtleta);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.CelularAtleta);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.Club)
                      .HasMaxLength(40);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.ObraSocialAtleta);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.NumeroCarnetObraSocial);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.PermisoDeViaje)
                      .HasMaxLength(3);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.Beca)
                      .HasMaxLength(3);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.FotoDniFrontalAtleta);

            modelBuilder.Entity<Atleta>()
                      .Property(x => x.FotoDniDorsalAtleta)
                      .HasMaxLength(20);

            modelBuilder.Entity<Atleta>()
                     .Property(x => x.FotoPasaporteFrontalAtleta);

            modelBuilder.Entity<Atleta>()
                     .Property(x => x.FotoPasaporteDorsalAtleta);

            //Relaciones

            modelBuilder.Entity<Atleta>()
                        .HasOne(m => m.MadreAtleta);

            modelBuilder.Entity<Atleta>()
                        .HasOne(p => p.PadreAtleta);

            modelBuilder.Entity<Atleta>()
                        .HasOne(t => t.TutorAtleta);


            //------Madre------

            modelBuilder.Entity<MadreDeAtleta>()
                       .HasKey(x => x.Id);

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.NombreMadre)
                        .HasMaxLength(30);

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.ApellidoMadre)
                        .HasMaxLength(30);

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.DniMadre)
                        .HasMaxLength(99_999_999);

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.CelularMadre);

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.EmailMadre);
                        

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.DireccionMadre);

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.FotoDniFrontalMadre);

            modelBuilder.Entity<MadreDeAtleta>()
                        .Property(x => x.FotoDniDorsalMadre);


            //---------Padre---------

            modelBuilder.Entity<PadreDeAtleta>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.NombrePadre)
                        .HasMaxLength(30);

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.ApellidoPadre)
                        .HasMaxLength(30);

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.DniPadre)
                        .HasMaxLength(99_999_999);

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.CelularPadre);

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.EmailPadre);
        

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.DireccionPadre);

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.FotoDniFrontalPadre);

            modelBuilder.Entity<PadreDeAtleta>()
                        .Property(x => x.FotoDniDorsalPadre);


            //---------Tutor---------

            modelBuilder.Entity<TutorDeAtleta>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.NombreTutor)
                        .HasMaxLength(30);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.ApellidoTutor)
                        .HasMaxLength(30);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.DniTutor)
                        .HasMaxLength(99_999_999);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.CelularTutor);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.EmailTutor);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.DireccionTutor);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.FotoDniFrontalTutor);

            modelBuilder.Entity<TutorDeAtleta>()
                        .Property(x => x.FotoDniDorsalTutor);

        }
    }
}
