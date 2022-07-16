using MediatR;

namespace Application.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<Guid>
{
	public string Title { get; set; }
	public string Details { get; set; }
}
