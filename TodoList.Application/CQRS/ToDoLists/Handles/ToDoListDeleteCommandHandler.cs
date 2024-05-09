using MediatR;
using TodoList.Application.CQRS.ToDoLists.Commands;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.ToDoLists.Handles
{
	public class ToDoListDeleteCommandHandler : IRequestHandler<ToDoListDeleteCommand, ToDoList>
	{
		private readonly IToDoListRepository _toDoListRepository;

		public ToDoListDeleteCommandHandler(IToDoListRepository toDoListRepository)
		{
			_toDoListRepository = toDoListRepository;
		}

		public async Task<ToDoList> Handle(ToDoListDeleteCommand request, CancellationToken cancellationToken)
		{
			ToDoList? toDoListById = await _toDoListRepository.GetByIdAsync(request.Id);
			if (toDoListById == null) throw new ArgumentException("Error: The item could not be found.");

			return await _toDoListRepository.DeleteAsync(request.Id);
		}
	}
}
