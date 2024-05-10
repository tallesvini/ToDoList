using TodoList.Domain.Enum;

namespace TodoList.Application.DTOs
{
	public class ToDoListDTO
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public StatusEnum Status { get; set; }
	}
}
