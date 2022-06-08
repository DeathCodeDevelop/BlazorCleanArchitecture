using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
	public void Configure(EntityTypeBuilder<Note> builder) 
	{
		builder.HasKey(note => note.Id);
		builder.HasIndex(note => note.Id).IsUnique();
		builder.Property(note => note.Title).HasMaxLength(32);
	}
}
