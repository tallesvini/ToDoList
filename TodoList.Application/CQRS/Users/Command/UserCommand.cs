using MediatR;
using TodoList.Domain.Entities;
using TodoList.Domain.Enum;

namespace TodoList.Application.CQRS.Users.Command
{
	public class UserCommand : IRequest<User>
	{
		public string UserName { get; set; }
		public string PassWord { get; set; }
		public RoleEnum Role { get; set; }
	}
}
