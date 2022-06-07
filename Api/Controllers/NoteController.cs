using Application.Notes.Commands.CreateNote;
using Application.Notes.Commands.DeleteNote;
using Application.Notes.Commands.UpdateNote;
using Application.Notes.Queries.GetAll;
using Application.Notes.Queries.GetNoteDetails;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Data.ViewModels;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class NoteController : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetAllNoteViewModel>>> GetAll() 
		{
			var query = new GetAllNotesQuery() { UserId = UserId };

			var response = await mediator.Send(query);

			if (response != null)
				return Ok(mapper.Map<IEnumerable<GetAllNotesResponse>, IEnumerable<GetAllNoteViewModel>>(response));

			return Ok(null);
		}

		[HttpGet]
		public async Task<ActionResult<GetNoteDetailsResponse>> GetById(Guid id)
		{
			var query = new GetNoteDetailsQuery() 
			{ 
				Id = id,
				UserId = UserId
			};

			var response = await mediator.Send(query);
			return Ok(response);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create(CreateNoteViewModel model) 
		{
			var command = mapper.Map<CreateNoteViewModel, CreateNoteCommand>(model);
			command.UserId = UserId;

			var response = await mediator.Send(command);
			return Ok(response);
		}


		[HttpPut]
		public async Task<IActionResult> Update(UpdateNoteViewModel model)
		{
			var command = mapper.Map<UpdateNoteViewModel, UpdateNoteCommand>(model);
			command.UserId = UserId;
			await mediator.Send(command);
			
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Guid>> Delete(Guid id)
		{
			var command = new DeleteNoteCommand()
			{
				Id = id,
				UserId = UserId
			};

			var response = await mediator.Send(command);
			return Ok(response);
		}
	}
}
