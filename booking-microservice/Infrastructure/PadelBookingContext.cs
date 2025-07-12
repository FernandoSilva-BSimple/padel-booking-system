using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PadelBookingContext : DbContext
{
    public virtual DbSet<BookingDataModel> Bookings { get; set; }
    public virtual DbSet<CourtDataModel> Courts { get; set; }
    public virtual DbSet<ClubDataModel> Clubs { get; set; }

    public PadelBookingContext(DbContextOptions<PadelBookingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingDataModel>().OwnsOne(a => a.BookingPeriod);
        modelBuilder.Entity<ClubDataModel>().OwnsOne(a => a.TimePeriod);

        base.OnModelCreating(modelBuilder);
    }

}