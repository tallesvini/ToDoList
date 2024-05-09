using TodoList.Domain.Enum;

namespace TodoList.Application.DTOs
{
	public class UserDTO : BaseDTO
	{
		public string UserName { get; private set; }
		public RoleEnum Role { get; private set; }
	}
}
