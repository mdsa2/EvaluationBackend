using System.Globalization;
using e_parliament.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EvaluationBackend.Helpers.OneSignal;
using EvaluationBackend.DATA;
using EvaluationBackend.Helpers;
using EvaluationBackend.Repository;
using EvaluationBackend.Services;
using EvaluationBackend.Interface;
using EvaluationBackend.Respository;

namespace EvaluationBackend.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ItypeOfVehicleRepositry, typeOfVehicleRepositry>();
            services.AddScoped<ItypeOfVechileService, typeOfVehicleService>();
            services.AddScoped<ICitizenRepositry, CitizenRepositry>();
            services.AddScoped<ICitizenService, CitizenService>();
            services.AddScoped<IPlaceFineRepositry, PlaceFineRepositry>();
            services.AddScoped<IPlaceFineService, PlaceFineService>();
            services.AddScoped<IReportRepositry, ReportRepositry>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IFineRepositry, FineRepositry>();
            services.AddScoped<IFineService, FineService>();
            services.AddScoped<IVehicalRepositry, VehicleRepositry>();
            services.AddScoped<IVehicaleService, VehicalService>();
            services.AddScoped<IGovRepositry, GovRepositry>();
            services.AddScoped<IGovService, GovService>();
            services.AddScoped<IFineTypeRepositry, FineTypeRepositry>();
            services.AddScoped<IFineTypeService, FineTypeService>();
            services.AddScoped<IVehicleCityRepositry, VehicleCityRepositry>();
            services.AddScoped<IVehicleCityService, VehicleCityService>();
         
            services.AddScoped<AuthorizeActionFilter>();
            services.AddScoped<PermissionSeeder>();
            
            // seed data from permission seeder service
            
            var serviceProvider = services.BuildServiceProvider();
            var permissionSeeder = serviceProvider.GetService<PermissionSeeder>();
            permissionSeeder.SeedPermissions();

            return services;
        }
    }
}