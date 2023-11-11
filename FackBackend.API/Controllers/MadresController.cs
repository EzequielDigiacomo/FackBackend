using Controladora.FacBackend.DTOs.MadreDto;
using Controladora.FacBackend.Services.MadreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FackBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MadresController : ControllerBase
    {
        private readonly IMadreServices _services;
        public MadresController(IMadreServices services)
        {
            _services = services;
        }

        // GET: api/<MadreAtletaController>
        [HttpGet]
        //[Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<List<MadreDetailsDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<MadreAtletaController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<MadreDetailsDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<MadreAtletaController>
        [HttpPost]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<MadreDetailsDto> Post([FromBody] MadreCreateDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<MadreAtletaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<MadreDetailsDto> Put(int id, [FromBody] MadreCreateDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<MadreAtletaController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<MadreDetailsDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
