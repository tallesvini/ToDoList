using MediatR;
using TodoList.Domain.Entities;
using TodoList.Domain.Enum;

namespace TodoList.Application.CQRS.ToDoLists.Queries
{
	public class GetToDoListByStatusQuery : IRequest<IEnumerable<ToDoList>>
	{
        public StatusEnum Status { get; set; }

		public GetToDoListByStatusQuery(StatusEnum status)
		{
			Status = status;
		}
	}
}
