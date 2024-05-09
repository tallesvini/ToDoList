using MediatR;
using TodoList.Domain.Entities;

namespace TodoList.Application.CQRS.ToDoLists.Queries
{
	public class GetToDoListQuery : IRequest<IEnumerable<ToDoList>> { }
}
