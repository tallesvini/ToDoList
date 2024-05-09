using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TodoList.Application.CQRS.ToDoLists.Commands;
using TodoList.Application.CQRS.Users.Commands;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.ToDoLists.Handles
{
	public class ToDoListCreateCommandHandler : IRequestHandler<ToDoListCreateCommand, ToDoList>
	{
		private readonly IToDoListRepository _toDoListRepository;
		private readonly IValidator<ToDoList> _validator;
		private readonly IMapper _mapper;

		public ToDoListCreateCommandHandler(IToDoListRepository toDoListRepository, IValidator<ToDoList> validator, IMapper mapper)
		{
			_toDoListRepository = toDoListRepository;
			_validator = validator;
			_mapper = mapper;
		}

		public async Task<ToDoList> Handle(ToDoListCreateCommand request, CancellationToken cancellationToken)
		{
			ToDoList toDoList = _mapper.Map<ToDoList>(request);

			ValidationResult validationResults = _validator.Validate(toDoList);
			if (!validationResults.IsValid) throw new ValidationException(validationResults.Errors);

			return await _toDoListRepository.CreateAsync(toDoList);
		}
	}
}
