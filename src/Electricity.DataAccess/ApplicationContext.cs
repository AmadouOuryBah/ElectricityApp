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
        Database.Migrate();
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
    public DbSet<ElectricalEquipement> ElectricalEquipments { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<HeatMeter> HeatMeters { get; set; }
    public DbSet<MetersData> MetersDatas { get; set; }
    public DbSet<WaterMeter> WaterMeters { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<RoomElectricalEquipement> RoomElectricalEquipements { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}
