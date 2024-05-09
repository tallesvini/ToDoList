using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Data.Context;

namespace TodoList.Infra.Data.Repositories
{
	public abstract class GenericRepository<TEntity> : IGenericInterface<TEntity> 
		where TEntity : class
	{
		private readonly AppDbContext _dbContext;

		protected GenericRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<TEntity?> GetByIdAsync(Guid id)
		{
			if (id == Guid.Empty) throw new ArgumentNullException("Id cannot be empty", nameof(id));
			return await _dbContext.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			if(entity == null) throw new ArgumentNullException(nameof(entity));

			await _dbContext.Set<TEntity>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;	
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return entity;
		}
	}
}
