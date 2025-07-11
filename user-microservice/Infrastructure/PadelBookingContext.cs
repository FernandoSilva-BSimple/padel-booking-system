using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PadelBookingContext : DbContext
{
    public virtual DbSet<UserDataModel> Users { get; set; }

    public PadelBookingContext(DbContextOptions<PadelBookingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
}