using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;
public interface IApplicationDbContext
{
	DbSet<Note> Notes { get; set; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
