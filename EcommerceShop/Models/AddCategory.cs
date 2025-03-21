using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Models
{
    public class AddCategory
    {
        [Key]
        public int id { get; set; }
        [Required]
        public required string category_name { get; set; }
    }
}
