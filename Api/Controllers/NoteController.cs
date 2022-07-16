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
using Application.Common.Exceptions;
using Application.Notes.Commands.DeleteAllNotes;
using Application.Notes.Queries.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class NoteController : BaseController
	{
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<IEnumerable<NoteViewModel>>> GetAll()
		{
			var query = new GetAllNotesQuery() { UserId = UserId };

			var response = await mediator.Send(query);

			if (response != null)
				return Ok(mapper.Map<IEnumerable<NoteDTO>, IEnumerable<NoteViewModel>>(response));

			return NotFound(null);
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<NoteViewModel>> GetById(Guid id)
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
		[Authorize]
		public async Task<ActionResult<Guid>> Create(CreateNoteViewModel model)
		{
			var command = mapper.Map<CreateNoteViewModel, CreateNoteCommand>(model);
			command.UserId = UserId;

			var response = await mediator.Send(command);
			return Ok(response);
		}


		[HttpPut]
		[Authorize]
		public async Task<IActionResult> Update(UpdateNoteViewModel model)
		{

			var command = mapper.Map<UpdateNoteViewModel, UpdateNoteCommand>(model);
			command.UserId = UserId;
			await mediator.Send(command);

			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize]
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

		[HttpDelete]
		[Authorize]
		public async Task<ActionResult> DeleteAll()
		{
			var command = new DeleteAllNotesCommand() { UserId = UserId };
			var response = await mediator.Send(command);

			return Ok(response);
		}
	}
}
