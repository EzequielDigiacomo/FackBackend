using Controladora.FacBackend.DTOs.MadreDto;

namespace Controladora.FacBackend.Services.MadreServices
{
    public interface IMadreServices
    {
        Task<MadreDetailsDto> Actualizar(int id, MadreCreateDto dto);
        Task<MadreDetailsDto> Crear(MadreCreateDto dto);
        Task<MadreDetailsDto> ObtenerPorId(int id);
        Task<List<MadreDetailsDto>> ObtenerTodos();
        Task<MadreDetailsDto> Remover(int id);
    }
}