using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public abstract class BaseController : ControllerBase
	{
		private IMediator _mediator = null!;
		private IMapper _mapper = null!;

		protected IMediator mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
		protected IMapper mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();

		internal Guid UserId => !User.Identity.IsAuthenticated
			? Guid.Empty
			: Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
	}
}
