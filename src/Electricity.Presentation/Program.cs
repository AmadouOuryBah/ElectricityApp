using Electricity.DataAccess;
using Electricity.DataAccess.Repositories.Interface;
using Electricity.DataAccess.Repositories;
using Electricity.Presentation.Profiles;
using Microsoft.EntityFrameworkCore;
using Electricity.DataAccess.Entities;
using Electricity.BusinessLogic.Services;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            options.EnableDetailedErrors(true);
            options.EnableSensitiveDataLogging(true);
        });
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<IGenericRepository<ElectricalEquipement>, ElectricalEquipementRepository>();
        builder.Services.AddScoped<IElectricityEquipement, ElectricalEquipementService>();
        builder.Services.AddScoped<IConsumptionCalcultationService, ConsumptionComputationService>();

        builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
        builder.Services.AddScoped<IResourceService, ResourceService>();

        builder.Services.AddScoped<IRoomRepository, RoomRepository>();
        builder.Services.AddScoped<IRoomService, RoomService>();

        builder.Services.AddScoped<IRoomRepository, RoomRepository>();

        builder.Services.AddScoped<IGenericRepository<Renter>, RenterRepository>();
        builder.Services.AddScoped<IRenter, RenterService>();

        builder.Services.AddScoped<IGenericRepository<Building>, BuildingRepository>();
        builder.Services.AddScoped<IBuildingService, BuildingService>();

        builder.Services.AddScoped<IGenericRepository<RoomElectricalEquipement>,  RoomElectricalEquipementRepository>();
        builder.Services.AddScoped<IRoomElectricalEquipementService,  RoomElectricalEquipementService>();

        builder.Services.AddScoped<IGenericRepository<Schedule>, ScheduleRepository>();
        builder.Services.AddScoped<IScheduleService, ScheduleService>();

       

        builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
            });

        //builder.Services.AddCors(options =>
        //{
        //    options.AddPolicy("MyPolicy", policy =>
        //    {
        //        policy.AllowAnyHeader();
        //        policy.AllowAnyOrigin();
        //        policy.AllowAnyMethod();

        //    });
        //});

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
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}