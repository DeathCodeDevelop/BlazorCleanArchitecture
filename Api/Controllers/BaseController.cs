using Application.Interfaces.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public abstract class BaseController : ControllerBase
	{
		private IMediator _mediator = null!;
		private IMapper _mapper = null!;

		protected IMediator mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
		protected IMapper mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();

		protected Guid UserId => HttpContext.RequestServices.GetRequiredService<ICurrentUserService>().UserId;
	}
}
