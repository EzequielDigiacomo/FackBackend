using AccesoDatos.FacBackend;
using Controladora.FacBackend.DTOs.MadreDto;
using Entidades.FacBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.FacBackend.Services.MadreServices
{
    public class MadreServices : IMadreServices
    {
        private readonly ApplicationDbContext _context;
        public MadreServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MadreDetailsDto>> ObtenerTodos()
        {
            var madresAtletas = await _context.MadreDeAtletas.Select(m => new MadreDetailsDto
            {
                Id = m.Id,
                NombreMadre = m.NombreMadre,
                ApellidoMadre = m.ApellidoMadre,
                DniMadre = m.DniMadre,
                CelularDeLaMadre = m.CelularMadre,
                DireccionDeLaMadre = m.DireccionMadre,
                EmailDeLaMadre = m.EmailMadre,
                FotoDniDorsalMadre = m.FotoDniDorsalMadre,
                FotoDniFrontalMadre = m.FotoDniFrontalMadre,

            }).ToListAsync();

            return madresAtletas;
        }

        public async Task<MadreDetailsDto> ObtenerPorId(int id)
        {
            var madre = await BuscarPorId(id);

            return new MadreDetailsDto
            {
                Id = madre.Id,
                NombreMadre = madre.NombreMadre,
                ApellidoMadre = madre.ApellidoMadre,
                DniMadre = madre.DniMadre,
                CelularDeLaMadre = madre.CelularMadre,
                DireccionDeLaMadre = madre.DireccionMadre,
                EmailDeLaMadre = madre.EmailMadre,
                FotoDniDorsalMadre = madre.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madre.FotoDniFrontalMadre,
            };
        }

        public async Task<MadreDetailsDto> Crear(MadreCreateDto dto)
        {
            var dniRepetido = await _context.MadreDeAtletas.AnyAsync(x => x.DniMadre == dto.DniMadre);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe una Madre con ese dni {dto.DniMadre}");
            }

            var madreAtleta = new MadreDeAtleta
            {

                NombreMadre = dto.NombreMadre,
                ApellidoMadre = dto.ApellidoMadre,
                DniMadre = dto.DniMadre,
                CelularMadre = dto.CelularDeLaMadre,
                DireccionMadre = dto.DireccionDeLaMadre,
                EmailMadre = dto.EmailDeLaMadre,
                FotoDniDorsalMadre = dto.FotoDniDorsalMadre,
                FotoDniFrontalMadre = dto.FotoDniFrontalMadre,
            };


            await _context.AddAsync(madreAtleta);
            await _context.SaveChangesAsync();

            return new MadreDetailsDto
            {
                Id = madreAtleta.Id,
                NombreMadre = madreAtleta.NombreMadre,
                ApellidoMadre = madreAtleta.ApellidoMadre,
                DniMadre = madreAtleta.DniMadre,
                CelularDeLaMadre = madreAtleta.CelularMadre,
                DireccionDeLaMadre = madreAtleta.DireccionMadre,
                EmailDeLaMadre = madreAtleta.EmailMadre,
                FotoDniDorsalMadre = madreAtleta.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madreAtleta.FotoDniFrontalMadre,
            };

        }

        public async Task<MadreDetailsDto> Actualizar(int id, MadreCreateDto dto)
        {
            var dniRepetido = await _context.MadreDeAtletas.AnyAsync(x => x.DniMadre == dto.DniMadre && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe una Medre con ese dni {dto.DniMadre}");
            }

            var madreAtleta = await BuscarPorId(id);


            madreAtleta.NombreMadre = dto.NombreMadre;
            madreAtleta.ApellidoMadre = dto.ApellidoMadre;
            madreAtleta.DniMadre = dto.DniMadre;
            madreAtleta.CelularMadre = dto.CelularDeLaMadre;
            madreAtleta.DireccionMadre = dto.DireccionDeLaMadre;
            madreAtleta.EmailMadre = dto.EmailDeLaMadre;
            madreAtleta.FotoDniDorsalMadre = dto.FotoDniDorsalMadre;
            madreAtleta.FotoDniFrontalMadre = dto.FotoDniFrontalMadre;


            _context.Update(madreAtleta);
            await _context.SaveChangesAsync();

            return new MadreDetailsDto
            {
                Id = madreAtleta.Id,
                NombreMadre = madreAtleta.NombreMadre,
                ApellidoMadre = madreAtleta.ApellidoMadre,
                DniMadre = madreAtleta.DniMadre,
                CelularDeLaMadre = madreAtleta.CelularMadre,
                DireccionDeLaMadre = madreAtleta.DireccionMadre,
                EmailDeLaMadre = madreAtleta.EmailMadre,
                FotoDniDorsalMadre = madreAtleta.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madreAtleta.FotoDniFrontalMadre,
            };
        }

        public async Task<MadreDetailsDto> Remover(int id)
        {
            var madreAtleta = await BuscarPorId(id);
            _context.Remove(madreAtleta);
            await _context.SaveChangesAsync();

            return new MadreDetailsDto
            {
                Id = madreAtleta.Id,
                NombreMadre = madreAtleta.NombreMadre,
                ApellidoMadre = madreAtleta.ApellidoMadre,
                DniMadre = madreAtleta.DniMadre,
                CelularDeLaMadre = madreAtleta.CelularMadre,
                DireccionDeLaMadre = madreAtleta.DireccionMadre,
                EmailDeLaMadre = madreAtleta.EmailMadre,
                FotoDniDorsalMadre = madreAtleta.FotoDniDorsalMadre,
                FotoDniFrontalMadre = madreAtleta.FotoDniFrontalMadre,
            };
        }


        private async Task<MadreDeAtleta> BuscarPorId(int id)
        {
            var madre = await _context.MadreDeAtletas.FindAsync(id);

            if (madre == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return madre;
        }
    }
}

