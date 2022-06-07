using Application.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection
			services, string connectionString)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlite(connectionString);
			});

			services.AddScoped<IApplicationDbContext>(provider =>
				provider.GetService<ApplicationDbContext>());

			return services;
		}
	}
}
