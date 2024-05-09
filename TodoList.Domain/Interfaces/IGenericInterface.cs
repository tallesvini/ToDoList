using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces
{
	public interface IGenericInterface<TEntity> where TEntity : class
	{
		Task<TEntity?> GetByIdAsync(Guid id);
		Task<TEntity> CreateAsync(TEntity entity);
		Task<TEntity> UpdateAsync(TEntity entity);
	}
}
