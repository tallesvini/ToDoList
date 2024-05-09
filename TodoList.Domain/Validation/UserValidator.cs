using FluentValidation;
using TodoList.Domain.Entities;
using TodoList.Domain.Validation.Errors;

namespace TodoList.Domain.Validation
{
	public class UserValidator : AbstractValidator<User>
	{
        public UserValidator()
        {
			RuleFor(user => user)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required);

			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required)
						.MaximumLength(255).WithMessage(GenericErrorsMessages.MustBeLessThan255);

			RuleFor(x => x.PassWord)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required)
						.MaximumLength(255).WithMessage(GenericErrorsMessages.MustBeLessThan255);

			RuleFor(x => x.Role)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required);
		}
    }
}
