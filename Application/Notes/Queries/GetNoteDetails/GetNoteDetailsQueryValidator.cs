using FluentValidation;

namespace Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
{
	public GetNoteDetailsQueryValidator()
	{
		RuleFor(query =>
			query.Id).NotEqual(Guid.Empty);
	}
}

