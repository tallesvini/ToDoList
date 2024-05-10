using TodoList.Application.DTOs;
using TodoList.Domain.Enum;

namespace TodoList.Application.Interfaces
{
	public interface IToDoListService
	{
		Task<IEnumerable<ToDoListDTO>> GetAllToDoListAsync();
		Task<ToDoListDTO?> GetToDoListByIdAsync(Guid id);
		Task CreateToDoListAsync(ToDoListDTO entity);
		Task UpdateToDoListAsync(ToDoListDTO entity);
		Task DeleteAllToDoListAsync();
		Task DeleteToDoListAsync(Guid id);
	}
}
