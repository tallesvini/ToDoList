using TodoList.Domain.Enum;

namespace TodoList.Domain.Entities
{
	public class ToDoList : BaseEntity
	{
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset EndDate { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public StatusEnum Status { get; private set; }

		public ToDoList(string title, string description, DateTimeOffset startDate, DateTimeOffset endDate, Guid userId, User user, StatusEnum status)
		{
			Title = title;
			Description = description;
			StartDate = startDate;
			EndDate = endDate;
			UserId = userId;
			User = user;
			Status = status;
		}
	}
}
