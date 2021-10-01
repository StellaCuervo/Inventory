using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Data.Repositories;
using Inventory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Data.DIServices
{
    public static class DIServicesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<IAssetRepository,AssetRepository>()
                .AddScoped<IAssetTypeRepository, AssetTypeRepository>()
                .AddScoped<IDeviceRepository, DeviceRepository>()
                .AddScoped<ILocationRepository, LocationRepository>();
            return services;
        }
    }
}
