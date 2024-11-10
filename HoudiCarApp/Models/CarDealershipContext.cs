using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HoudiCarApp.Models
{
    public class CarDealershipContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CarDealership.db");
        }
    }
}
