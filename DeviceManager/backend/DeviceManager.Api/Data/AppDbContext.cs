using DeviceManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Device> Devices { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Device>()
            .HasOne(d => d.AssignedToUser)
            .WithMany()
            .HasForeignKey(d => d.AssignedToUserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Device>()
            .Property(d => d.Type)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
}