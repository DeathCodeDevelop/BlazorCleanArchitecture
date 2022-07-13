using Application.Interfaces;
using Application.Notes.Queries.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Notes.Queries.GetAll;

public class GetAllNotesQuery : IRequest<IEnumerable<NoteDTO>>
{
	public Guid UserId { get; set; }
}

internal class GetAllNotesQueryHandler
	: IRequestHandler<GetAllNotesQuery, IEnumerable<NoteDTO>>
{
	private readonly IApplicationDbContext context;
	private readonly IMapper mapper;

	public GetAllNotesQueryHandler(IApplicationDbContext context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}

	public async Task<IEnumerable<NoteDTO>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
	{
		var entities = await context.Notes.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken);
		return mapper.Map<IEnumerable<Note>, IEnumerable<NoteDTO>>(entities);
	}
}

