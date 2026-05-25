using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_API.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoUnitario { get; set; }

        // Navegação
        public Pedido Pedido { get; set; } = null!;
        public Produto Produto { get; set; } = null!;
    }
}