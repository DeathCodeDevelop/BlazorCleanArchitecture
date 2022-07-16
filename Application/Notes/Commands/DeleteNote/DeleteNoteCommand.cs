using MediatR;

namespace Application.Notes.Commands.DeleteNote;

public class DeleteNoteCommand : IRequest
{
	public Guid Id { get; set; }
}

