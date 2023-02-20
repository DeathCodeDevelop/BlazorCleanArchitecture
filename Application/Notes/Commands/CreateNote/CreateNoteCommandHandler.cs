using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Application.Interfaces.Services;

namespace Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler
	: IRequestHandler<CreateNoteCommand, Guid>
{
	private readonly IApplicationDbContext _dbContext;
	private readonly ICurrentUserService _user;

	public CreateNoteCommandHandler(IApplicationDbContext dbContext, ICurrentUserService user)
	{
		_dbContext = dbContext;
		_user = user;
	}

	public async Task<Guid> Handle(CreateNoteCommand request,
		CancellationToken cancellationToken)
	{
		var note = new Note
		{
			UserId = _user.UserId,
			Title = request.Title,
			Details = request.Details,
			Id = Guid.NewGuid(),
			CreationDate = DateTime.Now,
			EditDate = null
		};

		await _dbContext.Notes.AddAsync(note, cancellationToken);
		await _dbContext.SaveChangesAsync(cancellationToken);

		return note.Id;
	}
}
