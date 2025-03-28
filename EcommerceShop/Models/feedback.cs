using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Models
{
    public class feedback
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Suject { get; set; }
        [Required]
        public string Massage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
///aa/aa////a// email // // Hi, I am interested in your product. Please send me more details. // 2021-07-01 12:00:00