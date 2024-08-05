using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Product name can't be null")]
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description can't be null")]
        [StringLength(200, ErrorMessage = "Maximum length is {1}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price can't be null")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must bigger than {1}")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity can't be null")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must bigger than {1} ")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Description can't be null")]
        public int CategoryId { get; set; }
    }
}
