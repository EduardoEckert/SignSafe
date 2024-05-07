using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignSafe.Application.Users.Queries.GetAll;
using SignSafe.Data.Context;
using SignSafe.Data.Repositories;
using SignSafe.Data.UoW;
using SignSafe.Domain.RepositoryInterfaces;
using System.Reflection;

namespace SignSafe.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(WebApplicationBuilder builder)
        {
            AddInfrastructure(builder);
            AddContext(builder.Services);
            AddRepositories(builder.Services);
            AddCommands(builder.Services);

        }
        private static void AddInfrastructure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
        private static void AddContext(IServiceCollection services)
        {
            services.AddScoped<DbContext, MyContext>();
        }
        private static void AddCommands(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllUserQuery).GetTypeInfo().Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetUserQuery).GetTypeInfo().Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(InsertUserCommand).GetTypeInfo().Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateUserCommand).GetTypeInfo().Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteUserCommand).GetTypeInfo().Assembly));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
