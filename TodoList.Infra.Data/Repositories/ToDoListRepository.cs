using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Enum;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Data.Context;

namespace TodoList.Infra.Data.Repositories
{
	public class ToDoListRepository : GenericRepository<ToDoList>, IToDoListRepository
	{
		private readonly AppDbContext _dbContext;

		public ToDoListRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<ToDoList>> GetAllAsync()
		{
			return await _dbContext.Set<ToDoList>().AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<ToDoList>> GetByStatusAsync(StatusEnum status)
		{
			return await _dbContext.Set<ToDoList>().AsNoTracking().Where(x => x.Status == status).ToListAsync();
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
