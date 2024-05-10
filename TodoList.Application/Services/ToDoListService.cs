using AutoMapper;
using MediatR;
using TodoList.Application.CQRS.ToDoLists.Commands;
using TodoList.Application.CQRS.ToDoLists.Queries;
using TodoList.Application.DTOs;
using TodoList.Application.Interfaces;
using TodoList.Domain.Enum;

namespace TodoList.Application.Services
{
	public class ToDoListService : IToDoListService
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ToDoListService(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ToDoListDTO>> GetAllToDoListAsync()
		{
			GetToDoListQuery toDoListQuery = new GetToDoListQuery();
			if (toDoListQuery == null) throw new Exception("Entity could not be loaded.");

			var result = await _mediator.Send(toDoListQuery);
			return _mapper.Map<IEnumerable<ToDoListDTO>>(result);
		}

		public async Task<ToDoListDTO?> GetToDoListByIdAsync(Guid id)
		{
			GetToDoListByIdQuery toDoListQuery = new GetToDoListByIdQuery(id);
			if (toDoListQuery == null) throw new Exception("Entity could not be loaded.");

			var result = await _mediator.Send(toDoListQuery);
			return _mapper.Map<ToDoListDTO?>(result);
		}

		public async Task<IEnumerable<ToDoListDTO>> GetToDoListByStatusAsync(StatusEnum status)
		{
			GetToDoListByStatusQuery toDoListQuery = new GetToDoListByStatusQuery(status);
			if (toDoListQuery == null) throw new Exception("Entity could not be loaded.");

			var result = await _mediator.Send(toDoListQuery);
			return _mapper.Map<IEnumerable<ToDoListDTO>>(result);
		}

		public async Task CreateToDoListAsync(ToDoListDTO entity)
		{
            ToDoListCreateCommand toDoListCreateCommand = _mapper.Map<ToDoListCreateCommand>(entity);
			await _mediator.Send(toDoListCreateCommand);
		}

		public async Task UpdateToDoListAsync(ToDoListDTO entity)
		{
			ToDoListUpdateCommand toDoListUpdateCommand = _mapper.Map<ToDoListUpdateCommand>(entity);
			await _mediator.Send(toDoListUpdateCommand);
		}

		public async Task DeleteAllToDoListAsync()
		{
			ToDoListDeleteAllCommand toDoListDeleteAllCommand = new ToDoListDeleteAllCommand();
			if (toDoListDeleteAllCommand == null) throw new Exception("Entity could not be loaded.");

			await _mediator.Send(toDoListDeleteAllCommand);
		}

		public async Task DeleteToDoListAsync(Guid id)
		{
			ToDoListDeleteCommand toDoListDeleteCommand = _mapper.Map<ToDoListDeleteCommand>(id);
			await _mediator.Send(toDoListDeleteCommand);
		}
	}
}
