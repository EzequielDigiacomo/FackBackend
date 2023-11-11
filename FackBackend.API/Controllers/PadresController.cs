using Controladora.FacBackend.DTOs.PadreDto;
using Controladora.FacBackend.Services.PadreServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FackBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadresController : ControllerBase
    {
        private readonly IPadreServices _services;
        public PadresController(IPadreServices services)
        {
            _services = services;
        }

        // GET: api/<PadreAtletaController>
        [HttpGet]
        //[Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<List<PadreDetailsDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<PadreAtletaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        //[Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<PadreDetailsDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<PadreAtletaController>
        [HttpPost]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<PadreDetailsDto> Post([FromBody] PadreCreateDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<PadreAtletaController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<PadreDetailsDto> Put(int id, [FromBody] PadreCreateDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<PadreAtletaController>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<PadreDetailsDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}
