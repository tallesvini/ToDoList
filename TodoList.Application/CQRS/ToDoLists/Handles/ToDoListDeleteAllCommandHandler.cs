using AutoMapper;
using MediatR;
using TodoList.Application.CQRS.ToDoLists.Commands;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.ToDoLists.Handles
{
	public class ToDoListDeleteAllCommandHandler : IRequestHandler<ToDoListDeleteAllCommand, IEnumerable<ToDoList>>
	{
		private readonly IToDoListRepository _toDoListRepository;
		private readonly IMapper _mapper;

		public ToDoListDeleteAllCommandHandler(IToDoListRepository toDoListRepository, IMapper mapper)
		{
			_toDoListRepository = toDoListRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ToDoList>> Handle(ToDoListDeleteAllCommand request, CancellationToken cancellationToken)
		{
			IEnumerable<ToDoList> toDoList = await _toDoListRepository.GetAllAsync();

			await _toDoListRepository.DeleteRangeAsync(toDoList);
			return toDoList;
		}
	}
}
