using FluentValidation;
using TodoList.Domain.Entities;
using TodoList.Domain.Validation.Errors;

namespace TodoList.Domain.Validation
{
	public class ToDoListValidator : AbstractValidator<ToDoList>
	{
        public ToDoListValidator()
        {
            RuleFor(toDo => toDo) 
                .NotEmpty().WithMessage(GenericErrorsMessages.Required)
                    .NotNull().WithMessage(GenericErrorsMessages.Required);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(GenericErrorsMessages.Required)
                    .NotNull().WithMessage(GenericErrorsMessages.Required)
                        .MaximumLength(255).WithMessage(GenericErrorsMessages.MustBeLessThan255);

			RuleFor(x => x.Description)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required)
						.MaximumLength(255).WithMessage(GenericErrorsMessages.MustBeLessThan255);

			RuleFor(x => x.StartDate)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required);

			RuleFor(x => x.Status)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required);

			RuleFor(x => x.UserId)
				.NotEmpty().WithMessage(GenericErrorsMessages.Required)
					.NotNull().WithMessage(GenericErrorsMessages.Required);
		}
    }
}
