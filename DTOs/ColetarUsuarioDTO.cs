using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs
{
    public class ColetarUsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
    }
}
