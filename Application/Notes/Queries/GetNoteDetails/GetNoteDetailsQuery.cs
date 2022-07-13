using Application.Common.Exceptions;
using Application.Interfaces;
using Application.Notes.Queries.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQuery : IRequest<NoteDTO>
{
	public Guid UserId { get; set; }
	public Guid Id { get; set; }
}

public class GetNoteDetailsQueryHandler
	: IRequestHandler<GetNoteDetailsQuery, NoteDTO>
{
	private readonly IApplicationDbContext _dbContext;
	private readonly IMapper _mapper;

	public GetNoteDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
		(_dbContext, _mapper) = (dbContext, mapper);

	public async Task<NoteDTO> Handle(GetNoteDetailsQuery request,
		CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Notes
			.FirstOrDefaultAsync(note =>
			note.Id == request.Id, cancellationToken);

		if (entity == null || entity.UserId != request.UserId)
			throw new NotFoundException(nameof(Note), request.UserId);

		return _mapper.Map<NoteDTO>(entity);
	}
}
