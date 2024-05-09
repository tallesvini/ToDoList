using TodoList.Domain.Entities;
using TodoList.Domain.Enum;

namespace TodoList.Domain.Interfaces
{
	public interface IToDoListRepository : IGenericInterface<ToDoList>
	{
		Task<IEnumerable<ToDoList>> GetAllAsync();
		Task<IEnumerable<ToDoList>> GetByStatusAsync(StatusEnum status);
		Task<ToDoList> DeleteAsync(Guid id);
	}
}
