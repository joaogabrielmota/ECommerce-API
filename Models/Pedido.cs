using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_API.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Pendente";

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorTotal { get; set; }

        public DateTime DataCriado { get; set; } = DateTime.UtcNow;

        public Usuario Usuario { get; set; } = null!;
        public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }
}