using Commons.Helpers;
using Data;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private static ApplicationDBContext contextInstance;
        public AuthenticateController()
        {
            contextInstance = new ApplicationDBContext();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto usuario)
        {
            usuario.Clave = EncryptHelper.Entriptar(usuario.Clave);
            var validarUsuario = contextInstance.Usuarios.Include(x=> x.Roles).FirstOrDefault(u=> u.Email == usuario.Email && u.Clave == usuario.Clave);
            if (validarUsuario != null)
            {
				return Ok(validarUsuario.Nombre + ";" + validarUsuario.Roles.Nombre + ";" + validarUsuario.Email);
			}
            else
            {
                return Unauthorized();
            }
        }
    }
}
