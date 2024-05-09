using MediatR;
using TodoList.Domain.Entities;
using TodoList.Domain.Enum;

namespace TodoList.Application.CQRS.Users.Command
{
    public class UserCreateCommand : IRequest<User>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public RoleEnum Role { get; set; }
    }
}
