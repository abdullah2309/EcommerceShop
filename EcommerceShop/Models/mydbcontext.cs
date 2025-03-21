using Microsoft.EntityFrameworkCore;

namespace EcommerceShop.Models
{
    public class MyDbcontext : DbContext 
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options):base(options) 
        {
            
        }

        public DbSet<feedback> feedbacks { get; set; }
        public DbSet<AddCategory> addCategories{ get; set; }
        public DbSet<AddProduct> addProducts  { get; set; }
        public DbSet<addsaleproduct> addProductsales { get; set; }

        
    }
}
