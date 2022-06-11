using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
	public class ValidationBehavior<TRequest, TRespose>
		: IPipelineBehavior<TRequest, TRespose> where TRequest : IRequest<TRespose>
	{
		private readonly IEnumerable<IValidator<TRequest>> validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => 
			this.validators = validators;

		public Task<TRespose> Handle(TRequest request,
			CancellationToken cancellationToken, RequestHandlerDelegate<TRespose> next)
		{
			var context = new ValidationContext<TRequest>(request);
			var failures = validators
				.Select(v => v.Validate(context))
				.SelectMany(result => result.Errors)
				.Where(failure => failure != null)
				.ToList();

			if (failures.Count != 0)
				throw new ValidationException(failures);

			return next();
		}
	}
}
