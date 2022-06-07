using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Notes.Commands.Exeptions;

namespace Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler
	: IRequestHandler<DeleteNoteCommand>
{
	private readonly IApplicationDbContext _dbContext;

	public DeleteNoteCommandHandler(IApplicationDbContext dbContext) =>
		_dbContext = dbContext;

	public async Task<Unit> Handle(DeleteNoteCommand request,
		CancellationToken cancellationToken)
	{
		var entity =
			await _dbContext.Notes
			.FindAsync(new object[] { request.Id }, cancellationToken);

		if (entity == null || entity.UserId != request.UserId) 
			throw new NotFoundException(nameof(Note), request.UserId);

		_dbContext.Notes.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}


