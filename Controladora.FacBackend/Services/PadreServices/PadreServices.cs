using AccesoDatos.FacBackend;
using Controladora.FacBackend.DTOs.PadreDto;
using Entidades.FacBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.FacBackend.Services.PadreServices
{
    public class PadreServices : IPadreServices
    {
        private readonly ApplicationDbContext _context;
        public PadreServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PadreDetailsDto>> ObtenerTodos()
        {
            var padresAtletas = await _context.PadreDeAtletas.Select(p => new PadreDetailsDto
            {
                Id = p.Id,
                NombrePadre = p.NombrePadre,
                ApellidoPadre = p.ApellidoPadre,
                DireccionDelPadre = p.DireccionPadre,
                DniPadre = p.DniPadre,
                CelularDelPadre = p.CelularPadre,
                EmailDelPadre = p.EmailPadre,
                FotoDniDorsalPadre = p.FotoDniDorsalPadre,
                FotoDniFrontalPadre = p.FotoDniFrontalPadre,

            }).ToListAsync();

            return padresAtletas;
        }

        public async Task<PadreDetailsDto> ObtenerPorId(int id)
        {
            var padre = await BuscarPorId(id);

            return new PadreDetailsDto
            {
                Id = padre.Id,
                NombrePadre = padre.NombrePadre,
                ApellidoPadre = padre.ApellidoPadre,
                DireccionDelPadre = padre.DireccionPadre,
                DniPadre = padre.DniPadre,
                CelularDelPadre = padre.CelularPadre,
                EmailDelPadre = padre.EmailPadre,
                FotoDniDorsalPadre = padre.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padre.FotoDniFrontalPadre,
            };
        }

        public async Task<PadreDetailsDto> Crear(PadreCreateDto dto)
        {
            var dniRepetido = await _context.PadreDeAtletas.AnyAsync(x => x.DniPadre == dto.DniPadre);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un Padre con ese dni {dto.DniPadre}");
            }

            var padreAtleta = new PadreDeAtleta
            {

                NombrePadre = dto.NombrePadre,
                ApellidoPadre = dto.ApellidoPadre,
                DniPadre = dto.DniPadre,
                CelularPadre = dto.CelularDelPadre,
                DireccionPadre = dto.DireccionDelPadre,
                EmailPadre = dto.EmailDelPadre,
                FotoDniDorsalPadre = dto.FotoDniDorsalPadre,
                FotoDniFrontalPadre = dto.FotoDniFrontalPadre,
            };


            await _context.AddAsync(padreAtleta);
            await _context.SaveChangesAsync();

            return new PadreDetailsDto
            {
                NombrePadre = padreAtleta.NombrePadre,
                ApellidoPadre = padreAtleta.ApellidoPadre,
                DniPadre = padreAtleta.DniPadre,
                CelularDelPadre = padreAtleta.CelularPadre,
                DireccionDelPadre = padreAtleta.DireccionPadre,
                EmailDelPadre = padreAtleta.EmailPadre,
                FotoDniDorsalPadre = padreAtleta.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padreAtleta.FotoDniFrontalPadre,
            };

        }

        public async Task<PadreDetailsDto> Actualizar(int id, PadreCreateDto dto)
        {
            var dniRepetido = await _context.PadreDeAtletas.AnyAsync(x => x.DniPadre == dto.DniPadre && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un Padre con ese dni {dto.DniPadre}");
            }

            var padreAtleta = await BuscarPorId(id);


            padreAtleta.NombrePadre = dto.NombrePadre;
            padreAtleta.ApellidoPadre = dto.ApellidoPadre;
            padreAtleta.DniPadre = dto.DniPadre;
            padreAtleta.CelularPadre = dto.CelularDelPadre;
            padreAtleta.DireccionPadre = dto.DireccionDelPadre;
            padreAtleta.EmailPadre = dto.EmailDelPadre;
            padreAtleta.FotoDniDorsalPadre = dto.FotoDniDorsalPadre;
            padreAtleta.FotoDniFrontalPadre = dto.FotoDniFrontalPadre;


            _context.Update(padreAtleta);
            await _context.SaveChangesAsync();

            return new PadreDetailsDto
            {
                Id = padreAtleta.Id,
                NombrePadre = padreAtleta.NombrePadre,
                ApellidoPadre = padreAtleta.ApellidoPadre,
                DireccionDelPadre = padreAtleta.DireccionPadre,
                DniPadre = padreAtleta.DniPadre,
                CelularDelPadre = padreAtleta.CelularPadre,
                EmailDelPadre = padreAtleta.EmailPadre,
                FotoDniDorsalPadre = padreAtleta.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padreAtleta.FotoDniFrontalPadre,
            };
        }

        public async Task<PadreDetailsDto> Remover(int id)
        {
            var padreAtleta = await BuscarPorId(id);
            _context.Remove(padreAtleta);
            await _context.SaveChangesAsync();

            return new PadreDetailsDto
            {
                Id = padreAtleta.Id,
                NombrePadre = padreAtleta.NombrePadre,
                ApellidoPadre = padreAtleta.ApellidoPadre,
                DireccionDelPadre = padreAtleta.DireccionPadre,
                DniPadre = padreAtleta.DniPadre,
                CelularDelPadre = padreAtleta.CelularPadre,
                EmailDelPadre = padreAtleta.EmailPadre,
                FotoDniDorsalPadre = padreAtleta.FotoDniDorsalPadre,
                FotoDniFrontalPadre = padreAtleta.FotoDniFrontalPadre,
            };
        }


        private async Task<PadreDeAtleta> BuscarPorId(int id)
        {
            var padre = await _context.PadreDeAtletas.FindAsync(id);

            if (padre == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return padre;
        }
    }
}

