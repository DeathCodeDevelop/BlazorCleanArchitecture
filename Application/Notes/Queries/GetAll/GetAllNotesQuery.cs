using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notes.Queries.GetAll
{
	public class GetAllNotesQuery : IRequest<IEnumerable<GetAllNotesResponse>>
	{
		public Guid UserId { get; set; }
	}

	internal class GetAllNotesQueryHandler 
		: IRequestHandler<GetAllNotesQuery, IEnumerable<GetAllNotesResponse>>
	{
		private readonly IApplicationDbContext context;
		private readonly IMapper mapper;

		public GetAllNotesQueryHandler(IApplicationDbContext context, IMapper mapper) 
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<GetAllNotesResponse>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
		{
			var entities = await context.Notes.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken);
			return mapper.Map<IEnumerable<Note>, IEnumerable<GetAllNotesResponse>>(entities);
		}
	}
}
