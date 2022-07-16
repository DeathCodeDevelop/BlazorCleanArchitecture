using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Application.Common.Exceptions;
using Application.Interfaces.Services;

namespace Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommandHandler
	: IRequestHandler<DeleteNoteCommand>
{
	private readonly IApplicationDbContext _dbContext;
	private readonly ICurrentUserService _user;

	public DeleteNoteCommandHandler(IApplicationDbContext dbContext, ICurrentUserService user)
	{
		_dbContext = dbContext;
		_user = user;
	}

	public async Task<Unit> Handle(DeleteNoteCommand request,
		CancellationToken cancellationToken)
	{
		var entity =
			await _dbContext.Notes
			.FindAsync(new object[] { request.Id }, cancellationToken);

		if (entity == null || entity.UserId != _user.UserId) 
			throw new NotFoundException(nameof(Note), _user.UserId);

		_dbContext.Notes.Remove(entity);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}


