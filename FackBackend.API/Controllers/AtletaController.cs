using Controladora.FacBackend.DTOs.Atleta;
using Controladora.FacBackend.Services.AtletaServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FackBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private readonly IAtletaServices _services;


        public AtletaController(IAtletaServices services)
        {
            _services = services;

        }

        // GET: api/<AtletaController>
        [HttpGet]
        //[Authorize(Roles = ("administrador, entrenador, administrativo, otros") )]
        public async Task<List<AtletaDetailsDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        //[Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<AtletaDetailsDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<AtletaDetailsDto> Post([FromBody] AtletaCreateDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<AtletaDetailsDto> Put(int id, [FromBody] AtletaCreateDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<AtletaDetailsDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
        
}
