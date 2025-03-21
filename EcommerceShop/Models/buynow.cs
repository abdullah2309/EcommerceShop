

using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Models
{
    public class buynow
    {
        [Key]
        public int Id { get; set; }  
        public  string Product_Name { get; set; }
        [Required]
        public  string Name { get; set; }
        public  int Quantity { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        public  string Address { get; set; }
        public int payment {  get; set; }

    }
}
