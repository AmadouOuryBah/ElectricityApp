using Electricity.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Electricity.DataAccess;

/// <summary>
/// 
/// </summary>
public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
    {
    
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<ElectricalMeter> ElectricalMeters { get; set; }
    public DbSet<ElectricalEquipment> ElectricalEquipments { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<HeatMeter> HeatMeters { get; set; }

    protected void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}
