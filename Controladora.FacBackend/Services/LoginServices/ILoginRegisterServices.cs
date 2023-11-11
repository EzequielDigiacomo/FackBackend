using Controladora.FacBackend.DTOs.Login;

namespace Controladora.FacBackend.Services.LoginServices
{
    public interface ILoginRegisterServices
    {
        Task<LoginRegisterDetailsDto> Actualizar(int id, LoginRegisterCreateDto dto);
        Task<LoginRegisterDetailsDto> Crear(LoginRegisterCreateDto dto);
        Task<LoginRegisterDetailsDto> ObtenerPorId(int id);
        Task<List<LoginRegisterDetailsDto>> ObtenerTodos();
        Task<LoginRegisterDetailsDto> Remover(int id);
    }
}