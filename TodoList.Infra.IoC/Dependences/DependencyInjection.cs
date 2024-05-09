using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Mappings;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Domain.Validation;
using TodoList.Infra.Data.Context;
using TodoList.Infra.Data.Repositories;
using MediatR;

namespace TodoList.Infra.IoC.Dependences
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDbContext(
			this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseOracle(configuration.GetConnectionString("DefaultConnection"));
				options.UseLazyLoadingProxies();
			});

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
			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}

		public static IServiceCollection AddFluentValidation(this IServiceCollection services)
		{
			services.AddFluentValidation();
			services.AddTransient<IValidator<ToDoList>, ToDoListValidator>();
			services.AddTransient<IValidator<User>, UserValidator>();

			return services;
		}
	}
}
