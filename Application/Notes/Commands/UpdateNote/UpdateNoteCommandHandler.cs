using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Application.Interfaces.Services;

namespace Application.Notes.Commands.UpdateNote;

public class DeleteNoteCommandHandler
	: IRequestHandler<UpdateNoteCommand>
{
	private readonly IApplicationDbContext _dbContext;
	private readonly ICurrentUserService _user;

	public DeleteNoteCommandHandler(IApplicationDbContext dbContext, ICurrentUserService user)
	{
		_dbContext = dbContext;
		_user = user;
	}

	public async Task<Unit> Handle(UpdateNoteCommand request,
		CancellationToken cancellationToken)
	{
		var entity =
			await _dbContext.Notes.FirstOrDefaultAsync(note =>
				note.Id == request.Id, cancellationToken);

		if (entity == null || entity.UserId != _user.UserId) 
			throw new NotFoundException(nameof(Note), _user.UserId);

		entity.Details = request.Details;
		entity.Title = request.Title;
		entity.EditDate = DateTime.Now;

		await _dbContext.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}


