using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pantokrator.Graphql.Data;
using Pantokrator.Graphql.Data.Context.AdventureWorks;
using Pantokrator.GraphQL.Api.Core;

namespace Pantokrator.Graphql.Api
{
    public class Startup : WebApplicationStarter
    {
        public Startup(IHostingEnvironment env) : base(env)
        {

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {

            //Register Ecomm Connection
            IDbConnection connection =
            new SqlConnection(Configuration.GetConnectionString("Default"));
            services.AddScoped(p => connection);


            services.AddDbContext<AdventureWorks>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            // Add functionality to inject IOptions<T>
            services.AddOptions();


            // *If* you need access to generic IConfiguration this is **required**
            services.AddSingleton<IConfiguration>(Configuration);

            //Register Data Module
            services.AddDataModule();


            //services.AddMvc();

            base.ConfigureServices(services);
        }

        protected override void ConfigureStartup(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {

        }

    }
}
