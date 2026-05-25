using ECommerce_API.Services;
using ECommerce_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ECommerce_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosServices _services;

        public UsuariosController(UsuariosServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody]Usuario usuario)
        {
            var resultado = await _services.CreateUsuario(usuario);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var resultado = await _services.GetUsuarios();
            return Ok(resultado);
        }
    }
}
