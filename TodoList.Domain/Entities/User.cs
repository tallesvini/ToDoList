using TodoList.Domain.Enum;

namespace TodoList.Domain.Entities
{
	public class User : BaseEntity
	{
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public RoleEnum Role { get; private set; }

		//public ICollection<ToDoList> ToDoLists { get; private set; }

		public User(Guid id, string userName, string passWord, RoleEnum role)
		{
			Id = id;
			UserName = userName;
			PassWord = passWord;
			Role = role;
		}
	}
}
