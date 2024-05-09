using TodoList.Application.DTOs;
using TodoList.Domain.Enum;

namespace TodoList.Application.Interfaces
{
	public interface IToDoListService
	{
		Task<IEnumerable<ToDoListDTO>> GetAllToDoListAsync();
		Task<ToDoListDTO?> GetToDoListByIdAsync(Guid id);
		Task<IEnumerable<ToDoListDTO>> GetToDoListByStatusAsync(StatusEnum status);
		Task CreateToDoListAsync(ToDoListDTO entity);
		Task UpdateToDoListAsync(ToDoListDTO entity);
		Task DeleteToDoListAsync(Guid id);
	}
}
