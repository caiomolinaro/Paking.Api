using Api.Features.Establishment;
using Api.Features.Vehicle;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Api.Infrastructure;

[ExcludeFromCodeCoverage]
public class ParkingDbContext : IdentityDbContext<ApplicationUser>
{
    public ParkingDbContext(DbContextOptions<ParkingDbContext> options)
        : base(options)
    {
    }

    public DbSet<EstablishmentEntity> Establishment { get; set; }
    public DbSet<VehicleEntity> Vehicle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleEntity>()
            .ToTable("Vehicle");

        modelBuilder.Entity<VehicleEntity>()
            .Property(c => c.Brand)
            .HasConversion<string>();

        modelBuilder.Entity<VehicleEntity>()
            .Property(c => c.Color)
            .HasConversion<string>();

        modelBuilder.Entity<VehicleEntity>()
            .Property(c => c.Type)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}