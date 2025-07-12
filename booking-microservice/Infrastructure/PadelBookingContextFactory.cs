using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure
{
    public class PadelBookingContextFactory : IDesignTimeDbContextFactory<PadelBookingContext>
    {
        public PadelBookingContext CreateDbContext(string[] args)
        {
            // Lê appsettings.json manualmente
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<PadelBookingContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new PadelBookingContext(optionsBuilder.Options);
        }
    }
}
