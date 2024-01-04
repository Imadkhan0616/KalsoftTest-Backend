using KALSOFT_Test.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KALSOFT_Test.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        public DbSet<PropertyDetailsModel> PropertyDetails{ get; set; } 
        public DbSet<ExposureModel> Exposure{ get; set; }
    }
}
