using Controladora.FacBackend.DTOs.TutorDto;

namespace Controladora.FacBackend.Services.TutorServices
{
    public interface ITutorServices
    {
        Task<TutorDetailsDto> Actualizar(int id, TutorCreateDto dto);
        Task<TutorDetailsDto> Crear(TutorCreateDto dto);
        Task<TutorDetailsDto> ObtenerPorId(int id);
        Task<List<TutorDetailsDto>> ObtenerTodos();
        Task<TutorDetailsDto> Remover(int id);
    }
}