using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Interfaces;
using TodoList.Application.Mappings;
using TodoList.Application.Services;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Domain.Validation;
using TodoList.Infra.Data.Context;
using TodoList.Infra.Data.Repositories;

namespace TodoList.Infra.IoC.Dependences
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddConnection(
			this IServiceCollection services, IConfiguration configuration)
		{
            services.AddDbContext<AppDbContext>(options =>
                options.UseOracle(configuration.GetConnectionString("DefaultConnection")));

            return services;
		}

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var handles = AppDomain.CurrentDomain.Load("TodoList.Application");
            services.AddMediatR(handles);

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services)
		{
			services.AddScoped<IToDoListRepository, ToDoListRepository>();
			services.AddScoped<IToDoListService, ToDoListService>();

			return services;
		}

		public static IServiceCollection AddFluentValidation(this IServiceCollection services)
		{
			services.AddFluentValidationAutoValidation();
			services.AddTransient<IValidator<ToDoList>, ToDoListValidator>();

			return services;
		}
	}
}
