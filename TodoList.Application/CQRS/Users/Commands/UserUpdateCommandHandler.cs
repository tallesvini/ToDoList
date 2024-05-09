using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TodoList.Application.CQRS.Users.Command;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.Users.Commands
{
	public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, User>
	{
		private readonly IUserRepository _userRepository;
		private readonly IValidator<User> _validator;
		private readonly IMapper _mapper;

		public UserUpdateCommandHandler(IUserRepository userRepository, IValidator<User> validator, IMapper mapper)
		{
			_userRepository = userRepository;
			_validator = validator;
			_mapper = mapper;
		}

		public async Task<User> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
		{
			User? userProfileById = await _userRepository.GetByIdAsync(request.Id);
			if (userProfileById == null) throw new ApplicationException("Error: The item could not be found.");

			User userProfile = _mapper.Map(request, userProfileById);

			ValidationResult validationResults = _validator.Validate(userProfile);
			if (!validationResults.IsValid) throw new ValidationException(validationResults.Errors);

			return await _userRepository.UpdateAsync(userProfile);
		}
	}
}
