using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using API.SingalR;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
         IConfiguration config)
        {

            // Application Data context
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();

            // Services
            services.AddScoped<LogUserActivity>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddSignalR();
            services.AddSingleton<PresenceTracker>();


            // Repository services
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // settings
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            
            return services;
        }
    }
}