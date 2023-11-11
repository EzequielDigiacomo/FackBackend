using Controladora.FacBackend.DTOs;
using Controladora.FacBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FackBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private readonly ILoginRegisterServices _services;

        public LoginRegisterController(ILoginRegisterServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<List<LoginRegisterDetailsDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();
            return respuesta;
        }

        // GET api/<LoginRegisterController>/5
        [HttpGet("{id}")]
        public async Task<LoginRegisterDetailsDto> GetById(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }


        // POST api/<LoginRegisterController>
        [HttpPost]
        public async Task<LoginRegisterDetailsDto> Post([FromBody] LoginRegisterCreateDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<LoginRegisterController>/5
        [HttpPut("{id}")]
        public async Task<LoginRegisterDetailsDto> Put(int id, [FromBody] LoginRegisterCreateDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<LoginRegisterController>/5
        [HttpDelete("{id}")]
        public async Task<LoginRegisterDetailsDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}

