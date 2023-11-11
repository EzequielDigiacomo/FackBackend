using AccesoDatos.FacBackend;
using Controladora.FacBackend.DTOs.TutorDto;
using Entidades.FacBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.FacBackend.Services.TutorServices
{
    public class TutorServices : ITutorServices
    {
        private readonly ApplicationDbContext _context;
        public TutorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TutorDetailsDto>> ObtenerTodos()
        {
            var tutorAtleta = await _context.TutorDeAtletas.Select(t => new TutorDetailsDto
            {
                Id = t.Id,
                NombreTutor = t.NombreTutor,
                ApellidoTutor = t.ApellidoTutor,
                DireccionDelTutor = t.DireccionTutor,
                DniTutor = t.DniTutor,
                CelularDelTutor = t.CelularTutor,
                EmailDelTutor = t.EmailTutor,
                FotoDniDorsalTutor = t.FotoDniDorsalTutor,
                FotoDniFrontalTutor = t.FotoDniFrontalTutor,

            }).ToListAsync();

            return tutorAtleta;
        }

        public async Task<TutorDetailsDto> ObtenerPorId(int id)
        {
            var tutor = await BuscarPorId(id);

            return new TutorDetailsDto
            {
                Id = tutor.Id,
                NombreTutor = tutor.NombreTutor,
                ApellidoTutor = tutor.ApellidoTutor,
                DireccionDelTutor = tutor.DireccionTutor,
                DniTutor = tutor.DniTutor,
                CelularDelTutor = tutor.CelularTutor,
                EmailDelTutor = tutor.EmailTutor,
                FotoDniDorsalTutor = tutor.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutor.FotoDniFrontalTutor,
            };
        }

        public async Task<TutorDetailsDto> Crear(TutorCreateDto dto)
        {
            var dniRepetido = await _context.TutorDeAtletas.AnyAsync(x => x.DniTutor == dto.DniTutor);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un tutor con ese dni {dto.DniTutor}");
            }

            var tutorAtleta = new TutorDeAtleta
            {
                NombreTutor = dto.NombreTutor,
                ApellidoTutor = dto.ApellidoTutor,
                DireccionTutor = dto.DireccionDelTutor,
                DniTutor = dto.DniTutor,
                CelularTutor = dto.CelularDelTutor,
                EmailTutor = dto.EmailDelTutor,
                FotoDniDorsalTutor = dto.FotoDniDorsalTutor,
                FotoDniFrontalTutor = dto.FotoDniFrontalTutor,
            };


            await _context.AddAsync(tutorAtleta);
            await _context.SaveChangesAsync();

            return new TutorDetailsDto
            {
                NombreTutor = tutorAtleta.NombreTutor,
                ApellidoTutor = tutorAtleta.ApellidoTutor,
                DireccionDelTutor = tutorAtleta.DireccionTutor,
                DniTutor = tutorAtleta.DniTutor,
                CelularDelTutor = tutorAtleta.CelularTutor,
                EmailDelTutor = tutorAtleta.EmailTutor,
                FotoDniDorsalTutor = tutorAtleta.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutorAtleta.FotoDniFrontalTutor,
            };

        }

        public async Task<TutorDetailsDto> Actualizar(int id, TutorCreateDto dto)
        {
            var dniRepetido = await _context.TutorDeAtletas.AnyAsync(x => x.DniTutor == dto.DniTutor && id != x.Id);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un tutor con ese dni {dto.DniTutor}");
            }

            var tutorAtleta = await BuscarPorId(id);


            tutorAtleta.NombreTutor = dto.NombreTutor;
            tutorAtleta.ApellidoTutor = dto.ApellidoTutor;
            tutorAtleta.DireccionTutor = dto.DireccionDelTutor;
            tutorAtleta.DniTutor = dto.DniTutor;
            tutorAtleta.CelularTutor = dto.CelularDelTutor;
            tutorAtleta.EmailTutor = dto.EmailDelTutor;
            tutorAtleta.FotoDniDorsalTutor = dto.FotoDniDorsalTutor;
            tutorAtleta.FotoDniFrontalTutor = dto.FotoDniFrontalTutor;


            _context.Update(tutorAtleta);
            await _context.SaveChangesAsync();

            return new TutorDetailsDto
            {
                NombreTutor = tutorAtleta.NombreTutor,
                ApellidoTutor = tutorAtleta.ApellidoTutor,
                DireccionDelTutor = tutorAtleta.DireccionTutor,
                DniTutor = tutorAtleta.DniTutor,
                CelularDelTutor = tutorAtleta.CelularTutor,
                EmailDelTutor = tutorAtleta.EmailTutor,
                FotoDniDorsalTutor = tutorAtleta.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutorAtleta.FotoDniFrontalTutor,
            };
        }

        public async Task<TutorDetailsDto> Remover(int id)
        {
            var tutorAtleta = await BuscarPorId(id);
            _context.Remove(tutorAtleta);
            await _context.SaveChangesAsync();

            return new TutorDetailsDto
            {
                Id = tutorAtleta.Id,
                NombreTutor = tutorAtleta.NombreTutor,
                ApellidoTutor = tutorAtleta.ApellidoTutor,
                DireccionDelTutor = tutorAtleta.DireccionTutor,
                DniTutor = tutorAtleta.DniTutor,
                CelularDelTutor = tutorAtleta.CelularTutor,
                EmailDelTutor = tutorAtleta.EmailTutor,
                FotoDniDorsalTutor = tutorAtleta.FotoDniDorsalTutor,
                FotoDniFrontalTutor = tutorAtleta.FotoDniFrontalTutor,
            };
        }


        private async Task<TutorDeAtleta> BuscarPorId(int id)
        {
            var tutor = await _context.TutorDeAtletas.FindAsync(id);

            if (tutor == null)
            {
                throw new Exception($"El atleta con id {id} no existe");
            }

            return tutor;
        }
    }
}

