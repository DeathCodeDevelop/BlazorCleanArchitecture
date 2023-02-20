using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Notes.Queries.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Notes.Queries.GetAll;

public class GetAllNotesQuery : IRequest<IEnumerable<NoteDTO>>
{

}

internal class GetAllNotesQueryHandler
	: IRequestHandler<GetAllNotesQuery, IEnumerable<NoteDTO>>
{
	private readonly IApplicationDbContext _context;
	private readonly IMapper _mapper;
	private readonly ICurrentUserService _user;

	public GetAllNotesQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService user)
	{
		_context = context;
		_mapper = mapper;
		_user = user;
	}

	public async Task<IEnumerable<NoteDTO>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
	{
		var entities = await _context.Notes.Where(x => x.UserId == _user.UserId).ToListAsync(cancellationToken);
		return _mapper.Map<IEnumerable<Note>, IEnumerable<NoteDTO>>(entities);
	}
}

