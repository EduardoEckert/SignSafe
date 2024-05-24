﻿using MediatR;
using MediatR.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignSafe.Application.Users.Commands.Delete;
using SignSafe.Application.Users.Commands.Insert;
using SignSafe.Application.Users.Commands.Update;
using SignSafe.Application.Users.Queries.Get;
using SignSafe.Application.Users.Queries.GetAll;
using SignSafe.Data.Context;
using SignSafe.Data.Repositories;
using SignSafe.Data.UoW;
using SignSafe.Domain.Contracts.Api;
using SignSafe.Domain.Dtos.Users;
using SignSafe.Domain.RepositoryInterfaces;
using MediatRServiceConfiguration = Microsoft.Extensions.DependencyInjection.MediatRServiceConfiguration;

namespace SignSafe.Ioc
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(WebApplicationBuilder builder)
        {
            AddInfrastructure(builder);
            AddContext(builder.Services);
            AddMediatrRegistration(builder.Services);

            AddRepositories(builder.Services);
            AddCommands(builder.Services);
            AddQueries(builder.Services);
        }

        private static void AddInfrastructure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddContext(IServiceCollection services)
        {
            services.AddScoped<DbContext, MyContext>();
        }

        private static void AddMediatrRegistration(IServiceCollection services)
        {
            var serviceConfig = new MediatRServiceConfiguration();
            ServiceRegistrar.AddRequiredServices(services, serviceConfig);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void AddCommands(IServiceCollection services)
        {
            //User
            services.AddScoped<IRequestHandler<InsertUserCommand>, InsertUserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
        }

        private static void AddQueries(IServiceCollection services)
        {
            //User
            services.AddScoped<IRequestHandler<GetUsersByFilterQuery, PaginatedResult<List<UserDto>>>, GetUsersByFilterQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserQuery, UserDto>, GetUserQueryHandler>();
        }
    }
}
