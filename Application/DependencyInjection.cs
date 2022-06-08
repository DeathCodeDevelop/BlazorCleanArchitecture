using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Application.Common.Mappings;
using AutoMapper;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection
		services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddMediatR(Assembly.GetExecutingAssembly());

		return services;
	}
}

