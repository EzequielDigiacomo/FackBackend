using AccesoDatos.FacBackend;
using Controladora.FacBackend.DTOs.Login;
using Entidades.FacBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Controladora.FacBackend.Services.LoginServices
{
    public class LoginRegisterServices : ILoginRegisterServices
    {
        private readonly ApplicationDbContext _context;

        public LoginRegisterServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<LoginRegisterDetailsDto>> ObtenerTodos()
        {
            var loginLista = await _context.Logins.Select(l => new LoginRegisterDetailsDto
            {
                Id = l.Id,
                Nombre = l.Nombre,
                Apellido = l.Apellido,
                Rol = l.Rol,
                Email = l.Email,
                Password = l.Password, //Despues Eliminar 

            }).ToListAsync();

            return loginLista;
        }

        public async Task<LoginRegisterDetailsDto> ObtenerPorId(int id)
        {
            var login = await BuscarPorId(id);

            return new LoginRegisterDetailsDto
            {
                Id = login.Id,
                Nombre = login.Nombre,
                Apellido = login.Apellido,
                Rol = login.Rol,
                Email = login.Email,
                Password = login.Password,
            };
        }

        public async Task<LoginRegisterDetailsDto> Crear(LoginRegisterCreateDto dto)
        {
            var emailRepetido = await _context.Logins.AnyAsync(x => x.Email == dto.Email);
            if (emailRepetido)
            {
                throw new Exception($"Ya existe una cuenta con ese email {dto.Email}");
            }

            var login = new Login
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Rol = dto.Rol,
                Email = dto.Email,
                Password = dto.Password,
            };

            await _context.AddAsync(login);
            await _context.SaveChangesAsync();

            return new LoginRegisterDetailsDto
            {
                Id = login.Id,
                Nombre = login.Nombre,
                Apellido = login.Apellido,
                Rol = login.Rol,
                Email = login.Email,
                Password = login.Password,
            };
        }



        public async Task<LoginRegisterDetailsDto> Actualizar(int id, LoginRegisterCreateDto dto)
        {

            var login = await BuscarPorId(id);

            login.Nombre = dto.Nombre;
            login.Apellido = dto.Apellido;
            login.Rol = dto.Rol;
            login.Email = dto.Email;
            login.Password = dto.Password;


            _context.Update(login);
            await _context.SaveChangesAsync();

            return new LoginRegisterDetailsDto
            {
                Id = login.Id,
                Nombre = login.Nombre,
                Apellido = login.Apellido,
                Rol = login.Rol,
                Email = login.Email,
                Password = login.Password,
            };
        }

        public async Task<LoginRegisterDetailsDto> Remover(int id)
        {
            var login = await BuscarPorId(id);
            _context.Remove(login);
            await _context.SaveChangesAsync();

            return new LoginRegisterDetailsDto
            {
                Id = login.Id,
                Nombre = login.Nombre,
                Apellido = login.Apellido,
                Rol = login.Rol,
                Email = login.Email,
                Password = login.Password,
            };
        }


        private async Task<Login> BuscarPorId(int id)
        {
            var login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                throw new Exception($"El login con id {id} no existe");
            }

            return login;
        }




    }
}


