using TodoList.Application.DTOs;

namespace TodoList.Application.Interfaces
{
	public interface IUserService
	{
		Task CreateAsync(UserDTO entity);
		Task UpdateAsync(UserDTO entity);
	}
}
