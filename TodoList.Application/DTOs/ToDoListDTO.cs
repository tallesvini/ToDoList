using TodoList.Domain.Enum;

namespace TodoList.Application.DTOs
{
	public class ToDoListDTO : BaseDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTimeOffset StartDate { get; set; }
		public DateTimeOffset EndDate { get; set; }
		public StatusEnum Status { get; set; }
	}
}
