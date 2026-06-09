using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.DTOs
{
    public class AtualizarUsuarioDTO
    {
        [MaxLength(100)]
        public string? Nome { get; set; }

        [EmailAddress]
        [MaxLength(150)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Telefone { get; set; }

        [MaxLength(500)]
        public string? Endereco { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}
