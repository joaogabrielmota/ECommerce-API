using ECommerce_API.Models;
using ECommerce_API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce_API.Services
{
    public class UsuariosServices
    {
        private UsuariosRepositories _repositories;

        public UsuariosServices(UsuariosRepositories repositories)
        {
            _repositories = repositories;
        }

        public async Task<IEnumerable<Usuario>> CreateUsuario(Usuario usuario)
        {
            var resultado = await _repositories.CreateUsuarios(usuario);
            return resultado;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var resultado = await _repositories.GetUsuarios();
            return resultado;
        }
    }
}
