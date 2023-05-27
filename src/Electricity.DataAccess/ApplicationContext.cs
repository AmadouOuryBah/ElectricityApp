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
    public DbSet<ElectricityConsumptionDto> ElectricityConsumptions { get; set; }
    public DbSet<ElectricalEquipement> ElectricalEquipments { get; set; }
    public DbSet<Building> Buildings { get; set; }
  
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<RoomElectricalEquipement> RoomElectricalEquipements { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Role>()
           .HasData(new()
           {
               Id = -2,
               Name = "user",
           }, new Role()
           {
               Id = -1,
               Name = "admin"
           });

        builder.Entity<User>()
            .HasData(new User()
            {
                Id = -1,
                Username = "Patrick",
                Password = "123456",
                RoleId = -1
            });

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}
