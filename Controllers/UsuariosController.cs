using ECommerce_API.Services;
using ECommerce_API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;

namespace ECommerce_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private UsuariosServices _servicos;

        public UsuariosController(UsuariosServices servicos)
        {
            _servicos = servicos;
        }

        [HttpPost("CriarUsuario")]
        public async Task<IActionResult> CriarUsuario(string nome, string email, string senha, string telefone, string endereco)
        {
            var resultado = await _servicos.CriarUsuario(nome, email, senha, telefone, endereco);
            return Ok(resultado);
        }

        [HttpGet("ColetarTodosOsUsuarios")]
        public async Task<IActionResult> ColetarTodosUsuarios()
        {
            var resultado = await _servicos.ColetarTodosUsuarios();
            return Ok(resultado);
        }

        [HttpGet("ColetarUsuarioPorID")]
        public async Task<IActionResult> ColetarUsuarioId(int id)
        {
            var resultado = await _servicos.ColetarUsuarioId(id);
            return Ok(resultado);
        }

        [HttpPatch("AtualizarUsuario")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] AtualizarUsuarioDTO atualizarUsuarioDTO)
        {
            var resultado = await _servicos.AtualizarUsuario(id, atualizarUsuarioDTO);
            return Ok(resultado);
        }
    }
}
   
