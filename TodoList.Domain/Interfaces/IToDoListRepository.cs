using TodoList.Domain.Entities;
using TodoList.Domain.Enum;

namespace TodoList.Domain.Interfaces
{
	public interface IToDoListRepository
	{
		Task<IEnumerable<ToDoList>> GetAllAsync();
		Task<ToDoList?> GetByIdAsync(Guid id);
		Task<ToDoList> CreateAsync(ToDoList entity);
		Task<ToDoList> UpdateAsync(ToDoList entity);
		Task<IEnumerable<ToDoList>> DeleteRangeAsync(IEnumerable<ToDoList> listToDo);
		Task<ToDoList> DeleteAsync(Guid id);
	}
}
