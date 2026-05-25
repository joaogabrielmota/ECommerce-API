using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Senha { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Telefone { get; set; }

        [MaxLength(500)]
        public string? Endereco { get; set; }

        public DateTime DataCriado { get; set; } = DateTime.UtcNow;

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}