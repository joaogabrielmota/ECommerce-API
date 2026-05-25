using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_API.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        public int EstoqueQtd { get; set; } = 0;

        public DateTime DataPublicacao { get; set; } = DateTime.UtcNow;

        public bool Ativo { get; set; } = true;

        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Categoria Categoria { get; set; } = null!;

        public ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
    }
}