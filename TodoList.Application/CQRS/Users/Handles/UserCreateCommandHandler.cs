using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using TodoList.Application.CQRS.Users.Command;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.CQRS.Users.Handles
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<User> _validator;
        private readonly IMapper _mapper;

        public UserCreateCommandHandler(IUserRepository userRepository, IValidator<User> validator, IMapper mapper)
        {
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request);

            ValidationResult validationResults = _validator.Validate(user);
            if (!validationResults.IsValid) throw new ValidationException(validationResults.Errors);

            return await _userRepository.CreateAsync(user);
        }
    }
}
