using FluentValidation;

namespace Application.Notes.Commands.UpdateNote;

public class CreateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
{
	public CreateNoteCommandValidator()
	{
		RuleFor(command =>
			command.Title).NotEmpty().MaximumLength(250);
		RuleFor(command =>
			command.UserId).NotEqual(Guid.Empty);
		RuleFor(command =>
			command.Id).NotEqual(Guid.Empty);
	}
}
