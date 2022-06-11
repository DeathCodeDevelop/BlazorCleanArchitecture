using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;
using Application.Common.Behaviors;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection
		services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddMediatR(Assembly.GetExecutingAssembly());
		
		services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
		services.AddTransient(typeof(IPipelineBehavior<,>), 
			typeof(ValidationBehavior<,>));

		return services;
	}
}

