using MediatR;
using TodoList.Application.CQRS.ToDoLists.Queries;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.ToDoLists.Handles
{
	public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoListByIdQuery, ToDoList?>
	{
		private readonly IToDoListRepository _toDoRepository;

		public GetToDoByIdQueryHandler(IToDoListRepository toDoRepository)
		{
			_toDoRepository = toDoRepository;
		}

		public async Task<ToDoList?> Handle(GetToDoListByIdQuery request, CancellationToken cancellationToken)
		{
			return await _toDoRepository.GetByIdAsync(request.Id);
		}
	}
}
