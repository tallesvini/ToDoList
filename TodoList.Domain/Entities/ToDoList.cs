using TodoList.Domain.Enum;

namespace TodoList.Domain.Entities
{
	public class ToDoList
	{
		public Guid Id { get; private set; }
		public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public StatusEnum Status { get; private set; }
        public ToDoList() { }

        public ToDoList(string title, string description, DateTime startDate, DateTime endDate, StatusEnum status)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }
    }
}
