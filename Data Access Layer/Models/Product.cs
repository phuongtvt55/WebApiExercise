using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
