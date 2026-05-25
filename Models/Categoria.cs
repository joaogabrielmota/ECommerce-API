using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}