using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PadelBookingContext : DbContext
{
    public virtual DbSet<ClubDataModel> Clubs { get; set; }

    public PadelBookingContext(DbContextOptions<PadelBookingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClubDataModel>().OwnsOne(a => a.TimePeriod);

        base.OnModelCreating(modelBuilder);
    }

}