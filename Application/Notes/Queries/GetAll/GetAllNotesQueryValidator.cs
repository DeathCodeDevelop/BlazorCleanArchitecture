using FluentValidation;

namespace Application.Notes.Queries.GetAll;

public class GetAllNotesQueryValidator : AbstractValidator<GetAllNotesQuery>
{
	public GetAllNotesQueryValidator()
	{
		RuleFor(query =>
			query.UserId).NotEqual(Guid.Empty);
	}
}

