using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTO
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Category name can't be null")]
        [StringLength(40, ErrorMessage = "Maxium length is {1}")]
        public string CategoryName { get; set; }
    }
}
