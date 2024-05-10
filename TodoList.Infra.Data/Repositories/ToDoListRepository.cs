using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Enum;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Data.Context;

namespace TodoList.Infra.Data.Repositories
{
	public class ToDoListRepository : IToDoListRepository
	{
		private readonly AppDbContext _dbContext;

		public ToDoListRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<ToDoList>> GetAllAsync()
		{
			return await _dbContext.Set<ToDoList>().AsNoTracking().ToListAsync();
		}

		public async Task<ToDoList?> GetByIdAsync(Guid id)
		{
			if (id == Guid.Empty) throw new ArgumentNullException("Id cannot be empty", nameof(id));
			return await _dbContext.Set<ToDoList>().FindAsync(id);
		}

		public async Task<ToDoList> CreateAsync(ToDoList entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			await _dbContext.Set<ToDoList>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<ToDoList> UpdateAsync(ToDoList entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<IEnumerable<ToDoList>> DeleteRangeAsync(IEnumerable<ToDoList> listToDo)
		{
			_dbContext.Set<ToDoList>().RemoveRange(listToDo);
			await _dbContext.SaveChangesAsync();

			return listToDo;
		}

		public async Task<ToDoList> DeleteAsync(Guid id)
		{
			ToDoList? entity = await GetByIdAsync(id);
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			_dbContext.Set<ToDoList>().Remove(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}
	}
}
