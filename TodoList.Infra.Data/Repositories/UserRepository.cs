using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infra.Data.Context;

namespace TodoList.Infra.Data.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		public UserRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
