using AccesoDatos.FacBackend;
using Controladora.FacBackend.DTOs.Atleta;
using Entidades.FacBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.FacBackend.Services.AtletaServices
{
    public class AtletaServices : IAtletaServices
    {
        private readonly ApplicationDbContext _context;
        public AtletaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AtletaDetailsDto>> ObtenerTodos()
        {

            var atletas = await _context.Atletas.Select(a => new AtletaDetailsDto

            {
                Id = a.Id,
                Nombre = a.NombreAtleta,
                Apellido = a.ApellidoAtleta,
                Nacionalidad = a.Nacionalidad,
                Dni = a.DniAtleta,
                NumeroDePasaporte = a.NumeroDePasaporte,
                Direccion = a.DireccionAtleta,
                EmailDelAtleta = a.EmailAtleta,
                FechaDeNacimientoDelAtleta = a.FechaDeNacimientoAtleta,
                Celular = a.CelularAtleta,
                Club = a.Club,
                ObraSocial = a.ObraSocialAtleta,
                NumeroCarnetObraSocial = a.NumeroCarnetObraSocial,
                PermisoDeViaje = a.PermisoDeViaje,
                Beca = a.Beca,
                FotoDniFrontal = a.FotoDniFrontalAtleta,
                FotoDniDorsal = a.FotoDniDorsalAtleta,
                FotoPasaporteFrontal = a.FotoPasaporteFrontalAtleta,
                FotoPasaporteDorsal = a.FotoPasaporteDorsalAtleta,
                MadreAtletaId = a.MadreAtletaId,
                PadreAtletaId = a.PadreAtletaId,
                TutorAtletaId = a.TutorAtletaId

            }).ToListAsync();
            return atletas;
        }

        public async Task<AtletaDetailsDto> ObtenerPorId(int id)
        {
            var atleta = await BuscarPorId(id);

            return new AtletaDetailsDto
            {
                Id = atleta.Id,
                Nombre = atleta.NombreAtleta,
                Apellido = atleta.ApellidoAtleta,
                Nacionalidad = atleta.Nacionalidad,
                Dni = atleta.DniAtleta,
                NumeroDePasaporte = atleta.NumeroDePasaporte,
                Direccion = atleta.DireccionAtleta,
                EmailDelAtleta = atleta.EmailAtleta,
                FechaDeNacimientoDelAtleta = atleta.FechaDeNacimientoAtleta,
                Celular = atleta.CelularAtleta,
                Club = atleta.Club,
                ObraSocial = atleta.ObraSocialAtleta,
                NumeroCarnetObraSocial = atleta.NumeroCarnetObraSocial,
                PermisoDeViaje = atleta.PermisoDeViaje,
                Beca = atleta.Beca,
                FotoDniFrontal = atleta.FotoDniFrontalAtleta,
                FotoDniDorsal = atleta.FotoDniDorsalAtleta,
                FotoPasaporteFrontal = atleta.FotoPasaporteFrontalAtleta,
                FotoPasaporteDorsal = atleta.FotoPasaporteDorsalAtleta,
                MadreAtletaId = atleta.MadreAtletaId,
                PadreAtletaId = atleta.PadreAtletaId,
                TutorAtletaId = atleta.TutorAtletaId,
            };
        }

        public async Task<AtletaDetailsDto> Crear(AtletaCreateDto dto)
        {
            var dniRepetido = await _context.Atletas.AnyAsync(x => x.DniAtleta == dto.Dni);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un Atleta con ese dni {dto.Dni}");
            }

            var atleta = new Atleta
            {
                NombreAtleta = dto.Nombre,
                ApellidoAtleta = dto.Apellido,
                Nacionalidad = dto.Nacionalidad,
                DniAtleta = dto.Dni,
                NumeroDePasaporte = dto.NumeroDePasaporte,
                DireccionAtleta = dto.Direccion,
                EmailAtleta = dto.EmailDelAtleta,
                FechaDeNacimientoAtleta = dto.FechaDeNacimientoDelAtleta,
                CelularAtleta = dto.Celular,
                Club = dto.Club,
                ObraSocialAtleta = dto.ObraSocial,
                NumeroCarnetObraSocial = dto.NumeroCarnetObraSocial,
                PermisoDeViaje = dto.PermisoDeViaje,
                Beca = dto.Beca,
                FotoDniFrontalAtleta = dto.FotoDniFrontal,
                FotoDniDorsalAtleta = dto.FotoDniDorsal,
                FotoPasaporteFrontalAtleta = dto.FotoPasaporteFrontal,
                FotoPasaporteDorsalAtleta = dto.FotoPasaporteDorsal,
                MadreAtletaId = dto.MadreAtletaId,
                PadreAtletaId = dto.PadreAtletaId,
                TutorAtletaId = dto.TutorAtletaId,
            };


            await _context.AddAsync(atleta);
            await _context.SaveChangesAsync();

            return new AtletaDetailsDto
            {
                Id = atleta.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Nacionalidad = dto.Nacionalidad,
                Dni = dto.Dni,
                NumeroDePasaporte = dto.NumeroDePasaporte,
                Direccion = dto.Direccion,
                EmailDelAtleta = dto.EmailDelAtleta,
                FechaDeNacimientoDelAtleta = dto.FechaDeNacimientoDelAtleta,
                Celular = dto.Celular,
                Club = dto.Club,
                ObraSocial = dto.ObraSocial,
                NumeroCarnetObraSocial = dto.NumeroCarnetObraSocial,
                PermisoDeViaje = dto.PermisoDeViaje,
                Beca = dto.Beca,
                FotoDniFrontal = dto.FotoDniFrontal,
                FotoDniDorsal = dto.FotoDniDorsal,
                FotoPasaporteFrontal = dto.FotoPasaporteFrontal,
                FotoPasaporteDorsal = dto.FotoPasaporteDorsal,
                MadreAtletaId = dto.MadreAtletaId,
                PadreAtletaId = dto.PadreAtletaId,
                TutorAtletaId = dto.TutorAtletaId,
            };

        }

        public async Task<AtletaDetailsDto> Actualizar(int id, AtletaCreateDto dto)
        {
            var dniRepetido = await _context.Atletas.AnyAsync(x => x.DniAtleta == dto.Dni && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un Atleta con ese dni {dto.Dni}");
            }

            var atleta = await BuscarPorId(id);

            atleta.NombreAtleta = dto.Nombre;
            atleta.ApellidoAtleta = dto.Apellido;
            atleta.Nacionalidad = dto.Nacionalidad;
            atleta.DniAtleta = dto.Dni;
            atleta.NumeroDePasaporte = dto.NumeroDePasaporte;
            atleta.DireccionAtleta = dto.Direccion;
            atleta.EmailAtleta = dto.EmailDelAtleta;
            atleta.FechaDeNacimientoAtleta = dto.FechaDeNacimientoDelAtleta;
            atleta.CelularAtleta = dto.Celular;
            atleta.Club = dto.Club;
            atleta.ObraSocialAtleta = dto.ObraSocial;
            atleta.NumeroCarnetObraSocial = dto.NumeroCarnetObraSocial;
            atleta.PermisoDeViaje = dto.PermisoDeViaje;
            atleta.Beca = dto.Beca;
            atleta.FotoDniFrontalAtleta = dto.FotoDniFrontal;
            atleta.FotoDniDorsalAtleta = dto.FotoDniDorsal;
            atleta.FotoPasaporteFrontalAtleta = dto.FotoPasaporteFrontal;
            atleta.FotoPasaporteDorsalAtleta = dto.FotoPasaporteDorsal;
            atleta.MadreAtletaId = dto.MadreAtletaId;
            atleta.PadreAtletaId = dto.PadreAtletaId;
            atleta.TutorAtletaId = dto.TutorAtletaId;



            _context.Update(atleta);
            await _context.SaveChangesAsync();

            return new AtletaDetailsDto
            {
                Id = atleta.Id,
                Nombre = atleta.NombreAtleta,
                Apellido = atleta.ApellidoAtleta,
                Nacionalidad = atleta.Nacionalidad,
                Dni = atleta.DniAtleta,
                NumeroDePasaporte = atleta.NumeroDePasaporte,
                Direccion = atleta.DireccionAtleta,
                EmailDelAtleta = atleta.EmailAtleta,
                FechaDeNacimientoDelAtleta = atleta.FechaDeNacimientoAtleta,
                Celular = atleta.CelularAtleta,
                Club = atleta.Club,
                ObraSocial = atleta.ObraSocialAtleta,
                NumeroCarnetObraSocial = atleta.NumeroCarnetObraSocial,
                PermisoDeViaje = atleta.PermisoDeViaje,
                Beca = atleta.Beca,
                FotoDniFrontal = atleta.FotoDniFrontalAtleta,
                FotoDniDorsal = atleta.FotoDniDorsalAtleta,
                FotoPasaporteFrontal = atleta.FotoPasaporteFrontalAtleta,
                FotoPasaporteDorsal = atleta.FotoPasaporteDorsalAtleta,
                MadreAtletaId = atleta.MadreAtletaId,
                PadreAtletaId = atleta.PadreAtletaId,
                TutorAtletaId = atleta.TutorAtletaId,
            };
        }

        public async Task<AtletaDetailsDto> Remover(int id)
        {
            var atleta = await BuscarPorId(id);
            _context.Remove(atleta);
            await _context.SaveChangesAsync();

            return new AtletaDetailsDto
            {
                Id = atleta.Id,
                Nombre = atleta.NombreAtleta,
                Apellido = atleta.ApellidoAtleta,
                Nacionalidad = atleta.Nacionalidad,
                Dni = atleta.DniAtleta,
                NumeroDePasaporte = atleta.NumeroDePasaporte,
                Direccion = atleta.DireccionAtleta,
                EmailDelAtleta = atleta.EmailAtleta,
                FechaDeNacimientoDelAtleta = atleta.FechaDeNacimientoAtleta,
                Celular = atleta.CelularAtleta,
                Club = atleta.Club,
                ObraSocial = atleta.ObraSocialAtleta,
                NumeroCarnetObraSocial = atleta.NumeroCarnetObraSocial,
                PermisoDeViaje = atleta.PermisoDeViaje,
                Beca = atleta.Beca,
                FotoDniFrontal = atleta.FotoDniFrontalAtleta,
                FotoDniDorsal = atleta.FotoDniDorsalAtleta,
                FotoPasaporteFrontal = atleta.FotoPasaporteFrontalAtleta,
                FotoPasaporteDorsal = atleta.FotoPasaporteDorsalAtleta,
                MadreAtletaId = atleta.MadreAtletaId,
                PadreAtletaId = atleta.PadreAtletaId,
                TutorAtletaId = atleta.TutorAtletaId,
            };
        }


        private async Task<Atleta> BuscarPorId(int id)
        {
            var atleta = await _context.Atletas.FindAsync(id);

            if (atleta == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return atleta;
        }
    }
}