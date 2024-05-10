using MediatR;
using TodoList.Domain.Entities;

namespace TodoList.Application.CQRS.ToDoLists.Commands
{
	public class ToDoListDeleteAllCommand : IRequest<IEnumerable<ToDoList>> { }
}
