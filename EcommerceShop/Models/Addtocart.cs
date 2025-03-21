using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Models
{
    public class Addtocart
    {
        [Key]
        public int id { get; set; }
        
        public  required string UserEmail { get; set; }
      
        public required string Product_Name { get; set; }
        public int Product_Price { get; set; }
       
        public required string Quantity { get; set; }
      
        public required string Product_Details { get; set; }
      
        public required string Product_Images { get; set; }
    }
}
