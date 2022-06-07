using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure;
public static class DbInitializer
{
	public static void Initialize(ApplicationDbContext context) 
	{
		context.Database.EnsureCreated();
		//context.Notes.Add(new Note 
		//{
		//	UserId = new Guid(),
		//	Id = new Guid(),
		//	Title = "Salo",
		//	Details = "Make Salo",
		//	CreationDate = DateTime.Now,
		//	EditDate = null
		//});
		context.SaveChanges();
	}
}

