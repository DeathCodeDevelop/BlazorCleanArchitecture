using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.EntityTypeConfigurations;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
	public DbSet<Note> Notes { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder builder) 
	{
		builder.ApplyConfiguration(new NoteConfiguration());
		base.OnModelCreating(builder);

		builder.Entity<ApplicationUser>(entity => entity.ToTable("Users"));
		builder.Entity<IdentityRole>(entity => entity.ToTable("Roles"));
		builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable("UserRoles"));
		builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable("UserClaims"));
		builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable("UserLogins"));
		builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable("RoleClaims"));
		builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable("UserTokens"));
	}
}
