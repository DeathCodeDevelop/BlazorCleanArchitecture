using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Notes.Queries.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQuery : IRequest<NoteDTO>
{
	public Guid Id { get; set; }
}

public class GetNoteDetailsQueryHandler
	: IRequestHandler<GetNoteDetailsQuery, NoteDTO>
{
	private readonly IApplicationDbContext _dbContext;
	private readonly IMapper _mapper;
	private readonly ICurrentUserService _user;

	public GetNoteDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper, ICurrentUserService user) =>
		(_dbContext, _mapper, _user) = (dbContext, mapper, user);

	public async Task<NoteDTO> Handle(GetNoteDetailsQuery request,
		CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Notes
			.FirstOrDefaultAsync(note =>
			note.Id == request.Id, cancellationToken);

		if (entity == null || entity.UserId != _user.UserId)
			throw new NotFoundException(nameof(Note), _user.UserId);

		return _mapper.Map<NoteDTO>(entity);
	}
}
