using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Application.Common.Exceptions;

namespace Application.Notes.Commands.DeleteAllNotes;

public class DeleteNoteCommandHandler
	: IRequestHandler<DeleteAllNotesCommand>
{
	private readonly IApplicationDbContext _dbContext;

	public DeleteNoteCommandHandler(IApplicationDbContext dbContext) =>
		_dbContext = dbContext;

	public async Task<Unit> Handle(DeleteAllNotesCommand request,
		CancellationToken cancellationToken)
	{
		var entities = _dbContext.Notes
			.Where(n => n.UserId == request.UserId);

		if (entities == null)
			throw new NotFoundException(nameof(Note), request.UserId);

		_dbContext.Notes.RemoveRange(entities);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}


