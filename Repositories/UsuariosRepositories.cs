using ECommerce_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ECommerce_API.Repositories
{
    public class UsuariosRepositories
    {
        private readonly ECommerce_API.Data.ApplicationDbContext _context;

        public UsuariosRepositories(ECommerce_API.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> CreateUsuarios(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
