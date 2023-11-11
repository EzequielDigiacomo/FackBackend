using AccesoDatos.FacBackend;
using Controladora.FacBackend.DTOs;
using Entidades.FacBackend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FackBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginJoinController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginJoinController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hola {currentUser.Nombre}, tu rol es {currentUser.Rol} ");
        }

        [HttpPost]
        public IActionResult Login (LoginRegisterJoinDto userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                //crear token

                var token = Generate(user);

                return Ok(token);
            }

            return NotFound("Usuario no encontrado");
        }

        private Login Authenticate(LoginRegisterJoinDto userLogin)
        {
            var currentUser = _context.Logins.FirstOrDefault(user => user.Email.ToLower() == userLogin.Email.ToLower()
            && user.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        //Estos metodos hay que ponerlos en otro lado

        private string Generate(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //crear los claims (reclamaciones)
            var claims = new[]
            {
                //new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Nombre),
                new Claim(ClaimTypes.Surname, user.Apellido),
                new Claim(ClaimTypes.Role, user.Rol),
            };

            //crear el token
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                         _configuration["Jwt:Audience"],
                                         claims,
                                         expires: DateTime.Now.AddMinutes(1),
                                         signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Login GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new Login
                {
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Nombre = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Apellido = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Rol = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
