using MediatR;
using TodoList.Application.CQRS.ToDoLists.Queries;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.ToDoLists.Handles
{
	public class GetToDoQueryHandler : IRequestHandler<GetToDoListQuery, IEnumerable<ToDoList>>
	{
		private readonly IToDoListRepository _toDoRepository;

		public GetToDoQueryHandler(IToDoListRepository toDoRepository)
		{
			_toDoRepository = toDoRepository;
		}

		public async Task<IEnumerable<ToDoList>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
		{
			return await _toDoRepository.GetAllAsync();
		}
	}
}
