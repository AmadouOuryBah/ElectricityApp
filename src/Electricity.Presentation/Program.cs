using Electricity.DataAccess;
using Electricity.DataAccess.Repositories.Interface;
using Electricity.DataAccess.Repositories;
using Electricity.Presentation.Profiles;
using Microsoft.EntityFrameworkCore;
using Electricity.DataAccess.Entities;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        //
        builder.Services.AddAutoMapper(typeof(ApplicationProfiles));
        builder.Services.AddDbContext<ApplicationContext>(options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IGenericRepository<ElectricalEquipment>, ElectricalEquipmentRepository>();
        builder.Services.AddScoped<IElectricalEquipement, ElectricalEquipementService>();
        builder.Services.AddScoped<IGenericRepository<ElectricalMeter>, ElectricalMeterRepository>();
        builder.Services.AddScoped<IElectricalMeter, ElectricalMeterService>();
        builder.Services.AddScoped<IGenericRepository<Room>, RoomRepository>();
        builder.Services.AddScoped<IRoom, RoomService>();
        builder.Services.AddScoped<IGenericRepository<Renter>, RenterRepository>();
        builder.Services.AddScoped<IRenter, RenterService>();
        builder.Services.AddScoped<IGenericRepository<Building>, BuildingRepository>();
        builder.Services.AddScoped<IBuilding, BuildingService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}