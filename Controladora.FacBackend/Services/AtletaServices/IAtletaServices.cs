using Controladora.FacBackend.DTOs.Atleta;

namespace Controladora.FacBackend.Services.AtletaServices
{
    public interface IAtletaServices
    {
        Task<AtletaDetailsDto> Actualizar(int id, AtletaCreateDto dto);
        Task<AtletaDetailsDto> Crear(AtletaCreateDto dto);
        Task<AtletaDetailsDto> ObtenerPorId(int id);
        Task<List<AtletaDetailsDto>> ObtenerTodos();
        Task<AtletaDetailsDto> Remover(int id);
    }
}