using ECommerce_API.DTOs;
using ECommerce_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ECommerce_API.Repositories
{
    public class UsuariosRepositories
    {
        private readonly ECommerce_API.Data.ApplicationDbContext _contexto;

        public UsuariosRepositories(ECommerce_API.Data.ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Usuario>> CriarUsuario(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            await _contexto.SaveChangesAsync();
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ColetarTodosUsuarios()
        {
            var resultado = await _contexto.Usuarios.OrderBy(u => u.Id).ToListAsync();
            return resultado;
        }

        public async Task<Usuario> ColetarUsuarioId(int id)
        {
            var resultado = await _contexto.Usuarios.FindAsync(id);
            return resultado;
        }

        public async Task<Usuario?> AtualizarUsuario(int id, AtualizarUsuarioDTO dto)
        {
            var usuario = await ColetarUsuarioId(id);

            if (usuario == null)
                return null;

            if (!string.IsNullOrWhiteSpace(dto.Nome))
                usuario.Nome = dto.Nome;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                usuario.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Telefone))
                usuario.Telefone = dto.Telefone;

            if (!string.IsNullOrWhiteSpace(dto.Endereco))
                usuario.Endereco = dto.Endereco;

            usuario.DataAtualizacao = DateTime.UtcNow;

            await _contexto.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> AlterarStatusUsuario(int id)
        {
            var usuario = await ColetarUsuarioId(id);

            if (usuario.Ativo == true)
            {
                usuario.Ativo = false;
            }
            else if(usuario.Ativo ==false) 
            {
                usuario.Ativo = true;
            }
            await _contexto.SaveChangesAsync();
            return usuario;
        }
    }
}
