using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TodoList.Application.CQRS.ToDoLists.Commands;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.ToDoLists.Handles
{
	public class ToDoListUpdateCommandHandler : IRequestHandler<ToDoListUpdateCommand, ToDoList>
	{
		private readonly IToDoListRepository _toDoListRepository;
		private readonly IValidator<ToDoList> _validator;
		private readonly IMapper _mapper;

		public ToDoListUpdateCommandHandler(IToDoListRepository toDoListRepository, IValidator<ToDoList> validator, IMapper mapper)
		{
			_toDoListRepository = toDoListRepository;
			_validator = validator;
			_mapper = mapper;
		}

		public async Task<ToDoList> Handle(ToDoListUpdateCommand request, CancellationToken cancellationToken)
		{
			ToDoList? toDoListById = await _toDoListRepository.GetByIdAsync(request.Id);
			if (toDoListById == null) throw new ApplicationException("Error: The item could not be found.");

			ToDoList toDoList = _mapper.Map(request, toDoListById);

			ValidationResult validationResults = _validator.Validate(toDoList);
			if (!validationResults.IsValid) throw new ValidationException(validationResults.Errors);

			return await _toDoListRepository.UpdateAsync(toDoList);
		}
	}
}
