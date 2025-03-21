using System.ComponentModel.DataAnnotations;

namespace EcommerceShop.Models
{
    public class register
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public required string Email { get; set; }
        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$",
        ErrorMessage = "Invalid phone number format.")]
        public long PhoneNumber { get; set; }   
        [Required]
        public required string Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, contain one uppercase letter, one lowercase letter, one digit, and one special character.")]     
        public required string Password { get; set; }
        
    }
}
