using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Application.Common.Exceptions;
using Application.Interfaces.Services;

namespace Application.Notes.Commands.DeleteAllNotes;

public class DeleteNoteCommandHandler
	: IRequestHandler<DeleteAllNotesCommand>
{
	private readonly IApplicationDbContext _dbContext;
	private readonly ICurrentUserService _user;

	public DeleteNoteCommandHandler(IApplicationDbContext dbContext, ICurrentUserService user)
	{
		_dbContext = dbContext;
		_user = user;
	}

	public async Task<Unit> Handle(DeleteAllNotesCommand request,
		CancellationToken cancellationToken)
	{
		var entities = _dbContext.Notes
			.Where(n => n.UserId == _user.UserId);

		if (entities == null)
			throw new NotFoundException(nameof(Note), _user.UserId);

		_dbContext.Notes.RemoveRange(entities);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}


