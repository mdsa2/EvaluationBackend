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