﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceShop.Models
{
    public class AddProduct
    {
        [Key]
        public int Product_id  { get; set; }
        [Required]
        public required string Product_Name { get; set; }
        public int Product_Price { get; set; }
        [Required]
        public required string Product_Details { get; set; }
        [Required]
        public required string Product_Images { get; set; }
        [Required]
        public int category_list { get; set; }

        [ForeignKey("category_list")]
        public required virtual AddCategory AddCategory { get; set; }
    }
}
