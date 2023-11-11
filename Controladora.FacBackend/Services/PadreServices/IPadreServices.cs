using Controladora.FacBackend.DTOs.PadreDto;

namespace Controladora.FacBackend.Services.PadreServices
{
    public interface IPadreServices
    {
        Task<PadreDetailsDto> Actualizar(int id, PadreCreateDto dto);
        Task<PadreDetailsDto> Crear(PadreCreateDto dto);
        Task<PadreDetailsDto> ObtenerPorId(int id);
        Task<List<PadreDetailsDto>> ObtenerTodos();
        Task<PadreDetailsDto> Remover(int id);
    }
}