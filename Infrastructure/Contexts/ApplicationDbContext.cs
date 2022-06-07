using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.EntityTypeConfigurations;

namespace Infrastructure.Contexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public DbSet<Note> Notes { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder builder) 
	{
		builder.ApplyConfiguration(new NoteConfiguration());
		base.OnModelCreating(builder);
	}
}

