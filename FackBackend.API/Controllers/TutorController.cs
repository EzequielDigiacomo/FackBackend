using Controladora.FacBackend.DTOs.TutorDto;
using Controladora.FacBackend.Services.TutorServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FackBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorServices _services;
        public TutorController(ITutorServices services)
        {
            _services = services;
        }

        // GET: api/<TutorAtletaController>
        [HttpGet]
        //[Authorize(Roles = ("administrador, entrenador, administrativo, otros"))]
        public async Task<List<TutorDetailsDto>> Get()
        {
            var respuesta = await _services.ObtenerTodos();

            return respuesta;
        }

        // GET api/<TutorAtletaController>/5
        [HttpGet("{id}")]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<TutorDetailsDto> GetPorId(int id)
        {
            var respuesta = await _services.ObtenerPorId(id);
            return respuesta;
        }

        // POST api/<TutorAtletaController>
        [HttpPost]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<TutorDetailsDto> Post([FromBody] TutorCreateDto dto)
        {
            var respuesta = await _services.Crear(dto);
            return respuesta;
        }

        // PUT api/<TutorAtletaController>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<TutorDetailsDto> Put(int id, [FromBody] TutorCreateDto dto)
        {
            var respuesta = await _services.Actualizar(id, dto);
            return respuesta;
        }

        // DELETE api/<TutorAtletaController>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = ("administrador, entrenador, administrativo"))]
        public async Task<TutorDetailsDto> Delete(int id)
        {
            var respuesta = await _services.Remover(id);
            return respuesta;
        }
    }
}

