using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Notes.Commands.Exeptions;

namespace Application.Notes.Commands.UpdateNote;

public class DeleteNoteCommandHandler
	: IRequestHandler<UpdateNoteCommand>
{
	private readonly IApplicationDbContext _dbContext;

	public DeleteNoteCommandHandler(IApplicationDbContext dbContext) =>
		_dbContext = dbContext;

	public async Task<Unit> Handle(UpdateNoteCommand request,
		CancellationToken cancellationToken)
	{
		var entity =
			await _dbContext.Notes.FirstOrDefaultAsync(note =>
				note.Id == request.Id, cancellationToken);

		if (entity == null || entity.UserId != request.UserId) 
			throw new NotFoundException(nameof(Note), request.UserId);

		entity.Details = request.Details;
		entity.Title = request.Title;
		entity.EditDate = DateTime.Now;

		await _dbContext.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}


