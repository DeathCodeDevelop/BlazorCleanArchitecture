using FluentValidation;

namespace Application.Notes.Commands.CreateNote;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
	public CreateNoteCommandValidator()
	{
		RuleFor(command =>
			command.Title).NotEmpty().MaximumLength(250);
	}
}

