using MediatR;
using TodoList.Domain.Entities;

namespace TodoList.Application.CQRS.ToDoLists.Commands
{
	public class ToDoListDeleteCommand : IRequest<ToDoList>
	{
		public Guid Id { get; set; }

		public ToDoListDeleteCommand(Guid id)
		{
			Id = id;
		}
	}
}
