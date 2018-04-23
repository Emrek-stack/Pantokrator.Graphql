using Microsoft.Extensions.DependencyInjection;
using Pantokrator.Graphql.Data.Repository;
using Pantokrator.Graphql.Data.Repository.Impl;
using Pantokrator.Repository.Extensions;

namespace Pantokrator.Graphql.Data
{
    public static class DataModule
    {
        public static IServiceCollection AddDataModule(this IServiceCollection services)
        {

            services.AddRepositoryModule();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}
