using Microsoft.EntityFrameworkCore;

namespace EcommerceShop.Models
{
    public class registerdb :DbContext
    {
        public registerdb(DbContextOptions<registerdb> options) :base(options)
        {
            
        }
        public DbSet<buynow> buynow { get; set; }
        public DbSet<Addtocart> Addtocart { get; set; }
        
        public DbSet<adminlogin> adminlogins { get; set; }
        public DbSet<register> registers { get; set; }
       

    }
}
