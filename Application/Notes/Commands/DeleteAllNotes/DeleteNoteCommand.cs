using MediatR;

namespace Application.Notes.Commands.DeleteAllNotes;

public class DeleteAllNotesCommand : IRequest
{
	public Guid UserId { get; set; }
}

