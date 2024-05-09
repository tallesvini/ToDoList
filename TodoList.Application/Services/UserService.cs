using AutoMapper;
using MediatR;
using TodoList.Application.CQRS.Users.Command;
using TodoList.Application.DTOs;
using TodoList.Application.Interfaces;

namespace TodoList.Application.Services
{
    public class UserService : IUserService
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public UserService(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		public async Task CreateAsync(UserDTO entity)
		{
			UserCreateCommand userCreateCommand = _mapper.Map<UserCreateCommand>(entity);
			await _mediator.Send(userCreateCommand);
		}

		public async Task UpdateAsync(UserDTO entity)
		{
			UserUpdateCommand userUpdateCommand = _mapper.Map<UserUpdateCommand>(entity);
			await _mediator.Send(userUpdateCommand);
		}
	}
}
