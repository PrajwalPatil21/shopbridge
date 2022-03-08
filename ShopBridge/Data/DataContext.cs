using Microsoft.EntityFrameworkCore;
using ShopBridge.Repo.Entity;

namespace ShopBridge.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ProductDetails> productdata { get; set; }
    }
}
