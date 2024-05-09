using MediatR;
using TodoList.Domain.Entities;

namespace TodoList.Application.CQRS.ToDoLists.Queries
{
	public class GetToDoListByIdQuery : IRequest<ToDoList>
	{
        public Guid Id { get; set; }

		public GetToDoListByIdQuery(Guid id)
		{
			Id = id;
		}
	}
}
