using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "Category name can't be null")]
        [StringLength(40, ErrorMessage = "Maxium length is {1}")]
        public string CategoryName { get; set; }
    }
}
