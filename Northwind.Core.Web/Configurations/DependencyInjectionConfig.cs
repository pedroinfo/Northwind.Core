using Microsoft.Extensions.DependencyInjection;
using Northwind.Core.Domain.Entities;
using Northwind.Core.Domain.Repositories;
using Northwind.Core.Domain.Services;
using Northwind.Core.Infra.Context;
using Northwind.Core.Infra.Repositories;
using Northwind.Core.Service.Services;

namespace Northwind.Core.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
             services.AddScoped<NorthwindContext>();

            //  services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            // 

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
          

          // services.AddScoped<typeof(IRepositoryGeneric<>), ttRepositoryGeneric<>>();
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));

            return services;
        }
    }
}
