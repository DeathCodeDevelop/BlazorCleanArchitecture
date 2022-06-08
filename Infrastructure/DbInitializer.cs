using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure;
public static class DbInitializer
{
	public static void Initialize(ApplicationDbContext context) 
	{
		context.Database.EnsureCreated();
	}
}
