using ECommerce_API.DTOs;
using ECommerce_API.Models;
using ECommerce_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce_API.Services
{
    public class UsuariosServices
    {
        private UsuariosRepositories _repositorios;

        public UsuariosServices(UsuariosRepositories repositorios)
        {
            _repositorios = repositorios;
        }

        public async Task<IEnumerable<Usuario>> CriarUsuario(string nome, string email, string senha, string telefone, string endereco)
        {
            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Telefone = telefone,
                Endereco = endereco
            };
            var resultado = await _repositorios.CriarUsuario(usuario);
            return resultado;
        }

        public async Task<List<ColetarUsuarioDTO>> ColetarTodosUsuarios()
        {
            List<ColetarUsuarioDTO> coletarUsuariosDTO = new List<ColetarUsuarioDTO>();

            var usuarios = await _repositorios.ColetarTodosUsuarios();

            foreach (var usuario in usuarios)
            {
                ColetarUsuarioDTO coletarUsuarioDTO = new ColetarUsuarioDTO();
                coletarUsuarioDTO.Id = usuario.Id;
                coletarUsuarioDTO.Nome = usuario.Nome;
                coletarUsuarioDTO.Email = usuario.Email;
                coletarUsuarioDTO.Telefone = usuario.Telefone;
                coletarUsuarioDTO.Endereco = usuario.Endereco;

                coletarUsuariosDTO.Add(coletarUsuarioDTO);
            }
            return coletarUsuariosDTO;
        }

        public async Task<ColetarUsuarioDTO> ColetarUsuarioId(int id)
        {
            var usuario = await _repositorios.ColetarUsuarioId(id);

            ColetarUsuarioDTO coletarUsuarioDTO = new ColetarUsuarioDTO();

            coletarUsuarioDTO.Id = usuario.Id;
            coletarUsuarioDTO.Nome = usuario.Nome;
            coletarUsuarioDTO.Email = usuario.Email;
            coletarUsuarioDTO.Telefone = usuario.Telefone;
            coletarUsuarioDTO.Endereco = usuario.Endereco;

            return coletarUsuarioDTO;
        }

        public async Task<ColetarUsuarioDTO> AtualizarUsuario(int id, AtualizarUsuarioDTO atualizarUsuarioDTO)
         {  
            var usuarioAtualizado = await _repositorios.AtualizarUsuario(id, atualizarUsuarioDTO);

            ColetarUsuarioDTO coletarUsuarioDTO = new ColetarUsuarioDTO();

            coletarUsuarioDTO.Id = usuarioAtualizado.Id;
            coletarUsuarioDTO.Nome = usuarioAtualizado.Nome;
            coletarUsuarioDTO.Email = usuarioAtualizado.Email;
            coletarUsuarioDTO.Telefone = usuarioAtualizado.Telefone;
            coletarUsuarioDTO.Endereco = usuarioAtualizado.Endereco;

            return coletarUsuarioDTO;
        }

        public async Task<Usuario> AlterarStatusUsuario(int id)
        {

            var usuario = await _repositorios.AlterarStatusUsuario(id);

            return usuario;
        }
    }
}
