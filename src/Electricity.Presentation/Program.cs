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
        builder.Services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<IGenericRepository<ElectricalEquipement>, ElectricalEquipementRepository>();
        builder.Services.AddScoped<IElectricityEquipement, ElectricalEquipementService>();

        builder.Services.AddScoped<IGenericRepository<ElectricityMeter>, ElectricityMeterRepository>();
        builder.Services.AddScoped<IElectricityMeterService, ElectricityMeterService>();

        builder.Services.AddScoped<IGenericRepository<Room>, RoomRepository>();
        builder.Services.AddScoped<IRoomService, RoomService>();

        builder.Services.AddScoped<IRoomRepository, RoomRepository>();

        builder.Services.AddScoped<IGenericRepository<Renter>, RenterRepository>();
        builder.Services.AddScoped<IRenter, RenterService>();

        builder.Services.AddScoped<IGenericRepository<Building>, BuildingRepository>();
        builder.Services.AddScoped<IBuildingService, BuildingService>();

        builder.Services.AddScoped<IGenericRepository<HeatMeter>, HeatMeterRepository>();
        builder.Services.AddScoped<IHeatMeterService, HeatMeterService>();

        builder.Services.AddScoped<IGenericRepository<WaterMeter>, WaterMeterRepository>();
        builder.Services.AddScoped<IWaterMeterService, WaterMeterService>();

        builder.Services.AddScoped<IGenericRepository<RoomElectricalEquipement>,  RoomElectricalEquipementRepository>();
        builder.Services.AddScoped<IRoomElectricalEquipementService,  RoomElectricalEquipementService>();

        builder.Services.AddScoped<IGenericRepository<Schedule>, ScheduleRepository>();
        builder.Services.AddScoped<IScheduleService, ScheduleService>();

        builder.Services.AddScoped<IGenericRepository<MetersData>, MetersDataRepository>();

        builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();

            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseCors("MyPolicy");
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