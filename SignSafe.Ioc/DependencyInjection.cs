using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignSafe.Data.Context;

namespace SignSafe.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(WebApplicationBuilder builder)
        {
            AddInfrastructure(builder);
            AddContext(builder.Services);
            //AddRepositoriesDependecyInjection(services);
            //AddMappersDependecyInjection(services);
            //AddMediatRDependecyInjection(services);
        }
        private static void AddInfrastructure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
        private static void AddContext(IServiceCollection services)
        {
            services.AddScoped<DbContext, MyContext>();
        }
    }
}
