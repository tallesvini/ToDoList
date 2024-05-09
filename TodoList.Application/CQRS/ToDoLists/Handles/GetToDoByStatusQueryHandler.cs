using MediatR;
using TodoList.Application.CQRS.ToDoLists.Queries;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.ToDoLists.Handles
{
	public class GetToDoByStatusQueryHandler : IRequestHandler<GetToDoListByStatusQuery, IEnumerable<ToDoList>>
	{
		private readonly IToDoListRepository _toDoRepository;

		public GetToDoByStatusQueryHandler(IToDoListRepository toDoRepository)
		{
			_toDoRepository = toDoRepository;
		}

		public async Task<IEnumerable<ToDoList>> Handle(GetToDoListByStatusQuery request, CancellationToken cancellationToken)
		{
			return await _toDoRepository.GetByStatusAsync(request.Status);
		}
	}
}
